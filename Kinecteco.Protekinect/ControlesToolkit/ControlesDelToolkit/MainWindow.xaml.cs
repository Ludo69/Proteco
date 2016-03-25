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
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

namespace ControlesDelToolkit
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// Código mejorado.
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensorChooser miKinect;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            miKinect = new KinectSensorChooser();
            miKinect.KinectChanged += miKinect_KinectChanged;   //Evento si el estado del Kinect cambia
            sensorChooserUI.KinectSensorChooser = miKinect;     //Propiedad que verifica el estado del Kinect en la parte gráfica
            miKinect.Start();
        }

                                                    //Clase que contiene propiedades para verificar elementos de conexión y desconexión del Kinect(OldSensor,NewSensor)
        void miKinect_KinectChanged(object sender, KinectChangedEventArgs e)
        {
            bool error = true;

            if (e.OldSensor == null)    //Verificando si se desconecto el Kinect
            {
                try
                {
                    //Deshabilitando Streams de profundidad y de esqueleto
                    e.OldSensor.DepthStream.Disable();  
                    e.OldSensor.SkeletonStream.Disable();
                }
                catch (Exception)
                {
                    error = true;
                }
            }

            if (e.NewSensor == null)
                return;

            try
            {
                //Habilitando Streams de profundidad y de esqueleto
                e.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                e.NewSensor.SkeletonStream.Enable();

                try
                {
                    e.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;  //Habilitando el modo Seated(sentado) para que el Kinect solo capte las articulaciones superiores
                    //Los modos Near son exclusivos del Kinect de Windows
                    e.NewSensor.DepthStream.Range = DepthRange.Near;                        //Habilitanto el modo Near (modo cerca)
                    e.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;            //Habilitando el modo Near del stream de esqueleto
                }
                catch (InvalidOperationException)   //Devuelve esta excepción cuando el Kinect es para xbox360 
                {
                    //Deshabilitando modos Near
                    e.NewSensor.DepthStream.Range = DepthRange.Default;
                    e.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                }
            }
            catch (InvalidOperationException)
            {
                error = true;
            }

            ZonaCursor.KinectSensor = e.NewSensor;  //Habilitr el cursor en la interfaz gráfica
        }
        //Evento que se llama cuando damos click en los botón salir
        private void KinectTileButton_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Evento que se llama cuando damos click en los botones que dicen presioname
        private void KinectCircleButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bien Hecho!");
        }
    }
}
