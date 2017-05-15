namespace BadeDatos1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label origenLabel;
            System.Windows.Forms.Label destinoLabel;
            System.Windows.Forms.Label horaSalidaLabel;
            System.Windows.Forms.Label numEscalasLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.itinerarioDataSet1 = new BadeDatos1.ItinerarioDataSet1();
            this.vueloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vueloTableAdapter = new BadeDatos1.ItinerarioDataSet1TableAdapters.VueloTableAdapter();
            this.tableAdapterManager = new BadeDatos1.ItinerarioDataSet1TableAdapters.TableAdapterManager();
            this.vueloBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.vueloBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.origenTextBox = new System.Windows.Forms.TextBox();
            this.destinoTextBox = new System.Windows.Forms.TextBox();
            this.horaSalidaTextBox = new System.Windows.Forms.TextBox();
            this.numEscalasTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            idLabel = new System.Windows.Forms.Label();
            origenLabel = new System.Windows.Forms.Label();
            destinoLabel = new System.Windows.Forms.Label();
            horaSalidaLabel = new System.Windows.Forms.Label();
            numEscalasLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itinerarioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vueloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vueloBindingNavigator)).BeginInit();
            this.vueloBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(95, 56);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id:";
            // 
            // origenLabel
            // 
            origenLabel.AutoSize = true;
            origenLabel.Location = new System.Drawing.Point(95, 82);
            origenLabel.Name = "origenLabel";
            origenLabel.Size = new System.Drawing.Size(41, 13);
            origenLabel.TabIndex = 3;
            origenLabel.Text = "Origen:";
            // 
            // destinoLabel
            // 
            destinoLabel.AutoSize = true;
            destinoLabel.Location = new System.Drawing.Point(95, 108);
            destinoLabel.Name = "destinoLabel";
            destinoLabel.Size = new System.Drawing.Size(46, 13);
            destinoLabel.TabIndex = 5;
            destinoLabel.Text = "Destino:";
            // 
            // horaSalidaLabel
            // 
            horaSalidaLabel.AutoSize = true;
            horaSalidaLabel.Location = new System.Drawing.Point(95, 134);
            horaSalidaLabel.Name = "horaSalidaLabel";
            horaSalidaLabel.Size = new System.Drawing.Size(65, 13);
            horaSalidaLabel.TabIndex = 7;
            horaSalidaLabel.Text = "Hora Salida:";
            // 
            // numEscalasLabel
            // 
            numEscalasLabel.AutoSize = true;
            numEscalasLabel.Location = new System.Drawing.Point(95, 160);
            numEscalasLabel.Name = "numEscalasLabel";
            numEscalasLabel.Size = new System.Drawing.Size(72, 13);
            numEscalasLabel.TabIndex = 9;
            numEscalasLabel.Text = "Num Escalas:";
            // 
            // itinerarioDataSet1
            // 
            this.itinerarioDataSet1.DataSetName = "ItinerarioDataSet1";
            this.itinerarioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vueloBindingSource
            // 
            this.vueloBindingSource.DataMember = "Vuelo";
            this.vueloBindingSource.DataSource = this.itinerarioDataSet1;
            // 
            // vueloTableAdapter
            // 
            this.vueloTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = BadeDatos1.ItinerarioDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VueloTableAdapter = this.vueloTableAdapter;
            // 
            // vueloBindingNavigator
            // 
            this.vueloBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.vueloBindingNavigator.BindingSource = this.vueloBindingSource;
            this.vueloBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.vueloBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.vueloBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.vueloBindingNavigatorSaveItem});
            this.vueloBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.vueloBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.vueloBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.vueloBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.vueloBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.vueloBindingNavigator.Name = "vueloBindingNavigator";
            this.vueloBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.vueloBindingNavigator.Size = new System.Drawing.Size(607, 25);
            this.vueloBindingNavigator.TabIndex = 0;
            this.vueloBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // vueloBindingNavigatorSaveItem
            // 
            this.vueloBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vueloBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("vueloBindingNavigatorSaveItem.Image")));
            this.vueloBindingNavigatorSaveItem.Name = "vueloBindingNavigatorSaveItem";
            this.vueloBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.vueloBindingNavigatorSaveItem.Text = "Save Data";
            this.vueloBindingNavigatorSaveItem.Click += new System.EventHandler(this.vueloBindingNavigatorSaveItem_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vueloBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(173, 53);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 2;
            // 
            // origenTextBox
            // 
            this.origenTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vueloBindingSource, "Origen", true));
            this.origenTextBox.Location = new System.Drawing.Point(173, 79);
            this.origenTextBox.Name = "origenTextBox";
            this.origenTextBox.Size = new System.Drawing.Size(100, 20);
            this.origenTextBox.TabIndex = 4;
            // 
            // destinoTextBox
            // 
            this.destinoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vueloBindingSource, "Destino", true));
            this.destinoTextBox.Location = new System.Drawing.Point(173, 105);
            this.destinoTextBox.Name = "destinoTextBox";
            this.destinoTextBox.Size = new System.Drawing.Size(100, 20);
            this.destinoTextBox.TabIndex = 6;
            // 
            // horaSalidaTextBox
            // 
            this.horaSalidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vueloBindingSource, "HoraSalida", true));
            this.horaSalidaTextBox.Location = new System.Drawing.Point(173, 131);
            this.horaSalidaTextBox.Name = "horaSalidaTextBox";
            this.horaSalidaTextBox.Size = new System.Drawing.Size(100, 20);
            this.horaSalidaTextBox.TabIndex = 8;
            // 
            // numEscalasTextBox
            // 
            this.numEscalasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vueloBindingSource, "NumEscalas", true));
            this.numEscalasTextBox.Location = new System.Drawing.Point(173, 157);
            this.numEscalasTextBox.Name = "numEscalasTextBox";
            this.numEscalasTextBox.Size = new System.Drawing.Size(100, 20);
            this.numEscalasTextBox.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ir a último";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(173, 264);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(100, 20);
            this.Buscar.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Origen";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(117, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Ir a primero";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 361);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(origenLabel);
            this.Controls.Add(this.origenTextBox);
            this.Controls.Add(destinoLabel);
            this.Controls.Add(this.destinoTextBox);
            this.Controls.Add(horaSalidaLabel);
            this.Controls.Add(this.horaSalidaTextBox);
            this.Controls.Add(numEscalasLabel);
            this.Controls.Add(this.numEscalasTextBox);
            this.Controls.Add(this.vueloBindingNavigator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itinerarioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vueloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vueloBindingNavigator)).EndInit();
            this.vueloBindingNavigator.ResumeLayout(false);
            this.vueloBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ItinerarioDataSet1 itinerarioDataSet1;
        private System.Windows.Forms.BindingSource vueloBindingSource;
        private ItinerarioDataSet1TableAdapters.VueloTableAdapter vueloTableAdapter;
        private ItinerarioDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator vueloBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton vueloBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox origenTextBox;
        private System.Windows.Forms.TextBox destinoTextBox;
        private System.Windows.Forms.TextBox horaSalidaTextBox;
        private System.Windows.Forms.TextBox numEscalasTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

