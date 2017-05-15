namespace FuenteYColorEjmplo
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
            this.buttonF = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.labelF = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No pos miau =^. .^=";
            // 
            // buttonF
            // 
            this.buttonF.Location = new System.Drawing.Point(12, 100);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(75, 23);
            this.buttonF.TabIndex = 1;
            this.buttonF.Text = "Fuente";
            this.buttonF.UseVisualStyleBackColor = true;
            this.buttonF.Click += new System.EventHandler(this.buttonF_Click);
            // 
            // buttonC
            // 
            this.buttonC.Location = new System.Drawing.Point(110, 100);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(75, 23);
            this.buttonC.TabIndex = 2;
            this.buttonC.Text = "Color";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.buttonC_Click);
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Location = new System.Drawing.Point(12, 13);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(0, 13);
            this.labelF.TabIndex = 3;
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(12, 30);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(0, 13);
            this.labelC.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 135);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelF);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label labelC;
    }
}

