
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Factura));
            this.dataGridFatura = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageDialogInfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtNewInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnSearchMonth = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearchDate = new Guna.UI2.WinForms.Guna2Button();
            this.btnFacturaCliente = new Guna.UI2.WinForms.Guna2Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetallesDeLaFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRango = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFatura)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFatura
            // 
            this.dataGridFatura.AllowUserToAddRows = false;
            this.dataGridFatura.AllowUserToDeleteRows = false;
            this.dataGridFatura.AllowUserToResizeColumns = false;
            this.dataGridFatura.AllowUserToResizeRows = false;
            this.dataGridFatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridFatura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridFatura.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(148)))), ((int)(((byte)(242)))));
            this.dataGridFatura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFatura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFatura.ColumnHeadersHeight = 35;
            this.dataGridFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridFatura.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridFatura.EnableHeadersVisualStyles = false;
            this.dataGridFatura.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dataGridFatura.Location = new System.Drawing.Point(32, 53);
            this.dataGridFatura.Name = "dataGridFatura";
            this.dataGridFatura.ReadOnly = true;
            this.dataGridFatura.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridFatura.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridFatura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFatura.Size = new System.Drawing.Size(901, 474);
            this.dataGridFatura.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Facturas Realizadas";
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
            this.guna2GroupBox1.Controls.Add(this.txtNewInvoice);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(123)))), ((int)(((byte)(200)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Poppins Medium", 12F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(939, 53);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(300, 122);
            this.guna2GroupBox1.TabIndex = 4;
            this.guna2GroupBox1.Text = "Facturación";
            // 
            // txtNewInvoice
            // 
            this.txtNewInvoice.BorderRadius = 10;
            this.txtNewInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtNewInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtNewInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtNewInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtNewInvoice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtNewInvoice.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewInvoice.ForeColor = System.Drawing.Color.White;
            this.txtNewInvoice.Image = ((System.Drawing.Image)(resources.GetObject("txtNewInvoice.Image")));
            this.txtNewInvoice.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewInvoice.Location = new System.Drawing.Point(29, 53);
            this.txtNewInvoice.Name = "txtNewInvoice";
            this.txtNewInvoice.Size = new System.Drawing.Size(253, 49);
            this.txtNewInvoice.TabIndex = 0;
            this.txtNewInvoice.Text = "Crear Nueva Factura";
            this.txtNewInvoice.Click += new System.EventHandler(this.txtNewInvoice_Click);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.btnRango);
            this.guna2GroupBox2.Controls.Add(this.btnSearchMonth);
            this.guna2GroupBox2.Controls.Add(this.btnSearchDate);
            this.guna2GroupBox2.Controls.Add(this.btnFacturaCliente);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(123)))), ((int)(((byte)(200)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Poppins", 12F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(939, 190);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(300, 337);
            this.guna2GroupBox2.TabIndex = 5;
            this.guna2GroupBox2.Text = "Buscar Facturas";
            // 
            // btnSearchMonth
            // 
            this.btnSearchMonth.BorderRadius = 10;
            this.btnSearchMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchMonth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearchMonth.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMonth.ForeColor = System.Drawing.Color.White;
            this.btnSearchMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchMonth.Image")));
            this.btnSearchMonth.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearchMonth.Location = new System.Drawing.Point(29, 186);
            this.btnSearchMonth.Name = "btnSearchMonth";
            this.btnSearchMonth.Size = new System.Drawing.Size(253, 49);
            this.btnSearchMonth.TabIndex = 3;
            this.btnSearchMonth.Text = "Buscar por Mes";
            this.btnSearchMonth.Click += new System.EventHandler(this.btnSearchMonth_Click);
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.BorderRadius = 10;
            this.btnSearchDate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchDate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearchDate.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDate.ForeColor = System.Drawing.Color.White;
            this.btnSearchDate.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchDate.Image")));
            this.btnSearchDate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearchDate.Location = new System.Drawing.Point(29, 119);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(253, 49);
            this.btnSearchDate.TabIndex = 2;
            this.btnSearchDate.Text = "Buscar Por Fecha";
            this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);
            // 
            // btnFacturaCliente
            // 
            this.btnFacturaCliente.BorderRadius = 10;
            this.btnFacturaCliente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFacturaCliente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFacturaCliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFacturaCliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFacturaCliente.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnFacturaCliente.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaCliente.ForeColor = System.Drawing.Color.White;
            this.btnFacturaCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturaCliente.Image")));
            this.btnFacturaCliente.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFacturaCliente.Location = new System.Drawing.Point(29, 54);
            this.btnFacturaCliente.Name = "btnFacturaCliente";
            this.btnFacturaCliente.Size = new System.Drawing.Size(253, 49);
            this.btnFacturaCliente.TabIndex = 1;
            this.btnFacturaCliente.Text = "Buscar Por Cliente";
            this.btnFacturaCliente.Click += new System.EventHandler(this.btnFacturaCliente_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesDeLaFacturaToolStripMenuItem,
            this.eliminarFacturaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(257, 64);
            // 
            // verDetallesDeLaFacturaToolStripMenuItem
            // 
            this.verDetallesDeLaFacturaToolStripMenuItem.Font = new System.Drawing.Font("Poppins", 10F);
            this.verDetallesDeLaFacturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verDetallesDeLaFacturaToolStripMenuItem.Image")));
            this.verDetallesDeLaFacturaToolStripMenuItem.Name = "verDetallesDeLaFacturaToolStripMenuItem";
            this.verDetallesDeLaFacturaToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.verDetallesDeLaFacturaToolStripMenuItem.Text = "Ver Detalles de la Factura";
            // 
            // eliminarFacturaToolStripMenuItem
            // 
            this.eliminarFacturaToolStripMenuItem.Font = new System.Drawing.Font("Poppins", 10F);
            this.eliminarFacturaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarFacturaToolStripMenuItem.Image")));
            this.eliminarFacturaToolStripMenuItem.Name = "eliminarFacturaToolStripMenuItem";
            this.eliminarFacturaToolStripMenuItem.Size = new System.Drawing.Size(256, 30);
            this.eliminarFacturaToolStripMenuItem.Text = "Eliminar Factura";
            this.eliminarFacturaToolStripMenuItem.Click += new System.EventHandler(this.eliminarFacturaToolStripMenuItem_Click);
            // 
            // btnRango
            // 
            this.btnRango.BorderRadius = 10;
            this.btnRango.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRango.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRango.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRango.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRango.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRango.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRango.ForeColor = System.Drawing.Color.White;
            this.btnRango.Image = ((System.Drawing.Image)(resources.GetObject("btnRango.Image")));
            this.btnRango.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRango.Location = new System.Drawing.Point(29, 253);
            this.btnRango.Name = "btnRango";
            this.btnRango.Size = new System.Drawing.Size(253, 49);
            this.btnRango.TabIndex = 4;
            this.btnRango.Text = "Buscar por Rango de Fecha";
            this.btnRango.Click += new System.EventHandler(this.btnRango_Click);
            // 
            // UC_Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.dataGridFatura);
            this.Controls.Add(this.label1);
            this.Name = "UC_Factura";
            this.Size = new System.Drawing.Size(1247, 735);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFatura)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFatura;
        private System.Windows.Forms.Label label1;
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
    }
}
