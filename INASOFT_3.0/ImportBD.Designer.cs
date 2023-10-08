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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBD));
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtRuta = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.MessageDialoginfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNameDB = new System.Windows.Forms.Label();
            this.btnCrearBD = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.Bttn_Info = new System.Windows.Forms.Button();
            this.guna2GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2GroupBox3.Controls.Add(this.Bttn_Info);
            this.guna2GroupBox3.Controls.Add(this.btnSeleccionar);
            this.guna2GroupBox3.Controls.Add(this.label5);
            this.guna2GroupBox3.Controls.Add(this.label6);
            this.guna2GroupBox3.Controls.Add(this.btnCrearBD);
            this.guna2GroupBox3.Controls.Add(this.lbNameDB);
            this.guna2GroupBox3.Controls.Add(this.label3);
            this.guna2GroupBox3.Controls.Add(this.label2);
            this.guna2GroupBox3.Controls.Add(this.label1);
            this.guna2GroupBox3.Controls.Add(this.txtRuta);
            this.guna2GroupBox3.Controls.Add(this.btnImport);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2GroupBox3.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox3.Location = new System.Drawing.Point(4, 4);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.Size = new System.Drawing.Size(685, 311);
            this.guna2GroupBox3.TabIndex = 3;
            this.guna2GroupBox3.Text = "Importar Base de Datos del Software";
            // 
            // txtRuta
            // 
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.DefaultText = "";
            this.txtRuta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRuta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRuta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRuta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRuta.Enabled = false;
            this.txtRuta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRuta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRuta.Location = new System.Drawing.Point(13, 175);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.PasswordChar = '\0';
            this.txtRuta.PlaceholderText = "ruta del archivo de respaldo";
            this.txtRuta.SelectedText = "";
            this.txtRuta.Size = new System.Drawing.Size(439, 36);
            this.txtRuta.TabIndex = 4;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.Control;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Image = global::INASOFT_3._0.Properties.Resources.icons8_backup_66;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(104, 239);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(396, 50);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Completar Importación";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Para Importar la Base de Datos siga los siguientes paso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paso 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(75, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Crear la base de datos con el nombre: ";
            // 
            // lbNameDB
            // 
            this.lbNameDB.AutoSize = true;
            this.lbNameDB.BackColor = System.Drawing.Color.Transparent;
            this.lbNameDB.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameDB.ForeColor = System.Drawing.Color.Black;
            this.lbNameDB.Location = new System.Drawing.Point(449, 96);
            this.lbNameDB.Name = "lbNameDB";
            this.lbNameDB.Size = new System.Drawing.Size(73, 30);
            this.lbNameDB.TabIndex = 8;
            this.lbNameDB.Text = "Prueba";
            // 
            // btnCrearBD
            // 
            this.btnCrearBD.BackColor = System.Drawing.SystemColors.Control;
            this.btnCrearBD.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearBD.ForeColor = System.Drawing.Color.Black;
            this.btnCrearBD.Location = new System.Drawing.Point(532, 92);
            this.btnCrearBD.Name = "btnCrearBD";
            this.btnCrearBD.Size = new System.Drawing.Size(84, 39);
            this.btnCrearBD.TabIndex = 9;
            this.btnCrearBD.Text = "Crear";
            this.btnCrearBD.UseVisualStyleBackColor = false;
            this.btnCrearBD.Click += new System.EventHandler(this.btnCrearBD_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(75, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "Seleccionar el archivo SQL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "Paso 2:";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionar.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.Black;
            this.btnSeleccionar.Location = new System.Drawing.Point(458, 172);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(158, 39);
            this.btnSeleccionar.TabIndex = 12;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // Bttn_Info
            // 
            this.Bttn_Info.BackColor = System.Drawing.Color.Transparent;
            this.Bttn_Info.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Bttn_Info.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Bttn_Info.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Bttn_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bttn_Info.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Bttn_Info.ForeColor = System.Drawing.SystemColors.Control;
            this.Bttn_Info.Image = ((System.Drawing.Image)(resources.GetObject("Bttn_Info.Image")));
            this.Bttn_Info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bttn_Info.Location = new System.Drawing.Point(322, 137);
            this.Bttn_Info.Margin = new System.Windows.Forms.Padding(4);
            this.Bttn_Info.Name = "Bttn_Info";
            this.Bttn_Info.Size = new System.Drawing.Size(41, 36);
            this.Bttn_Info.TabIndex = 77;
            this.Bttn_Info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bttn_Info.UseVisualStyleBackColor = false;
            this.Bttn_Info.Click += new System.EventHandler(this.Bttn_Info_Click);
            // 
            // ImportBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 320);
            this.Controls.Add(this.guna2GroupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportBD";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Base de datos";
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.Button btnImport;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialoginfo;
        private Guna.UI2.WinForms.Guna2TextBox txtRuta;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCrearBD;
        private System.Windows.Forms.Label lbNameDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Bttn_Info;
    }
}