using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GACS_Multicast
{
    public class ConexionMexDer
    {
        //VARIABLES GLOBALES
        Stopwatch stopwatch = new Stopwatch();
        
        //ENCABEZADO
        short tamañoMensaje;
        sbyte totalMensajes;
        sbyte grupoMarketData;
        sbyte sesion;
        int numeroSecuencia;
        DateTime timeStampBolsa;
        string data_feed_tape_letter_id_;

        public static bool ByteToFile(string _FileName, byte unByte)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Append,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.WriteByte(unByte);

                // close file stream
                _FileStream.Close();
                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }
        
        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Append,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // close file stream
                _FileStream.Close();
                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }


        public static bool BufferToFile(string _FileName, byte[] _ByteArray, int final)
        {
            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Append,
                                            System.IO.FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(_ByteArray, 0, final);

                // close file stream
                _FileStream.Close();
                return true;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            // error occured, return false
            return false;
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static byte[] GetBytesChar(char argument)
        {
            byte[] byteArray = BitConverter.GetBytes(argument);
            return byteArray;
        }

        public static string getTs(DateTime value)
        {
            return value.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

        public static string getDate(DateTime value)
        {
            return value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static StreamWriter abrirCatalogo(string date, string tape_letter)
        {
            //StreamWriter streamWriter = new StreamWriter("C://Users//Administrator//Desktop//logMulticast19_" + nombre + ".txt", true);
            StreamWriter streamWriter = new StreamWriter("C://Users//Administrator.GACSKIO//Desktop//logCatálogo19_" + date + "_" + tape_letter + ".txt", true);

            return streamWriter;
        }

        public static StreamWriter abrirLog(string date, string tape_letter)
        {
            //StreamWriter streamWriter = new StreamWriter("C://Users//Administrator//Desktop//logMulticast19_" + nombre + ".txt", true);
            StreamWriter streamWriter = new StreamWriter("C://Users//Administrator.GACSKIO//Desktop//logTxtTEST_" + date + "_" + tape_letter + ".txt", true);

            return streamWriter;
        }

        public static StreamWriter abrirTipo(string date, string tape_letter)
        {
            //StreamWriter streamWriter = new StreamWriter("C://Users//Administrator//Desktop//logMulticast19_" + nombre + ".txt", true);
            StreamWriter streamWriter = new StreamWriter("C://Users//Administrator.GACSKIO//Desktop//logTipos_" + date + "_" + tape_letter + ".txt", true);
            return streamWriter;
        }

        public class Ticker
        {
            public double precio { get; set; }
            public int ordenes { get; set; }
            public int volumen { get; set; }
        }

        public void conectar(string local_ip_adress, int port, string ip_multicast_channel_adress, int network_phy_interface_number, int buffer_size, string data_feed_tape_letter_id)
        {
            data_feed_tape_letter_id_ = data_feed_tape_letter_id;
            //double resolution = 1E9 / Stopwatch.Frequency;
            //Console.WriteLine("The minimum measurable time on this system is: {0} nanoseconds", resolution);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //IPAddress host_ipAddress = IPAddress.Parse("10.200.3.1");
            IPAddress host_ipAddress = IPAddress.Parse(local_ip_adress);
            //IPEndPoint ipep = new IPEndPoint(host_ipAddress, 12121);
            IPEndPoint ipep = new IPEndPoint(host_ipAddress, port);
            s.Bind(ipep);

            //IPAddress ip = IPAddress.Parse("239.100.100.5");
            IPAddress ip = IPAddress.Parse(ip_multicast_channel_adress);
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            //MulticastOption optionsMulticast = new MulticastOption(ip, 13);
            MulticastOption optionsMulticast = new MulticastOption(ip, network_phy_interface_number);

            s.SetSocketOption(SocketOptionLevel.IP,
                SocketOptionName.AddMembership,
                    new MulticastOption(ip, network_phy_interface_number));

            //byte[] arregloBytes = new byte[66000];
            byte[] arregloBytes = new byte[buffer_size];

            try
            {

                int contadorColor = 0;

                while (true)
                {
                    ////////Escribir bytes
                    int finalBuffer = s.Receive(arregloBytes);
                    DateTime date = DateTime.Now;
                    BufferToFile("C://Users//Administrator.GACSKIO//Desktop//logBytesTEST_" + getDate(date) + "_" + data_feed_tape_letter_id + ".bin", arregloBytes, finalBuffer);
                    //////

                    char primerByte = (char)arregloBytes[0];
                    char segundoByte = (char)arregloBytes[1];

                    tamañoMensaje = (short)(arregloBytes[0] << 8 | arregloBytes[1]);

                    totalMensajes = (sbyte)(arregloBytes[2]);

                    grupoMarketData = (sbyte)(arregloBytes[3]); //Canal

                    sesion = (sbyte)(arregloBytes[4]); //Sesión

                    byte[] bytesInt = { arregloBytes[5], arregloBytes[6], arregloBytes[7], arregloBytes[8] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesInt);

                    numeroSecuencia = BitConverter.ToInt32(bytesInt, 0);              

                    if (numeroSecuencia != 0)
                    {
                        try
                        {
                            byte[] bytesTimestamp = { arregloBytes[9], arregloBytes[10], arregloBytes[11], arregloBytes[12], arregloBytes[13], arregloBytes[14], arregloBytes[15], arregloBytes[16] };
                            if (BitConverter.IsLittleEndian)
                                Array.Reverse(bytesTimestamp);

                            long longVar = BitConverter.ToInt64(bytesTimestamp, 0);
                            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                            timeStampBolsa = start.AddMilliseconds(longVar).ToLocalTime();

                            System.Console.WriteLine(
                                "Tamaño Mensaje: " + tamañoMensaje + "\n" +
                                "Total Mensajes: " + totalMensajes + "\n" +
                                "Canal: " + grupoMarketData + "\n" +
                                "Sesión: " + sesion + "\n" +
                                "Numero Secuencia: " + numeroSecuencia + "\n" +
                                //"Timestamp: " + getTs(date) + "\n" +
                                "Tape: " + data_feed_tape_letter_id + "\n"
                            );                      

                            //N mensajes
                            if (totalMensajes > 1)
                            {

                                //Console.WriteLine("--->" + totalMensajes);
                                var longitudMensaje = 17;

                                for (int i = 0; i < totalMensajes; i++)
                                {
                                    try
                                    {
                                        procesarMensaje(arregloBytes, longitudMensaje + ((i + 1) * 2));
                                        longitudMensaje = (short)(arregloBytes[longitudMensaje + ((i + 1) * 2) - 2] << 8 | arregloBytes[longitudMensaje + ((i + 1) * 2) - 1]) + longitudMensaje;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Error en el for;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,," + e.Message);
                                    }
                                    
                                }
                                StreamWriter archivo = abrirLog(getDate(date), data_feed_tape_letter_id);
                                archivo.WriteLine(tamañoMensaje + "|" + totalMensajes + "|" + grupoMarketData + "|" + sesion + "|" + numeroSecuencia + "|" + timeStampBolsa);
                                archivo.Dispose();
                            }
                            //Un mensaje
                            else if (totalMensajes == 1)
                            {
                                procesarMensaje(arregloBytes, 19);
                                StreamWriter archivo = abrirLog(getDate(date), data_feed_tape_letter_id); 
                                archivo.WriteLine(tamañoMensaje + "|" + totalMensajes + "|" + grupoMarketData + "|" + sesion + "|" + numeroSecuencia + "|" + timeStampBolsa);
                                archivo.Dispose();
                            }
                            //Cero mensajes/Mensaje Administrativo
                            else
                            {
                                StreamWriter archivo = abrirLog(getDate(date), data_feed_tape_letter_id);
                                archivo.WriteLine(tamañoMensaje + "|" + totalMensajes + "|" + grupoMarketData + "|" + sesion + "|" + numeroSecuencia + "|" + timeStampBolsa);
                                archivo.Dispose();

                                //Console.WriteLine("Total de mensajes 0/Mensaje Administrativo");
                                
                                //ConsoleColor color = new ConsoleColor();
                                //if(contadorColor == 0)
                                //{
                                //    color = ConsoleColor.Blue;
                                //}

                                //if(contadorColor == 1)
                                //{
                                //    color = ConsoleColor.Cyan;
                                //}

                                //if(contadorColor == 2)
                                //{
                                //    color = ConsoleColor.DarkBlue;
                                //}

                                //if (contadorColor == 3)
                                //{
                                //    color = ConsoleColor.DarkBlue;
                                //    contadorColor = 0;
                                //}

                                //contadorColor++;
                                //Console.BackgroundColor = color;
                                //Console.WriteLine("Total de mensajes 0/Mensaje Administrativo");
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine(ex.Message);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //private void procesarMensajeSecuencialDerivados

        private void procesarMensaje(byte[] arregloBytes, int inicio)
        {
            //stopwatch.Start();

            char tipoMensaje = (char)arregloBytes[inicio];
            DateTime date = DateTime.Now;

            //Log tipo mensaje
            StreamWriter archivoTipo = abrirTipo(getDate(date), data_feed_tape_letter_id_);
            archivoTipo.WriteLine(tipoMensaje);
            archivoTipo.Dispose();
            ////////////////////////////////////
          
            ////1 -> Profundidad
            if (tipoMensaje == 49)
            {
                //Console.WriteLine("Soy 1");
                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                var nivelBid = (sbyte)(arregloBytes[inicio + 5]);

                var nivelAsk = (sbyte)(arregloBytes[inicio + 6]);

                List<Ticker> bid = new List<Ticker>();
                List<Ticker> ask = new List<Ticker>();

                for (int i = 0; i < nivelBid; i++)
                {
                    byte[] bytesPrecioEntero = { arregloBytes[inicio + 7 + (14 * i)], arregloBytes[inicio + 8 + (14 * i)], arregloBytes[inicio + 9 + (14 * i)], arregloBytes[inicio + 10 + (14 * i)], arregloBytes[inicio + 11 + (14 * i)], arregloBytes[inicio + 12 + (14 * i)], arregloBytes[inicio + 13 + (14 * i)], arregloBytes[inicio + 14 + (14 * i)] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesPrecioEntero);
                    Int64 precio = BitConverter.ToInt64(bytesPrecioEntero, 0);
                    double precioCompleto = (double)precio / 100000000;

                    byte[] bytesNumeroOrdenes = { arregloBytes[inicio + 15 + (14 * i)], arregloBytes[inicio + 16 + (14 * i)] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesNumeroOrdenes);
                    int numeroOrdenes = BitConverter.ToInt16(bytesNumeroOrdenes, 0);

                    byte[] bytesNumeroVolumen = { arregloBytes[inicio + 17 + (14 * i)], arregloBytes[inicio + 18 + (14 * i)], arregloBytes[inicio + 19 + (14 * i)], arregloBytes[inicio + 20 + (14 * i)] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesNumeroVolumen);
                    int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

                    bid.Add(new Ticker() { precio = precioCompleto, ordenes = numeroOrdenes, volumen = volumen });

                    //Console.WriteLine(bid[i].precio + "-" + bid[i].ordenes + "-" + bid[i].volumen);
                    }

                    for (int i = 0; i < nivelAsk; i++)
                    {
                        byte[] bytesPrecioEntero = { arregloBytes[inicio + 7 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 8 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 9 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 10 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 11 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 12 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 13 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 14 + (14 * i) + (14 * nivelBid)] };
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytesPrecioEntero);
                        Int64 precio = BitConverter.ToInt64(bytesPrecioEntero, 0);
                        double precioCompleto = (double)precio / 100000000;

                        byte[] bytesNumeroOrdenes = { arregloBytes[inicio + 15 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 16 + (14 * i) + (14 * nivelBid)] };
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytesNumeroOrdenes);
                        int numeroOrdenes = BitConverter.ToInt16(bytesNumeroOrdenes, 0);

                        byte[] bytesNumeroVolumen = { arregloBytes[inicio + 17 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 18 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 19 + (14 * i) + (14 * nivelBid)], arregloBytes[inicio + 20 + (14 * i) + (14 * nivelBid)] };
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytesNumeroVolumen);
                        int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

                        ask.Add(new Ticker() { precio = precioCompleto, ordenes = numeroOrdenes, volumen = volumen });

                        //Console.WriteLine(ask[i].precio + "-" + ask[i].ordenes + "-" + ask[i].volumen);
                    }

                    if (numeroInstrumento == 353638)
                    {
                        //Console.Clear();
                        ////Console.WriteLine(numeroInstrumento + "   " + nivelBid + "    " + nivelAsk);
                        //int ordenesBid = 0;
                        //int ordenesAsk = 0;

                        //int volumenCompra = 0;
                        //int volumenVenta = 0;

                        //for (int i = 0; i < 10; i++)
                        //{
                        //    ordenesBid = ordenesBid + bid[i].ordenes;
                        //    ordenesAsk = ordenesAsk + ask[i].ordenes;

                        //    volumenCompra = volumenCompra + bid[i].volumen;
                        //    volumenVenta = volumenVenta + ask[i].volumen;

                        //}

                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine(ordenesAsk + " - " + volumenVenta);
                        //Console.WriteLine();
                        //Console.WriteLine("                 " + ask[9].volumen + " @ " + ask[9].precio + " - " + ask[9].ordenes);
                        //Console.WriteLine("                 " + ask[8].volumen + " @ " + ask[8].precio + " - " + ask[8].ordenes);
                        //Console.WriteLine("                 " + ask[7].volumen + " @ " + ask[7].precio + " - " + ask[7].ordenes);
                        //Console.WriteLine("                 " + ask[6].volumen + " @ " + ask[6].precio + " - " + ask[6].ordenes);
                        //Console.WriteLine("                 " + ask[5].volumen + " @ " + ask[5].precio + " - " + ask[5].ordenes);
                        //Console.WriteLine("                 " + ask[4].volumen + " @ " + ask[4].precio + " - " + ask[4].ordenes);
                        //Console.WriteLine("                 " + ask[3].volumen + " @ " + ask[3].precio + " - " + ask[3].ordenes);
                        //Console.WriteLine("                 " + ask[2].volumen + " @ " + ask[2].precio + " - " + ask[2].ordenes);
                        //Console.WriteLine("                 " + ask[1].volumen + " @ " + ask[1].precio + " - " + ask[1].ordenes);
                        //Console.WriteLine("                 " + ask[0].volumen + " @ " + ask[0].precio + " - " + ask[0].ordenes);
                        //Console.WriteLine();
                        //Console.WriteLine(ask[0].precio - bid[0].precio);
                        //Console.WriteLine();
                        //Console.WriteLine(bid[0].ordenes + " - " + bid[0].volumen + " @ " + bid[0].precio);
                        //Console.WriteLine(bid[1].ordenes + " - " + bid[1].volumen + " @ " + bid[1].precio);
                        //Console.WriteLine(bid[2].ordenes + " - " + bid[2].volumen + " @ " + bid[2].precio);
                        //Console.WriteLine(bid[3].ordenes + " - " + bid[3].volumen + " @ " + bid[3].precio);
                        //Console.WriteLine(bid[4].ordenes + " - " + bid[4].volumen + " @ " + bid[4].precio);
                        //Console.WriteLine(bid[5].ordenes + " - " + bid[5].volumen + " @ " + bid[5].precio);
                        //Console.WriteLine(bid[6].ordenes + " - " + bid[6].volumen + " @ " + bid[6].precio);
                        //Console.WriteLine(bid[7].ordenes + " - " + bid[7].volumen + " @ " + bid[7].precio);
                        //Console.WriteLine(bid[8].ordenes + " - " + bid[8].volumen + " @ " + bid[8].precio);
                        //Console.WriteLine(bid[9].ordenes + " - " + bid[9].volumen + " @ " + bid[9].precio);
                        //Console.WriteLine();
                        //Console.WriteLine(ordenesBid + " - " + volumenCompra);

                        //Console.WriteLine();
                        //Console.WriteLine();

                        //double demandaVSOferta = 0;
                        //demandaVSOferta = (double)volumenCompra / volumenVenta;

                        //Console.WriteLine(demandaVSOferta);

                    }

                    ////MEXTRAC H7
                    //if (numeroInstrumento == 355776)
                    //{
                    //    //COMPLETO
                    //    if (bid.Count() > 0 && ask.Count() > 0)
                    //    {
                    //        Console.WriteLine(numeroInstrumento + "   " + nivelBid + "    " + nivelAsk + "      " + bid[0].volumen + " @ " + bid[0].precio + " || " + ask[0].volumen + " @ " + ask[0].precio);
                    //    }

                    //    //SOLO BID
                    //    else if(bid.Count() > 0 && ask.Count() == 0)
                    //    {
                    //        Console.WriteLine(numeroInstrumento + "   " + nivelBid + "    " + nivelAsk + "      " + bid[0].volumen + "@" + bid[0].precio + " || " + "0 @ 0");
                    //    }

                    //    //SOLO ASK
                    //    else if(bid.Count() == 0 && ask.Count() > 0)
                    //    {
                    //        Console.WriteLine(numeroInstrumento + "   " + nivelBid + "    " + nivelAsk + "      " + "0 @ 0" + " || " + ask[0].volumen + " @ " + ask[0].precio);
                    //    }

                    //}

                //}
            }
            //S -> Eventos de sistema
            else if (tipoMensaje == 83)
            {
                //Console.WriteLine("Soy S");
                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0); //Siempre será cero

                char codigoEvento = (char)arregloBytes[inicio + 5];

                //M -> Inicio de receso administrativo
                //N -> Fin de receso administrativo

                //if (codigoEvento == 77 || codigoEvento == 77)    // Si es M o N
                if (codigoEvento == 77) //Si es M
                {
                    char mercado = (char)arregloBytes[inicio + 6];

                    byte[] bytesTimestampInicio = { arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12], arregloBytes[inicio + 13], arregloBytes[inicio + 14] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesTimestampInicio);
                    long longVarTimestampInicio = BitConverter.ToInt64(bytesTimestampInicio, 0);
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime timestampEnvioRecesoAdministrativo = start.AddMilliseconds(longVarTimestampInicio).ToLocalTime();

                    byte[] bytesTimestampFin = { arregloBytes[inicio + 15], arregloBytes[inicio + 16], arregloBytes[inicio + 17], arregloBytes[inicio + 18], arregloBytes[inicio + 19], arregloBytes[inicio + 20], arregloBytes[inicio + 21], arregloBytes[inicio + 22] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesTimestampFin);
                    long longVarTimestampFin = BitConverter.ToInt64(bytesTimestampFin, 0);
                    //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime timestampFinRecesoAdministrativo = start.AddMilliseconds(longVarTimestampFin).ToLocalTime();

                    Console.WriteLine(codigoEvento + "|" + mercado + "|" + getTs(timestampEnvioRecesoAdministrativo) + "|" + getTs(timestampFinRecesoAdministrativo));
                }

                //Console.WriteLine(codigoEvento);
            }
             //Q -> Hechos del mercado de derivados
            else if (tipoMensaje == 81)
            {
                //Console.WriteLine("Soy Q");
                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                byte[] bytesTimestampHecho = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesTimestampHecho);
                long longVarHecho = BitConverter.ToInt64(bytesTimestampHecho, 0);
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime timestampHecho = start.AddMilliseconds(longVarHecho).ToLocalTime();

                byte[] bytesNumeroVolumen = { arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroVolumen);
                int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

                byte[] bytesPrecioEntero = { arregloBytes[inicio + 17], arregloBytes[inicio + 18], arregloBytes[inicio + 19], arregloBytes[inicio + 20], arregloBytes[inicio + 21], arregloBytes[inicio + 22], arregloBytes[inicio + 23], arregloBytes[inicio + 24] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioEntero);
                Int64 precio64 = BitConverter.ToInt64(bytesPrecioEntero, 0);
                double precio = (double)precio64 / 100000000;

                char tipoConcertacion = (char)arregloBytes[inicio + 25];

                byte[] bytesFolioHecho = { arregloBytes[inicio + 26], arregloBytes[inicio + 27], arregloBytes[inicio + 28], arregloBytes[inicio + 29] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesFolioHecho);
                int folioHecho = BitConverter.ToInt32(bytesFolioHecho, 0); //error api

                char tipoOperacion = (char)arregloBytes[inicio + 30];

                byte[] bytesImporte = { arregloBytes[inicio + 31], arregloBytes[inicio + 32], arregloBytes[inicio + 33], arregloBytes[inicio + 34], arregloBytes[inicio + 35], arregloBytes[inicio + 36], arregloBytes[inicio + 37], arregloBytes[inicio + 38] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesImporte);
                Int64 importe = BitConverter.ToInt64(bytesImporte, 0);
                double importeCompleto = (double)importe / 100000000; 

                byte[] bytesFolioHechoPadre = { arregloBytes[inicio + 39], arregloBytes[inicio + 40], arregloBytes[inicio + 41], arregloBytes[inicio + 42] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesFolioHechoPadre);
                int folioHechoPadre = BitConverter.ToInt32(bytesFolioHechoPadre, 0);

                char tipoPata = (char)arregloBytes[inicio + 43];

                //if (numeroInstrumento == 353638)
                //{

                //    //HECHO
                //    //Console.WriteLine("TICK: " + volumen + "@" + precio + " - " + getTs(timestampHecho) + " | " + getTs(exchageTimeStamp) + " Tipo: " + tipoConcertacion + " Pata: " + tipoPata);

                //    //exchageTimeStamp
                    
                //    //  Console.WriteLine(tipoMensaje + "|" +
                //  //numeroInstrumento + "|" +
                //  //getTs(timestampHecho) + "|" +
                //  //volumen + "|" +
                //  //precio + "|" +
                //  //tipoConcertacion + "|" +
                //  //folioHecho + "|" +
                //  //tipoOperacion + "|" +
                //  //importeCompleto + "|" +
                //  //folioHechoPadre + "|" +
                //  //tipoPata);
                //}

            }
            //O -> Mejor Postura
            //else if (tipoMensaje == 79)
            //{
            //    //Console.WriteLine("Soy O");
            //    byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
            //    if (BitConverter.IsLittleEndian)
            //        Array.Reverse(bytesNumeroInstrumento);
            //    int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

            //    byte[] bytesNumeroVolumen = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8] };
            //    if (BitConverter.IsLittleEndian)
            //        Array.Reverse(bytesNumeroVolumen);
            //    int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

            //    byte[] bytesPrecioOtasa = { arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12], arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16] };
            //    if (BitConverter.IsLittleEndian)
            //        Array.Reverse(bytesPrecioOtasa);
            //    Int64 precioOtasa = BitConverter.ToInt64(bytesPrecioOtasa, 0);
            //    double precioOtasaCompleto = (double)precioOtasa / 100000000;

            //    char lado = (char)arregloBytes[inicio + 17];

            //    char tipoOperacion = (char)arregloBytes[inicio + 18];

            //    //if (numeroInstrumento == 353638)
            //    //{
            //    //    Console.WriteLine(numeroInstrumento + "|" +
            //    //                      volumen + "|" +
            //    //                      precioOtasaCompleto + "|" +
            //    //                      lado + "|" +
            //    //                      tipoOperacion + "\n");
            //    //}

            //    //if (numeroInstrumento == 9)
            //    //{
            //    //    Console.WriteLine(numeroInstrumento + "|" +
            //    //                      volumen + "|" +
            //    //                      precioOtasaCompleto + "|" +
            //    //                      lado + "|" +
            //    //                      tipoOperacion);

            //    //}

            //}
            //R -> Estadísticas de los instrumentos 
            else if (tipoMensaje == 82)
            {
                //Console.WriteLine("Soy R");
                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                byte[] bytesPrecioLiquidacionDiaAnterior = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioLiquidacionDiaAnterior);
                Int64 precioLiquidacionDiaAnterior64 = BitConverter.ToInt64(bytesPrecioLiquidacionDiaAnterior, 0);
                double precioLiquidacionDiaAnterior = (double)precioLiquidacionDiaAnterior64 / 100000000;

                byte[] bytesPrecioApertura = { arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16], arregloBytes[inicio + 17], arregloBytes[inicio + 18], arregloBytes[inicio + 19], arregloBytes[inicio + 20] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioApertura);
                Int64 precioApertura64 = BitConverter.ToInt64(bytesPrecioApertura, 0);
                double precioApertura = (double)precioApertura64 / 100000000;

                byte[] bytesPrecioMaximoDia = { arregloBytes[inicio + 21], arregloBytes[inicio + 22], arregloBytes[inicio + 23], arregloBytes[inicio + 24], arregloBytes[inicio + 25], arregloBytes[inicio + 26], arregloBytes[inicio + 27], arregloBytes[inicio + 28] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioMaximoDia);
                Int64 precioMaximoDia64 = BitConverter.ToInt64(bytesPrecioMaximoDia, 0);
                double precioMaximo = (double)precioMaximoDia64 / 100000000;

                byte[] bytesPrecioMinimoDia = { arregloBytes[inicio + 29], arregloBytes[inicio + 30], arregloBytes[inicio + 31], arregloBytes[inicio + 32], arregloBytes[inicio + 33], arregloBytes[inicio + 34], arregloBytes[inicio + 35], arregloBytes[inicio + 36] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioMinimoDia);
                Int64 precioMinimoDia64 = BitConverter.ToInt64(bytesPrecioMinimoDia, 0);
                double precioMinimo = (double)precioMinimoDia64 / 100000000;

                byte[] bytesPrecioUltimoDia = { arregloBytes[inicio + 37], arregloBytes[inicio + 38], arregloBytes[inicio + 39], arregloBytes[inicio + 40], arregloBytes[inicio + 41], arregloBytes[inicio + 42], arregloBytes[inicio + 43], arregloBytes[inicio + 44] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioUltimoDia);
                Int64 precioUltimoDia64 = BitConverter.ToInt64(bytesPrecioUltimoDia, 0);
                double lastPrice = (double)precioUltimoDia64 / 100000000;

                //Console.WriteLine(numeroInstrumento + "|" + precioLiquidacionDiaAnterior + "|" + precioApertura + "|" + precioMaximo + "|" + precioMinimo + "|" + lastPrice);
            }
            //I -> Interés Abierto
            else if (tipoMensaje == 100)
            {
                //Console.WriteLine("Soy I");
                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                byte[] bytesInteresAbierto = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesInteresAbierto);
                int interesAbiertoInt = BitConverter.ToInt32(bytesInteresAbierto, 0);
                double interesAbierto = (double)interesAbiertoInt / 10000;

                //Console.WriteLine(bytesNumeroInstrumento + "    " + interesAbierto);
            }
            //H -> Cancelación de Hecho
            else if (tipoMensaje == 72)
            {
                //Console.WriteLine("Soy H");

                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                byte[] bytesCancelacionHecho = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesCancelacionHecho);
                int cancelacionHecho = BitConverter.ToInt32(bytesCancelacionHecho, 0);

                //Console.WriteLine(numeroInstrumento + "     " + cancelacionHecho);
            }
            //4 -> Cambios de estado
            else if (tipoMensaje == 52)
            {
                //Console.WriteLine("Soy 4");
                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                char estadoInstrumento = (char)arregloBytes[inicio + 5];

                //Console.WriteLine("CAMBIO ESTADO - " + numeroInstrumento + "|" + estadoInstrumento);
            }
            //d -> Catálogo enviado para instrumentos que pertenecen al mercado de derivados de futuros, opciones y Swaps
            else if (tipoMensaje == 'd')
            {
                //DateTime date = DateTime.Now;

                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                string tipoValor = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 5, 2);

                string clase = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 7, 7);

                string vencimiento = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 14, 6);

                char tipoOpcion = (char)arregloBytes[inicio + 20];

                byte[] bytesPrecioEjercicio = { arregloBytes[inicio + 21], arregloBytes[inicio + 22], arregloBytes[inicio + 23], arregloBytes[inicio + 24], arregloBytes[inicio + 25], arregloBytes[inicio + 26], arregloBytes[inicio + 27], arregloBytes[inicio + 28] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioEjercicio);
                Int64 precioEjercicio64 = BitConverter.ToInt64(bytesPrecioEjercicio, 0);
                double precioEjercicio = (double)precioEjercicio64 / 100000000;

                byte[] bytesBid = { arregloBytes[inicio + 29], arregloBytes[inicio + 30], arregloBytes[inicio + 31], arregloBytes[inicio + 32], arregloBytes[inicio + 33], arregloBytes[inicio + 34], arregloBytes[inicio + 35], arregloBytes[inicio + 36] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesBid);
                Int64 bid64 = BitConverter.ToInt64(bytesBid, 0);
                double bid = (double)bid64 / 100000000;

                byte[] bytesPrecioLiquidacionDiaAnterior = { arregloBytes[inicio + 37], arregloBytes[inicio + 38], arregloBytes[inicio + 39], arregloBytes[inicio + 40], arregloBytes[inicio + 41], arregloBytes[inicio + 42], arregloBytes[inicio + 43], arregloBytes[inicio + 44] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioLiquidacionDiaAnterior);
                Int64 precioLiquidacionDiaAnterior64 = BitConverter.ToInt64(bytesPrecioLiquidacionDiaAnterior, 0);
                double precioLiquidacionDiaAnterior = (double)precioLiquidacionDiaAnterior64 / 100000000;

                byte[] bytesUltimaFechaOperacion = { arregloBytes[inicio + 45], arregloBytes[inicio + 46], arregloBytes[inicio + 47], arregloBytes[inicio + 48], arregloBytes[inicio + 49], arregloBytes[inicio + 50], arregloBytes[inicio + 51], arregloBytes[inicio + 52] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesUltimaFechaOperacion);
                long ultimaFechaOperacion = BitConverter.ToInt64(bytesUltimaFechaOperacion, 0);
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime timestampUltimaFechaOperacion = start.AddMilliseconds(ultimaFechaOperacion).ToLocalTime();

                byte[] bytesFechaVencimiento = { arregloBytes[inicio + 53], arregloBytes[inicio + 54], arregloBytes[inicio + 55], arregloBytes[inicio + 56], arregloBytes[inicio + 57], arregloBytes[inicio + 58], arregloBytes[inicio + 59], arregloBytes[inicio + 60] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesFechaVencimiento);
                long fechaVencimiento = BitConverter.ToInt64(bytesFechaVencimiento, 0);
                //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime timestampFechaVencimiento = start.AddMilliseconds(fechaVencimiento).ToLocalTime();

                byte[] bytesContratoAbiertos = { arregloBytes[inicio + 61], arregloBytes[inicio + 62], arregloBytes[inicio + 63], arregloBytes[inicio + 64] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesContratoAbiertos);
                int contratoAbiertos = BitConverter.ToInt32(bytesContratoAbiertos, 0);

                byte[] bytesTamañoContrato = { arregloBytes[inicio + 65], arregloBytes[inicio + 66], arregloBytes[inicio + 67], arregloBytes[inicio + 68] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesTamañoContrato);
                int tamañoContrato = BitConverter.ToInt32(bytesTamañoContrato, 0);

                string emisoraSubyacente = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 69, 7);

                string serieSubyacente = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 76, 6);

                string tvSubyacente = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 82, 2);

                string codigoProducto = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 84, 12);

                char vencimientoDiario = (char)arregloBytes[inicio + 96];

                StreamWriter catalogo = abrirCatalogo("opcionesYfuturos_" + getDate(date), data_feed_tape_letter_id_);

                Console.WriteLine(numeroInstrumento + "|" + tipoValor + "|" + clase);
                catalogo.WriteLine(getTs(date) + "|" + numeroInstrumento + "|" + tipoValor + "|" + clase + "|" + vencimiento + "|" + tipoOpcion + "|" + precioEjercicio + "|" + bid + "|" + precioLiquidacionDiaAnterior + "|" + getDate(timestampUltimaFechaOperacion) + "|" + getDate(timestampFechaVencimiento) + "|" + contratoAbiertos + "|" + tamañoContrato + "|" + emisoraSubyacente + "|" + serieSubyacente + "|" + tvSubyacente + "|" + codigoProducto + "|" + vencimientoDiario);
                catalogo.Dispose();
            }
            //Repetido
            else if (tipoMensaje == 100)
            {
                //DateTime date = DateTime.Now;

                byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesNumeroInstrumento);
                int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                string tipoValor = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 5, 2);

                string clase = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 7, 7);

                string vencimiento = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 14, 6);

                char tipoOpcion = (char)arregloBytes[inicio + 20];

                byte[] bytesPrecioEjercicio = { arregloBytes[inicio + 21], arregloBytes[inicio + 22], arregloBytes[inicio + 23], arregloBytes[inicio + 24], arregloBytes[inicio + 25], arregloBytes[inicio + 26], arregloBytes[inicio + 27], arregloBytes[inicio + 28] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioEjercicio);
                Int64 precioEjercicio64 = BitConverter.ToInt64(bytesPrecioEjercicio, 0);
                double precioEjercicio = (double)precioEjercicio64 / 100000000;

                byte[] bytesBid = { arregloBytes[inicio + 29], arregloBytes[inicio + 30], arregloBytes[inicio + 31], arregloBytes[inicio + 32], arregloBytes[inicio + 33], arregloBytes[inicio + 34], arregloBytes[inicio + 35], arregloBytes[inicio + 36] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesBid);
                Int64 bid64 = BitConverter.ToInt64(bytesBid, 0);
                double bid = (double)bid64 / 100000000;

                byte[] bytesPrecioLiquidacionDiaAnterior = { arregloBytes[inicio + 37], arregloBytes[inicio + 38], arregloBytes[inicio + 39], arregloBytes[inicio + 40], arregloBytes[inicio + 41], arregloBytes[inicio + 42], arregloBytes[inicio + 43], arregloBytes[inicio + 44] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesPrecioLiquidacionDiaAnterior);
                Int64 precioLiquidacionDiaAnterior64 = BitConverter.ToInt64(bytesPrecioLiquidacionDiaAnterior, 0);
                double precioLiquidacionDiaAnterior = (double)precioLiquidacionDiaAnterior64 / 100000000;

                byte[] bytesUltimaFechaOperacion = { arregloBytes[inicio + 45], arregloBytes[inicio + 46], arregloBytes[inicio + 47], arregloBytes[inicio + 48], arregloBytes[inicio + 49], arregloBytes[inicio + 50], arregloBytes[inicio + 51], arregloBytes[inicio + 52] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesUltimaFechaOperacion);
                long ultimaFechaOperacion = BitConverter.ToInt64(bytesUltimaFechaOperacion, 0);
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime timestampUltimaFechaOperacion = start.AddMilliseconds(ultimaFechaOperacion).ToLocalTime();

                byte[] bytesFechaVencimiento = { arregloBytes[inicio + 53], arregloBytes[inicio + 54], arregloBytes[inicio + 55], arregloBytes[inicio + 56], arregloBytes[inicio + 57], arregloBytes[inicio + 58], arregloBytes[inicio + 59], arregloBytes[inicio + 60] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesFechaVencimiento);
                long fechaVencimiento = BitConverter.ToInt64(bytesFechaVencimiento, 0);
                //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime timestampFechaVencimiento = start.AddMilliseconds(fechaVencimiento).ToLocalTime();

                byte[] bytesContratoAbiertos = { arregloBytes[inicio + 61], arregloBytes[inicio + 62], arregloBytes[inicio + 63], arregloBytes[inicio + 64] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesContratoAbiertos);
                int contratoAbiertos = BitConverter.ToInt32(bytesContratoAbiertos, 0);

                byte[] bytesTamañoContrato = { arregloBytes[inicio + 65], arregloBytes[inicio + 66], arregloBytes[inicio + 67], arregloBytes[inicio + 68] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesTamañoContrato);
                int tamañoContrato = BitConverter.ToInt32(bytesTamañoContrato, 0);

                string emisoraSubyacente = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 69, 7);

                string serieSubyacente = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 76, 6);

                string tvSubyacente = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 82, 2);

                string codigoProducto = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 84, 12);

                char vencimientoDiario = (char)arregloBytes[inicio + 96];

                StreamWriter catalogo = abrirCatalogo("opcionesYfuturos100_" + getDate(date), data_feed_tape_letter_id_);

                Console.WriteLine(numeroInstrumento + "|" + tipoValor + "|" + clase);
                catalogo.WriteLine(getTs(date) + "|" + numeroInstrumento + "|" + tipoValor + "|" + clase + "|" + vencimiento + "|" + tipoOpcion + "|" + precioEjercicio + "|" + bid + "|" + precioLiquidacionDiaAnterior + "|" + getDate(timestampUltimaFechaOperacion) + "|" + getDate(timestampFechaVencimiento) + "|" + contratoAbiertos + "|" + tamañoContrato + "|" + emisoraSubyacente + "|" + serieSubyacente + "|" + tvSubyacente + "|" + codigoProducto + "|" + vencimientoDiario);
                catalogo.Dispose();
            }
            else
            {
                //Console.WriteLine("No es 1, S, Q, O, R, I, H, 4, d:::::::::::::::::::::::: es " + tipoMensaje);
            }
             //stopwatch.Stop();
             //System.Console.WriteLine("--> Process Time: " + stopwatch.ElapsedMilliseconds + " ms");
        }

    }
}
