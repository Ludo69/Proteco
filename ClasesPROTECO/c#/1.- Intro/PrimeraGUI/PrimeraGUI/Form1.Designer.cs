namespace PrimeraGUI
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
            this.textoLbl = new System.Windows.Forms.Label();
            this.botonBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textoLbl
            // 
            this.textoLbl.AutoSize = true;
            this.textoLbl.Location = new System.Drawing.Point(13, 13);
            this.textoLbl.Name = "textoLbl";
            this.textoLbl.Size = new System.Drawing.Size(29, 13);
            this.textoLbl.TabIndex = 0;
            this.textoLbl.Text = "Hola";
            // 
            // botonBtn
            // 
            this.botonBtn.Location = new System.Drawing.Point(16, 58);
            this.botonBtn.Name = "botonBtn";
            this.botonBtn.Size = new System.Drawing.Size(75, 23);
            this.botonBtn.TabIndex = 1;
            this.botonBtn.Text = "Pícame";
            this.botonBtn.UseVisualStyleBackColor = true;
            this.botonBtn.Click += new System.EventHandler(this.botonBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 150);
            this.Controls.Add(this.botonBtn);
            this.Controls.Add(this.textoLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textoLbl;
        private System.Windows.Forms.Button botonBtn;
    }
}

