namespace ComprasCheckBox
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
            this.manzanaCkb = new System.Windows.Forms.CheckBox();
            this.peraCkb = new System.Windows.Forms.CheckBox();
            this.mangoCkb = new System.Windows.Forms.CheckBox();
            this.descuentoGrb = new System.Windows.Forms.GroupBox();
            this.unamRbt = new System.Windows.Forms.RadioButton();
            this.martesRbt = new System.Windows.Forms.RadioButton();
            this.noRbt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cantidadMz = new System.Windows.Forms.TextBox();
            this.cantidadPe = new System.Windows.Forms.TextBox();
            this.cantidadMg = new System.Windows.Forms.TextBox();
            this.cantidadNa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.naranjaCkb = new System.Windows.Forms.CheckBox();
            this.checkBoxTodo = new System.Windows.Forms.CheckBox();
            this.TodoA = new System.Windows.Forms.CheckBox();
            this.TodoB = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.descuentoGrb.SuspendLayout();
            this.SuspendLayout();
            // 
            // manzanaCkb
            // 
            this.manzanaCkb.AutoSize = true;
            this.manzanaCkb.Location = new System.Drawing.Point(20, 54);
            this.manzanaCkb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.manzanaCkb.Name = "manzanaCkb";
            this.manzanaCkb.Size = new System.Drawing.Size(140, 24);
            this.manzanaCkb.TabIndex = 0;
            this.manzanaCkb.Text = "manzanas $25";
            this.manzanaCkb.UseVisualStyleBackColor = true;
            this.manzanaCkb.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // peraCkb
            // 
            this.peraCkb.AutoSize = true;
            this.peraCkb.Location = new System.Drawing.Point(20, 91);
            this.peraCkb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.peraCkb.Name = "peraCkb";
            this.peraCkb.Size = new System.Drawing.Size(106, 24);
            this.peraCkb.TabIndex = 1;
            this.peraCkb.Text = "peras $30";
            this.peraCkb.UseVisualStyleBackColor = true;
            this.peraCkb.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // mangoCkb
            // 
            this.mangoCkb.AutoSize = true;
            this.mangoCkb.Location = new System.Drawing.Point(20, 128);
            this.mangoCkb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mangoCkb.Name = "mangoCkb";
            this.mangoCkb.Size = new System.Drawing.Size(123, 24);
            this.mangoCkb.TabIndex = 2;
            this.mangoCkb.Text = "mangos $20";
            this.mangoCkb.UseVisualStyleBackColor = true;
            this.mangoCkb.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // descuentoGrb
            // 
            this.descuentoGrb.Controls.Add(this.unamRbt);
            this.descuentoGrb.Controls.Add(this.martesRbt);
            this.descuentoGrb.Controls.Add(this.noRbt);
            this.descuentoGrb.Location = new System.Drawing.Point(328, 54);
            this.descuentoGrb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descuentoGrb.Name = "descuentoGrb";
            this.descuentoGrb.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descuentoGrb.Size = new System.Drawing.Size(300, 154);
            this.descuentoGrb.TabIndex = 4;
            this.descuentoGrb.TabStop = false;
            this.descuentoGrb.Text = "Descuentos";
            // 
            // unamRbt
            // 
            this.unamRbt.AutoSize = true;
            this.unamRbt.Location = new System.Drawing.Point(10, 111);
            this.unamRbt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unamRbt.Name = "unamRbt";
            this.unamRbt.Size = new System.Drawing.Size(127, 24);
            this.unamRbt.TabIndex = 2;
            this.unamRbt.Text = "UNAM (10%)";
            this.unamRbt.UseVisualStyleBackColor = true;
            this.unamRbt.CheckedChanged += new System.EventHandler(this.hacerDescuento);
            // 
            // martesRbt
            // 
            this.martesRbt.AutoSize = true;
            this.martesRbt.Location = new System.Drawing.Point(10, 74);
            this.martesRbt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.martesRbt.Name = "martesRbt";
            this.martesRbt.Size = new System.Drawing.Size(210, 24);
            this.martesRbt.TabIndex = 1;
            this.martesRbt.Text = "Martes de tianguis (15%)";
            this.martesRbt.UseVisualStyleBackColor = true;
            this.martesRbt.CheckedChanged += new System.EventHandler(this.hacerDescuento);
            // 
            // noRbt
            // 
            this.noRbt.AutoSize = true;
            this.noRbt.Checked = true;
            this.noRbt.Location = new System.Drawing.Point(10, 35);
            this.noRbt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noRbt.Name = "noRbt";
            this.noRbt.Size = new System.Drawing.Size(136, 24);
            this.noRbt.TabIndex = 0;
            this.noRbt.TabStop = true;
            this.noRbt.Text = "Sin descuento";
            this.noRbt.UseVisualStyleBackColor = true;
            this.noRbt.CheckedChanged += new System.EventHandler(this.hacerDescuento);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 234);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total:";
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLbl.Location = new System.Drawing.Point(106, 234);
            this.totalLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(0, 25);
            this.totalLbl.TabIndex = 6;
            this.totalLbl.Click += new System.EventHandler(this.totalLbl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Precio x Kilo";
            // 
            // cantidadMz
            // 
            this.cantidadMz.Location = new System.Drawing.Point(172, 54);
            this.cantidadMz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cantidadMz.Name = "cantidadMz";
            this.cantidadMz.Size = new System.Drawing.Size(74, 26);
            this.cantidadMz.TabIndex = 8;
            this.cantidadMz.TextChanged += new System.EventHandler(this.validarPrecio);
            // 
            // cantidadPe
            // 
            this.cantidadPe.Location = new System.Drawing.Point(172, 88);
            this.cantidadPe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cantidadPe.Name = "cantidadPe";
            this.cantidadPe.Size = new System.Drawing.Size(74, 26);
            this.cantidadPe.TabIndex = 9;
            this.cantidadPe.TextChanged += new System.EventHandler(this.validarPrecio);
            // 
            // cantidadMg
            // 
            this.cantidadMg.Location = new System.Drawing.Point(172, 125);
            this.cantidadMg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cantidadMg.Name = "cantidadMg";
            this.cantidadMg.Size = new System.Drawing.Size(74, 26);
            this.cantidadMg.TabIndex = 10;
            this.cantidadMg.TextChanged += new System.EventHandler(this.validarPrecio);
            // 
            // cantidadNa
            // 
            this.cantidadNa.Location = new System.Drawing.Point(172, 162);
            this.cantidadNa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cantidadNa.Name = "cantidadNa";
            this.cantidadNa.Size = new System.Drawing.Size(74, 26);
            this.cantidadNa.TabIndex = 11;
            this.cantidadNa.TextChanged += new System.EventHandler(this.validarPrecio);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kilos";
            // 
            // naranjaCkb
            // 
            this.naranjaCkb.AutoSize = true;
            this.naranjaCkb.Location = new System.Drawing.Point(20, 165);
            this.naranjaCkb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.naranjaCkb.Name = "naranjaCkb";
            this.naranjaCkb.Size = new System.Drawing.Size(127, 24);
            this.naranjaCkb.TabIndex = 3;
            this.naranjaCkb.Text = "naranjas $15";
            this.naranjaCkb.UseVisualStyleBackColor = true;
            this.naranjaCkb.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // checkBoxTodo
            // 
            this.checkBoxTodo.AutoSize = true;
            this.checkBoxTodo.Location = new System.Drawing.Point(20, 199);
            this.checkBoxTodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxTodo.Name = "checkBoxTodo";
            this.checkBoxTodo.Size = new System.Drawing.Size(71, 24);
            this.checkBoxTodo.TabIndex = 13;
            this.checkBoxTodo.Text = "Todo";
            this.checkBoxTodo.UseVisualStyleBackColor = true;
            this.checkBoxTodo.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // TodoA
            // 
            this.TodoA.AutoSize = true;
            this.TodoA.Location = new System.Drawing.Point(20, 237);
            this.TodoA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TodoA.Name = "TodoA";
            this.TodoA.Size = new System.Drawing.Size(82, 24);
            this.TodoA.TabIndex = 14;
            this.TodoA.Text = "TodoA";
            this.TodoA.UseVisualStyleBackColor = true;
            this.TodoA.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // TodoB
            // 
            this.TodoB.AutoSize = true;
            this.TodoB.Location = new System.Drawing.Point(20, 271);
            this.TodoB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TodoB.Name = "TodoB";
            this.TodoB.Size = new System.Drawing.Size(82, 24);
            this.TodoB.TabIndex = 15;
            this.TodoB.Text = "TodoB";
            this.TodoB.UseVisualStyleBackColor = true;
            this.TodoB.CheckedChanged += new System.EventHandler(this.carrito);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(328, 271);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(251, 46);
            this.checkedListBox1.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 282);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(442, 26);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 358);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.TodoB);
            this.Controls.Add(this.TodoA);
            this.Controls.Add(this.checkBoxTodo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cantidadNa);
            this.Controls.Add(this.cantidadMg);
            this.Controls.Add(this.cantidadPe);
            this.Controls.Add(this.cantidadMz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descuentoGrb);
            this.Controls.Add(this.naranjaCkb);
            this.Controls.Add(this.mangoCkb);
            this.Controls.Add(this.peraCkb);
            this.Controls.Add(this.manzanaCkb);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Tienda";
            this.descuentoGrb.ResumeLayout(false);
            this.descuentoGrb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox manzanaCkb;
        private System.Windows.Forms.CheckBox peraCkb;
        private System.Windows.Forms.CheckBox mangoCkb;
        private System.Windows.Forms.GroupBox descuentoGrb;
        private System.Windows.Forms.RadioButton unamRbt;
        private System.Windows.Forms.RadioButton martesRbt;
        private System.Windows.Forms.RadioButton noRbt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cantidadMz;
        private System.Windows.Forms.TextBox cantidadPe;
        private System.Windows.Forms.TextBox cantidadMg;
        private System.Windows.Forms.TextBox cantidadNa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox naranjaCkb;
        private System.Windows.Forms.CheckBox checkBoxTodo;
        private System.Windows.Forms.CheckBox TodoA;
        private System.Windows.Forms.CheckBox TodoB;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

