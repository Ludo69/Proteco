namespace PrimerChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grafica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.materiasCLB = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnaRdB = new System.Windows.Forms.RadioButton();
            this.lineaRdB = new System.Windows.Forms.RadioButton();
            this.graficarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grafica
            // 
            chartArea3.Name = "ChartArea1";
            this.grafica.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grafica.Legends.Add(legend3);
            this.grafica.Location = new System.Drawing.Point(12, 111);
            this.grafica.Name = "grafica";
            series5.BorderWidth = 4;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series5.Legend = "Legend1";
            series5.Name = "Reprobados";
            series6.BorderWidth = 4;
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Aprobados";
            this.grafica.Series.Add(series5);
            this.grafica.Series.Add(series6);
            this.grafica.Size = new System.Drawing.Size(450, 242);
            this.grafica.TabIndex = 0;
            this.grafica.Text = "chart1";
            // 
            // materiasCLB
            // 
            this.materiasCLB.FormattingEnabled = true;
            this.materiasCLB.Items.AddRange(new object[] {
            "Álgebra",
            "Cálculo",
            "Dibujo",
            "Progra. A.",
            "Quimica"});
            this.materiasCLB.Location = new System.Drawing.Point(12, 7);
            this.materiasCLB.Name = "materiasCLB";
            this.materiasCLB.Size = new System.Drawing.Size(145, 94);
            this.materiasCLB.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lineaRdB);
            this.groupBox1.Controls.Add(this.columnaRdB);
            this.groupBox1.Location = new System.Drawing.Point(173, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // columnaRdB
            // 
            this.columnaRdB.AutoSize = true;
            this.columnaRdB.Checked = true;
            this.columnaRdB.Location = new System.Drawing.Point(7, 20);
            this.columnaRdB.Name = "columnaRdB";
            this.columnaRdB.Size = new System.Drawing.Size(66, 17);
            this.columnaRdB.TabIndex = 0;
            this.columnaRdB.TabStop = true;
            this.columnaRdB.Text = "Columna";
            this.columnaRdB.UseVisualStyleBackColor = true;
            this.columnaRdB.CheckedChanged += new System.EventHandler(this.lineaRdB_CheckedChanged);
            // 
            // lineaRdB
            // 
            this.lineaRdB.AutoSize = true;
            this.lineaRdB.Location = new System.Drawing.Point(6, 37);
            this.lineaRdB.Name = "lineaRdB";
            this.lineaRdB.Size = new System.Drawing.Size(51, 17);
            this.lineaRdB.TabIndex = 1;
            this.lineaRdB.Text = "Linea";
            this.lineaRdB.UseVisualStyleBackColor = true;
            this.lineaRdB.CheckedChanged += new System.EventHandler(this.lineaRdB_CheckedChanged);
            // 
            // graficarBtn
            // 
            this.graficarBtn.Location = new System.Drawing.Point(180, 78);
            this.graficarBtn.Name = "graficarBtn";
            this.graficarBtn.Size = new System.Drawing.Size(75, 23);
            this.graficarBtn.TabIndex = 3;
            this.graficarBtn.Text = "Graficar";
            this.graficarBtn.UseVisualStyleBackColor = true;
            this.graficarBtn.Click += new System.EventHandler(this.graficarBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 365);
            this.Controls.Add(this.graficarBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.materiasCLB);
            this.Controls.Add(this.grafica);
            this.Name = "Form1";
            this.Text = "Grafica Simple";
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafica;
        private System.Windows.Forms.CheckedListBox materiasCLB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton lineaRdB;
        private System.Windows.Forms.RadioButton columnaRdB;
        private System.Windows.Forms.Button graficarBtn;
    }
}

