﻿
namespace INASOFT_3._0.VistaFacturas
{
    partial class DetalleFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleFactura));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lbSubtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbClienteName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbIdFactura = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtBuscar_Productos = new Guna.UI2.WinForms.Guna2TextBox();
            this.Cbx_Productos = new System.Windows.Forms.ComboBox();
            this.btnAccept = new Guna.UI2.WinForms.Guna2Button();
            this.txtIdDetalleFactura = new System.Windows.Forms.TextBox();
            this.btnAñadirProducto = new Guna.UI2.WinForms.Guna2Button();
            this.SpinCantidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdProduc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lbExistencias = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.MessageDialogError = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogWar = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogInfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.btnBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 48);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(949, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "2. Agregar Productos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.txtIdFactura);
            this.guna2GroupBox1.Controls.Add(this.txtIdCliente);
            this.guna2GroupBox1.Controls.Add(this.lbSubtotal);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.lbClienteName);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.lbIdFactura);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(16, 55);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(973, 137);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "Información de la Factura";
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(240, 48);
            this.txtIdFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Size = new System.Drawing.Size(39, 28);
            this.txtIdFactura.TabIndex = 7;
            this.txtIdFactura.Text = "11";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(347, 48);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(39, 28);
            this.txtIdCliente.TabIndex = 6;
            this.txtIdCliente.Text = "2";
            // 
            // lbSubtotal
            // 
            this.lbSubtotal.AutoSize = true;
            this.lbSubtotal.BackColor = System.Drawing.Color.White;
            this.lbSubtotal.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubtotal.Location = new System.Drawing.Point(818, 75);
            this.lbSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSubtotal.Name = "lbSubtotal";
            this.lbSubtotal.Size = new System.Drawing.Size(64, 27);
            this.lbSubtotal.TabIndex = 5;
            this.lbSubtotal.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Poppins", 14F);
            this.label7.Location = new System.Drawing.Point(647, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 42);
            this.label7.TabIndex = 4;
            this.label7.Text = "Subtotal: C$";
            // 
            // lbClienteName
            // 
            this.lbClienteName.AutoSize = true;
            this.lbClienteName.BackColor = System.Drawing.Color.White;
            this.lbClienteName.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClienteName.Location = new System.Drawing.Point(428, 70);
            this.lbClienteName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbClienteName.Name = "lbClienteName";
            this.lbClienteName.Size = new System.Drawing.Size(86, 40);
            this.lbClienteName.TabIndex = 3;
            this.lbClienteName.Text = "name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 40);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cliente:";
            // 
            // lbIdFactura
            // 
            this.lbIdFactura.AutoSize = true;
            this.lbIdFactura.BackColor = System.Drawing.Color.White;
            this.lbIdFactura.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdFactura.Location = new System.Drawing.Point(175, 77);
            this.lbIdFactura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIdFactura.Name = "lbIdFactura";
            this.lbIdFactura.Size = new System.Drawing.Size(38, 27);
            this.lbIdFactura.TabIndex = 1;
            this.lbIdFactura.Text = "11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 40);
            this.label2.TabIndex = 0;
            this.label2.Text = "Factura No:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Controls.Add(this.dataGridView1);
            this.btnBuscar.Controls.Add(this.button1);
            this.btnBuscar.Controls.Add(this.TxtBuscar_Productos);
            this.btnBuscar.Controls.Add(this.Cbx_Productos);
            this.btnBuscar.Controls.Add(this.btnAccept);
            this.btnBuscar.Controls.Add(this.txtIdDetalleFactura);
            this.btnBuscar.Controls.Add(this.btnAñadirProducto);
            this.btnBuscar.Controls.Add(this.SpinCantidad);
            this.btnBuscar.Controls.Add(this.label3);
            this.btnBuscar.Controls.Add(this.txtIdProduc);
            this.btnBuscar.Controls.Add(this.groupBox1);
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Location = new System.Drawing.Point(16, 200);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(973, 598);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Añadir Productos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 295);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(924, 219);
            this.dataGridView1.TabIndex = 82;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseClick);
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
            this.button1.Location = new System.Drawing.Point(784, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 55);
            this.button1.TabIndex = 81;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TxtBuscar_Productos
            // 
            this.TxtBuscar_Productos.Animated = true;
            this.TxtBuscar_Productos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtBuscar_Productos.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtBuscar_Productos.BorderRadius = 5;
            this.TxtBuscar_Productos.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.TxtBuscar_Productos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtBuscar_Productos.DefaultText = "";
            this.TxtBuscar_Productos.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtBuscar_Productos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtBuscar_Productos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtBuscar_Productos.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtBuscar_Productos.FillColor = System.Drawing.SystemColors.Window;
            this.TxtBuscar_Productos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtBuscar_Productos.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar_Productos.ForeColor = System.Drawing.Color.Black;
            this.TxtBuscar_Productos.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtBuscar_Productos.Location = new System.Drawing.Point(445, 66);
            this.TxtBuscar_Productos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtBuscar_Productos.Name = "TxtBuscar_Productos";
            this.TxtBuscar_Productos.PasswordChar = '\0';
            this.TxtBuscar_Productos.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.TxtBuscar_Productos.PlaceholderText = "Buscar productos";
            this.TxtBuscar_Productos.SelectedText = "";
            this.TxtBuscar_Productos.Size = new System.Drawing.Size(331, 46);
            this.TxtBuscar_Productos.TabIndex = 74;
            this.TxtBuscar_Productos.TextChanged += new System.EventHandler(this.TxtBuscar_Productos_TextChanged);
            // 
            // Cbx_Productos
            // 
            this.Cbx_Productos.DropDownHeight = 90;
            this.Cbx_Productos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx_Productos.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Productos.FormattingEnabled = true;
            this.Cbx_Productos.IntegralHeight = false;
            this.Cbx_Productos.Location = new System.Drawing.Point(25, 71);
            this.Cbx_Productos.Margin = new System.Windows.Forms.Padding(4);
            this.Cbx_Productos.Name = "Cbx_Productos";
            this.Cbx_Productos.Size = new System.Drawing.Size(412, 39);
            this.Cbx_Productos.TabIndex = 73;
            this.Cbx_Productos.SelectedIndexChanged += new System.EventHandler(this.Cbx_Productos_SelectedIndexChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.BorderRadius = 10;
            this.btnAccept.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAccept.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAccept.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAccept.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAccept.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.Location = new System.Drawing.Point(324, 528);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(313, 46);
            this.btnAccept.TabIndex = 26;
            this.btnAccept.Text = "Aceptar y Continuar";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtIdDetalleFactura
            // 
            this.txtIdDetalleFactura.Location = new System.Drawing.Point(901, 521);
            this.txtIdDetalleFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdDetalleFactura.Name = "txtIdDetalleFactura";
            this.txtIdDetalleFactura.Size = new System.Drawing.Size(47, 28);
            this.txtIdDetalleFactura.TabIndex = 25;
            // 
            // btnAñadirProducto
            // 
            this.btnAñadirProducto.BorderRadius = 10;
            this.btnAñadirProducto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAñadirProducto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAñadirProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAñadirProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAñadirProducto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAñadirProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAñadirProducto.ForeColor = System.Drawing.Color.White;
            this.btnAñadirProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnAñadirProducto.Image")));
            this.btnAñadirProducto.Location = new System.Drawing.Point(625, 230);
            this.btnAñadirProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(259, 46);
            this.btnAñadirProducto.TabIndex = 23;
            this.btnAñadirProducto.Text = "Añadir Producto";
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // SpinCantidad
            // 
            this.SpinCantidad.BackColor = System.Drawing.Color.Transparent;
            this.SpinCantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpinCantidad.Font = new System.Drawing.Font("Poppins", 11F);
            this.SpinCantidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SpinCantidad.Location = new System.Drawing.Point(156, 230);
            this.SpinCantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpinCantidad.Name = "SpinCantidad";
            this.SpinCantidad.Size = new System.Drawing.Size(93, 46);
            this.SpinCantidad.TabIndex = 22;
            this.SpinCantidad.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SpinCantidad.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(32, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cantidad:";
            // 
            // txtIdProduc
            // 
            this.txtIdProduc.Location = new System.Drawing.Point(907, 91);
            this.txtIdProduc.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdProduc.Name = "txtIdProduc";
            this.txtIdProduc.Size = new System.Drawing.Size(47, 28);
            this.txtIdProduc.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.lbExistencias);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbProductName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(25, 128);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(924, 91);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(581, 30);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 28);
            this.txtPrecio.TabIndex = 13;
            // 
            // lbExistencias
            // 
            this.lbExistencias.AutoSize = true;
            this.lbExistencias.BackColor = System.Drawing.Color.White;
            this.lbExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbExistencias.Location = new System.Drawing.Point(853, 32);
            this.lbExistencias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExistencias.Name = "lbExistencias";
            this.lbExistencias.Size = new System.Drawing.Size(25, 26);
            this.lbExistencias.TabIndex = 12;
            this.lbExistencias.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label10.Location = new System.Drawing.Point(725, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 26);
            this.label10.TabIndex = 11;
            this.label10.Text = "Existencias:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label8.Location = new System.Drawing.Point(460, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 26);
            this.label8.TabIndex = 9;
            this.label8.Text = "Precio: C$";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.BackColor = System.Drawing.Color.White;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbProductName.Location = new System.Drawing.Point(139, 33);
            this.lbProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(21, 24);
            this.lbProductName.TabIndex = 8;
            this.lbProductName.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(16, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Producto:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarProductoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(220, 32);
            // 
            // eliminarProductoToolStripMenuItem
            // 
            this.eliminarProductoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.eliminarProductoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarProductoToolStripMenuItem.Image")));
            this.eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            this.eliminarProductoToolStripMenuItem.Size = new System.Drawing.Size(219, 28);
            this.eliminarProductoToolStripMenuItem.Text = "Eliminar Producto";
            this.eliminarProductoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProductoToolStripMenuItem_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // MessageDialogError
            // 
            this.MessageDialogError.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageDialogError.Caption = null;
            this.MessageDialogError.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            this.MessageDialogError.Parent = null;
            this.MessageDialogError.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialogError.Text = null;
            // 
            // MessageDialogWar
            // 
            this.MessageDialogWar.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageDialogWar.Caption = null;
            this.MessageDialogWar.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.MessageDialogWar.Parent = null;
            this.MessageDialogWar.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialogWar.Text = null;
            // 
            // MessageDialogInfo
            // 
            this.MessageDialogInfo.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageDialogInfo.Caption = null;
            this.MessageDialogInfo.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageDialogInfo.Parent = null;
            this.MessageDialogInfo.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialogInfo.Text = null;
            // 
            // DetalleFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(989, 805);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DetalleFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetalleFactura";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.btnBuscar.ResumeLayout(false);
            this.btnBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpinCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GroupBox btnBuscar;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnAñadirProducto;
        private Guna.UI2.WinForms.Guna2NumericUpDown SpinCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdProduc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbExistencias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdDetalleFactura;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogError;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogWar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogInfo;
        public System.Windows.Forms.TextBox txtIdCliente;
        public System.Windows.Forms.Label lbSubtotal;
        public System.Windows.Forms.Label lbClienteName;
        public System.Windows.Forms.Label lbIdFactura;
        private Guna.UI2.WinForms.Guna2Button btnAccept;
        private System.Windows.Forms.TextBox txtPrecio;
        public Guna.UI2.WinForms.Guna2TextBox TxtBuscar_Productos;
        private System.Windows.Forms.ComboBox Cbx_Productos;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtIdFactura;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}