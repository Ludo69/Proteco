namespace DateTimePicker
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
            this.label1 = new System.Windows.Forms.Label();
            this.precioLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calendario = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.paginaLbl = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "El costo base del envío es de: $";
            // 
            // precioLbl
            // 
            this.precioLbl.AutoSize = true;
            this.precioLbl.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precioLbl.Location = new System.Drawing.Point(260, 13);
            this.precioLbl.Name = "precioLbl";
            this.precioLbl.Size = new System.Drawing.Size(32, 18);
            this.precioLbl.TabIndex = 1;
            this.precioLbl.Text = "600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "¿cuándo quieres recibir tu pedido?";
            // 
            // calendario
            // 
            this.calendario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.calendario.Location = new System.Drawing.Point(16, 79);
            this.calendario.Name = "calendario";
            this.calendario.Size = new System.Drawing.Size(110, 20);
            this.calendario.TabIndex = 3;
            this.calendario.ValueChanged += new System.EventHandler(this.calendario_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mientras más tiempo pase es más barato el envío.";
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(19, 146);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(52, 18);
            this.totalLbl.TabIndex = 5;
            this.totalLbl.Text = "Total:";
            // 
            // paginaLbl
            // 
            this.paginaLbl.ActiveLinkColor = System.Drawing.Color.Olive;
            this.paginaLbl.AutoSize = true;
            this.paginaLbl.LinkColor = System.Drawing.Color.Green;
            this.paginaLbl.Location = new System.Drawing.Point(22, 178);
            this.paginaLbl.Name = "paginaLbl";
            this.paginaLbl.Size = new System.Drawing.Size(111, 13);
            this.paginaLbl.TabIndex = 6;
            this.paginaLbl.TabStop = true;
            this.paginaLbl.Text = "Visita nuestra página!!";
            this.paginaLbl.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.paginaLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.paginaLbl_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(192, 178);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Prueba un programa!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 218);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.paginaLbl);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.precioLbl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label precioLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker calendario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.LinkLabel paginaLbl;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

