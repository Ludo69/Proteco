namespace JorgePadEjemplo
{
    partial class Form2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.blanco = new System.Windows.Forms.Label();
            this.azul = new System.Windows.Forms.Label();
            this.amarillo = new System.Windows.Forms.Label();
            this.rojo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.negro = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.courier = new System.Windows.Forms.RadioButton();
            this.comic = new System.Windows.Forms.RadioButton();
            this.times = new System.Windows.Forms.RadioButton();
            this.lucida = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Subrayado = new System.Windows.Forms.CheckBox();
            this.cursivas = new System.Windows.Forms.CheckBox();
            this.negritas = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 199);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.blanco);
            this.tabPage1.Controls.Add(this.azul);
            this.tabPage1.Controls.Add(this.amarillo);
            this.tabPage1.Controls.Add(this.rojo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.negro);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Colores";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // blanco
            // 
            this.blanco.BackColor = System.Drawing.Color.White;
            this.blanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.blanco.Location = new System.Drawing.Point(83, 60);
            this.blanco.Name = "blanco";
            this.blanco.Size = new System.Drawing.Size(34, 33);
            this.blanco.TabIndex = 6;
            this.blanco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // azul
            // 
            this.azul.BackColor = System.Drawing.Color.Blue;
            this.azul.Location = new System.Drawing.Point(265, 60);
            this.azul.Name = "azul";
            this.azul.Size = new System.Drawing.Size(34, 33);
            this.azul.TabIndex = 5;
            this.azul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // amarillo
            // 
            this.amarillo.BackColor = System.Drawing.Color.Yellow;
            this.amarillo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.amarillo.Location = new System.Drawing.Point(202, 60);
            this.amarillo.Name = "amarillo";
            this.amarillo.Size = new System.Drawing.Size(34, 33);
            this.amarillo.TabIndex = 4;
            this.amarillo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // rojo
            // 
            this.rojo.BackColor = System.Drawing.Color.Red;
            this.rojo.Location = new System.Drawing.Point(143, 60);
            this.rojo.Name = "rojo";
            this.rojo.Size = new System.Drawing.Size(34, 33);
            this.rojo.TabIndex = 3;
            this.rojo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elige un color de letra con clic izquierdo y un color de fondo con clic derecho";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Colores de letra y de fondo";
            // 
            // negro
            // 
            this.negro.BackColor = System.Drawing.Color.Black;
            this.negro.Location = new System.Drawing.Point(21, 60);
            this.negro.Name = "negro";
            this.negro.Size = new System.Drawing.Size(34, 33);
            this.negro.TabIndex = 0;
            this.negro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cambiarColor);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.courier);
            this.tabPage2.Controls.Add(this.comic);
            this.tabPage2.Controls.Add(this.times);
            this.tabPage2.Controls.Add(this.lucida);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 173);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fuente";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // courier
            // 
            this.courier.AutoSize = true;
            this.courier.Location = new System.Drawing.Point(27, 98);
            this.courier.Name = "courier";
            this.courier.Size = new System.Drawing.Size(58, 17);
            this.courier.TabIndex = 3;
            this.courier.Text = "Courier";
            this.courier.UseVisualStyleBackColor = true;
            this.courier.Click += new System.EventHandler(this.cambiarFuente);
            // 
            // comic
            // 
            this.comic.AutoSize = true;
            this.comic.Location = new System.Drawing.Point(27, 74);
            this.comic.Name = "comic";
            this.comic.Size = new System.Drawing.Size(100, 17);
            this.comic.TabIndex = 2;
            this.comic.Text = "Comic Sans MS";
            this.comic.UseVisualStyleBackColor = true;
            this.comic.Click += new System.EventHandler(this.cambiarFuente);
            // 
            // times
            // 
            this.times.AutoSize = true;
            this.times.Location = new System.Drawing.Point(27, 50);
            this.times.Name = "times";
            this.times.Size = new System.Drawing.Size(115, 17);
            this.times.TabIndex = 1;
            this.times.Text = "Times New Roman";
            this.times.UseVisualStyleBackColor = true;
            this.times.Click += new System.EventHandler(this.cambiarFuente);
            // 
            // lucida
            // 
            this.lucida.AutoSize = true;
            this.lucida.Checked = true;
            this.lucida.Location = new System.Drawing.Point(27, 26);
            this.lucida.Name = "lucida";
            this.lucida.Size = new System.Drawing.Size(98, 17);
            this.lucida.TabIndex = 0;
            this.lucida.TabStop = true;
            this.lucida.Text = "Lucida Console";
            this.lucida.UseVisualStyleBackColor = true;
            this.lucida.Click += new System.EventHandler(this.cambiarFuente);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Subrayado);
            this.tabPage3.Controls.Add(this.cursivas);
            this.tabPage3.Controls.Add(this.negritas);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(376, 173);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Estilos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Subrayado
            // 
            this.Subrayado.AutoSize = true;
            this.Subrayado.Location = new System.Drawing.Point(35, 79);
            this.Subrayado.Name = "Subrayado";
            this.Subrayado.Size = new System.Drawing.Size(77, 17);
            this.Subrayado.TabIndex = 2;
            this.Subrayado.Text = "Subrayado";
            this.Subrayado.UseVisualStyleBackColor = true;
            this.Subrayado.CheckedChanged += new System.EventHandler(this.Subrayado_CheckedChanged);
            // 
            // cursivas
            // 
            this.cursivas.AutoSize = true;
            this.cursivas.Location = new System.Drawing.Point(35, 55);
            this.cursivas.Name = "cursivas";
            this.cursivas.Size = new System.Drawing.Size(66, 17);
            this.cursivas.TabIndex = 1;
            this.cursivas.Text = "Cursivas";
            this.cursivas.UseVisualStyleBackColor = true;
            this.cursivas.CheckedChanged += new System.EventHandler(this.cursivas_CheckedChanged);
            // 
            // negritas
            // 
            this.negritas.AutoSize = true;
            this.negritas.Location = new System.Drawing.Point(35, 31);
            this.negritas.Name = "negritas";
            this.negritas.Size = new System.Drawing.Size(65, 17);
            this.negritas.TabIndex = 0;
            this.negritas.Text = "Negritas";
            this.negritas.UseVisualStyleBackColor = true;
            this.negritas.CheckedChanged += new System.EventHandler(this.negritas_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.numericUpDown1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(376, 173);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tamaño";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Elige el tamaño de letra";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(77, 62);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(209, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aplicar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(296, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(13, 206);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 3;
            this.label.Text = "label3";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 233);
            this.Controls.Add(this.label);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Form2";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label blanco;
        private System.Windows.Forms.Label azul;
        private System.Windows.Forms.Label amarillo;
        private System.Windows.Forms.Label rojo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label negro;
        private System.Windows.Forms.RadioButton courier;
        private System.Windows.Forms.RadioButton comic;
        private System.Windows.Forms.RadioButton times;
        private System.Windows.Forms.RadioButton lucida;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox Subrayado;
        private System.Windows.Forms.CheckBox cursivas;
        private System.Windows.Forms.CheckBox negritas;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label;
    }
}