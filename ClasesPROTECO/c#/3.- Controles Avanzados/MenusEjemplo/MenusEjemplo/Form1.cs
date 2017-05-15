using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MenusEjemplo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.ForeColor = Color.Black;
            label1.Font = new Font("Times New Roman",20);
        }

        public void clearColor()
        {
            negroToolStripMenuItem.Checked = false;
            azulToolStripMenuItem.Checked = false;
            verdeToolStripMenuItem.Checked = false;
        }

        public void clearFont()
        {
            timesNewRomanToolStripMenuItem.Checked = false;
            courierToolStripMenuItem.Checked = false;
            comicSansMSToolStripMenuItem.Checked = false;
        }

        private void cambiarTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = Interaction.InputBox("Ingresa una cadena", "Cambiar Texto");
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fue hecho por Jorge :3");

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void negroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearColor();
            label1.ForeColor = Color.Black;
            negroToolStripMenuItem.Checked = true;
        }

        private void azulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearColor();
            label1.ForeColor = Color.Blue;
            azulToolStripMenuItem.Checked = true;
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearColor();
            label1.ForeColor = Color.Green;
            verdeToolStripMenuItem.Checked = true;
        }

        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearFont();
            label1.Font = new Font("Times New Roman", 20, label1.Font.Style);
            timesNewRomanToolStripMenuItem.Checked = true;
        }

        private void comicSansMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearFont();
            label1.Font = new Font("Comic Sans MS", 20, label1.Font.Style);
            comicSansMSToolStripMenuItem.Checked = true;
        }

        private void courierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearFont();
            label1.Font = new Font("Courier", 20, label1.Font.Style);
            courierToolStripMenuItem.Checked = true;
        }
        private void cursivasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cursivasToolStripMenuItem.Checked = !cursivasToolStripMenuItem.Checked;
            label1.Font = new Font(label1.Font,
                label1.Font.Style ^ FontStyle.Italic //Operador XOR, es un operador lógico
                );
        }

        private void negritasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            negritasToolStripMenuItem.Checked = !negritasToolStripMenuItem.Checked;
            label1.Font = new Font(label1.Font, 
                label1.Font.Style ^ FontStyle.Bold //Operador XOR, es un operador lógico
                );
        }
    }
}
