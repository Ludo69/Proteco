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

namespace PowerPointKinect
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor miKinect;

        WriteableBitmap bitmapImagenColor = null;
        byte[] bytesColor;

        Skeleton[] esqueleto = null;

        bool movimientoAdelanteActivo = false;
        bool movimientoAtrasActivo = false;

        SolidColorBrush brushActivo = new SolidColorBrush(Colors.Green);
        SolidColorBrush brushInactivo = new SolidColorBrush(Colors.Red);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            miKinect = KinectSensor.KinectSensors.FirstOrDefault();
            if (miKinect == null)
            {
                MessageBox.Show("Esta aplicasion requiere de un sensor de kinect.");
                Application.Current.Shutdown();
            }

            miKinect.Start();
            miKinect.ColorStream.Enable();
            miKinect.SkeletonStream.Enable();

            miKinect.ColorFrameReady += miKinect_ColorFrameReady;
            miKinect.SkeletonFrameReady += miKinect_SkeletonFrameReady;
            Application.Current.Exit += Current_Exit;
        }

        void Current_Exit(object sender, ExitEventArgs e)
        {
            if (miKinect != null) {
                miKinect.Stop();
                miKinect = null;
            }
        }

        //Capturando flujo de esqueleto
        void miKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    esqueleto = new Skeleton[frame.SkeletonArrayLength];
                    frame.CopySkeletonDataTo(esqueleto);
                }
            }

            if (esqueleto == null) return;
            //Capturar el flujo de datos de esqueleto de una manera más eficiente que el foreach
            Skeleton esqueletoCercano = esqueleto.Where(s => s.TrackingState == SkeletonTrackingState.Tracked)
                                                 .OrderBy(s => s.Position.Z * Math.Abs(s.Position.X))
                                                 .FirstOrDefault();

            if (esqueletoCercano == null) return;

            //Se puede declarar una variable tipo var cuando no estas seguro del tipo
            var cabeza = esqueletoCercano.Joints[JointType.Head];
            var manoDer = esqueletoCercano.Joints[JointType.HandRight];
            var manoIzq = esqueletoCercano.Joints[JointType.HandLeft];

            if (cabeza.TrackingState == JointTrackingState.NotTracked ||
                manoDer.TrackingState == JointTrackingState.NotTracked ||
                manoIzq.TrackingState == JointTrackingState.NotTracked) 
            {
                    return;
            }
            
            //Función que se encarga de crear una elipse en las articulaciones cabeza, manoIzquierda y manoDerecha
            posicionEllipse(ellipseCabeza, cabeza, false);
            posicionEllipse(ellipseManoIzq, manoIzq, movimientoAtrasActivo);
            posicionEllipse(ellipseManoDer, manoDer, movimientoAdelanteActivo);

            //Función que se encarga de activar la flecha derecha o izquierda
            procesoAdelanteAtras(cabeza, manoDer, manoIzq);
        }

        private void procesoAdelanteAtras(Joint cabeza, Joint manoDer, Joint manoIzq)
        {
           //Validación de movimiento con la mano derecha
            if (manoDer.Position.X > cabeza.Position.X + 0.45) {
                if (!movimientoAdelanteActivo)
                {
                    movimientoAdelanteActivo = true;
                    System.Windows.Forms.SendKeys.SendWait("{Right}");//Activa la tecla flecha derecha
                }
            }
            else
            {
                movimientoAdelanteActivo = false;
            }
            //Validación de movimiento con la mano izquierda
            if (manoIzq.Position.X < cabeza.Position.X - 0.45)
            {
                if (!movimientoAtrasActivo)
                {
                    movimientoAtrasActivo = true;       
                    System.Windows.Forms.SendKeys.SendWait("{Left}");//Activa la tecla flecha izquierda
                }
            }
            else
            {
                movimientoAtrasActivo = false;
            }
        }

        private void posicionEllipse(Ellipse ellipse, Joint joint, bool activo)
        {
            //Cuando alguna articulación mano esta en la posición correcta se colorea de verde y se hace más grande el elipse cuando no está de color rojo
            if (activo)
            {
                ellipse.Width = 60;
                ellipse.Height = 60;
                ellipse.Fill = brushActivo;
            }
            else
            {
                ellipse.Width = 20;
                ellipse.Height = 20;
                ellipse.Fill = brushInactivo;
            }

            CoordinateMapper mapping = miKinect.CoordinateMapper;   

            var point = mapping.MapSkeletonPointToColorPoint(joint.Position, miKinect.ColorStream.Format);  //Mapea las coordenadas de la articulación en tres dimensiones a dos dimensiones
                                    //Formula para hacer más efectivo el ratreo de las articulaciones
            Canvas.SetLeft(ellipse, point.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, point.Y - ellipse.Height / 2);
        }

        //Flujo de cámara RGB
        void miKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame imagenColor = e.OpenColorImageFrame())
            {
                if (imagenColor == null)
                    return;

                if (bytesColor == null || bytesColor.Length != imagenColor.PixelDataLength)
                    bytesColor = new byte[imagenColor.PixelDataLength];

                imagenColor.CopyPixelDataTo(bytesColor);

                if (bitmapImagenColor == null)
                {
                    bitmapImagenColor = new WriteableBitmap(
                        imagenColor.Width,
                        imagenColor.Height,
                        96,
                        96,
                        PixelFormats.Bgr32,
                        null);
                }

                bitmapImagenColor.WritePixels(
                    new Int32Rect(0, 0, imagenColor.Width, imagenColor.Height),
                    bytesColor,
                    imagenColor.Width * imagenColor.BytesPerPixel,
                    0);

                imagenVideo.Source = bitmapImagenColor;
            }
        }
    }
}
