using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {

        public string usuario = "Vadik";
        public string password = "hola123";

        public Form1()
        {
            InitializeComponent();
        }

        private void inputBtn_Click(object sender, EventArgs e)
        {
            string user = usuarioTxb.Text;
            string pass = passTxb.Text;

            if (user.Equals(usuario) && pass.Equals(password))
            {
                MessageBox.Show("Acceso correcto");
            }
            else {
                MessageBox.Show("Ususario o contraseña incorrectos");
            }

        }
    }
}
