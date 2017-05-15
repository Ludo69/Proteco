namespace GraficarEcuacion
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.aTxB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bTxB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cTxB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inicioNUD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.finalNUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.presicion = new System.Windows.Forms.TextBox();
            this.graficarBtn = new System.Windows.Forms.Button();
            this.grafica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.inicioNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).BeginInit();
            this.SuspendLayout();
            // 
            // aTxB
            // 
            this.aTxB.Location = new System.Drawing.Point(13, 18);
            this.aTxB.Name = "aTxB";
            this.aTxB.Size = new System.Drawing.Size(38, 20);
            this.aTxB.TabIndex = 0;
            this.aTxB.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X^2 +";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X +";
            // 
            // bTxB
            // 
            this.bTxB.Location = new System.Drawing.Point(104, 18);
            this.bTxB.Name = "bTxB";
            this.bTxB.Size = new System.Drawing.Size(38, 20);
            this.bTxB.TabIndex = 2;
            this.bTxB.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "C = Y";
            // 
            // cTxB
            // 
            this.cTxB.Location = new System.Drawing.Point(183, 18);
            this.cTxB.Name = "cTxB";
            this.cTxB.Size = new System.Drawing.Size(38, 20);
            this.cTxB.TabIndex = 4;
            this.cTxB.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rango:";
            // 
            // inicioNUD
            // 
            this.inicioNUD.DecimalPlaces = 2;
            this.inicioNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.inicioNUD.Location = new System.Drawing.Point(57, 44);
            this.inicioNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.inicioNUD.Name = "inicioNUD";
            this.inicioNUD.Size = new System.Drawing.Size(54, 20);
            this.inicioNUD.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "a";
            // 
            // finalNUD
            // 
            this.finalNUD.DecimalPlaces = 2;
            this.finalNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.finalNUD.Location = new System.Drawing.Point(130, 44);
            this.finalNUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.finalNUD.Name = "finalNUD";
            this.finalNUD.Size = new System.Drawing.Size(51, 20);
            this.finalNUD.TabIndex = 9;
            this.finalNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Presición:";
            // 
            // presicion
            // 
            this.presicion.Location = new System.Drawing.Point(287, 43);
            this.presicion.Name = "presicion";
            this.presicion.Size = new System.Drawing.Size(59, 20);
            this.presicion.TabIndex = 11;
            this.presicion.Text = "0.5";
            // 
            // graficarBtn
            // 
            this.graficarBtn.Location = new System.Drawing.Point(373, 18);
            this.graficarBtn.Name = "graficarBtn";
            this.graficarBtn.Size = new System.Drawing.Size(75, 23);
            this.graficarBtn.TabIndex = 12;
            this.graficarBtn.Text = "Graficar";
            this.graficarBtn.UseVisualStyleBackColor = true;
            this.graficarBtn.Click += new System.EventHandler(this.graficarBtn_Click);
            // 
            // grafica
            // 
            chartArea1.Name = "ChartArea1";
            this.grafica.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grafica.Legends.Add(legend1);
            this.grafica.Location = new System.Drawing.Point(15, 82);
            this.grafica.Name = "grafica";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Maroon;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Linea";
            this.grafica.Series.Add(series1);
            this.grafica.Size = new System.Drawing.Size(445, 300);
            this.grafica.TabIndex = 13;
            this.grafica.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 389);
            this.Controls.Add(this.grafica);
            this.Controls.Add(this.graficarBtn);
            this.Controls.Add(this.presicion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.finalNUD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inicioNUD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cTxB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bTxB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aTxB);
            this.Name = "Form1";
            this.Text = "Resolver Ecuación";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inicioNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox aTxB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bTxB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cTxB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown inicioNUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown finalNUD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox presicion;
        private System.Windows.Forms.Button graficarBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafica;
    }
}

