using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GACS_Multicast
{
    public class Conexion
    {
        //VARIABLES GLOBALES
        Stopwatch stopwatch = new Stopwatch();
        

        public static string getTs(DateTime value)
        {
            //return value.ToString("yyyyMMddHHmmssfff");
            return value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            //return value.ToString("HHmmssfff");
        }

        public void conectar(string local_ip_adress, int port, string ip_multicast_channel_adress, int network_phy_interface_number, int buffer_size, string data_feed_tape_letter_id)
        {

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
                    char primerByte = (char)arregloBytes[0];
                    char segundoByte = (char)arregloBytes[1];

                    var tamañoMensaje = (short)(arregloBytes[0] << 8 | arregloBytes[1]);

                    var totalMensajes = (sbyte)(arregloBytes[2]);

                    var grupoMarketData = (sbyte)(arregloBytes[3]); //Canal
                    var sesion = (sbyte)(arregloBytes[4]); //Sesión

                    byte[] bytesInt = { arregloBytes[5], arregloBytes[6], arregloBytes[7], arregloBytes[8] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytesInt);

                    int numeroSecuencia = BitConverter.ToInt32(bytesInt, 0);

                    //System.Console.WriteLine("Primero: " + primerByte + " - Segundo: " + segundoByte + " --> Combinado: " + tamañoMensaje + " Número Mensajes: " + totalMensajes + " Byte: " + arregloBytes[3]); 

                    if (numeroSecuencia != 0)
                    {
                        try
                        {
                            byte[] bytesTimestamp = { arregloBytes[9], arregloBytes[10], arregloBytes[11], arregloBytes[12], arregloBytes[13], arregloBytes[14], arregloBytes[15], arregloBytes[16] };
                            if (BitConverter.IsLittleEndian)
                                Array.Reverse(bytesTimestamp);

                            long longVar = BitConverter.ToInt64(bytesTimestamp, 0);
                            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                            DateTime date = start.AddMilliseconds(longVar).ToLocalTime();

                            //char tipoMensaje = (char)arregloBytes[19];

                            System.Console.WriteLine(
                                "Tamaño Mensaje: " + tamañoMensaje + "\n" +
                                "Total Mensajes: " + totalMensajes + "\n" +
                                "Canal: " + grupoMarketData + "\n" +
                                "Sesión: " + sesion + "\n" +
                                "Numero Secuencia: " + numeroSecuencia + "\n" +
                                "Timestamp: " + getTs(date) + "\n" +
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
                            }
                            //Un mensaje
                            else if (totalMensajes == 1)
                            {
                                procesarMensaje(arregloBytes, 19);
                            }
                            //Cero mensajes/Mensaje Administrativo
                            else
                            {
                                Console.WriteLine("Total de mensajes 0/Mensaje Administrativo");
                                
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

                    int finalBuffer = s.Receive(arregloBytes);
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
            stopwatch.Start();

            char tipoMensaje = (char)arregloBytes[inicio];

            System.Console.WriteLine(tipoMensaje);

            //S -> Eventos de sistema
             if (tipoMensaje == 83)
            {
                Console.WriteLine("Soy S");
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

                Console.WriteLine(codigoEvento);
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

                Console.WriteLine(tipoMensaje + "|" +
                                  numeroInstrumento + "|" +
                                  getTs(timestampHecho) + "|" +
                                  volumen + "|" +
                                  precio + "|" +
                                  tipoConcertacion + "|" +
                                  folioHecho + "|" +
                                  tipoOperacion + "|" + 
                                  importeCompleto + "|" + 
                                  folioHechoPadre + "|" + 
                                  tipoPata);
            }
             ////P -> Hechos del mercado de capitales
             //else if (tipoMensaje == 80)
             //{
             //    //Console.WriteLine("Soy P");
             //    byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroInstrumento);
             //    int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

             //    byte[] bytesTimestampHecho = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesTimestampHecho);
             //    long longVarHecho = BitConverter.ToInt64(bytesTimestampHecho, 0);
             //    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
             //    DateTime timestampHecho = start.AddMilliseconds(longVarHecho).ToLocalTime();

             //    byte[] bytesNumeroVolumen = { arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroVolumen);
             //    int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

             //    byte[] bytesPrecioEntero = { arregloBytes[inicio + 17], arregloBytes[inicio + 18], arregloBytes[inicio + 19], arregloBytes[inicio + 20], arregloBytes[inicio + 21], arregloBytes[inicio + 22], arregloBytes[inicio + 23], arregloBytes[inicio + 24] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesPrecioEntero);
             //    Int64 precio = BitConverter.ToInt64(bytesPrecioEntero, 0);
             //    double precioCompleto = (double)precio / 100000000;

             //    char tipoConcertacion = (char)arregloBytes[inicio + 25];

             //    byte[] bytesFolioHecho = { arregloBytes[inicio + 26], arregloBytes[inicio + 27], arregloBytes[inicio + 28], arregloBytes[inicio + 29] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesFolioHecho);
             //    int folioHecho = BitConverter.ToInt32(bytesFolioHecho, 0);

             //    char fijaPrecio = (char)arregloBytes[inicio + 30];

             //    char tipoOperacion = (char)arregloBytes[inicio + 31];

             //    byte[] bytesImporte = { arregloBytes[inicio + 32], arregloBytes[inicio + 33], arregloBytes[inicio + 34], arregloBytes[inicio + 35], arregloBytes[inicio + 36], arregloBytes[inicio + 37], arregloBytes[inicio + 38], arregloBytes[inicio + 39] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesImporte);
             //    Int64 importe = BitConverter.ToInt64(bytesImporte, 0);
             //    double importeCompleto = (double)importe / 100000000; //////////////////////////No sé si es válido

             //    string casaCompradora = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 40, 5);

             //    string casaVendedora = System.Text.Encoding.UTF8.GetString(arregloBytes, inicio + 45, 5);

             //    char liquidacion = (char)arregloBytes[inicio + 50];

             //    char indicadorSubasta = (char)arregloBytes[inicio + 51];

             //    //if (numeroInstrumento == 9)
             //    //{
             //    //    System.Console.WriteLine(timestampHecho + " | " + precioCompleto + " | " + volumen + " | " + importeCompleto);
             //    //}

             //    //Console.WriteLine(tipoMensaje + "     " + numeroInstrumento + "     " + getTs(timestampHecho) + "     " + volumen + "    " + precioCompleto);
             //    //if (numeroInstrumento == 1862)
             //    //{
             //    //    Console.WriteLine(tipoMensaje + "     " + numeroInstrumento + "     " + getTs(timestampHecho) + "     " + volumen + "    " + precioCompleto);
             //    //}

             //    //Console.WriteLine(tipoMensaje + "|" +
             //    //                  numeroInstrumento + "|" +
             //    //                  getTs(timestampHecho) + "|" +
             //    //                  volumen + "|" +
             //    //                  precioCompleto + "|" +
             //    //                  tipoConcertacion + "|" +
             //    //                  folioHecho + "|" +
             //    //                  fijaPrecio + "|");

             //    //Console.Write(tipoOperacion + "|" + importeCompleto + "|" + casaCompradora + "|" + casaVendedora
             //    //                    + "|" + liquidacion + "|" + indicadorSubasta);
             //}
             //E -> Operatividad 
             else if (tipoMensaje == 69)
             {
                 //Console.WriteLine("Soy E");
             }
             //O -> Mejor Postura
             else if (tipoMensaje == 79)
             {
                 //Console.WriteLine("Soy O");
                 byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                 if (BitConverter.IsLittleEndian)
                     Array.Reverse(bytesNumeroInstrumento);
                 int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                 byte[] bytesNumeroVolumen = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8] };
                 if (BitConverter.IsLittleEndian)
                     Array.Reverse(bytesNumeroVolumen);
                 int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

                 byte[] bytesPrecioOtasa = { arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12], arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16] };
                 if (BitConverter.IsLittleEndian)
                     Array.Reverse(bytesPrecioOtasa);
                 Int64 precioOtasa = BitConverter.ToInt64(bytesPrecioOtasa, 0);
                 double precioOtasaCompleto = (double)precioOtasa / 100000000;

                 char lado = (char)arregloBytes[inicio + 17];

                 char tipoOperacion = (char)arregloBytes[inicio + 18];

                 if (numeroInstrumento == 353638)
                 {
                     Console.WriteLine(numeroInstrumento + "|" +
                                       volumen + "|" +
                                       precioOtasaCompleto + "|" +
                                       lado + "|" +
                                       tipoOperacion + "\n");
                 }

                 //if (numeroInstrumento == 9)
                 //{
                 //    Console.WriteLine(numeroInstrumento + "|" +
                 //                      volumen + "|" +
                 //                      precioOtasaCompleto + "|" +
                 //                      lado + "|" +
                 //                      tipoOperacion);

                 //}

             }
             //M -> Precio Promedio Ponderado
             else if (tipoMensaje == 77)
             {
                 //Console.WriteLine("Soy M");
                 byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
                 if (BitConverter.IsLittleEndian)
                     Array.Reverse(bytesNumeroInstrumento);
                 int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

                 byte[] bytesPrecioPromedioPonderado = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12] };
                 if (BitConverter.IsLittleEndian)
                     Array.Reverse(bytesPrecioPromedioPonderado);
                 Int64 precio = BitConverter.ToInt64(bytesPrecioPromedioPonderado, 0);
                 double precioPomedioPonderado = (double)precio / 100000000;

                 //Console.WriteLine(numeroInstrumento + "|" +
                 //                  precioPomedioPonderado);

             }
             ////2 -> Precio probable de asignación
             //else if (tipoMensaje == 50)
             //{
             //    //Console.WriteLine("Soy 2");
             //    byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroInstrumento);
             //    int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

             //    byte[] bytesPrecioProbableAsignacion = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesPrecioProbableAsignacion);
             //    Int64 precio = BitConverter.ToInt64(bytesPrecioProbableAsignacion, 0);
             //    double precioProbableAsignacion = (double)precio / 100000000;

             //    byte[] bytesNumeroVolumen = { arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroVolumen);
             //    int volumen = BitConverter.ToInt32(bytesNumeroVolumen, 0);

             //    //Console.WriteLine(numeroInstrumento + "|" +
             //    //precioProbableAsignacion + "|" +
             //    //volumen);

             //}
             ////3 -> Inicio de subastas continuas
             //else if (tipoMensaje == 51)
             //{
             //    //Console.WriteLine("Soy 3");
             //    byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroInstrumento);
             //    int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

             //    byte[] bytesHoraInicioSubasta = { arregloBytes[inicio + 5], arregloBytes[inicio + 6], arregloBytes[inicio + 7], arregloBytes[inicio + 8], arregloBytes[inicio + 9], arregloBytes[inicio + 10], arregloBytes[inicio + 11], arregloBytes[inicio + 12] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesHoraInicioSubasta);
             //    long longHoraInicioSubasta = BitConverter.ToInt64(bytesHoraInicioSubasta, 0);
             //    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
             //    DateTime timestampHoraInicioSubasta = start.AddMilliseconds(longHoraInicioSubasta).ToLocalTime();

             //    byte[] bytesHoraFinSubasta = { arregloBytes[inicio + 13], arregloBytes[inicio + 14], arregloBytes[inicio + 15], arregloBytes[inicio + 16], arregloBytes[inicio + 17], arregloBytes[inicio + 18], arregloBytes[inicio + 19], arregloBytes[inicio + 20] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesHoraFinSubasta);
             //    long longHoraFinSubasta = BitConverter.ToInt64(bytesHoraFinSubasta, 0);
             //    DateTime start2 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
             //    DateTime timestampHoraFinSubasta = start.AddMilliseconds(longHoraFinSubasta).ToLocalTime();

             //    //Console.WriteLine(numeroInstrumento + "|" +
             //    //timestampHoraInicioSubasta + "|" +
             //    //timestampHoraFinSubasta);
             //}
             ////4 -> Cambios de estado
             //else if (tipoMensaje == 52)
             //{
             //    //Console.WriteLine("Soy 4");
             //    byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroInstrumento);
             //    int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0);

             //    char estadoInstrumento = (char)arregloBytes[inicio + 5];

             //    //Console.WriteLine(numeroInstrumento + "|" +
             //    //                  estadoInstrumento);
             //}
             ////5 -> Existencia de posturas A Precio Medio
             //else if (tipoMensaje == 53)
             //{
             //    //Console.WriteLine("Soy 5");
             //    byte[] bytesNumeroInstrumento = { arregloBytes[inicio + 1], arregloBytes[inicio + 2], arregloBytes[inicio + 3], arregloBytes[inicio + 4] };
             //    if (BitConverter.IsLittleEndian)
             //        Array.Reverse(bytesNumeroInstrumento);
             //    int numeroInstrumento = BitConverter.ToInt32(bytesNumeroInstrumento, 0); //Error en API

             //    char existenPosturas = (char)arregloBytes[inicio + 3];

             //    //Console.WriteLine(numeroInstrumento + "|" + existenPosturas);

             //}
             else
             {
                 Console.WriteLine("No es S, P, O, M, 2, 3, 4, ni 5:::::::::::::::::::::::: es " + tipoMensaje);
             }

             stopwatch.Stop();
             System.Console.WriteLine("--> " + stopwatch.ElapsedMilliseconds);

        }

    }
}
