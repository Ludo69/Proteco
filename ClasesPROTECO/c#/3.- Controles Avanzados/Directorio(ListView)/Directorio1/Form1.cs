using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorio1
{
    public partial class Form1 : Form
    {
        string dirActual;

        public Form1()
        {
            InitializeComponent();
            // Guarda el directorio en el que se situa .exe
            //dirActual = Directory.GetCurrentDirectory();
            dirActual = @"C:\";

            listView1.View = View.Details; // Muestra las columnas personalizadas

            // Añade las columnas 
            listView1.Columns.Add("Nombre", 200);
            listView1.Columns.Add("Tamaño", 100);
            listView1.Columns.Add("Fecha de Modificacion", 150);

            DirectoryInfo dir = new DirectoryInfo(dirActual);
            // Crea una lista de directorios existentes dentro del dirActual
            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (var d in dirs)
            {
                // Arreglo de valores nombre, tamaño y fecha de modificación
                string[] attr = new string[]{d.Name, "", d.LastWriteTime.ToShortDateString()};

                // Cada item LisvViewItem toma un arreglo de strings para mostrar
                ListViewItem item = new ListViewItem(attr);

                // La lista listView1.Items toma un arreglo
                // de objetos ListViewItem
                listView1.Items.Add(item);
            }

            label_dir.Text = dirActual;

        }

    }
}
