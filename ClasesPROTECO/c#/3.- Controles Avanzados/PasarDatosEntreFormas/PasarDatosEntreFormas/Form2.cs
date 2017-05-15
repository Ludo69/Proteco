using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasarDatosEntreFormas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
        }
        public Form2(string title, string txt)
        {
            InitializeComponent();
            this.Text = title;
            label1.Text = txt;
        }
    }
}
