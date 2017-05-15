using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ComprasCheckBox
{
    public partial class Form1 : Form
    {

        public double Cuenta { get; set; }

        double flag = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void carrito(object sender, EventArgs e)
        {
            calcula();
        }

        private void hacerDescuento(object sender, EventArgs e)
        {
            RadioButton eleccion = sender as RadioButton;
            if (eleccion.Name.ToString() == "martesRbt")
            {
                flag = 0.85;
            }
            else
            {
                if (eleccion.Name.ToString() == "unamRbt")
                {
                    flag = 0.90;
                }else{
                    flag = 1;
                }
            }
            totalLbl.Text = String.Format("{0:C}", Cuenta*flag);
        }

        private void validarPrecio(object sender, EventArgs e)
        {
            calcula();
        }

        private void calcula() {
            try
            {
                Cuenta = 0;
                int stado = 0;


                if (stado == 0 && checkBoxTodo.Checked == true)
                {
                    manzanaCkb.Checked = checkBoxTodo.Checked;
                    mangoCkb.Checked = checkBoxTodo.Checked;
                    peraCkb.Checked = checkBoxTodo.Checked;
                    naranjaCkb.Checked = checkBoxTodo.Checked;
                    stado = 1;
                    totalLbl.Text = String.Format("{0:C}", stado * flag);
                }
                if (stado == 1 && !checkBoxTodo.Checked) 
                {

                    manzanaCkb.Checked = false;
                    mangoCkb.Checked = false;
                    peraCkb.Checked = false;
                    naranjaCkb.Checked = false;
                    stado = 2;
                    totalLbl.Text = String.Format("{0:C}", stado* flag);
                
                }


               /* if (TodoA.Checked == TodoA.Checked)
                {
                    manzanaCkb.Checked = TodoA.Checked;
                    peraCkb.Checked = TodoA.Checked;

                }

                if (TodoB.Checked == TodoB.Checked)
                {
                    mangoCkb.Checked = TodoB.Checked;
                    naranjaCkb.Checked = TodoB.Checked;
                }*/
            }
            catch (Exception e) {
                totalLbl.Text = " Error en ingresar datos";
            }
        }

  

        private void totalLbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }







    }
}
