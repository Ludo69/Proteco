using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimePicker
{
    public partial class Form1 : Form
    {

        DateTime fecha, hoy;
        double pagar;

        public Form1()
        {
            InitializeComponent();
            pagar = double.Parse(precioLbl.Text);
        }

        private void calendario_ValueChanged(object sender, EventArgs e)
        {
            fecha = calendario.Value;
            hoy = DateTime.Now;

            // TimeSpan sirve para hacer operaciones entre fechas, guarda una "fecha"
            TimeSpan diferencia = fecha - hoy;
            double costo = pagar;

            if (diferencia.Days > 1)
            {
                // Vamos a hacer descuento solo entre 3 y 30 días
                if (diferencia.Days >= 3 && diferencia.Days < 30)
                {
                    costo = pagar * Math.Pow(0.95, diferencia.Days);
                    totalLbl.Text = string.Format("Total: {0:C}", costo);
                }
                else
                {   
                    // if sin parentesis toma solo la primer linea de código siguiente
                    if (diferencia.Days == 2)
                        totalLbl.Text = string.Format("Total: {0:C}", pagar);
                    else          // Si es más de 30 días queda fijo el descuento
                        totalLbl.Text = string.Format("Total: {0:C}", pagar / 5);
                }

            }
            else
                MessageBox.Show("No se puede entregar en menos de dos días");

        }

        private void paginaLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Usa system.Diagnostics
            Process.Start("www.proteco.mx");
            (sender as LinkLabel).LinkVisited = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"C:\Users\Usuario\Documents\Visual Studio 2013\Projects\ClickMasRapido\ClickMasRapido\bin\Debug\ClickMasRapido.exe");
            (sender as LinkLabel).LinkVisited = true;
        }
    }
}
