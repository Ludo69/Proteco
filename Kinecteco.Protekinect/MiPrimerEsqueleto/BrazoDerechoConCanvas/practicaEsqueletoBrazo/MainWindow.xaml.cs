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

namespace practicaEsqueletoBrazo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor miKinect;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (KinectSensor.KinectSensors.Count == 0)
            {
                MessageBox.Show("No se detecta ningun kinect", "Visor de Camara");
                Application.Current.Shutdown();
            }

            miKinect = KinectSensor.KinectSensors.FirstOrDefault();

            try
            {
                miKinect.SkeletonStream.Enable();       //Habilitar flujo de datos de esqueletos
                miKinect.Start();
            }
            catch
            {
                MessageBox.Show("La inicializacion del Kinect fallo", "Visor de camara");
                Application.Current.Shutdown();
            }

            miKinect.SkeletonFrameReady += miKinect_SkeletonFrameReady;
        }

        private void miKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            canvasesqueleto.Children.Clear();                       //Borrar cualquier elemento que se encuentre en canvas, se encuentra afuera del Event Handler para borrar la linea creada antes de que la línea tenga nuevas coordenadas
            Skeleton[] esqueletos = null;                           //Array que almacenara los datos de esqueleto

//Captura de flujo de datos mediante Event Handler (controlador de eventos)
            using (SkeletonFrame frameEsqueleto = e.OpenSkeletonFrame()) {//Le indicamos que empiece a darnos frames de esqueletos y los almacene en el objeto e.OpenSkeletonFrame
                if (frameEsqueleto != null) {
                    esqueletos = new Skeleton[frameEsqueleto.SkeletonArrayLength];  //Instanciamos esqueletos del tamaño de frameEsqueleto
                    frameEsqueleto.CopySkeletonDataTo(esqueletos);//Copiar los datos capturados al array creado
                }
            }
//Cerramos el using porque ya almacenamos lo que obtuvimos de framesEsqueleto(el cual dejamos que se elimine) en el array esqueleto
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            if (esqueletos == null) return;//Verificación de seguridad por si el array esqueletos no contiene ningún valor

            //iterador esqueleto para iterar en el array esqueletos
            foreach (Skeleton esqueleto in esqueletos) {
                if (esqueleto.TrackingState == SkeletonTrackingState.Tracked) { //Si el esqueleto es detectado
                    Joint handJoint = esqueleto.Joints[JointType.HandRight];    //Creamos la variable handJoint de tipo Joint(articulación) y le asignamos [JointType.HandRight] que es un elemento de la propiedad Joint de la variable esqueleto
                    Joint elbowJoint = esqueleto.Joints[JointType.ElbowRight];  //Creamos la variable elbowJoint de tipo Joint(articulación) y le asignamos [JointType.ElbowRight] que es un elemento de la propiedad Joint de la variable esqueleto

                    Line huesoBrazoDer = new Line();    //Instanciamos el objeto huesoBrazoDer de la clase Line
                    huesoBrazoDer.Stroke = new SolidColorBrush(Colors.Green);   //Accedemos a la propiedad Stroke para indicar el color de la línea
                    huesoBrazoDer.StrokeThickness = 8;  //Accedemos a la propiedad StrokeThickness para indicar el ancho de la linea

                                                                                                       //las coordenadas en tres dimensiones
                                                                                                                           //Formato al cual queremos que se conviertan
                    ColorImagePoint puntoMano = miKinect.CoordinateMapper.MapSkeletonPointToColorPoint(handJoint.Position, ColorImageFormat.RgbResolution640x480Fps30); //Mapeando las coordenadas de tres dimensiones de handJoint a dos dimensiones con el método .MapSkeletonPointToColorPoint() para almacenarlas en puntoMano de tipo ColorImagePoint
                    huesoBrazoDer.X1 = puntoMano.X; //coordenada de origen x de la línea
                    huesoBrazoDer.Y1 = puntoMano.Y; //coordenada de origen y de la línea
                                                                                                       //las coordenadas en tres dimensiones
                                                                                                                            //Formato al cual queremos que se conviertan
                    ColorImagePoint puntoCodo = miKinect.CoordinateMapper.MapSkeletonPointToColorPoint(elbowJoint.Position, ColorImageFormat.RgbResolution640x480Fps30); //Mapeando las coordenadas de tres dimensiones de elbowJoint a dos dimensiones con el método .MapSkeletonPointToColorPoint() para almacenarlas en puntoCodo de tipo ColorImagePoint
                    huesoBrazoDer.X2 = puntoCodo.X; //coordenada de destino x de la línea
                    huesoBrazoDer.Y2 = puntoCodo.Y; //coordenada de destino y de la línea

                    canvasesqueleto.Children.Add(huesoBrazoDer);    //Agregando línea huesoBrazoDer al canvas
                }
            }
        }
    }
}
