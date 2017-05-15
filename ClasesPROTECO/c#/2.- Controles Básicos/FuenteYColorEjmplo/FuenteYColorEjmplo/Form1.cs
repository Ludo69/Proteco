using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuenteYColorEjmplo
{
    public partial class Form1 : Form
    {
        string textoF = "La fuente es: ";
        string textoC = "El color es: ";
        public Form1()
        {
            InitializeComponent();
            labelF.Text = textoF + label1.Font.Name;
            labelC.Text = textoC + label1.ForeColor.Name;
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                label1.Font = dlg.Font;
                labelF.Text = textoF + label1.Font.Name;
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                label1.ForeColor = dlg.Color;
                labelC.Text = textoC + label1.ForeColor.Name;
            }
        }
    }
}
