using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        bool pintando = false;

        //Colores
        Color colorPincel = Color.Black;
        Color colorFondo = Color.White;
        Color colorVar = Color.White;

        int size = 5;
        int estilo = 1; // estilo : 1-redondo, 2: cuadrado

        //Encapsula una superficie de dibujo
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = panelDibujo.CreateGraphics(); // Nombre del panel para dibujar en él
            colorVarOpc.BackColor = colorVar;
            panelDibujo.BackColor = colorFondo;
            labelSize.Text = size.ToString();
        }

        private void botonesTamano(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "buttonMas")
            {
                if (size < 50) 
                    size += 5; // Limite máximo en tamaño
            }
            else
            {
                if (size > 5) 
                    size -= 5; // Limite mínimo en tamaño
            }
            labelSize.Text = size.ToString();

        }

        private void cambiarFigura(object sender, EventArgs e)
        {
            estilo = (((RadioButton)sender).Name == "radioButtonCirculo") ? 1 : 2;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog paleta = new ColorDialog();
            paleta.ShowDialog(); // ShowDialog hace visible la ventana
            colorPincel = paleta.Color;
            colorVar = colorPincel;
            colorVarOpc.BackColor = colorVar;
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            g.Clear(colorFondo);
        }

        private void empezarPintar(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Detecta si se presionó el botón izquierdo del mouse
            {
                pintando = true; // Detecta que presionamos el mouse para dibujar
            }
        }

        private void dejarPintar(object sender, MouseEventArgs e)
        {
            pintando = false;
        }

        private void pintar(object sender, MouseEventArgs e)
        {
            if (!pintando) { return; } // Si no estoy pintando, me salgo de la función

            switch (estilo)
            {
                case 1:
                    g.FillEllipse(new SolidBrush(colorPincel), e.X, e.Y, size, size); // Dibuja una elipse
                    break;
                // SolidBrush crea un pincel de linea continua (solida) con el color indicado
                // param FillEllipse: Tipo de pincel, pos horiz, pos vert, ancho, alto

                case 2:
                    g.FillRectangle(new SolidBrush(colorPincel), e.X, e.Y, size, size); // Dibuja un cuadrado
                    // Mismos parámetros que FillEllipse
                    break;
            }
        }

        private void cambiarColor(object sender, MouseEventArgs e)
        {
            Color temp;
            switch (((Label)sender).Name)
            {
                case "blanco":
                    temp = Color.White;
                    break;
                case "negro":
                    temp = Color.Black;
                    break;
                case "rojo":
                    temp = Color.Red;
                    break;
                case "amarillo":
                    temp = Color.Yellow;
                    break;
                case "azul":
                    temp = Color.Blue;
                    break;
                default:
                    temp = colorVar;
                    break;
            }
            switch (e.Button)
            {
                case MouseButtons.Left:
                    colorPincel = temp;
                    break;

                case MouseButtons.Right:
                    colorFondo = temp;
                    panelDibujo.BackColor = colorFondo;
                    break;
            }
        }
    }
}
