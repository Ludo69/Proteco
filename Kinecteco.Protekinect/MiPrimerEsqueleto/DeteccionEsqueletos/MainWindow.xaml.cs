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

namespace DeteccionEsqueletos
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
            if (KinectSensor.KinectSensors.Count == 0) {
                MessageBox.Show("Ningun kinect detectado", "Visor de Posicion de Articulasion");
                Application.Current.Shutdown();
                return;
            }

            miKinect = KinectSensor.KinectSensors.FirstOrDefault();

            try
            {
                miKinect.SkeletonStream.Enable();//Habilitar flujo de datos de esqueletos
                miKinect.Start();
            }
            catch {
                MessageBox.Show("Fallo en la Iniciacion de Kinect", "Visor de Posicion de Articulasion");
                Application.Current.Shutdown();
            }

            miKinect.SkeletonFrameReady += miKinect_SkeletonFrameReady;
        }

        void miKinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            string mensaje = "No hay datos de esqueleto";   //Mensaje que se mostarará en el primer textblock (textBlockEstatus) cuando no se detecta nada
            string mensajeCaptura = "";                     //Variable que almacena los datos de la calidad de captura del esqueleto, indicandonos hacia donde hay que moverse para que el kinect tenga una buena captura
            Skeleton[] esqueletos = null;                   //Array que almacenara los datos de esqueleto

//Captura de flujo de datos mediante Event Handler (controlador de eventos)
            using (SkeletonFrame framesEsqueleto = e.OpenSkeletonFrame()){//Le indicamos que empiece a darnos frames de esqueletos y los almacene en el objeto e.OpenSkeletonFrame
                if (framesEsqueleto != null) { 
                    esqueletos = new Skeleton[framesEsqueleto.SkeletonArrayLength];     //Instanciamos esqueletos del tamaño de frameEsqueleto
                    framesEsqueleto.CopySkeletonDataTo(esqueletos); //Copiar los datos capturados al array creado
                }
            }
//Cerramos el using porque ya almacenamos lo que obtuvimos de framesEsqueleto(el cual dejamos que se elimine) en el array esqueleto
//------------------------------------------------------------------------------------------------------------------------------------

            if (esqueletos == null) return; //Verificación de seguridad por si el array esqueletos no contiene ningún valor

                          //iterador esqueleto para iterar en el array esqueletos
            foreach(Skeleton esqueleto in esqueletos){
                if (esqueleto.TrackingState == SkeletonTrackingState.Tracked) {//Si el esqueleto es detectado

                    if (esqueleto.ClippedEdges == 0)
                    {
                        mensajeCaptura = "Colocado Perfectamente";             //Si  ClippedEdges es igual a cero es que está bien colocado
                    }
                    //ClippedEdges se encarga de validar si todas las articulaciones están capturadas correctamente
                    /*public enum FrameEdges{
                        None = 0,               //Si  ClippedEdges es igual a cero es que está bien colocado
                        Rigth = 1,              //Si  ClippedEdges es igual a uno está muy a la derecha
                        Left = 2,               //Si  ClippedEdges es igual a uno está muy a la izquierda
                        Top = 4,                //Si  ClippedEdges es igual a uno está muy arriba
                        Bottom = 8,             //Si  ClippedEdges es igual a uno está muy abajo
                    }                           //También se pueden hacer combinaciones de las anteriores
                    */
                    else {  
                    //Validaciones que comprueban si el esqueleto está siendo correctamente capturado si no está correctamente capturado te indica hacia donde debes moverte
                                                        //8
                        if ((esqueleto.ClippedEdges & FrameEdges.Bottom) != 0)
                            mensajeCaptura += "Moverse arriba";
                                                        //4
                        if ((esqueleto.ClippedEdges & FrameEdges.Top) != 0)
                            mensajeCaptura += "Moverse abajo";
                                                        //1
                        if ((esqueleto.ClippedEdges & FrameEdges.Right) != 0)
                            mensajeCaptura += "Moverse a la izquierda";
                                                        //2
                        if ((esqueleto.ClippedEdges & FrameEdges.Left) != 0)
                            mensajeCaptura += "Moverse a la derecha";
                    }

                    Joint jointCabeza = esqueleto.Joints[JointType.Head];  //Creamos la variable jointCabeza de tipo Joint(articulación) y le asignamos [JointType.Head] que es un elemento de la propiedad Joint de la variable esqueleto
                    SkeletonPoint posicionCabeza = jointCabeza.Position;   //Creamos la variable posicionCabeza de tipo SketonPoint (guarda las posiciones 3D de una articulación) y le asignamos la el atributo Position de la variable tipo articuación jointCabeza

                    //Convierte el valor de los objetos en cadenas en función de los formatos especificados y los inserta en otra cadena.                   
                                                     //{0:0.0}    {la primera variable indicada posicionCabeza.X:el formato de impresión un digito antes del cero y uno después del cero}
                                                                //{1:0.0}    {la segunda variable indicada posicionCabeza.Y:el formato de impresión un digito antes del cero y uno después del cero}
                                                                         //{2:0.0}    {la primera tercera indicada posicionCabeza.Z:el formato de impresión un digito antes del cero y uno después del cero}
                    mensaje = string.Format("Cabeza: X:{0:0.0} Y:{1:0.0} Z:{2:0.0}", posicionCabeza.X, posicionCabeza.Y, posicionCabeza.Z);
                }
            }
            textBlockEstatus.Text = mensaje;        //Se asigna la variable tipo string mensaje a la propiedad Text del primer textBlock la cual mostrará la posición de la cabeza
            textBlockCaptura.Text = mensajeCaptura; //Se asigna la variable tipo string mensajeCaptura a la propiedad Text del segundo textBlock la cual mostrará el estatus de captura de la articulación cabeza
        }

    }
}
