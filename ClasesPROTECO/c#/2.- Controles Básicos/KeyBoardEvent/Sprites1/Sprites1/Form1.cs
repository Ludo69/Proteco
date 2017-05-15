using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprites1
{
    public partial class FormEscenario : Form
    {

        private Keys direccion;
        private Image imgA = Sprites1.Properties.Resources.link1;
        private Image imgB = Sprites1.Properties.Resources.link2;
        private bool usandoImgA = true;
        private bool caminando = false;

        public FormEscenario()
        {
            InitializeComponent();
        }

        private void Form1Escenario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                // KeyCode: enumeración que contiene los códigos de las teclas
                direccion = e.KeyCode;

                // Bandera que indica el inicio de caminar
                caminando = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (caminando)
            {
                switch (direccion)
                {
                    case Keys.Down:
                        // Actualiza las imágenes temporales
                        // según la dirección
                        imgA = Sprites1.Properties.Resources.link1;
                        imgB = Sprites1.Properties.Resources.link2;

                        // Restricción sobre los pixeles 
                        if (Link.Location.Y < (410 - Link.Size.Height))
                            // Para mover se sobreescribe Location
                            // creando una nueva estructura Point
                            Link.Location = new Point(Link.Location.X, Link.Location.Y + 10);
                        break;
                    case Keys.Left:
                        imgA = Sprites1.Properties.Resources.link3;
                        imgB = Sprites1.Properties.Resources.link4;
                        if(Link.Location.X>60)
                            Link.Location = new Point(Link.Location.X - 10, Link.Location.Y);
                        break;
                    case Keys.Right:
                        imgA = Sprites1.Properties.Resources.link5;
                        imgB = Sprites1.Properties.Resources.link6;
                        if (Link.Location.X < (440 - Link.Size.Width))
                            Link.Location = new Point(Link.Location.X + 10, Link.Location.Y);
                        break;
                    case Keys.Up:
                        imgA = Sprites1.Properties.Resources.link7;
                        imgB = Sprites1.Properties.Resources.link8;
                        if(Link.Location.Y>70)
                            Link.Location = new Point(Link.Location.X, Link.Location.Y - 10);
                        break;
                }

                // Alterna las imágenes imgA e imgB
                if (usandoImgA)
                {
                    Link.Image = imgB;
                    usandoImgA = false;
                }
                else
                {
                    Link.Image = imgA;
                    usandoImgA = true;
                }
            }
        }

        private void FormEscenario_KeyUp(object sender, KeyEventArgs e)
        {
            // bandera que indice que se terminó de caminar
            // (soltar la tecla)
            caminando = false;
        }
    }
}
