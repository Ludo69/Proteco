namespace Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.usuarioTxb = new System.Windows.Forms.TextBox();
            this.passTxb = new System.Windows.Forms.TextBox();
            this.inputBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lato", 8.25F);
            this.label1.Location = new System.Drawing.Point(84, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lato", 8.25F);
            this.label2.Location = new System.Drawing.Point(76, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // usuarioTxb
            // 
            this.usuarioTxb.Location = new System.Drawing.Point(188, 40);
            this.usuarioTxb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usuarioTxb.Name = "usuarioTxb";
            this.usuarioTxb.Size = new System.Drawing.Size(148, 26);
            this.usuarioTxb.TabIndex = 2;
            // 
            // passTxb
            // 
            this.passTxb.Location = new System.Drawing.Point(188, 85);
            this.passTxb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passTxb.Name = "passTxb";
            this.passTxb.PasswordChar = '$';
            this.passTxb.Size = new System.Drawing.Size(148, 26);
            this.passTxb.TabIndex = 3;
            // 
            // inputBtn
            // 
            this.inputBtn.Location = new System.Drawing.Point(188, 137);
            this.inputBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputBtn.Name = "inputBtn";
            this.inputBtn.Size = new System.Drawing.Size(112, 35);
            this.inputBtn.TabIndex = 4;
            this.inputBtn.Text = "Login";
            this.inputBtn.UseVisualStyleBackColor = true;
            this.inputBtn.Click += new System.EventHandler(this.inputBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 191);
            this.Controls.Add(this.inputBtn);
            this.Controls.Add(this.passTxb);
            this.Controls.Add(this.usuarioTxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuarioTxb;
        private System.Windows.Forms.TextBox passTxb;
        private System.Windows.Forms.Button inputBtn;
    }
}

