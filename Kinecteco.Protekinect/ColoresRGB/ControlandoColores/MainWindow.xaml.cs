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
using System.IO;

namespace ControlandoColores
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
            if (KinectSensor.KinectSensors.Count == 0)//Validación para ver si está conectado un Kinect
            {
                MessageBox.Show("No se ha detectado ningun Kinect", "Visor de Camara");
                Application.Current.Shutdown();
            }

            try
            {
                miKinect = KinectSensor.KinectSensors.FirstOrDefault();
                miKinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                miKinect.Start();
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al inicar Kinect", "Visor de Camara");
                Application.Current.Shutdown();
            }

            miKinect.ColorFrameReady += miKinect_ColorFrameReady;
        }

        //Array de colores tomado del kinect
        byte[] datosColor = null;
        WriteableBitmap bitmapEficiente = null;

        //Variables enteras que guardaran el valor del slieder
        int controlAzul = 0;
        int controlVerde = 0;
        int controlRojo = 0;
        int nuevoValor;

        void miKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame framesImagen = e.OpenColorImageFrame())
            {
                if (framesImagen == null) return;

                if (datosColor == null)
                    datosColor = new byte[framesImagen.PixelDataLength];

                framesImagen.CopyPixelDataTo(datosColor);


                for (int i = 0; i < datosColor.Length; i = i + 4)       //Se suma de cuatro para indicar que es el color azul e ignorar los demás
                {
                    nuevoValor = datosColor[i] + controlAzul;       //A los pixeles azules se les suma controlAzul que es el valor del slide azul.
                    //Cada color almacena 8 bits se pueden hacer 256 combinaciones diferentes. La intensidad de cada color va del 0 al 255 .
                    //Validaciones para manter la integridad de los pixeles azules que nunca sean menor a cero y nunca se pasen de 255.
                    if (nuevoValor < 0) nuevoValor = 0;
                    if (nuevoValor > 255) nuevoValor = 255;
                    datosColor[i] = (byte)nuevoValor;

                                 //datosColor[i + 1] son los pixeles verdes que recibe el Kinect
                    nuevoValor = datosColor[i + 1] + controlVerde;  //A los pixeles verdes se les suma controlVerde que es el valor del slide verde.
                    //Validaciones para manter la integridad de los pixeles verdes que nunca sean menor a cero y nunca se pasen de 255.
                    if (nuevoValor < 0) nuevoValor = 0;
                    if (nuevoValor > 255) nuevoValor = 255;
                    datosColor[i + 1] = (byte)nuevoValor;

                                 //datosColor[i + 2] son los pixeles rojos que recibe el Kinect
                    nuevoValor = datosColor[i + 2] + controlRojo;   //A los pixeles rojos se les suma controlRojo que es el valor del slide rojo.
                    //Validaciones para manter la integridad de los pixeles rojos que nunca sean menor a cero y nunca se pasen de 255.
                    if (nuevoValor < 0) nuevoValor = 0;
                    if (nuevoValor > 255) nuevoValor = 255;
                    datosColor[i + 2] = (byte)nuevoValor;
                }

                //Stream de video en pantalla
                if (grabarFoto)
                {
                    bitmapImagen = BitmapSource.Create(
                        framesImagen.Width, framesImagen.Height, 96, 96, PixelFormats.Bgr32, null,
                        datosColor, framesImagen.Width * framesImagen.BytesPerPixel);
                    grabarFoto = false;
                }

                if (bitmapEficiente == null)
                {
                    bitmapEficiente = new WriteableBitmap(
                        framesImagen.Width,
                        framesImagen.Height,
                        96,
                        96,
                        PixelFormats.Bgr32,
                        null);
                    colorStream.Source = bitmapEficiente;
                }

                bitmapEficiente.WritePixels(
                    new Int32Rect(0, 0, framesImagen.Width, framesImagen.Height),
                    datosColor,
                    framesImagen.Width * framesImagen.BytesPerPixel,
                    0
                    );

            }
        }

        //Tomar foto .jpg
        bool grabarFoto;
        BitmapSource bitmapImagen = null;

        private void tomarFoto_Click(object sender, RoutedEventArgs e)
        {
            grabarFoto = true;

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "capturaDeKinect";
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Pictures (.jpg)|*.jpg";

            if (dlg.ShowDialog() == true)
            {
                string nombreArchivo = dlg.FileName;
                using (FileStream stream = new FileStream(nombreArchivo, FileMode.Create))
                {
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImagen));
                    encoder.Save(stream);
                }
            }
        }

        //Eventos que se activan cuando se mueve el slide (Max: 255, Min: -255)
        private void sliderAzul_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controlAzul = (int)sliderAzul.Value;
        }

        private void sliderVerde_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controlVerde = (int)sliderVerde.Value;
        }
        private void sliderRojo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            controlRojo = (int)sliderRojo.Value;
        }

    }
}
