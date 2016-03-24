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

namespace CamaraWeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor miKinect;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            miKinect = KinectSensor.KinectSensors.FirstOrDefault();
            miKinect.Start();
            miKinect.ColorStream.Enable();
            miKinect.ColorFrameReady += MiKinect_ColorFrameReady;
        }

        void MiKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame frameImagen = e.OpenColorImageFrame()) {
                if (frameImagen == null) return;

                byte[] datosColor = new byte[frameImagen.PixelDataLength];

                frameImagen.CopyPixelDataTo(datosColor);

                mostrarVideo.Source = BitmapSource.Create(
                    frameImagen.Width, frameImagen.Height, //Ancho y alto de nuestra imagen
                    96, //DPI horizontales
                    96, //DPI verticales
                    PixelFormats.Bgr32, //Formato de los pixeles
                    null, //paleta del bitmap
                    datosColor, //Array que representa el contenido de la imagen
                    frameImagen.Width * frameImagen.BytesPerPixel //producto del ancho
                    );
            }
        }
    }
}
