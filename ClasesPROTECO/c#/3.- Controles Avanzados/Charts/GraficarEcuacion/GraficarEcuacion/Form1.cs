using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraficarEcuacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void graficarBtn_Click(object sender, EventArgs e)
        {
            foreach (var serie in grafica.Series)
                serie.Points.Clear();

            double pres = 0, inicio = 0, fin = 0, a = 0, b = 0, c = 0;

            try
            {
                // El numeric Up Down tiene un decimal, 
                // tenemos que hacer un casting
                inicio = (double)inicioNUD.Value;
                fin = (double)finalNUD.Value;

                a = double.Parse(aTxB.Text);
                b = double.Parse(bTxB.Text);
                c = double.Parse(cTxB.Text);
                pres = double.Parse(presicion.Text);
            }
            catch (Exception) {
                MessageBox.Show("Error al ingresar datos");
            }

            // Recorremos de inicio a fin 
            // con un incremento del valor de la presición
            for (double x = inicio; x < fin; x += pres)
            {
                grafica.Series["Linea"].Points.AddXY(x,resolver(a,b,c,x));
            }

        }

        private double resolver(double a, double b, double c, double x) {
            double y;
            y = a * x * x + b * x + c;
            return y;
        }

    }
}
