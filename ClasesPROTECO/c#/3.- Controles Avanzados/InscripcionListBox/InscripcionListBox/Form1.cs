using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InscripcionListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            datosLsB.Items.Add(input.Text);
            input.Clear();
            // Enfoca para no dar de nuevo click en el EditText
            input.Focus();
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            if (datosLsB.SelectedIndex != -1)
                datosLsB.Items.RemoveAt(datosLsB.SelectedIndex);
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // GetNextControl busca al siguiente elemento a partir de uno
                // ActiveControl representa al elemento en el que estamos (EditText)
                // True para tomar el siguiente elemento hacia adelante
                // Focus selecciona al elemento encontrado
                this.GetNextControl(ActiveControl, true).Focus();
                // Suprimimos la tecla para evitar el sonido
                e.SuppressKeyPress = true;
            }


        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            datosLsB.Items.Clear();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string elemento = materias.SelectedItem.ToString();
            // Si el nuevo valor del campo marcado es "checked", 
            // añadimos esa materia a nuestro horario
            if (e.NewValue == CheckState.Checked)
            {
                horarioLsB.Items.Add(elemento);
            }
            else
            {
                // Remove quita elemento por su nombre, a diferencia de RemoveAt que elimina por Index
                horarioLsB.Items.Remove(elemento);
            }

        }

        private void generarBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documento de texto (.txt)| *.txt";
            if (sfd.ShowDialog() == DialogResult.OK) { 
                // StreamWriter ocupa System.IO
                using (StreamWriter writer = new StreamWriter(sfd.FileName)) {
                    writer.WriteLine("Comprobante de Inscripción.");
                    writer.WriteLine(" ");
                    writer.WriteLine("\tAlumno:");
                    writer.Write("\t");
                    foreach (var item in datosLsB.Items)
                    {
                        writer.Write(item.ToString() + " ");
                    }
                    writer.WriteLine("");
                    writer.WriteLine("Materias a inscribir:");
                    foreach (var item in horarioLsB.Items)
                    {
                        writer.WriteLine("\t"+item.ToString());
                    }
                }

                MessageBox.Show("Comprobante Generado!");
            }
        }



    }
}
