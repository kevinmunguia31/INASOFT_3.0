﻿
namespace INASOFT_3._0
{
    partial class ADDEDIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADDEDIT));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodBarra = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNameP = new Guna.UI2.WinForms.Guna2TextBox();
            this.SpinExist = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacion = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPrecioCompra = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrecioVenta = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrecioDolar = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbProveedor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDolar = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExist)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 8;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 39);
            this.panel2.TabIndex = 1;
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
            this.btnClose.Location = new System.Drawing.Point(756, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Poppins SemiBold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(42, 2);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(271, 34);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "AÑADIR NUEVO PRODUCTO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SpinExist);
            this.groupBox1.Controls.Add(this.txtNameP);
            this.groupBox1.Controls.Add(this.txtCodBarra);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 279);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtCodBarra
            // 
            this.txtCodBarra.BorderColor = System.Drawing.Color.Silver;
            this.txtCodBarra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodBarra.DefaultText = "";
            this.txtCodBarra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodBarra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodBarra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodBarra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodBarra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodBarra.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtCodBarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCodBarra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodBarra.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtCodBarra.IconLeft")));
            this.txtCodBarra.Location = new System.Drawing.Point(6, 20);
            this.txtCodBarra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodBarra.Name = "txtCodBarra";
            this.txtCodBarra.PasswordChar = '\0';
            this.txtCodBarra.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtCodBarra.PlaceholderText = "Ingrese Codigo de Barra";
            this.txtCodBarra.SelectedText = "";
            this.txtCodBarra.Size = new System.Drawing.Size(335, 39);
            this.txtCodBarra.TabIndex = 0;
            // 
            // txtNameP
            // 
            this.txtNameP.BorderColor = System.Drawing.Color.Silver;
            this.txtNameP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameP.DefaultText = "";
            this.txtNameP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameP.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtNameP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNameP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameP.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtNameP.IconLeft")));
            this.txtNameP.Location = new System.Drawing.Point(6, 67);
            this.txtNameP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameP.Name = "txtNameP";
            this.txtNameP.PasswordChar = '\0';
            this.txtNameP.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNameP.PlaceholderText = "Nombre del Producto";
            this.txtNameP.SelectedText = "";
            this.txtNameP.Size = new System.Drawing.Size(335, 39);
            this.txtNameP.TabIndex = 1;
            // 
            // SpinExist
            // 
            this.SpinExist.BackColor = System.Drawing.Color.Transparent;
            this.SpinExist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpinExist.Font = new System.Drawing.Font("Poppins", 9F);
            this.SpinExist.Location = new System.Drawing.Point(135, 114);
            this.SpinExist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpinExist.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.SpinExist.Name = "SpinExist";
            this.SpinExist.Size = new System.Drawing.Size(206, 34);
            this.SpinExist.TabIndex = 3;
            this.SpinExist.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SpinExist.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Existencias:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.BorderColor = System.Drawing.Color.Silver;
            this.txtObservacion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservacion.DefaultText = "";
            this.txtObservacion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtObservacion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtObservacion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtObservacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservacion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtObservacion.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtObservacion.IconLeft")));
            this.txtObservacion.Location = new System.Drawing.Point(6, 166);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.PasswordChar = '\0';
            this.txtObservacion.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtObservacion.PlaceholderText = "Observaciones";
            this.txtObservacion.SelectedText = "";
            this.txtObservacion.Size = new System.Drawing.Size(335, 87);
            this.txtObservacion.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbProveedor);
            this.groupBox2.Controls.Add(this.txtPrecioDolar);
            this.groupBox2.Controls.Add(this.txtPrecioVenta);
            this.groupBox2.Controls.Add(this.txtPrecioCompra);
            this.groupBox2.Location = new System.Drawing.Point(400, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 279);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.BorderColor = System.Drawing.Color.Silver;
            this.txtPrecioCompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioCompra.DefaultText = "";
            this.txtPrecioCompra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioCompra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioCompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioCompra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioCompra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioCompra.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtPrecioCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioCompra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioCompra.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPrecioCompra.IconLeft")));
            this.txtPrecioCompra.Location = new System.Drawing.Point(6, 20);
            this.txtPrecioCompra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.PasswordChar = '\0';
            this.txtPrecioCompra.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrecioCompra.PlaceholderText = "Precio de Compra";
            this.txtPrecioCompra.SelectedText = "";
            this.txtPrecioCompra.Size = new System.Drawing.Size(335, 39);
            this.txtPrecioCompra.TabIndex = 6;
            this.txtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCompra_KeyPress);
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BorderColor = System.Drawing.Color.Silver;
            this.txtPrecioVenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioVenta.DefaultText = "";
            this.txtPrecioVenta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioVenta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioVenta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioVenta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioVenta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioVenta.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioVenta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioVenta.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPrecioVenta.IconLeft")));
            this.txtPrecioVenta.Location = new System.Drawing.Point(6, 71);
            this.txtPrecioVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.PasswordChar = '\0';
            this.txtPrecioVenta.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrecioVenta.PlaceholderText = "Precio de Venta";
            this.txtPrecioVenta.SelectedText = "";
            this.txtPrecioVenta.Size = new System.Drawing.Size(335, 39);
            this.txtPrecioVenta.TabIndex = 7;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // txtPrecioDolar
            // 
            this.txtPrecioDolar.BorderColor = System.Drawing.Color.Silver;
            this.txtPrecioDolar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecioDolar.DefaultText = "";
            this.txtPrecioDolar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecioDolar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecioDolar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioDolar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecioDolar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioDolar.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtPrecioDolar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrecioDolar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecioDolar.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPrecioDolar.IconLeft")));
            this.txtPrecioDolar.Location = new System.Drawing.Point(6, 123);
            this.txtPrecioDolar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrecioDolar.Name = "txtPrecioDolar";
            this.txtPrecioDolar.PasswordChar = '\0';
            this.txtPrecioDolar.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrecioDolar.PlaceholderText = "Precio En Dolar";
            this.txtPrecioDolar.SelectedText = "";
            this.txtPrecioDolar.Size = new System.Drawing.Size(335, 39);
            this.txtPrecioDolar.TabIndex = 8;
            this.txtPrecioDolar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioDolar_KeyPress);
            // 
            // cbProveedor
            // 
            this.cbProveedor.BackColor = System.Drawing.Color.Transparent;
            this.cbProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbProveedor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbProveedor.ItemHeight = 30;
            this.cbProveedor.Location = new System.Drawing.Point(6, 179);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(335, 36);
            this.cbProveedor.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.btnAdd.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(286, 349);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(226, 45);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Guardar Producto";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(679, 405);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 5;
            // 
            // txtDolar
            // 
            this.txtDolar.BorderColor = System.Drawing.Color.Silver;
            this.txtDolar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDolar.DefaultText = "";
            this.txtDolar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDolar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDolar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDolar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDolar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDolar.Font = new System.Drawing.Font("Poppins", 10F);
            this.txtDolar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDolar.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtDolar.IconLeft")));
            this.txtDolar.Location = new System.Drawing.Point(12, 398);
            this.txtDolar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDolar.Name = "txtDolar";
            this.txtDolar.PasswordChar = '\0';
            this.txtDolar.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDolar.PlaceholderText = "P. Dolar";
            this.txtDolar.SelectedText = "";
            this.txtDolar.Size = new System.Drawing.Size(111, 39);
            this.txtDolar.TabIndex = 10;
            this.txtDolar.TextChanged += new System.EventHandler(this.txtDolar_TextChanged);
            this.txtDolar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDolar_KeyPress);
            // 
            // ADDEDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDolar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ADDEDIT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADDEDIT";
            this.Load += new System.EventHandler(this.ADDEDIT_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinExist)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox txtDolar;
        public Guna.UI2.WinForms.Guna2TextBox txtCodBarra;
        public Guna.UI2.WinForms.Guna2TextBox txtNameP;
        public Guna.UI2.WinForms.Guna2NumericUpDown SpinExist;
        public Guna.UI2.WinForms.Guna2TextBox txtObservacion;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioCompra;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioVenta;
        public Guna.UI2.WinForms.Guna2TextBox txtPrecioDolar;
        public Guna.UI2.WinForms.Guna2ComboBox cbProveedor;
        public System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.TextBox txtId;
    }
}