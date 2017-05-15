using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void graficarBtn_Click(object sender, EventArgs e)
        {
            // Limpiar la gráfica, limpiamos cada una de las series que tenga
            foreach (var serie in grafica.Series)
                serie.Points.Clear();

            // Clase para generar números aleatorios
            Random num = new Random();
            int random;

            // Recorrer el CheckedListBox
            for (int i = 0; i < materiasCLB.Items.Count; i++)
            {
                // Para cada materia genero un nuevo número aleatorio
                random = num.Next(1,100);
                // Ver si sus elementos estan checados
                if (materiasCLB.GetItemChecked(i))
                {
                    // Cadena para agregar el elemento a la gráfica
                    string str = materiasCLB.Items[i].ToString();

                    grafica.Series["Reprobados"].Points.AddXY(str,random);
                    grafica.Series["Aprobados"].Points.AddXY(str, 100 - random);
                }
            }

            /*
            grafica.Series["Reprobados"].Points.AddXY("Álgebra",33);
            grafica.Series["Aprobados"].Points.AddXY("Álgebra", 67);

            grafica.Series["Reprobados"].Points.AddXY("Cálculo", 43);
            grafica.Series["Aprobados"].Points.AddXY("Cálculo", 57);

            grafica.Series["Reprobados"].Points.AddXY("Dibujo", 10);
            grafica.Series["Aprobados"].Points.AddXY("Dibujo", 90);
             */
        }

        private void lineaRdB_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as RadioButton).Name.Equals("columnaRdB"))
                foreach (var item in grafica.Series)
                    item.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            else
                foreach (var item in grafica.Series)
                    item.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

        }


    }
}
