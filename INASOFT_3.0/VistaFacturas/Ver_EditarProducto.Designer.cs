namespace INASOFT_3._0.VistaFacturas
{
    partial class Ver_EditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ver_EditarProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupBox_VerProd = new System.Windows.Forms.GroupBox();
            this.GroupBox_EditarProd = new System.Windows.Forms.GroupBox();
            this.Cbx_Estados = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Btn_AddProducto = new Guna.UI2.WinForms.Guna2Button();
            this.Txt_IDProd = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrecioCompra = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SpinExist = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodBarra = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrecioVenta = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MessageBox_Import = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Warnings = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Ok = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Error = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Question = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.GroupBox_VerProd.SuspendLayout();
            this.GroupBox_EditarProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExist)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 36);
            this.panel1.TabIndex = 33;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(586, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(43, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ver Productos";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::INASOFT_3._0.Properties.Resources.icons8_show_property_50px;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(617, 338);
            this.dataGridView1.TabIndex = 25;
            // 
            // GroupBox_VerProd
            // 
            this.GroupBox_VerProd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GroupBox_VerProd.Controls.Add(this.GroupBox_EditarProd);
            this.GroupBox_VerProd.Controls.Add(this.dataGridView1);
            this.GroupBox_VerProd.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_VerProd.Location = new System.Drawing.Point(0, 42);
            this.GroupBox_VerProd.Name = "GroupBox_VerProd";
            this.GroupBox_VerProd.Size = new System.Drawing.Size(623, 362);
            this.GroupBox_VerProd.TabIndex = 87;
            this.GroupBox_VerProd.TabStop = false;
            this.GroupBox_VerProd.Text = "Cambiar precio";
            // 
            // GroupBox_EditarProd
            // 
            this.GroupBox_EditarProd.Controls.Add(this.Cbx_Estados);
            this.GroupBox_EditarProd.Controls.Add(this.label8);
            this.GroupBox_EditarProd.Controls.Add(this.Btn_AddProducto);
            this.GroupBox_EditarProd.Controls.Add(this.Txt_IDProd);
            this.GroupBox_EditarProd.Controls.Add(this.txtPrecioCompra);
            this.GroupBox_EditarProd.Controls.Add(this.label2);
            this.GroupBox_EditarProd.Controls.Add(this.SpinExist);
            this.GroupBox_EditarProd.Controls.Add(this.label6);
            this.GroupBox_EditarProd.Controls.Add(this.txtCodBarra);
            this.GroupBox_EditarProd.Controls.Add(this.label1);
            this.GroupBox_EditarProd.Controls.Add(this.txtObservacion);
            this.GroupBox_EditarProd.Controls.Add(this.label3);
            this.GroupBox_EditarProd.Controls.Add(this.label4);
            this.GroupBox_EditarProd.Controls.Add(this.txtNameP);
            this.GroupBox_EditarProd.Controls.Add(this.txtPrecioVenta);
            this.GroupBox_EditarProd.Controls.Add(this.label7);
            this.GroupBox_EditarProd.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_EditarProd.Name = "GroupBox_EditarProd";
            this.GroupBox_EditarProd.Size = new System.Drawing.Size(623, 362);
            this.GroupBox_EditarProd.TabIndex = 26;
            this.GroupBox_EditarProd.TabStop = false;
            this.GroupBox_EditarProd.Text = "Editar producto ";
            // 
            // Cbx_Estados
            // 
            this.Cbx_Estados.BackColor = System.Drawing.SystemColors.Control;
            this.Cbx_Estados.DropDownHeight = 90;
            this.Cbx_Estados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx_Estados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cbx_Estados.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Estados.FormattingEnabled = true;
            this.Cbx_Estados.IntegralHeight = false;
            this.Cbx_Estados.Items.AddRange(new object[] {
            "Activo",
            "No Activo"});
            this.Cbx_Estados.Location = new System.Drawing.Point(286, 125);
            this.Cbx_Estados.Name = "Cbx_Estados";
            this.Cbx_Estados.Size = new System.Drawing.Size(191, 30);
            this.Cbx_Estados.TabIndex = 101;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(286, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 22);
            this.label8.TabIndex = 100;
            this.label8.Text = "Estado:";
            // 
            // Btn_AddProducto
            // 
            this.Btn_AddProducto.BorderRadius = 8;
            this.Btn_AddProducto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Btn_AddProducto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Btn_AddProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Btn_AddProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Btn_AddProducto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.Btn_AddProducto.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AddProducto.ForeColor = System.Drawing.Color.White;
            this.Btn_AddProducto.Image = ((System.Drawing.Image)(resources.GetObject("Btn_AddProducto.Image")));
            this.Btn_AddProducto.Location = new System.Drawing.Point(474, 318);
            this.Btn_AddProducto.Name = "Btn_AddProducto";
            this.Btn_AddProducto.Size = new System.Drawing.Size(137, 32);
            this.Btn_AddProducto.TabIndex = 98;
            this.Btn_AddProducto.Text = "Agregar producto";
            this.Btn_AddProducto.Click += new System.EventHandler(this.Btn_AddProducto_Click);
            // 
            // Txt_IDProd
            // 
            this.Txt_IDProd.BackColor = System.Drawing.Color.Transparent;
            this.Txt_IDProd.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.Txt_IDProd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_IDProd.DefaultText = "";
            this.Txt_IDProd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txt_IDProd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txt_IDProd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_IDProd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txt_IDProd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_IDProd.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_IDProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Txt_IDProd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txt_IDProd.Location = new System.Drawing.Point(588, 21);
            this.Txt_IDProd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_IDProd.Name = "Txt_IDProd";
            this.Txt_IDProd.PasswordChar = '\0';
            this.Txt_IDProd.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.Txt_IDProd.PlaceholderText = "";
            this.Txt_IDProd.SelectedText = "";
            this.Txt_IDProd.Size = new System.Drawing.Size(29, 26);
            this.Txt_IDProd.TabIndex = 97;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrecioCompra.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrecioCompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioCompra.DefaultText = "";
            this.txtPrecioCompra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioCompra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioCompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioCompra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioCompra.FillColor = System.Drawing.SystemColors.Control;
            this.txtPrecioCompra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioCompra.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioCompra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioCompra.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPrecioCompra.IconLeft")));
            this.txtPrecioCompra.Location = new System.Drawing.Point(286, 56);
            this.txtPrecioCompra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.PasswordChar = '\0';
            this.txtPrecioCompra.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrecioCompra.PlaceholderText = "Precio de Compra";
            this.txtPrecioCompra.SelectedText = "";
            this.txtPrecioCompra.Size = new System.Drawing.Size(191, 30);
            this.txtPrecioCompra.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(293, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cant. comprada:";
            // 
            // SpinExist
            // 
            this.SpinExist.BackColor = System.Drawing.SystemColors.Control;
            this.SpinExist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpinExist.FillColor = System.Drawing.SystemColors.Control;
            this.SpinExist.Font = new System.Drawing.Font("Poppins", 9F);
            this.SpinExist.Location = new System.Drawing.Point(293, 192);
            this.SpinExist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpinExist.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.SpinExist.Name = "SpinExist";
            this.SpinExist.Size = new System.Drawing.Size(94, 30);
            this.SpinExist.TabIndex = 19;
            this.SpinExist.UpDownButtonFillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SpinExist.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(286, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 22);
            this.label6.TabIndex = 22;
            this.label6.Text = "Precio de compra:";
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodBarra.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCodBarra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodBarra.DefaultText = "";
            this.txtCodBarra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodBarra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodBarra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodBarra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodBarra.FillColor = System.Drawing.SystemColors.Control;
            this.txtCodBarra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodBarra.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCodBarra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodBarra.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtCodBarra.IconLeft")));
            this.txtCodBarra.Location = new System.Drawing.Point(10, 56);
            this.txtCodBarra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.PasswordChar = '\0';
            this.txtCodBarra.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtCodBarra.PlaceholderText = "Ingrese Codigo de Barra";
            this.txtCodBarra.SelectedText = "";
            this.txtCodBarra.Size = new System.Drawing.Size(191, 30);
            this.txtCodBarra.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Código del producto:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.BackColor = System.Drawing.SystemColors.Control;
            this.txtObservacion.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtObservacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservacion.DefaultText = "";
            this.txtObservacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.FillColor = System.Drawing.SystemColors.Control;
            this.txtObservacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtObservacion.IconLeft")));
            this.txtObservacion.Location = new System.Drawing.Point(10, 251);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtObservacion.PlaceholderText = "Observaciones";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.SelectedText = "";
            this.txtObservacion.Size = new System.Drawing.Size(235, 77);
            this.txtObservacion.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(6, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Observaciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nombre del producto:";
            // 
            // txtNameP
            // 
            this.txtNameP.BackColor = System.Drawing.SystemColors.Control;
            this.txtNameP.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNameP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameP.DefaultText = "";
            this.txtNameP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameP.FillColor = System.Drawing.SystemColors.Control;
            this.txtNameP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameP.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNameP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameP.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtNameP.IconLeft")));
            this.txtNameP.Location = new System.Drawing.Point(10, 125);
            this.txtNameP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameP.Name = "txtNameP";
            this.txtNameP.PasswordChar = '\0';
            this.txtNameP.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNameP.PlaceholderText = "Nombre del Producto";
            this.txtNameP.SelectedText = "";
            this.txtNameP.Size = new System.Drawing.Size(191, 30);
            this.txtNameP.TabIndex = 11;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrecioVenta.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrecioVenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioVenta.DefaultText = "";
            this.txtPrecioVenta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioVenta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioVenta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioVenta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioVenta.FillColor = System.Drawing.SystemColors.Control;
            this.txtPrecioVenta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioVenta.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioVenta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioVenta.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPrecioVenta.IconLeft")));
            this.txtPrecioVenta.Location = new System.Drawing.Point(10, 187);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.PasswordChar = '\0';
            this.txtPrecioVenta.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrecioVenta.PlaceholderText = "Precio de Venta";
            this.txtPrecioVenta.SelectedText = "";
            this.txtPrecioVenta.Size = new System.Drawing.Size(191, 30);
            this.txtPrecioVenta.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(10, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio de venta:";
            // 
            // MessageBox_Import
            // 
            this.MessageBox_Import.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Import.Caption = null;
            this.MessageBox_Import.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageBox_Import.Parent = null;
            this.MessageBox_Import.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageBox_Import.Text = null;
            // 
            // MessageBox_Warnings
            // 
            this.MessageBox_Warnings.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Warnings.Caption = null;
            this.MessageBox_Warnings.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.MessageBox_Warnings.Parent = null;
            this.MessageBox_Warnings.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Warnings.Text = null;
            // 
            // MessageBox_Ok
            // 
            this.MessageBox_Ok.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Ok.Caption = null;
            this.MessageBox_Ok.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageBox_Ok.Parent = null;
            this.MessageBox_Ok.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Ok.Text = null;
            // 
            // MessageBox_Error
            // 
            this.MessageBox_Error.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Error.Caption = null;
            this.MessageBox_Error.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            this.MessageBox_Error.Parent = null;
            this.MessageBox_Error.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Error.Text = null;
            // 
            // MessageBox_Question
            // 
            this.MessageBox_Question.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            this.MessageBox_Question.Caption = null;
            this.MessageBox_Question.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            this.MessageBox_Question.Parent = null;
            this.MessageBox_Question.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Question.Text = null;
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // Ver_EditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 404);
            this.Controls.Add(this.GroupBox_VerProd);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ver_EditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver_EditarProducto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.GroupBox_VerProd.ResumeLayout(false);
            this.GroupBox_EditarProd.ResumeLayout(false);
            this.GroupBox_EditarProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2TextBox txtNameP;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label7;
        public Guna.UI2.WinForms.Guna2TextBox txtCodBarra;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2TextBox txtObservacion;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2NumericUpDown SpinExist;
        private System.Windows.Forms.Label label6;
        public Guna.UI2.WinForms.Guna2TextBox Txt_IDProd;
        private Guna.UI2.WinForms.Guna2Button Btn_AddProducto;
        public System.Windows.Forms.GroupBox GroupBox_EditarProd;
        public System.Windows.Forms.GroupBox GroupBox_VerProd;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox Cbx_Estados;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Import;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Warnings;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Ok;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Error;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Question;
        public Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}