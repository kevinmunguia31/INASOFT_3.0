namespace INASOFT_3._0
{
    partial class ImportBD
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
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.MessageDialoginfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.txtRuta = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GroupBox3.Controls.Add(this.txtRuta);
            this.guna2GroupBox3.Controls.Add(this.btnImport);
            this.guna2GroupBox3.Controls.Add(this.pictureBox3);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.Yellow;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox3.Location = new System.Drawing.Point(4, 4);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(686, 184);
            this.guna2GroupBox3.TabIndex = 3;
            this.guna2GroupBox3.Text = "Importar Base de Datos del Software";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Lime;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(170, 105);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(362, 50);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Seleccionar e Importar Base de Datos";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::INASOFT_3._0.Properties.Resources.icons8_database_daily_import_40;
            this.pictureBox3.Location = new System.Drawing.Point(14, 52);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(55, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
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
            // txtRuta
            // 
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.DefaultText = "";
            this.txtRuta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRuta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRuta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRuta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRuta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRuta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRuta.Location = new System.Drawing.Point(97, 52);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.PasswordChar = '\0';
            this.txtRuta.PlaceholderText = "ruta del archivo de respaldo";
            this.txtRuta.SelectedText = "";
            this.txtRuta.Size = new System.Drawing.Size(518, 36);
            this.txtRuta.TabIndex = 4;
            // 
            // ImportBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 189);
            this.Controls.Add(this.guna2GroupBox3);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportBD";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importar Base de datos";
            this.guna2GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialoginfo;
        private Guna.UI2.WinForms.Guna2TextBox txtRuta;
    }
}