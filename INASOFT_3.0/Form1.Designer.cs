
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
            this.btnProvider = new Guna.UI2.WinForms.Guna2Button();
            this.btnClientes = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnUser = new Guna.UI2.WinForms.Guna2Button();
            this.btnFactura = new Guna.UI2.WinForms.Guna2Button();
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
            this.panel1.Size = new System.Drawing.Size(1096, 54);
            this.panel1.TabIndex = 0;
            // 
            // btnLogaut
            // 
            this.btnLogaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogaut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogaut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogaut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogaut.Image")));
            this.btnLogaut.ImageRotate = 0F;
            this.btnLogaut.Location = new System.Drawing.Point(1020, 3);
            this.btnLogaut.Name = "btnLogaut";
            this.btnLogaut.ShadowDecoration.Depth = 10;
            this.btnLogaut.ShadowDecoration.Enabled = true;
            this.btnLogaut.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnLogaut.Size = new System.Drawing.Size(72, 48);
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
            this.lbTipoUser.Location = new System.Drawing.Point(888, 27);
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
            this.lbUserName.Location = new System.Drawing.Point(886, 4);
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
            this.panel2.Controls.Add(this.btnProvider);
            this.panel2.Controls.Add(this.btnClientes);
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.guna2Button2);
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnUser);
            this.panel2.Controls.Add(this.btnFactura);
            this.panel2.Controls.Add(this.btnProductos);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1096, 48);
            this.panel2.TabIndex = 1;
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
            this.btnProvider.Location = new System.Drawing.Point(756, 0);
            this.btnProvider.Name = "btnProvider";
            this.btnProvider.Size = new System.Drawing.Size(134, 45);
            this.btnProvider.TabIndex = 4;
            this.btnProvider.Text = "Proveedores";
            this.btnProvider.Click += new System.EventHandler(this.btnProvider_Click);
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
            this.btnClientes.Location = new System.Drawing.Point(635, 0);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(115, 45);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.CustomBorderColor = System.Drawing.Color.White;
            this.guna2Button1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.guna2Button1.Image = global::INASOFT_3._0.Properties.Resources.icons8_buy_40px_1;
            this.guna2Button1.Location = new System.Drawing.Point(363, 0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(145, 45);
            this.guna2Button1.TabIndex = 8;
            this.guna2Button1.Text = "Devoluciones";
            this.guna2Button1.Click += new System.EventHandler(this.Guna2Button1_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button2.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(78)))), ((int)(((byte)(221)))));
            this.guna2Button2.CheckedState.FillColor = System.Drawing.Color.White;
            this.guna2Button2.CustomBorderColor = System.Drawing.Color.White;
            this.guna2Button2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Poppins SemiBold", 12F);
            this.guna2Button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.guna2Button2.Image = global::INASOFT_3._0.Properties.Resources.icons8_credit_control_40px;
            this.guna2Button2.Location = new System.Drawing.Point(514, 0);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(115, 45);
            this.guna2Button2.TabIndex = 9;
            this.guna2Button2.Text = "Crédito";
            this.guna2Button2.Click += new System.EventHandler(this.Guna2Button2_Click);
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
            this.btnSettings.Location = new System.Drawing.Point(1017, 0);
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
            this.btnUser.Location = new System.Drawing.Point(896, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(115, 45);
            this.btnUser.TabIndex = 6;
            this.btnUser.Text = "Usuarios";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
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
            this.btnFactura.Location = new System.Drawing.Point(242, 0);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(115, 45);
            this.btnFactura.TabIndex = 3;
            this.btnFactura.Text = "Facturar";
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
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
            this.btnProductos.Location = new System.Drawing.Point(121, 0);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(115, 45);
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
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(115, 45);
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
            this.panelContenedor.Size = new System.Drawing.Size(1096, 379);
            this.panelContenedor.TabIndex = 2;
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
            this.ClientSize = new System.Drawing.Size(1096, 481);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INA-SOFTWARE vBeta 1.0.3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
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
        private Guna.UI2.WinForms.Guna2Button btnProvider;
        private Guna.UI2.WinForms.Guna2Button btnFactura;
        private Guna.UI2.WinForms.Guna2Button btnClientes;
        private Guna.UI2.WinForms.Guna2Button btnProductos;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private System.Windows.Forms.Panel panelContenedor;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnLogaut;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialogErr;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}

