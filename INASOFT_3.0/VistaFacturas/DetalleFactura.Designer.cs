
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lbSubtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbClienteName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbIdFactura = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAccept = new Guna.UI2.WinForms.Guna2Button();
            this.txtIdDetalleFactura = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAñadirProducto = new Guna.UI2.WinForms.Guna2Button();
            this.SpinCantidad = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdProduc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbExistencias = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtCodigo = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.MessageDialogError = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogWar = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogInfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_Descuento = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.btnBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpinCantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 39);
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
            this.btnClose.Location = new System.Drawing.Point(720, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "2. Agregar Productos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 33);
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
            this.guna2GroupBox1.Controls.Add(this.txtIdCliente);
            this.guna2GroupBox1.Controls.Add(this.lbSubtotal);
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.lbClienteName);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.lbIdFactura);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(12, 45);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(730, 111);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "Información de la Factura";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(260, 39);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(30, 24);
            this.txtIdCliente.TabIndex = 6;
            // 
            // lbSubtotal
            // 
            this.lbSubtotal.AutoSize = true;
            this.lbSubtotal.BackColor = System.Drawing.Color.White;
            this.lbSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbSubtotal.Location = new System.Drawing.Point(613, 62);
            this.lbSubtotal.Name = "lbSubtotal";
            this.lbSubtotal.Size = new System.Drawing.Size(49, 22);
            this.lbSubtotal.TabIndex = 5;
            this.lbSubtotal.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(498, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "Subtotal: C$";
            // 
            // lbClienteName
            // 
            this.lbClienteName.AutoSize = true;
            this.lbClienteName.BackColor = System.Drawing.Color.White;
            this.lbClienteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbClienteName.Location = new System.Drawing.Point(313, 62);
            this.lbClienteName.Name = "lbClienteName";
            this.lbClienteName.Size = new System.Drawing.Size(58, 22);
            this.lbClienteName.TabIndex = 3;
            this.lbClienteName.Text = "name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(239, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cliente:";
            // 
            // lbIdFactura
            // 
            this.lbIdFactura.AutoSize = true;
            this.lbIdFactura.BackColor = System.Drawing.Color.White;
            this.lbIdFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbIdFactura.Location = new System.Drawing.Point(125, 62);
            this.lbIdFactura.Name = "lbIdFactura";
            this.lbIdFactura.Size = new System.Drawing.Size(32, 22);
            this.lbIdFactura.TabIndex = 1;
            this.lbIdFactura.Text = "24";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Factura No:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Controls.Add(this.Txt_Descuento);
            this.btnBuscar.Controls.Add(this.label6);
            this.btnBuscar.Controls.Add(this.btnAccept);
            this.btnBuscar.Controls.Add(this.txtIdDetalleFactura);
            this.btnBuscar.Controls.Add(this.dataGridView1);
            this.btnBuscar.Controls.Add(this.btnAñadirProducto);
            this.btnBuscar.Controls.Add(this.SpinCantidad);
            this.btnBuscar.Controls.Add(this.label3);
            this.btnBuscar.Controls.Add(this.txtIdProduc);
            this.btnBuscar.Controls.Add(this.groupBox1);
            this.btnBuscar.Controls.Add(this.btnSearch);
            this.btnBuscar.Controls.Add(this.txtCodigo);
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Location = new System.Drawing.Point(12, 171);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(730, 519);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Añadir Productos";
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
            this.btnAccept.Location = new System.Drawing.Point(245, 470);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(235, 37);
            this.btnAccept.TabIndex = 26;
            this.btnAccept.Text = "Aceptar y Continuar";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtIdDetalleFactura
            // 
            this.txtIdDetalleFactura.Location = new System.Drawing.Point(678, 209);
            this.txtIdDetalleFactura.Name = "txtIdDetalleFactura";
            this.txtIdDetalleFactura.Size = new System.Drawing.Size(36, 24);
            this.txtIdDetalleFactura.TabIndex = 25;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(148)))), ((int)(((byte)(242)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Total,
            this.id});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(21, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(692, 208);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarProductoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 28);
            // 
            // eliminarProductoToolStripMenuItem
            // 
            this.eliminarProductoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.eliminarProductoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarProductoToolStripMenuItem.Image")));
            this.eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            this.eliminarProductoToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.eliminarProductoToolStripMenuItem.Text = "Eliminar Producto";
            this.eliminarProductoToolStripMenuItem.Click += new System.EventHandler(this.eliminarProductoToolStripMenuItem_Click);
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
            this.btnAñadirProducto.Location = new System.Drawing.Point(468, 201);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(194, 37);
            this.btnAñadirProducto.TabIndex = 23;
            this.btnAñadirProducto.Text = "Añadir Producto";
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // SpinCantidad
            // 
            this.SpinCantidad.BackColor = System.Drawing.Color.Transparent;
            this.SpinCantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SpinCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SpinCantidad.Location = new System.Drawing.Point(116, 201);
            this.SpinCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SpinCantidad.Name = "SpinCantidad";
            this.SpinCantidad.Size = new System.Drawing.Size(70, 37);
            this.SpinCantidad.TabIndex = 22;
            this.SpinCantidad.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.SpinCantidad.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(23, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cantidad:";
            // 
            // txtIdProduc
            // 
            this.txtIdProduc.Location = new System.Drawing.Point(677, 89);
            this.txtIdProduc.Name = "txtIdProduc";
            this.txtIdProduc.Size = new System.Drawing.Size(36, 24);
            this.txtIdProduc.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lbExistencias);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbPrecio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbProductName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(21, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 74);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // lbExistencias
            // 
            this.lbExistencias.AutoSize = true;
            this.lbExistencias.BackColor = System.Drawing.Color.White;
            this.lbExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbExistencias.Location = new System.Drawing.Point(650, 26);
            this.lbExistencias.Name = "lbExistencias";
            this.lbExistencias.Size = new System.Drawing.Size(21, 22);
            this.lbExistencias.TabIndex = 12;
            this.lbExistencias.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label10.Location = new System.Drawing.Point(544, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 22);
            this.label10.TabIndex = 11;
            this.label10.Text = "Existencias:";
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.BackColor = System.Drawing.Color.White;
            this.lbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lbPrecio.Location = new System.Drawing.Point(407, 25);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(21, 22);
            this.lbPrecio.TabIndex = 10;
            this.lbPrecio.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label8.Location = new System.Drawing.Point(313, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 22);
            this.label8.TabIndex = 9;
            this.label8.Text = "Precio: C$";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.BackColor = System.Drawing.Color.White;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lbProductName.Location = new System.Drawing.Point(104, 27);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(17, 18);
            this.lbProductName.TabIndex = 8;
            this.lbProductName.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Producto:";
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(429, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(194, 44);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Buscar Producto";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigo.DefaultText = "";
            this.txtCodigo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCodigo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigo.Location = new System.Drawing.Point(21, 54);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PasswordChar = '\0';
            this.txtCodigo.PlaceholderText = "Ingrese el Codigo del Producto";
            this.txtCodigo.SelectedText = "";
            this.txtCodigo.Size = new System.Drawing.Size(402, 43);
            this.txtCodigo.TabIndex = 0;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label6.Location = new System.Drawing.Point(223, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 22);
            this.label6.TabIndex = 27;
            this.label6.Text = "Descuento";
            // 
            // Txt_Descuento
            // 
            this.Txt_Descuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Txt_Descuento.Location = new System.Drawing.Point(325, 207);
            this.Txt_Descuento.Name = "Txt_Descuento";
            this.Txt_Descuento.Size = new System.Drawing.Size(78, 27);
            this.Txt_Descuento.TabIndex = 28;
            // 
            // DetalleFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 702);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetalleFactura";
            this.Load += new System.EventHandler(this.DetalleFactura_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.btnBuscar.ResumeLayout(false);
            this.btnBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpinCantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GroupBox btnBuscar;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigo;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnAñadirProducto;
        private Guna.UI2.WinForms.Guna2NumericUpDown SpinCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdProduc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbExistencias;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdDetalleFactura;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
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
        private System.Windows.Forms.TextBox Txt_Descuento;
        private System.Windows.Forms.Label label6;
    }
}