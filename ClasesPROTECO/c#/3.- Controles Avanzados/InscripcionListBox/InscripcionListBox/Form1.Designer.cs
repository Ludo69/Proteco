namespace InscripcionListBox
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
            this.datosLsB = new System.Windows.Forms.ListBox();
            this.input = new System.Windows.Forms.TextBox();
            this.agregarBtn = new System.Windows.Forms.Button();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.limpiarBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.materias = new System.Windows.Forms.CheckedListBox();
            this.horarioLsB = new System.Windows.Forms.ListBox();
            this.generarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // datosLsB
            // 
            this.datosLsB.FormattingEnabled = true;
            this.datosLsB.Location = new System.Drawing.Point(13, 13);
            this.datosLsB.Name = "datosLsB";
            this.datosLsB.Size = new System.Drawing.Size(132, 82);
            this.datosLsB.TabIndex = 0;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(171, 13);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(122, 20);
            this.input.TabIndex = 1;
            this.input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // agregarBtn
            // 
            this.agregarBtn.Location = new System.Drawing.Point(171, 40);
            this.agregarBtn.Name = "agregarBtn";
            this.agregarBtn.Size = new System.Drawing.Size(75, 23);
            this.agregarBtn.TabIndex = 2;
            this.agregarBtn.Text = "Agregar";
            this.agregarBtn.UseVisualStyleBackColor = true;
            this.agregarBtn.Click += new System.EventHandler(this.agregarBtn_Click);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.Location = new System.Drawing.Point(171, 69);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminarBtn.TabIndex = 3;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(258, 40);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 4;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.limpiarBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(258, 69);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 5;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // materias
            // 
            this.materias.FormattingEnabled = true;
            this.materias.Items.AddRange(new object[] {
            "Cálculo Vectorial",
            "Álgebra Lineal",
            "Ética",
            "Química",
            "Sistemas Operativos"});
            this.materias.Location = new System.Drawing.Point(13, 118);
            this.materias.Name = "materias";
            this.materias.Size = new System.Drawing.Size(132, 124);
            this.materias.TabIndex = 6;
            this.materias.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.materias_ItemCheck);
            // 
            // horarioLsB
            // 
            this.horarioLsB.FormattingEnabled = true;
            this.horarioLsB.Location = new System.Drawing.Point(171, 118);
            this.horarioLsB.Name = "horarioLsB";
            this.horarioLsB.Size = new System.Drawing.Size(122, 121);
            this.horarioLsB.TabIndex = 7;
            // 
            // generarBtn
            // 
            this.generarBtn.Location = new System.Drawing.Point(107, 259);
            this.generarBtn.Name = "generarBtn";
            this.generarBtn.Size = new System.Drawing.Size(86, 41);
            this.generarBtn.TabIndex = 8;
            this.generarBtn.Text = "Generar Comprobante";
            this.generarBtn.UseVisualStyleBackColor = true;
            this.generarBtn.Click += new System.EventHandler(this.generarBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 331);
            this.Controls.Add(this.generarBtn);
            this.Controls.Add(this.horarioLsB);
            this.Controls.Add(this.materias);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.agregarBtn);
            this.Controls.Add(this.input);
            this.Controls.Add(this.datosLsB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox datosLsB;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button agregarBtn;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.CheckedListBox materias;
        private System.Windows.Forms.ListBox horarioLsB;
        private System.Windows.Forms.Button generarBtn;
    }
}

