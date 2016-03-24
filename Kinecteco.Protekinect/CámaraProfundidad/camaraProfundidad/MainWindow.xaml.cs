using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Kinect;

namespace camaraProfundidad
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor miKinect; //Variable de la clase kinect-sensor
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (KinectSensor.KinectSensors.Count == 0) {
                MessageBox.Show("No se detecta ningun kinect", "Visor de Camara");
                Application.Current.Shutdown();
            }

            try
            {
                miKinect = KinectSensor.KinectSensors.FirstOrDefault();
                miKinect.DepthStream.Enable();  //Habailitamos cámara de profundidad similar a como se habilita la cámara RGB
                miKinect.Start();
                miKinect.DepthFrameReady += miKinect_DepthFrameReady;
            }
            catch {
                MessageBox.Show("Fallo al inicializar kinect", "Visor de KInect");
                Application.Current.Shutdown();
            }
        }

        short[] datosDistancia = null;          //Almacenamos datos de distancia recibidos mediante el Event Handler
        byte[] colorImagenDistancia = null;     //Asigna color a los pixeles según el criterio del SDK (desconocidos, muy cerca, muy lejos)    
        WriteableBitmap bitmapImagenDistancia = null;   //Variable que vamos a utilizar para mostrar los frames

        void miKinect_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            //Capturar datos con Event Handler
            using (DepthImageFrame framesDistancia = e.OpenDepthImageFrame()) { //Almacena un frame de datos de distancia
                if (framesDistancia == null) return;

                if (datosDistancia == null)
                    datosDistancia = new short[framesDistancia.PixelDataLength];    //En un short caben 16 bits (13 de la cámara de profundidad y 3 de detección de esqueleto)

                if (colorImagenDistancia == null)
                    colorImagenDistancia = new byte[framesDistancia.PixelDataLength * 4];   //Se multiplica por 4 porque son 4 colores (rojo,verde,azul y transparente)

                framesDistancia.CopyPixelDataTo(datosDistancia);
                int posColorImagenDistancia = 0;    //Entero iterador de los cuatro colores

                for (int i = 0; i < framesDistancia.PixelDataLength; i++)      //Recorremos los frames para "colorearlos" con ayuda de uno de los tres criterios (UnknownDepth,TooFarDepth,TooNearDepth) o 
                {
                    //Almacena los datos de profundidad sin los bits de detección de esqueleto ()
                    int valorDistancia = datosDistancia[i] >> 3;    //Usamos el operador de desplazamiento en tres para descartar los 3 bits de detección de esqueletos

                    if (valorDistancia == miKinect.DepthStream.UnknownDepth){//Validación que detecta pixeles desconocidos para el kinect (se mostraran en rojo)
                        colorImagenDistancia[posColorImagenDistancia++] = 0; //Azul
                        colorImagenDistancia[posColorImagenDistancia++] = 0; //Verde
                        colorImagenDistancia[posColorImagenDistancia++] = 255; //Rojo
                    }
                    else if (valorDistancia == miKinect.DepthStream.TooFarDepth){//Validación que detecta pixeles muy lejos para el kinect (se mostraran en azul)
                        colorImagenDistancia[posColorImagenDistancia++] = 255; //Azul
                        colorImagenDistancia[posColorImagenDistancia++] = 0; //Verde
                        colorImagenDistancia[posColorImagenDistancia++] = 0; //Rojo
                    }
                    else if (valorDistancia == miKinect.DepthStream.TooNearDepth){//Validación que detecta pixeles muy cerca para el kinect (se mostraran en verde)
                        colorImagenDistancia[posColorImagenDistancia++] = 0; //Azul
                        colorImagenDistancia[posColorImagenDistancia++] = 255; //Verde
                        colorImagenDistancia[posColorImagenDistancia++] = 0; //Rojo
                    }

                    else {//Si alguna de las distancias no entra en las categorias anteriores le asignamos un valor de iluminación entre más cerca más brillante de lo contrario más oscuro
                                                            //Se recorre para que queden solo 8 bits
                        byte byteDistancia = (byte)(255 - (valorDistancia >> 5));
                                                                          //Se asigna el mismo valor para que entre más cerca más iluminado entre más lejos más oscuro
                        colorImagenDistancia[posColorImagenDistancia++] = byteDistancia; //Azul
                        colorImagenDistancia[posColorImagenDistancia++] = byteDistancia; //Verde
                        colorImagenDistancia[posColorImagenDistancia++] = byteDistancia; //Rojo
                    }
                    posColorImagenDistancia++;//Transparante
                }


                //Mostramos el resultado de los pixeles coloreados
                if (bitmapImagenDistancia == null) {
                    this.bitmapImagenDistancia = new WriteableBitmap(
                        framesDistancia.Width,
                        framesDistancia.Height,
                        96,
                        96,
                        PixelFormats.Bgr32,
                        null);
                    DistanciaKinect.Source = bitmapImagenDistancia;
                }

                this.bitmapImagenDistancia.WritePixels(
                    new Int32Rect(0, 0, framesDistancia.Width, framesDistancia.Height),
                    colorImagenDistancia, //Datos de pixeles a color
                    framesDistancia.Width * 4,
                    0
                    );
            }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        }

    }
}
