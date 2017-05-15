namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonMas = new System.Windows.Forms.Button();
            this.buttonMenos = new System.Windows.Forms.Button();
            this.labelSize = new System.Windows.Forms.Label();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonCuadrado = new System.Windows.Forms.RadioButton();
            this.radioButtonCirculo = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonColor = new System.Windows.Forms.Button();
            this.blanco = new System.Windows.Forms.Label();
            this.negro = new System.Windows.Forms.Label();
            this.colorVarOpc = new System.Windows.Forms.Label();
            this.azul = new System.Windows.Forms.Label();
            this.amarillo = new System.Windows.Forms.Label();
            this.rojo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDibujo
            // 
            this.panelDibujo.BackColor = System.Drawing.Color.White;
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDibujo.Location = new System.Drawing.Point(13, 13);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(379, 331);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.empezarPintar);
            this.panelDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pintar);
            this.panelDibujo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dejarPintar);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.labelSize);
            this.groupBox1.Controls.Add(this.buttonMenos);
            this.groupBox1.Controls.Add(this.buttonMas);
            this.groupBox1.Location = new System.Drawing.Point(400, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tamaño";
            // 
            // buttonMas
            // 
            this.buttonMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMas.Location = new System.Drawing.Point(7, 20);
            this.buttonMas.Name = "buttonMas";
            this.buttonMas.Size = new System.Drawing.Size(34, 31);
            this.buttonMas.TabIndex = 0;
            this.buttonMas.Text = "+";
            this.buttonMas.UseVisualStyleBackColor = true;
            this.buttonMas.Click += new System.EventHandler(this.botonesTamano);
            // 
            // buttonMenos
            // 
            this.buttonMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenos.Location = new System.Drawing.Point(7, 57);
            this.buttonMenos.Name = "buttonMenos";
            this.buttonMenos.Size = new System.Drawing.Size(34, 31);
            this.buttonMenos.TabIndex = 1;
            this.buttonMenos.Text = "-";
            this.buttonMenos.UseVisualStyleBackColor = true;
            this.buttonMenos.Click += new System.EventHandler(this.botonesTamano);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSize.Location = new System.Drawing.Point(49, 35);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(0, 31);
            this.labelSize.TabIndex = 2;
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Location = new System.Drawing.Point(400, 318);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(101, 28);
            this.buttonBorrar.TabIndex = 2;
            this.buttonBorrar.Text = "Borrar Todo";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.radioButtonCirculo);
            this.groupBox2.Controls.Add(this.radioButtonCuadrado);
            this.groupBox2.Location = new System.Drawing.Point(400, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 72);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Figura";
            // 
            // radioButtonCuadrado
            // 
            this.radioButtonCuadrado.AutoSize = true;
            this.radioButtonCuadrado.Location = new System.Drawing.Point(6, 42);
            this.radioButtonCuadrado.Name = "radioButtonCuadrado";
            this.radioButtonCuadrado.Size = new System.Drawing.Size(71, 17);
            this.radioButtonCuadrado.TabIndex = 0;
            this.radioButtonCuadrado.Text = "Cuadrado";
            this.radioButtonCuadrado.UseVisualStyleBackColor = true;
            this.radioButtonCuadrado.Click += new System.EventHandler(this.cambiarFigura);
            // 
            // radioButtonCirculo
            // 
            this.radioButtonCirculo.AutoSize = true;
            this.radioButtonCirculo.Checked = true;
            this.radioButtonCirculo.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCirculo.Name = "radioButtonCirculo";
            this.radioButtonCirculo.Size = new System.Drawing.Size(59, 17);
            this.radioButtonCirculo.TabIndex = 1;
            this.radioButtonCirculo.TabStop = true;
            this.radioButtonCirculo.Text = "Círculo";
            this.radioButtonCirculo.UseVisualStyleBackColor = true;
            this.radioButtonCirculo.Click += new System.EventHandler(this.cambiarFigura);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.azul);
            this.groupBox3.Controls.Add(this.amarillo);
            this.groupBox3.Controls.Add(this.rojo);
            this.groupBox3.Controls.Add(this.colorVarOpc);
            this.groupBox3.Controls.Add(this.negro);
            this.groupBox3.Controls.Add(this.blanco);
            this.groupBox3.Controls.Add(this.buttonColor);
            this.groupBox3.Location = new System.Drawing.Point(400, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(101, 113);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Colores";
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(7, 79);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(86, 23);
            this.buttonColor.TabIndex = 0;
            this.buttonColor.Text = "Elegir Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // blanco
            // 
            this.blanco.BackColor = System.Drawing.Color.White;
            this.blanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.blanco.Location = new System.Drawing.Point(7, 20);
            this.blanco.Name = "blanco";
            this.blanco.Size = new System.Drawing.Size(21, 19);
            this.blanco.TabIndex = 1;
            this.blanco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // negro
            // 
            this.negro.BackColor = System.Drawing.Color.Black;
            this.negro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.negro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.negro.Location = new System.Drawing.Point(37, 20);
            this.negro.Name = "negro";
            this.negro.Size = new System.Drawing.Size(21, 19);
            this.negro.TabIndex = 2;
            this.negro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // colorVarOpc
            // 
            this.colorVarOpc.BackColor = System.Drawing.Color.White;
            this.colorVarOpc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorVarOpc.Location = new System.Drawing.Point(67, 20);
            this.colorVarOpc.Name = "colorVarOpc";
            this.colorVarOpc.Size = new System.Drawing.Size(21, 19);
            this.colorVarOpc.TabIndex = 3;
            this.colorVarOpc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // azul
            // 
            this.azul.BackColor = System.Drawing.Color.Blue;
            this.azul.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.azul.Location = new System.Drawing.Point(67, 47);
            this.azul.Name = "azul";
            this.azul.Size = new System.Drawing.Size(21, 19);
            this.azul.TabIndex = 6;
            this.azul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // amarillo
            // 
            this.amarillo.BackColor = System.Drawing.Color.Yellow;
            this.amarillo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.amarillo.Location = new System.Drawing.Point(37, 47);
            this.amarillo.Name = "amarillo";
            this.amarillo.Size = new System.Drawing.Size(21, 19);
            this.amarillo.TabIndex = 5;
            this.amarillo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // rojo
            // 
            this.rojo.BackColor = System.Drawing.Color.Red;
            this.rojo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rojo.Location = new System.Drawing.Point(7, 47);
            this.rojo.Name = "rojo";
            this.rojo.Size = new System.Drawing.Size(21, 19);
            this.rojo.TabIndex = 4;
            this.rojo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(511, 356);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelDibujo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Paint de Jorge";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button buttonMenos;
        private System.Windows.Forms.Button buttonMas;
        private System.Windows.Forms.Button buttonBorrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonCirculo;
        private System.Windows.Forms.RadioButton radioButtonCuadrado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label azul;
        private System.Windows.Forms.Label amarillo;
        private System.Windows.Forms.Label rojo;
        private System.Windows.Forms.Label colorVarOpc;
        private System.Windows.Forms.Label negro;
        private System.Windows.Forms.Label blanco;
        private System.Windows.Forms.Button buttonColor;
    }
}

