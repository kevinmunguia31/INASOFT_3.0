
namespace INASOFT_3._0.UserControls
{
    partial class UC_Productos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Productos));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existenciasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciocompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioventaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciodolarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciototalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editar = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbProveedor = new System.Windows.Forms.Label();
            this.lbObservaciones = new System.Windows.Forms.Label();
            this.lbPrecioTotal = new System.Windows.Forms.Label();
            this.lbPrecioDolar = new System.Windows.Forms.Label();
            this.lbPrecioVenta = new System.Windows.Forms.Label();
            this.lbPrecioCompra = new System.Windows.Forms.Label();
            this.lbExistencias = new System.Windows.Forms.Label();
            this.lbNameP = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbCapital = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbCantiTota = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2CircleButton();
            this.MessageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogInfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogWar = new Guna.UI2.WinForms.Guna2MessageDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(27, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Productos En Inventario";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(148)))), ((int)(((byte)(242)))));
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.codigoDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.existenciasDataGridViewTextBoxColumn,
            this.preciocompraDataGridViewTextBoxColumn,
            this.precioventaDataGridViewTextBoxColumn,
            this.preciodolarDataGridViewTextBoxColumn,
            this.preciototalDataGridViewTextBoxColumn,
            this.observacionDataGridViewTextBoxColumn,
            this.idproveedorDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.productosBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(33, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 324);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 46;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            this.codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            this.codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            this.codigoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoDataGridViewTextBoxColumn.Width = 81;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 86;
            // 
            // existenciasDataGridViewTextBoxColumn
            // 
            this.existenciasDataGridViewTextBoxColumn.DataPropertyName = "Existencias";
            this.existenciasDataGridViewTextBoxColumn.HeaderText = "Existencias";
            this.existenciasDataGridViewTextBoxColumn.Name = "existenciasDataGridViewTextBoxColumn";
            this.existenciasDataGridViewTextBoxColumn.ReadOnly = true;
            this.existenciasDataGridViewTextBoxColumn.Width = 105;
            // 
            // preciocompraDataGridViewTextBoxColumn
            // 
            this.preciocompraDataGridViewTextBoxColumn.DataPropertyName = "Precio_compra";
            this.preciocompraDataGridViewTextBoxColumn.HeaderText = "Precio_compra";
            this.preciocompraDataGridViewTextBoxColumn.Name = "preciocompraDataGridViewTextBoxColumn";
            this.preciocompraDataGridViewTextBoxColumn.ReadOnly = true;
            this.preciocompraDataGridViewTextBoxColumn.Width = 136;
            // 
            // precioventaDataGridViewTextBoxColumn
            // 
            this.precioventaDataGridViewTextBoxColumn.DataPropertyName = "Precio_venta";
            this.precioventaDataGridViewTextBoxColumn.HeaderText = "Precio_venta";
            this.precioventaDataGridViewTextBoxColumn.Name = "precioventaDataGridViewTextBoxColumn";
            this.precioventaDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioventaDataGridViewTextBoxColumn.Width = 121;
            // 
            // preciodolarDataGridViewTextBoxColumn
            // 
            this.preciodolarDataGridViewTextBoxColumn.DataPropertyName = "Precio_dolar";
            this.preciodolarDataGridViewTextBoxColumn.HeaderText = "Precio_dolar";
            this.preciodolarDataGridViewTextBoxColumn.Name = "preciodolarDataGridViewTextBoxColumn";
            this.preciodolarDataGridViewTextBoxColumn.ReadOnly = true;
            this.preciodolarDataGridViewTextBoxColumn.Width = 118;
            // 
            // preciototalDataGridViewTextBoxColumn
            // 
            this.preciototalDataGridViewTextBoxColumn.DataPropertyName = "Precio_total";
            this.preciototalDataGridViewTextBoxColumn.HeaderText = "Precio_total";
            this.preciototalDataGridViewTextBoxColumn.Name = "preciototalDataGridViewTextBoxColumn";
            this.preciototalDataGridViewTextBoxColumn.ReadOnly = true;
            this.preciototalDataGridViewTextBoxColumn.Width = 114;
            // 
            // observacionDataGridViewTextBoxColumn
            // 
            this.observacionDataGridViewTextBoxColumn.DataPropertyName = "Observacion";
            this.observacionDataGridViewTextBoxColumn.HeaderText = "Observacion";
            this.observacionDataGridViewTextBoxColumn.Name = "observacionDataGridViewTextBoxColumn";
            this.observacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionDataGridViewTextBoxColumn.Width = 116;
            // 
            // idproveedorDataGridViewTextBoxColumn
            // 
            this.idproveedorDataGridViewTextBoxColumn.DataPropertyName = "Id_proveedor";
            this.idproveedorDataGridViewTextBoxColumn.HeaderText = "Id_proveedor";
            this.idproveedorDataGridViewTextBoxColumn.Name = "idproveedorDataGridViewTextBoxColumn";
            this.idproveedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idproveedorDataGridViewTextBoxColumn.Width = 123;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editar,
            this.eliminar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            // 
            // editar
            // 
            this.editar.Image = ((System.Drawing.Image)(resources.GetObject("editar.Image")));
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(169, 22);
            this.editar.Text = "Editar Producto";
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // eliminar
            // 
            this.eliminar.Image = ((System.Drawing.Image)(resources.GetObject("eliminar.Image")));
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(169, 22);
            this.eliminar.Text = "Eliminar Producto";
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataSource = typeof(INASOFT_3._0.Modelos.Productos);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.lbProveedor);
            this.groupBox1.Controls.Add(this.lbObservaciones);
            this.groupBox1.Controls.Add(this.lbPrecioTotal);
            this.groupBox1.Controls.Add(this.lbPrecioDolar);
            this.groupBox1.Controls.Add(this.lbPrecioVenta);
            this.groupBox1.Controls.Add(this.lbPrecioCompra);
            this.groupBox1.Controls.Add(this.lbExistencias);
            this.groupBox1.Controls.Add(this.lbNameP);
            this.groupBox1.Controls.Add(this.lbCodigo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 179);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles del Producto:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(11, 19);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(32, 27);
            this.txtID.TabIndex = 18;
            // 
            // lbProveedor
            // 
            this.lbProveedor.AutoSize = true;
            this.lbProveedor.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProveedor.Location = new System.Drawing.Point(853, 130);
            this.lbProveedor.Name = "lbProveedor";
            this.lbProveedor.Size = new System.Drawing.Size(27, 25);
            this.lbProveedor.TabIndex = 17;
            this.lbProveedor.Text = ".....";
            // 
            // lbObservaciones
            // 
            this.lbObservaciones.AutoSize = true;
            this.lbObservaciones.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObservaciones.Location = new System.Drawing.Point(887, 85);
            this.lbObservaciones.Name = "lbObservaciones";
            this.lbObservaciones.Size = new System.Drawing.Size(27, 25);
            this.lbObservaciones.TabIndex = 16;
            this.lbObservaciones.Text = ".....";
            // 
            // lbPrecioTotal
            // 
            this.lbPrecioTotal.AutoSize = true;
            this.lbPrecioTotal.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioTotal.Location = new System.Drawing.Point(967, 42);
            this.lbPrecioTotal.Name = "lbPrecioTotal";
            this.lbPrecioTotal.Size = new System.Drawing.Size(27, 25);
            this.lbPrecioTotal.TabIndex = 15;
            this.lbPrecioTotal.Text = ".....";
            // 
            // lbPrecioDolar
            // 
            this.lbPrecioDolar.AutoSize = true;
            this.lbPrecioDolar.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioDolar.Location = new System.Drawing.Point(535, 130);
            this.lbPrecioDolar.Name = "lbPrecioDolar";
            this.lbPrecioDolar.Size = new System.Drawing.Size(27, 25);
            this.lbPrecioDolar.TabIndex = 14;
            this.lbPrecioDolar.Text = ".....";
            // 
            // lbPrecioVenta
            // 
            this.lbPrecioVenta.AutoSize = true;
            this.lbPrecioVenta.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioVenta.Location = new System.Drawing.Point(543, 85);
            this.lbPrecioVenta.Name = "lbPrecioVenta";
            this.lbPrecioVenta.Size = new System.Drawing.Size(27, 25);
            this.lbPrecioVenta.TabIndex = 13;
            this.lbPrecioVenta.Text = ".....";
            // 
            // lbPrecioCompra
            // 
            this.lbPrecioCompra.AutoSize = true;
            this.lbPrecioCompra.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecioCompra.Location = new System.Drawing.Point(561, 42);
            this.lbPrecioCompra.Name = "lbPrecioCompra";
            this.lbPrecioCompra.Size = new System.Drawing.Size(27, 25);
            this.lbPrecioCompra.TabIndex = 12;
            this.lbPrecioCompra.Text = ".....";
            // 
            // lbExistencias
            // 
            this.lbExistencias.AutoSize = true;
            this.lbExistencias.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExistencias.Location = new System.Drawing.Point(98, 130);
            this.lbExistencias.Name = "lbExistencias";
            this.lbExistencias.Size = new System.Drawing.Size(27, 25);
            this.lbExistencias.TabIndex = 11;
            this.lbExistencias.Text = ".....";
            // 
            // lbNameP
            // 
            this.lbNameP.AutoSize = true;
            this.lbNameP.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameP.Location = new System.Drawing.Point(81, 85);
            this.lbNameP.Name = "lbNameP";
            this.lbNameP.Size = new System.Drawing.Size(27, 25);
            this.lbNameP.TabIndex = 10;
            this.lbNameP.Text = ".....";
            // 
            // lbCodigo
            // 
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(81, 42);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(27, 25);
            this.lbCodigo.TabIndex = 9;
            this.lbCodigo.Text = ".....";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(766, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 25);
            this.label8.TabIndex = 8;
            this.label8.Text = "Proveedor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(766, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Observaciones:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(766, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "Precio Total (Exit*Unid): C$ ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(396, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Precio en Dolar: U$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(396, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Precio de Venta: C$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(396, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Precio de Compra: C$";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Existencias:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Codigo:";
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.BorderColor = System.Drawing.Color.Purple;
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Poppins", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(844, 7);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Buscar Producto";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(216, 33);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.Font = new System.Drawing.Font("Poppins Medium", 12F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1066, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 34);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbCapital);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lbCantiTota);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(1172, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 329);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lbCapital
            // 
            this.lbCapital.AutoSize = true;
            this.lbCapital.Font = new System.Drawing.Font("Poppins SemiBold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCapital.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbCapital.Location = new System.Drawing.Point(9, 205);
            this.lbCapital.Name = "lbCapital";
            this.lbCapital.Size = new System.Drawing.Size(37, 48);
            this.lbCapital.TabIndex = 4;
            this.lbCapital.Text = "0";
            this.lbCapital.Click += new System.EventHandler(this.lbCapital_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Poppins SemiBold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(44, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 48);
            this.label13.TabIndex = 3;
            this.label13.Text = "C$";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "Total Invertido:";
            // 
            // lbCantiTota
            // 
            this.lbCantiTota.AutoSize = true;
            this.lbCantiTota.Font = new System.Drawing.Font("Poppins SemiBold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantiTota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbCantiTota.Location = new System.Drawing.Point(60, 41);
            this.lbCantiTota.Name = "lbCantiTota";
            this.lbCantiTota.Size = new System.Drawing.Size(47, 60);
            this.lbCantiTota.TabIndex = 1;
            this.lbCantiTota.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Total de Productos";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAdd.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(1171, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(182, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Añadir Producto";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(797, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnRefresh.Size = new System.Drawing.Size(39, 40);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MessageDialog
            // 
            this.MessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            this.MessageDialog.Caption = null;
            this.MessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            this.MessageDialog.Parent = null;
            this.MessageDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialog.Text = null;
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
            // MessageDialogWar
            // 
            this.MessageDialogWar.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageDialogWar.Caption = null;
            this.MessageDialogWar.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.MessageDialogWar.Parent = null;
            this.MessageDialogWar.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialogWar.Text = null;
            // 
            // UC_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "UC_Productos";
            this.Size = new System.Drawing.Size(1360, 585);
            this.Load += new System.EventHandler(this.UC_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn existenciasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciocompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioventaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciodolarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciototalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbNameP;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.Label lbProveedor;
        private System.Windows.Forms.Label lbObservaciones;
        private System.Windows.Forms.Label lbPrecioTotal;
        private System.Windows.Forms.Label lbPrecioDolar;
        private System.Windows.Forms.Label lbPrecioVenta;
        private System.Windows.Forms.Label lbPrecioCompra;
        private System.Windows.Forms.Label lbExistencias;
        private System.Windows.Forms.TextBox txtID;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbCantiTota;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbCapital;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editar;
        private System.Windows.Forms.ToolStripMenuItem eliminar;
        private Guna.UI2.WinForms.Guna2CircleButton btnRefresh;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialog;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogInfo;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogWar;
    }
}
