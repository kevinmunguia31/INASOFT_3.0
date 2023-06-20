
namespace INASOFT_3._0.UserControls
{
    partial class UC_Factura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Factura));
            this.dataGridFatura = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MessageDialogInfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRango = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearchMonth = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearchDate = new Guna.UI2.WinForms.Guna2Button();
            this.btnFacturaCliente = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.txtNewInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.verDetallesDeLaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFatura)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFatura
            // 
            this.dataGridFatura.AllowUserToAddRows = false;
            this.dataGridFatura.AllowUserToDeleteRows = false;
            this.dataGridFatura.AllowUserToResizeColumns = false;
            this.dataGridFatura.AllowUserToResizeRows = false;
            this.dataGridFatura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridFatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridFatura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridFatura.BackgroundColor = System.Drawing.Color.White;
            this.dataGridFatura.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridFatura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFatura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFatura.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridFatura.EnableHeadersVisualStyles = false;
            this.dataGridFatura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dataGridFatura.Location = new System.Drawing.Point(43, 74);
            this.dataGridFatura.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridFatura.Name = "dataGridFatura";
            this.dataGridFatura.ReadOnly = true;
            this.dataGridFatura.RowHeadersVisible = false;
            this.dataGridFatura.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridFatura.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridFatura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFatura.Size = new System.Drawing.Size(1427, 583);
            this.dataGridFatura.TabIndex = 3;
            this.dataGridFatura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFatura_CellContentClick);
            this.dataGridFatura.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridFatura_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesDeLaFacturaToolStripMenuItem,
            this.eliminarFacturaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(279, 56);
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
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.Controls.Add(this.guna2Button1);
            this.guna2GroupBox1.Controls.Add(this.txtNewInvoice);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(123)))), ((int)(((byte)(200)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(1478, 74);
            this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(393, 226);
            this.guna2GroupBox1.TabIndex = 4;
            this.guna2GroupBox1.Text = "Facturación";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox2.Controls.Add(this.btnRango);
            this.guna2GroupBox2.Controls.Add(this.btnSearchMonth);
            this.guna2GroupBox2.Controls.Add(this.btnSearchDate);
            this.guna2GroupBox2.Controls.Add(this.btnFacturaCliente);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(123)))), ((int)(((byte)(200)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(1478, 308);
            this.guna2GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(393, 349);
            this.guna2GroupBox2.TabIndex = 5;
            this.guna2GroupBox2.Text = "Buscar Facturas";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1616, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 22);
            this.textBox1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(388, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(1811, 9);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 57);
            this.btnRefresh.TabIndex = 82;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRango
            // 
            this.btnRango.BorderRadius = 10;
            this.btnRango.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRango.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRango.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRango.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRango.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRango.FillColor = System.Drawing.Color.Indigo;
            this.btnRango.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRango.ForeColor = System.Drawing.Color.White;
            this.btnRango.Image = ((System.Drawing.Image)(resources.GetObject("btnRango.Image")));
            this.btnRango.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRango.ImageSize = new System.Drawing.Size(25, 25);
            this.btnRango.Location = new System.Drawing.Point(27, 260);
            this.btnRango.Margin = new System.Windows.Forms.Padding(4);
            this.btnRango.Name = "btnRango";
            this.btnRango.Size = new System.Drawing.Size(339, 60);
            this.btnRango.TabIndex = 4;
            this.btnRango.Text = "Buscar por Fecha - Fecha";
            this.btnRango.Click += new System.EventHandler(this.btnRango_Click);
            // 
            // btnSearchMonth
            // 
            this.btnSearchMonth.BorderRadius = 10;
            this.btnSearchMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchMonth.FillColor = System.Drawing.Color.DarkOrchid;
            this.btnSearchMonth.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMonth.ForeColor = System.Drawing.Color.White;
            this.btnSearchMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchMonth.Image")));
            this.btnSearchMonth.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearchMonth.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSearchMonth.Location = new System.Drawing.Point(27, 192);
            this.btnSearchMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchMonth.Name = "btnSearchMonth";
            this.btnSearchMonth.Size = new System.Drawing.Size(339, 60);
            this.btnSearchMonth.TabIndex = 3;
            this.btnSearchMonth.Text = "Buscar por Mes";
            this.btnSearchMonth.Click += new System.EventHandler(this.btnSearchMonth_Click);
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.BorderRadius = 10;
            this.btnSearchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchDate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchDate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchDate.FillColor = System.Drawing.Color.DeepPink;
            this.btnSearchDate.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDate.ForeColor = System.Drawing.Color.White;
            this.btnSearchDate.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchDate.Image")));
            this.btnSearchDate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearchDate.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSearchDate.Location = new System.Drawing.Point(27, 126);
            this.btnSearchDate.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(339, 60);
            this.btnSearchDate.TabIndex = 2;
            this.btnSearchDate.Text = "Buscar Por Fecha";
            this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);
            // 
            // btnFacturaCliente
            // 
            this.btnFacturaCliente.BorderRadius = 10;
            this.btnFacturaCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturaCliente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFacturaCliente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFacturaCliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFacturaCliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFacturaCliente.FillColor = System.Drawing.Color.Purple;
            this.btnFacturaCliente.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaCliente.ForeColor = System.Drawing.Color.White;
            this.btnFacturaCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturaCliente.Image")));
            this.btnFacturaCliente.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFacturaCliente.ImageSize = new System.Drawing.Size(25, 25);
            this.btnFacturaCliente.Location = new System.Drawing.Point(27, 57);
            this.btnFacturaCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacturaCliente.Name = "btnFacturaCliente";
            this.btnFacturaCliente.Size = new System.Drawing.Size(339, 60);
            this.btnFacturaCliente.TabIndex = 1;
            this.btnFacturaCliente.Text = "Buscar Por Cliente";
            this.btnFacturaCliente.Click += new System.EventHandler(this.btnFacturaCliente_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.guna2Button1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(39, 139);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(327, 60);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Factura rápida";
            this.guna2Button1.Click += new System.EventHandler(this.Guna2Button1_Click);
            // 
            // txtNewInvoice
            // 
            this.txtNewInvoice.Animated = true;
            this.txtNewInvoice.BackColor = System.Drawing.Color.Transparent;
            this.txtNewInvoice.BorderColor = System.Drawing.Color.Transparent;
            this.txtNewInvoice.BorderRadius = 10;
            this.txtNewInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtNewInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtNewInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtNewInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtNewInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtNewInvoice.FillColor = System.Drawing.Color.DarkOrchid;
            this.txtNewInvoice.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewInvoice.ForeColor = System.Drawing.Color.White;
            this.txtNewInvoice.Image = ((System.Drawing.Image)(resources.GetObject("txtNewInvoice.Image")));
            this.txtNewInvoice.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewInvoice.ImageSize = new System.Drawing.Size(25, 25);
            this.txtNewInvoice.Location = new System.Drawing.Point(39, 71);
            this.txtNewInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewInvoice.Name = "txtNewInvoice";
            this.txtNewInvoice.Size = new System.Drawing.Size(327, 60);
            this.txtNewInvoice.TabIndex = 0;
            this.txtNewInvoice.Text = "Factura detallada";
            this.txtNewInvoice.Click += new System.EventHandler(this.txtNewInvoice_Click);
            // 
            // verDetallesDeLaFacturaToolStripMenuItem
            // 
            this.verDetallesDeLaFacturaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.verDetallesDeLaFacturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verDetallesDeLaFacturaToolStripMenuItem.Image")));
            this.verDetallesDeLaFacturaToolStripMenuItem.Name = "verDetallesDeLaFacturaToolStripMenuItem";
            this.verDetallesDeLaFacturaToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.verDetallesDeLaFacturaToolStripMenuItem.Text = "Ver Detalles de la Factura";
            // 
            // eliminarFacturaToolStripMenuItem
            // 
            this.eliminarFacturaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.eliminarFacturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarFacturaToolStripMenuItem.Image")));
            this.eliminarFacturaToolStripMenuItem.Name = "eliminarFacturaToolStripMenuItem";
            this.eliminarFacturaToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.eliminarFacturaToolStripMenuItem.Text = "Eliminar Factura";
            this.eliminarFacturaToolStripMenuItem.Click += new System.EventHandler(this.eliminarFacturaToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(35, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 53);
            this.label2.TabIndex = 84;
            this.label2.Text = "Facturas Realizadas";
            // 
            // UC_Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.dataGridFatura);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_Factura";
            this.Size = new System.Drawing.Size(1887, 722);
            this.Load += new System.EventHandler(this.UC_Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFatura)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogInfo;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Button txtNewInvoice;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2Button btnSearchMonth;
        private Guna.UI2.WinForms.Guna2Button btnSearchDate;
        private Guna.UI2.WinForms.Guna2Button btnFacturaCliente;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verDetallesDeLaFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarFacturaToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button btnRango;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        public System.Windows.Forms.DataGridView dataGridFatura;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}
