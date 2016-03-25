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

namespace practicaEsqueletoCompleto2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor miKinect;

        byte[] datosColor = null;
        WriteableBitmap colorImagenBitmap = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (KinectSensor.KinectSensors.Count == 0)
            {
                MessageBox.Show("No se detecta ningun kinect");
                Application.Current.Shutdown();
            }

            miKinect = KinectSensor.KinectSensors.FirstOrDefault();

            try
            {
                miKinect.SkeletonStream.Enable();//Habilitar flujo de datos de esqueletos
                miKinect.ColorStream.Enable();//Habilitar flujo de datos de la cámara RGB
                miKinect.Start();
            }
            catch
            {
                MessageBox.Show("La inicializacion del Kinect fallo");
                Application.Current.Shutdown();
            }

            miKinect.SkeletonFrameReady += miKinect_SkeletonFrameReady;
            miKinect.ColorFrameReady += miKinect_ColorFrameReady;
        }

        void miKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e){
//Captura de flujo de datos de la cámara RBG mediante Event Handler (controlador de eventos)
            using (ColorImageFrame framesColor = e.OpenColorImageFrame())
            {
                if (framesColor == null) return;

                if (datosColor == null)
                    datosColor = new byte[framesColor.PixelDataLength];

                framesColor.CopyPixelDataTo(datosColor);

                if (colorImagenBitmap == null)
                {
                    this.colorImagenBitmap = new WriteableBitmap(
                        framesColor.Width,  //Ancho y alto de nuestra imagen
                        framesColor.Height,
                        96, //DPI horizontales
                        96, //DPI verticales
                        PixelFormats.Bgr32, //Formato de los pixeles
                        null //paleta del bitmap
                        );
                }

                this.colorImagenBitmap.WritePixels(
                    new Int32Rect(0, 0, framesColor.Width, framesColor.Height),
                    datosColor, //Array que representa el contenido de la imagen
                    framesColor.Width * framesColor.BytesPerPixel, //producto del ancho
                    0  
                    );

                canvasEsqueleto.Background = new ImageBrush(colorImagenBitmap); //Asignando el flujo de la cámara RGB al atributo .Background del canvas
            }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }


        void miKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            canvasEsqueleto.Children.Clear();  //Borrar cualquier elemento que se encuentre en canvas, se encuentra afuera del Event Handler para borrar la linea creada antes de que la línea tenga nuevas coordenadas
            Skeleton[] esqueletos = null; //Array que almacenara los datos de esqueleto

//Captura de flujo de datos de esqueleto mediante Event Handler (controlador de eventos)
            using (SkeletonFrame frameEsqueleto = e.OpenSkeletonFrame())
            {
                if (frameEsqueleto != null)
                {
                    esqueletos = new Skeleton[frameEsqueleto.SkeletonArrayLength];
                    frameEsqueleto.CopySkeletonDataTo(esqueletos);
                }
            }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (esqueletos == null) return; //Verificación de seguridad por si el array esqueletos no contiene ningún valor

            //iterador esqueleto para iterar en el array esqueletos
            foreach (Skeleton esqueleto in esqueletos)
            {
                if (esqueleto.TrackingState == SkeletonTrackingState.Tracked)   //Si el esqueleto es detectado
                {
                    //Creamos todas las lineas que unen las articulaciones mediante la función agregarLinea pasando como parametro las dos articulaciones a unir

                    // Columna Vertebral
                    agregarLinea(esqueleto.Joints[JointType.Head], esqueleto.Joints[JointType.ShoulderCenter]);
                    agregarLinea(esqueleto.Joints[JointType.ShoulderCenter], esqueleto.Joints[JointType.Spine]);

                    // Pierna Izquierda
                    agregarLinea(esqueleto.Joints[JointType.Spine], esqueleto.Joints[JointType.HipCenter]);
                    agregarLinea(esqueleto.Joints[JointType.HipCenter], esqueleto.Joints[JointType.HipLeft]);
                    agregarLinea(esqueleto.Joints[JointType.HipLeft], esqueleto.Joints[JointType.KneeLeft]);
                    agregarLinea(esqueleto.Joints[JointType.KneeLeft], esqueleto.Joints[JointType.AnkleLeft]);
                    agregarLinea(esqueleto.Joints[JointType.AnkleLeft], esqueleto.Joints[JointType.FootLeft]);

                    // Pierna Derecha
                    agregarLinea(esqueleto.Joints[JointType.HipCenter], esqueleto.Joints[JointType.HipRight]);
                    agregarLinea(esqueleto.Joints[JointType.HipRight], esqueleto.Joints[JointType.KneeRight]);
                    agregarLinea(esqueleto.Joints[JointType.KneeRight], esqueleto.Joints[JointType.AnkleRight]);
                    agregarLinea(esqueleto.Joints[JointType.AnkleRight], esqueleto.Joints[JointType.FootRight]);

                    // Brazo Izquierda
                    agregarLinea(esqueleto.Joints[JointType.ShoulderCenter], esqueleto.Joints[JointType.ShoulderLeft]);
                    agregarLinea(esqueleto.Joints[JointType.ShoulderLeft], esqueleto.Joints[JointType.ElbowLeft]);
                    agregarLinea(esqueleto.Joints[JointType.ElbowLeft], esqueleto.Joints[JointType.WristLeft]);
                    agregarLinea(esqueleto.Joints[JointType.WristLeft], esqueleto.Joints[JointType.HandLeft]);

                    // Brazo Derecho
                    agregarLinea(esqueleto.Joints[JointType.ShoulderCenter], esqueleto.Joints[JointType.ShoulderRight]);
                    agregarLinea(esqueleto.Joints[JointType.ShoulderRight], esqueleto.Joints[JointType.ElbowRight]);
                    agregarLinea(esqueleto.Joints[JointType.ElbowRight], esqueleto.Joints[JointType.WristRight]);
                    agregarLinea(esqueleto.Joints[JointType.WristRight], esqueleto.Joints[JointType.HandRight]);
                }
            }
        }

        //Creamos una función que crea las lineas entre las articulaciones, recibe como parametros las dos articulasciones que deseas "unir" con una linea
                          //Creamos la variable j1 de tipo Joint(articulación) y le asignamos [JointType.AlgunaArticulación] que es un elemento de la propiedad Joint de la variable esqueleto
                                    //Creamos la variable j2 de tipo Joint(articulación) y le asignamos [JointType.AlgunaArticulación] que es un elemento de la propiedad Joint de la variable esqueleto
        void agregarLinea(Joint j1, Joint j2)
        {
            Line lineaHueso = new Line(); //Instanciamos el objeto huesoBrazoDer de la clase Line
            lineaHueso.Stroke = new SolidColorBrush(Colors.Green); //Accedemos a la propiedad Stroke para indicar el color de la línea
            lineaHueso.StrokeThickness = 5; //Accedemos a la propiedad StrokeThickness para indicar el ancho de la linea

                                                                                         //las coordenadas en tres dimensiones
                                                                                                      //Formato al cual queremos que se conviertan
            ColorImagePoint j1P = miKinect.CoordinateMapper.MapSkeletonPointToColorPoint(j1.Position, ColorImageFormat.RgbResolution640x480Fps30);//Mapeando las coordenadas de tres dimensiones de j1 a dos dimensiones con el método .MapSkeletonPointToColorPoint() para almacenarlas en j1P de tipo ColorImagePoint
            lineaHueso.X1 = j1P.X;//coordenada de origen x de la línea
            lineaHueso.Y1 = j1P.Y;//coordenada de origen y de la línea

                                                                                        //las coordenadas en tres dimensiones
                                                                                                      //Formato al cual queremos que se conviertan
            ColorImagePoint j2P = miKinect.CoordinateMapper.MapSkeletonPointToColorPoint(j2.Position, ColorImageFormat.RgbResolution640x480Fps30); //Mapeando las coordenadas de tres dimensiones de j2 a dos dimensiones con el método .MapSkeletonPointToColorPoint() para almacenarlas en j2P de tipo ColorImagePoint
            lineaHueso.X2 = j2P.X;//coordenada de destino x de la línea
            lineaHueso.Y2 = j2P.Y;//coordenada de destino y de la línea

            canvasEsqueleto.Children.Add(lineaHueso);//Agregando línea huesoBrazoDer al canvas
        }
    }
}
