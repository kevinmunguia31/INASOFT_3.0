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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ver_EditarProducto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.Lb_titulo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.MessageBox_Import = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Warnings = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Ok = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Error = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Question = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.GroupBox_EditarProd = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtBuscar_Productos = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Lb_CantStocks = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Cbx_Productos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SpinExis_Min = new Guna.UI2.WinForms.Guna2NumericUpDown();
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
            this.button2 = new System.Windows.Forms.Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Rbttn_ExistProduct = new System.Windows.Forms.RadioButton();
            this.Rbttn_NewProduct = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.GroupBox_EditarProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExis_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExist)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.Lb_titulo);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 36);
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
            this.btnClose.Location = new System.Drawing.Point(608, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Lb_titulo
            // 
            this.Lb_titulo.AutoSize = true;
            this.Lb_titulo.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold);
            this.Lb_titulo.ForeColor = System.Drawing.Color.White;
            this.Lb_titulo.Location = new System.Drawing.Point(43, 3);
            this.Lb_titulo.Name = "Lb_titulo";
            this.Lb_titulo.Size = new System.Drawing.Size(119, 26);
            this.Lb_titulo.TabIndex = 1;
            this.Lb_titulo.Text = "Ver Productos";
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
            // GroupBox_EditarProd
            // 
            this.GroupBox_EditarProd.Controls.Add(this.button1);
            this.GroupBox_EditarProd.Controls.Add(this.TxtBuscar_Productos);
            this.GroupBox_EditarProd.Controls.Add(this.label13);
            this.GroupBox_EditarProd.Controls.Add(this.Lb_CantStocks);
            this.GroupBox_EditarProd.Controls.Add(this.label16);
            this.GroupBox_EditarProd.Controls.Add(this.Cbx_Productos);
            this.GroupBox_EditarProd.Controls.Add(this.label5);
            this.GroupBox_EditarProd.Controls.Add(this.SpinExis_Min);
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
            this.GroupBox_EditarProd.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox_EditarProd.Location = new System.Drawing.Point(0, 105);
            this.GroupBox_EditarProd.Name = "GroupBox_EditarProd";
            this.GroupBox_EditarProd.Size = new System.Drawing.Size(653, 360);
            this.GroupBox_EditarProd.TabIndex = 88;
            this.GroupBox_EditarProd.TabStop = false;
            this.GroupBox_EditarProd.Text = "Realizar Remesa";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(350, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 31);
            this.button1.TabIndex = 109;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtBuscar_Productos
            // 
            this.TxtBuscar_Productos.Animated = true;
            this.TxtBuscar_Productos.BackColor = System.Drawing.Color.Transparent;
            this.TxtBuscar_Productos.BackgroundImage = global::INASOFT_3._0.Properties.Resources.icons8_search_20px;
            this.TxtBuscar_Productos.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtBuscar_Productos.BorderRadius = 5;
            this.TxtBuscar_Productos.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.TxtBuscar_Productos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtBuscar_Productos.DefaultText = "";
            this.TxtBuscar_Productos.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtBuscar_Productos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtBuscar_Productos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtBuscar_Productos.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtBuscar_Productos.FillColor = System.Drawing.SystemColors.Control;
            this.TxtBuscar_Productos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtBuscar_Productos.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar_Productos.ForeColor = System.Drawing.Color.Black;
            this.TxtBuscar_Productos.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtBuscar_Productos.IconLeft = global::INASOFT_3._0.Properties.Resources.icons8_search_20px;
            this.TxtBuscar_Productos.Location = new System.Drawing.Point(213, 50);
            this.TxtBuscar_Productos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtBuscar_Productos.Name = "TxtBuscar_Productos";
            this.TxtBuscar_Productos.PasswordChar = '\0';
            this.TxtBuscar_Productos.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.TxtBuscar_Productos.PlaceholderText = "Buscar productos";
            this.TxtBuscar_Productos.SelectedText = "";
            this.TxtBuscar_Productos.Size = new System.Drawing.Size(131, 30);
            this.TxtBuscar_Productos.TabIndex = 108;
            this.TxtBuscar_Productos.TextChanged += new System.EventHandler(this.TxtBuscar_Productos_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(405, 206);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 22);
            this.label13.TabIndex = 106;
            this.label13.Text = "Cant. Stock:";
            // 
            // Lb_CantStocks
            // 
            this.Lb_CantStocks.AutoSize = true;
            this.Lb_CantStocks.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_CantStocks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Lb_CantStocks.Location = new System.Drawing.Point(405, 226);
            this.Lb_CantStocks.Name = "Lb_CantStocks";
            this.Lb_CantStocks.Size = new System.Drawing.Size(24, 22);
            this.Lb_CantStocks.TabIndex = 107;
            this.Lb_CantStocks.Text = "--";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(12, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 22);
            this.label16.TabIndex = 105;
            this.label16.Text = "Productos:";
            // 
            // Cbx_Productos
            // 
            this.Cbx_Productos.BackColor = System.Drawing.SystemColors.Control;
            this.Cbx_Productos.DropDownHeight = 90;
            this.Cbx_Productos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx_Productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cbx_Productos.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Productos.FormattingEnabled = true;
            this.Cbx_Productos.IntegralHeight = false;
            this.Cbx_Productos.Location = new System.Drawing.Point(16, 50);
            this.Cbx_Productos.Name = "Cbx_Productos";
            this.Cbx_Productos.Size = new System.Drawing.Size(191, 30);
            this.Cbx_Productos.TabIndex = 104;
            this.Cbx_Productos.SelectedIndexChanged += new System.EventHandler(this.Cbx_Productos_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(405, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 103;
            this.label5.Text = "Cant. comprada:";
            // 
            // SpinExis_Min
            // 
            this.SpinExis_Min.BackColor = System.Drawing.SystemColors.Control;
            this.SpinExis_Min.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpinExis_Min.FillColor = System.Drawing.SystemColors.Control;
            this.SpinExis_Min.Font = new System.Drawing.Font("Poppins", 9F);
            this.SpinExis_Min.Location = new System.Drawing.Point(543, 274);
            this.SpinExis_Min.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpinExis_Min.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.SpinExis_Min.Name = "SpinExis_Min";
            this.SpinExis_Min.Size = new System.Drawing.Size(94, 30);
            this.SpinExis_Min.TabIndex = 102;
            this.SpinExis_Min.UpDownButtonFillColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SpinExis_Min.UpDownButtonForeColor = System.Drawing.Color.White;
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
            this.Cbx_Estados.Location = new System.Drawing.Point(405, 170);
            this.Cbx_Estados.Name = "Cbx_Estados";
            this.Cbx_Estados.Size = new System.Drawing.Size(191, 30);
            this.Cbx_Estados.TabIndex = 101;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(405, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 22);
            this.label8.TabIndex = 100;
            this.label8.Text = "Estado:";
            // 
            // Btn_AddProducto
            // 
            this.Btn_AddProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_AddProducto.BorderRadius = 8;
            this.Btn_AddProducto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Btn_AddProducto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Btn_AddProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Btn_AddProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Btn_AddProducto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.Btn_AddProducto.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AddProducto.ForeColor = System.Drawing.Color.White;
            this.Btn_AddProducto.Image = ((System.Drawing.Image)(resources.GetObject("Btn_AddProducto.Image")));
            this.Btn_AddProducto.Location = new System.Drawing.Point(510, 322);
            this.Btn_AddProducto.Name = "Btn_AddProducto";
            this.Btn_AddProducto.Size = new System.Drawing.Size(137, 32);
            this.Btn_AddProducto.TabIndex = 98;
            this.Btn_AddProducto.Text = "Confirmar";
            this.Btn_AddProducto.Click += new System.EventHandler(this.Btn_AddProducto_Click_1);
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
            this.Txt_IDProd.Location = new System.Drawing.Point(618, 12);
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
            this.txtPrecioCompra.Location = new System.Drawing.Point(405, 51);
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
            this.label2.Location = new System.Drawing.Point(539, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Exist. Minimas:";
            // 
            // SpinExist
            // 
            this.SpinExist.BackColor = System.Drawing.SystemColors.Control;
            this.SpinExist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpinExist.FillColor = System.Drawing.SystemColors.Control;
            this.SpinExist.Font = new System.Drawing.Font("Poppins", 9F);
            this.SpinExist.Location = new System.Drawing.Point(405, 274);
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
            this.label6.Location = new System.Drawing.Point(405, 31);
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
            this.txtCodBarra.Location = new System.Drawing.Point(16, 104);
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
            this.label1.Location = new System.Drawing.Point(12, 78);
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
            this.txtObservacion.Location = new System.Drawing.Point(16, 226);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtObservacion.PlaceholderText = "Observaciones";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.SelectedText = "";
            this.txtObservacion.Size = new System.Drawing.Size(328, 77);
            this.txtObservacion.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 200);
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
            this.label4.Location = new System.Drawing.Point(12, 138);
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
            this.txtNameP.Location = new System.Drawing.Point(16, 164);
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
            this.txtPrecioVenta.Location = new System.Drawing.Point(405, 110);
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
            this.label7.Location = new System.Drawing.Point(401, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio de venta:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Image = global::INASOFT_3._0.Properties.Resources.icons8_invisible_20px1;
            this.button2.Location = new System.Drawing.Point(608, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 108;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.Rbttn_ExistProduct);
            this.groupBox1.Controls.Add(this.Rbttn_NewProduct);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 63);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de remesa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(405, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 22);
            this.label9.TabIndex = 108;
            this.label9.Text = "Ver productos en el inventario:";
            // 
            // Rbttn_ExistProduct
            // 
            this.Rbttn_ExistProduct.AutoSize = true;
            this.Rbttn_ExistProduct.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbttn_ExistProduct.Location = new System.Drawing.Point(187, 24);
            this.Rbttn_ExistProduct.Name = "Rbttn_ExistProduct";
            this.Rbttn_ExistProduct.Size = new System.Drawing.Size(136, 26);
            this.Rbttn_ExistProduct.TabIndex = 1;
            this.Rbttn_ExistProduct.TabStop = true;
            this.Rbttn_ExistProduct.Text = "Producto Existente";
            this.Rbttn_ExistProduct.UseVisualStyleBackColor = true;
            this.Rbttn_ExistProduct.CheckedChanged += new System.EventHandler(this.Rbttn_ExistProduct_CheckedChanged);
            // 
            // Rbttn_NewProduct
            // 
            this.Rbttn_NewProduct.AutoSize = true;
            this.Rbttn_NewProduct.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbttn_NewProduct.Location = new System.Drawing.Point(16, 24);
            this.Rbttn_NewProduct.Name = "Rbttn_NewProduct";
            this.Rbttn_NewProduct.Size = new System.Drawing.Size(124, 26);
            this.Rbttn_NewProduct.TabIndex = 0;
            this.Rbttn_NewProduct.TabStop = true;
            this.Rbttn_NewProduct.Text = "Nuevo producto";
            this.Rbttn_NewProduct.UseVisualStyleBackColor = true;
            this.Rbttn_NewProduct.CheckedChanged += new System.EventHandler(this.Rbttn_NewProduct_CheckedChanged);
            // 
            // Ver_EditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox_EditarProd);
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
            this.GroupBox_EditarProd.ResumeLayout(false);
            this.GroupBox_EditarProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExis_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExist)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Import;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Warnings;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Ok;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Error;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Question;
        public Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        public System.Windows.Forms.Label Lb_titulo;
        public System.Windows.Forms.GroupBox GroupBox_EditarProd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2NumericUpDown SpinExis_Min;
        public System.Windows.Forms.ComboBox Cbx_Estados;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button Btn_AddProducto;
        public Guna.UI2.WinForms.Guna2TextBox Txt_IDProd;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioCompra;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2NumericUpDown SpinExist;
        private System.Windows.Forms.Label label6;
        public Guna.UI2.WinForms.Guna2TextBox txtCodBarra;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2TextBox txtObservacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2TextBox txtNameP;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioVenta;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton Rbttn_NewProduct;
        public System.Windows.Forms.ComboBox Cbx_Productos;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button button1;
        public Guna.UI2.WinForms.Guna2TextBox TxtBuscar_Productos;
        public System.Windows.Forms.Label Lb_CantStocks;
        public System.Windows.Forms.RadioButton Rbttn_ExistProduct;
    }
}