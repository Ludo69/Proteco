using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadeDatos1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void vueloBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vueloBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.itinerarioDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itinerarioDataSet1.Vuelo' table. You can move, or remove it, as needed.
            this.vueloTableAdapter.Fill(this.itinerarioDataSet1.Vuelo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vueloBindingSource.MoveLast();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vueloBindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Busca el índice de la tupla cuya columna Origen contenga el valor de Buscar.Text
            // Regresa -1 si no hay coincidencia
            var indice = vueloBindingSource.Find("Origen", Buscar.Text);
            if (indice > -1)
            {
                vueloBindingSource.Position = indice;
            }
        }
    }
}
