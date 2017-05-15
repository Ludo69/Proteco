using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JorgePadEjemplo
{
    public partial class Form1 : Form
    {
        string archivo = "";
        bool guardado = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void abrir(object sender, CancelEventArgs e)
        {
            string texto;
            archivo = openFileDialog1.FileName;

            texto = File.ReadAllText(archivo);
            textBox1.Text = texto;
            guardado = true;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void guardar(object sender, CancelEventArgs e)
        {
            string texto = textBox1.Text;
            archivo = saveFileDialog1.FileName;

            File.WriteAllText(archivo, texto);
            guardado = true;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(archivo))
            {
                guardarComoToolStripMenuItem_Click(this, EventArgs.Empty);
                
            }
            else
            {
                File.WriteAllText(archivo, textBox1.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (guardado)
            {
                guardado = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!guardado)
            {
                DialogResult dlg = MessageBox.Show("¿Guardar cambios en el archivo?", "Guardar archivo", MessageBoxButtons.YesNoCancel);
                switch(dlg){
                    case DialogResult.Yes:
                        guardarToolStripMenuItem_Click(this, EventArgs.Empty);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void formatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ventana = new Form2(textBox1.Font, textBox1.ForeColor, textBox1.BackColor);
            
            if (ventana.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = ventana.Fuente;
                textBox1.ForeColor = ventana.CTexto;
                textBox1.BackColor = ventana.CFondo;
                
            }
            
        }
    }
}
