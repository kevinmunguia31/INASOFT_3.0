
namespace INASOFT_3._0
{
    partial class Principal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogaut = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbTipoUser = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnReport = new Guna.UI2.WinForms.Guna2Button();
            this.btnProvider = new Guna.UI2.WinForms.Guna2Button();
            this.btnFactura = new Guna.UI2.WinForms.Guna2Button();
            this.btnClientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnProductos = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.guna2MessageDialogErr = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogaut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.btnLogaut);
            this.panel1.Controls.Add(this.lbTipoUser);
            this.panel1.Controls.Add(this.lbUserName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 54);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnLogaut
            // 
            this.btnLogaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogaut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogaut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogaut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogaut.Image")));
            this.btnLogaut.ImageRotate = 0F;
            this.btnLogaut.Location = new System.Drawing.Point(1222, 3);
            this.btnLogaut.Name = "btnLogaut";
            this.btnLogaut.ShadowDecoration.Depth = 10;
            this.btnLogaut.ShadowDecoration.Enabled = true;
            this.btnLogaut.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLogaut.Size = new System.Drawing.Size(48, 48);
            this.btnLogaut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogaut.TabIndex = 3;
            this.btnLogaut.TabStop = false;
            this.btnLogaut.Click += new System.EventHandler(this.btnLogaut_Click);
            // 
            // lbTipoUser
            // 
            this.lbTipoUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTipoUser.BackColor = System.Drawing.Color.Transparent;
            this.lbTipoUser.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoUser.ForeColor = System.Drawing.Color.White;
            this.lbTipoUser.Location = new System.Drawing.Point(1066, 27);
            this.lbTipoUser.Name = "lbTipoUser";
            this.lbTipoUser.Size = new System.Drawing.Size(126, 21);
            this.lbTipoUser.TabIndex = 5;
            this.lbTipoUser.Text = "Administrador";
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.White;
            this.lbUserName.Location = new System.Drawing.Point(1063, 4);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(178, 42);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "Kevin Munguia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "INASOFTWARE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnUser);
            this.panel2.Controls.Add(this.btnReport);
            this.panel2.Controls.Add(this.btnProvider);
            this.panel2.Controls.Add(this.btnFactura);
            this.panel2.Controls.Add(this.btnClientes);
            this.panel2.Controls.Add(this.btnProductos);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1274, 48);
            this.panel2.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSettings.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnSettings.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSettings.CustomBorderColor = System.Drawing.Color.White;
            this.btnSettings.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.FillColor = System.Drawing.Color.White;
            this.btnSettings.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(1093, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(176, 45);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Text = "Configuraciones";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnUser
            // 
            this.btnUser.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnUser.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnUser.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnUser.CustomBorderColor = System.Drawing.Color.White;
            this.btnUser.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUser.FillColor = System.Drawing.Color.White;
            this.btnUser.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.Location = new System.Drawing.Point(947, 2);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(140, 45);
            this.btnUser.TabIndex = 6;
            this.btnUser.Text = "Usuarios";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnReport
            // 
            this.btnReport.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReport.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnReport.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnReport.CustomBorderColor = System.Drawing.Color.White;
            this.btnReport.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReport.FillColor = System.Drawing.Color.White;
            this.btnReport.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(780, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(161, 45);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Reportes";
            // 
            // btnProvider
            // 
            this.btnProvider.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProvider.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnProvider.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnProvider.CustomBorderColor = System.Drawing.Color.White;
            this.btnProvider.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnProvider.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProvider.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProvider.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProvider.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProvider.FillColor = System.Drawing.Color.White;
            this.btnProvider.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnProvider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnProvider.Image = ((System.Drawing.Image)(resources.GetObject("btnProvider.Image")));
            this.btnProvider.Location = new System.Drawing.Point(613, 2);
            this.btnProvider.Name = "btnProvider";
            this.btnProvider.Size = new System.Drawing.Size(161, 45);
            this.btnProvider.TabIndex = 4;
            this.btnProvider.Text = "Proveedores";
            this.btnProvider.Click += new System.EventHandler(this.btnProvider_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnFactura.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnFactura.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnFactura.CustomBorderColor = System.Drawing.Color.White;
            this.btnFactura.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnFactura.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFactura.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFactura.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFactura.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFactura.FillColor = System.Drawing.Color.White;
            this.btnFactura.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnFactura.Image = ((System.Drawing.Image)(resources.GetObject("btnFactura.Image")));
            this.btnFactura.Location = new System.Drawing.Point(446, 2);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(161, 45);
            this.btnFactura.TabIndex = 3;
            this.btnFactura.Text = "Facturar";
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnClientes.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnClientes.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnClientes.CustomBorderColor = System.Drawing.Color.White;
            this.btnClientes.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnClientes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClientes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClientes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClientes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClientes.FillColor = System.Drawing.Color.White;
            this.btnClientes.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Location = new System.Drawing.Point(303, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(137, 45);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnProductos.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnProductos.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnProductos.CustomBorderColor = System.Drawing.Color.White;
            this.btnProductos.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnProductos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProductos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProductos.FillColor = System.Drawing.Color.White;
            this.btnProductos.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.Location = new System.Drawing.Point(157, 2);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(140, 45);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnHome
            // 
            this.btnHome.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHome.Checked = true;
            this.btnHome.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.btnHome.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnHome.CustomBorderColor = System.Drawing.Color.White;
            this.btnHome.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.White;
            this.btnHome.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(1, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(150, 45);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 102);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1274, 379);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // guna2MessageDialogErr
            // 
            this.guna2MessageDialogErr.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialogErr.Caption = null;
            this.guna2MessageDialogErr.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            this.guna2MessageDialogErr.Parent = this;
            this.guna2MessageDialogErr.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialogErr.Text = "";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(200, 30);
            this.ClientSize = new System.Drawing.Size(1274, 481);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INA-SOFTWARE vBeta 1.0.3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogaut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTipoUser;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnUser;
        private Guna.UI2.WinForms.Guna2Button btnReport;
        private Guna.UI2.WinForms.Guna2Button btnProvider;
        private Guna.UI2.WinForms.Guna2Button btnFactura;
        private Guna.UI2.WinForms.Guna2Button btnClientes;
        private Guna.UI2.WinForms.Guna2Button btnProductos;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private System.Windows.Forms.Panel panelContenedor;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnLogaut;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialogErr;
    }
}

