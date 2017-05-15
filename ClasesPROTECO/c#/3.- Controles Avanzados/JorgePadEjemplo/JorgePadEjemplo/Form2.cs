using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JorgePadEjemplo
{
    public partial class Form2 : Form
    {
        private Font _fuente;
        public Font Fuente
        {
            get
            {
                return _fuente;
            }
            set
            {
                _fuente = value;
            }
        }
        private Color _ctexto;
        public Color CTexto
        {
            get
            {
                return _ctexto;
            }
            set
            {
                _ctexto = value;
            }
        }
        private Color _cfondo;
        public Color CFondo
        {
            get
            {
                return _cfondo;
            }
            set
            {
                _cfondo = value;
            }
        }
        public Form2(Font f, Color t, Color fon)
        {
            InitializeComponent();
            Fuente = f;
            CTexto = t;
            CFondo = fon;
        }

        private void cambiarColor(object sender, MouseEventArgs e)
        {
            label.Text = "Se acciona color";
            Color temp;
            switch (((Label)sender).Name)
            {
                case "blanco":
                    temp = Color.White;
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
                    temp = Color.Black;
                    break;
            }
            switch (e.Button)
            {
                case MouseButtons.Left:
                    CTexto = temp;
                    break;

                case MouseButtons.Right:
                    CFondo = temp;
                    break;
            }
        }

        private void negritas_CheckedChanged(object sender, EventArgs e)
        {
            Fuente = new Font(_fuente, _fuente.Style ^ FontStyle.Bold);
            label.Text = "Se acciona negritas";
        }

        private void cursivas_CheckedChanged(object sender, EventArgs e)
        {
            Fuente = new Font(_fuente, _fuente.Style ^ FontStyle.Italic);
            label.Text = "Se acciona cursivas";
        }

        private void Subrayado_CheckedChanged(object sender, EventArgs e)
        {
            Fuente = new Font(_fuente, _fuente.Style ^ FontStyle.Underline);
            label.Text = "Se acciona subrayado";
        }

        private void cambiarFuente(object sender, EventArgs e)
        {
            string nombre;
            label.Text = "Se acciona cambiar fuente";
            switch (((RadioButton)sender).Name)
            {
                case "courier":
                    nombre = "Courier";
                    break;
                case "comic":
                    nombre = "Comic Sans MS";
                    break;
                case "times":
                    nombre = "Times New Roman";
                    break;
                default:
                    nombre = "Lucida Console";
                    break;
            }
            Fuente = new Font(nombre,_fuente.Size,_fuente.Style);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Fuente = new Font(_fuente.FontFamily, (int)numericUpDown1.Value, _fuente.Style);
            label.Text = "Se acciona numero";
        }

    }
}
