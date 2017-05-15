namespace ClickMasRapido
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
            this.contadorLbl = new System.Windows.Forms.Label();
            this.segundosLbl = new System.Windows.Forms.Label();
            this.clickBtn = new System.Windows.Forms.Button();
            this.restartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contadorLbl
            // 
            this.contadorLbl.AutoSize = true;
            this.contadorLbl.Location = new System.Drawing.Point(40, 13);
            this.contadorLbl.Name = "contadorLbl";
            this.contadorLbl.Size = new System.Drawing.Size(38, 13);
            this.contadorLbl.TabIndex = 0;
            this.contadorLbl.Text = "Clicks:";
            // 
            // segundosLbl
            // 
            this.segundosLbl.AutoSize = true;
            this.segundosLbl.Location = new System.Drawing.Point(211, 13);
            this.segundosLbl.Name = "segundosLbl";
            this.segundosLbl.Size = new System.Drawing.Size(58, 13);
            this.segundosLbl.TabIndex = 1;
            this.segundosLbl.Text = "Segundos:";
            // 
            // clickBtn
            // 
            this.clickBtn.Location = new System.Drawing.Point(100, 66);
            this.clickBtn.Name = "clickBtn";
            this.clickBtn.Size = new System.Drawing.Size(75, 23);
            this.clickBtn.TabIndex = 2;
            this.clickBtn.Text = "Click!!";
            this.clickBtn.UseVisualStyleBackColor = true;
            this.clickBtn.Click += new System.EventHandler(this.clickBtn_Click);
            // 
            // restartBtn
            // 
            this.restartBtn.Enabled = false;
            this.restartBtn.Location = new System.Drawing.Point(224, 66);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(75, 23);
            this.restartBtn.TabIndex = 3;
            this.restartBtn.Text = "Reiniciar";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 101);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.clickBtn);
            this.Controls.Add(this.segundosLbl);
            this.Controls.Add(this.contadorLbl);
            this.Name = "Form1";
            this.Text = "Click Más Rapido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contadorLbl;
        private System.Windows.Forms.Label segundosLbl;
        private System.Windows.Forms.Button clickBtn;
        private System.Windows.Forms.Button restartBtn;
    }
}

