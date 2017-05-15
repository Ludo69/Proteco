using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcu
{
    public partial class Form1 : Form
    {
        bool empezando;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            empezando = true;
        }

        public void agregar(char ar)
        {
            if (empezando)
            {
                textBox1.Text = "";
                empezando = false;
            }
            textBox1.Text = textBox1.Text + ar;
        }

        private void buttonE_Click(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            agregar('0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregar('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregar('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            agregar('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            agregar('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            agregar('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            agregar('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            agregar('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            agregar('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            agregar('9');
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            empezando = true;
        }

        private void buttonS_Click(object sender, EventArgs e)
        {

        }

        private void buttonR_Click(object sender, EventArgs e)
        {

        }

        private void buttonM_Click(object sender, EventArgs e)
        {

        }

        private void buttonD_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            agregar('.');
        }
    }
}
