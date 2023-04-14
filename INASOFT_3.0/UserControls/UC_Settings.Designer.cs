
namespace INASOFT_3._0.UserControls
{
    partial class UC_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtNameNgo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTelefono = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRUC = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNameAdmin = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnguardar = new Guna.UI2.WinForms.Guna2Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.MessageDialoginfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageDialogWar = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuraciones del Programa";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.txtId);
            this.guna2GroupBox1.Controls.Add(this.btnguardar);
            this.guna2GroupBox1.Controls.Add(this.txtNameAdmin);
            this.guna2GroupBox1.Controls.Add(this.txtRUC);
            this.guna2GroupBox1.Controls.Add(this.txtTelefono);
            this.guna2GroupBox1.Controls.Add(this.txtAddress);
            this.guna2GroupBox1.Controls.Add(this.txtNameNgo);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Poppins", 11F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(24, 60);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(904, 310);
            this.guna2GroupBox1.TabIndex = 1;
            this.guna2GroupBox1.Text = "Información del Negocio";
            // 
            // txtNameNgo
            // 
            this.txtNameNgo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameNgo.DefaultText = "";
            this.txtNameNgo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameNgo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameNgo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameNgo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameNgo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameNgo.Font = new System.Drawing.Font("Poppins", 11F);
            this.txtNameNgo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNameNgo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameNgo.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtNameNgo.IconLeft")));
            this.txtNameNgo.Location = new System.Drawing.Point(13, 54);
            this.txtNameNgo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameNgo.Name = "txtNameNgo";
            this.txtNameNgo.PasswordChar = '\0';
            this.txtNameNgo.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNameNgo.PlaceholderText = "Nombre del Negocio";
            this.txtNameNgo.SelectedText = "";
            this.txtNameNgo.Size = new System.Drawing.Size(376, 41);
            this.txtNameNgo.TabIndex = 0;
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Poppins", 11F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtAddress.IconLeft")));
            this.txtAddress.Location = new System.Drawing.Point(13, 119);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtAddress.PlaceholderText = "Dirección";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(376, 41);
            this.txtAddress.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTelefono.DefaultText = "";
            this.txtTelefono.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTelefono.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTelefono.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTelefono.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTelefono.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTelefono.Font = new System.Drawing.Font("Poppins", 11F);
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTelefono.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTelefono.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTelefono.IconLeft")));
            this.txtTelefono.Location = new System.Drawing.Point(433, 54);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PasswordChar = '\0';
            this.txtTelefono.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTelefono.PlaceholderText = "Teléfono";
            this.txtTelefono.SelectedText = "";
            this.txtTelefono.Size = new System.Drawing.Size(376, 41);
            this.txtTelefono.TabIndex = 2;
            // 
            // txtRUC
            // 
            this.txtRUC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRUC.DefaultText = "";
            this.txtRUC.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRUC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRUC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRUC.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRUC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRUC.Font = new System.Drawing.Font("Poppins", 11F);
            this.txtRUC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRUC.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRUC.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtRUC.IconLeft")));
            this.txtRUC.Location = new System.Drawing.Point(433, 119);
            this.txtRUC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.PasswordChar = '\0';
            this.txtRUC.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtRUC.PlaceholderText = "Número RUC";
            this.txtRUC.SelectedText = "";
            this.txtRUC.Size = new System.Drawing.Size(376, 41);
            this.txtRUC.TabIndex = 3;
            // 
            // txtNameAdmin
            // 
            this.txtNameAdmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNameAdmin.DefaultText = "";
            this.txtNameAdmin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNameAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNameAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameAdmin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNameAdmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameAdmin.Font = new System.Drawing.Font("Poppins", 11F);
            this.txtNameAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNameAdmin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNameAdmin.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtNameAdmin.IconLeft")));
            this.txtNameAdmin.Location = new System.Drawing.Point(246, 188);
            this.txtNameAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameAdmin.Name = "txtNameAdmin";
            this.txtNameAdmin.PasswordChar = '\0';
            this.txtNameAdmin.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtNameAdmin.PlaceholderText = "Nombre del Administrador";
            this.txtNameAdmin.SelectedText = "";
            this.txtNameAdmin.Size = new System.Drawing.Size(376, 41);
            this.txtNameAdmin.TabIndex = 4;
            // 
            // btnguardar
            // 
            this.btnguardar.BorderRadius = 10;
            this.btnguardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnguardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnguardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnguardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnguardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnguardar.Font = new System.Drawing.Font("Poppins Medium", 11F);
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.Image = ((System.Drawing.Image)(resources.GetObject("btnguardar.Image")));
            this.btnguardar.Location = new System.Drawing.Point(333, 246);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(207, 45);
            this.btnguardar.TabIndex = 5;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(13, 262);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(30, 29);
            this.txtId.TabIndex = 6;
            // 
            // MessageDialoginfo
            // 
            this.MessageDialoginfo.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageDialoginfo.Caption = null;
            this.MessageDialoginfo.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageDialoginfo.Parent = null;
            this.MessageDialoginfo.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialoginfo.Text = null;
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
            // UC_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.Name = "UC_Settings";
            this.Size = new System.Drawing.Size(1115, 585);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtRUC;
        private Guna.UI2.WinForms.Guna2TextBox txtTelefono;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtNameNgo;
        private Guna.UI2.WinForms.Guna2Button btnguardar;
        private Guna.UI2.WinForms.Guna2TextBox txtNameAdmin;
        private System.Windows.Forms.TextBox txtId;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialoginfo;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogWar;
    }
}
