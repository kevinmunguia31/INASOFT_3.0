namespace INASOFT_3._0.VistaFacturas
{
    partial class EstadoDelCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstadoDelCredito));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MessageDialogInfo = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Ok = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Warnings = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Import = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBox_Question = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageBoxError = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageInformation = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.MessageWarning = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Lb_FechaFin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lb_FechaInicial = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.datagridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.Lb_Cliente = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Lb_Cod_Factu = new System.Windows.Forms.Label();
            this.Txt_IDFactura = new System.Windows.Forms.TextBox();
            this.Txt_IDCredito = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 39);
            this.panel1.TabIndex = 2;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(864, 5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(32, 26);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Click += new System.EventHandler(this.Guna2Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado del crédito";
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
            // MessageDialogInfo
            // 
            this.MessageDialogInfo.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageDialogInfo.Caption = null;
            this.MessageDialogInfo.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageDialogInfo.Parent = null;
            this.MessageDialogInfo.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageDialogInfo.Text = null;
            // 
            // MessageBox_Ok
            // 
            this.MessageBox_Ok.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Ok.Caption = null;
            this.MessageBox_Ok.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageBox_Ok.Parent = null;
            this.MessageBox_Ok.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Ok.Text = null;
            // 
            // MessageBox_Warnings
            // 
            this.MessageBox_Warnings.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Warnings.Caption = null;
            this.MessageBox_Warnings.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.MessageBox_Warnings.Parent = null;
            this.MessageBox_Warnings.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Warnings.Text = null;
            // 
            // MessageBox_Import
            // 
            this.MessageBox_Import.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox_Import.Caption = null;
            this.MessageBox_Import.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageBox_Import.Parent = null;
            this.MessageBox_Import.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.MessageBox_Import.Text = null;
            // 
            // MessageBox_Question
            // 
            this.MessageBox_Question.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            this.MessageBox_Question.Caption = null;
            this.MessageBox_Question.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            this.MessageBox_Question.Parent = null;
            this.MessageBox_Question.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox_Question.Text = null;
            // 
            // MessageBoxError
            // 
            this.MessageBoxError.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBoxError.Caption = null;
            this.MessageBoxError.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            this.MessageBoxError.Parent = null;
            this.MessageBoxError.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBoxError.Text = null;
            // 
            // MessageInformation
            // 
            this.MessageInformation.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageInformation.Caption = null;
            this.MessageInformation.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.MessageInformation.Parent = null;
            this.MessageInformation.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageInformation.Text = null;
            // 
            // MessageWarning
            // 
            this.MessageWarning.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageWarning.Caption = null;
            this.MessageWarning.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.MessageWarning.Parent = null;
            this.MessageWarning.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageWarning.Text = null;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Lb_FechaFin
            // 
            this.Lb_FechaFin.AutoSize = true;
            this.Lb_FechaFin.BackColor = System.Drawing.Color.Transparent;
            this.Lb_FechaFin.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_FechaFin.ForeColor = System.Drawing.Color.Black;
            this.Lb_FechaFin.Location = new System.Drawing.Point(93, 85);
            this.Lb_FechaFin.Name = "Lb_FechaFin";
            this.Lb_FechaFin.Size = new System.Drawing.Size(24, 23);
            this.Lb_FechaFin.TabIndex = 96;
            this.Lb_FechaFin.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 23);
            this.label4.TabIndex = 95;
            this.label4.Text = "Fecha de fin:";
            // 
            // Lb_FechaInicial
            // 
            this.Lb_FechaInicial.AutoSize = true;
            this.Lb_FechaInicial.BackColor = System.Drawing.Color.Transparent;
            this.Lb_FechaInicial.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_FechaInicial.ForeColor = System.Drawing.Color.Black;
            this.Lb_FechaInicial.Location = new System.Drawing.Point(113, 53);
            this.Lb_FechaInicial.Name = "Lb_FechaInicial";
            this.Lb_FechaInicial.Size = new System.Drawing.Size(24, 23);
            this.Lb_FechaInicial.TabIndex = 94;
            this.Lb_FechaInicial.Text = "--";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(8, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 23);
            this.label14.TabIndex = 93;
            this.label14.Text = "Fecha de Inicio:";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox2.Controls.Add(this.datagridView1);
            this.guna2GroupBox2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Location = new System.Drawing.Point(12, 123);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(876, 209);
            this.guna2GroupBox2.TabIndex = 99;
            this.guna2GroupBox2.Text = "Productos facturados";
            // 
            // datagridView1
            // 
            this.datagridView1.AllowUserToAddRows = false;
            this.datagridView1.AllowUserToDeleteRows = false;
            this.datagridView1.AllowUserToResizeColumns = false;
            this.datagridView1.AllowUserToResizeRows = false;
            this.datagridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.datagridView1.BackgroundColor = System.Drawing.Color.White;
            this.datagridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(44)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridView1.ColumnHeadersHeight = 35;
            this.datagridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagridView1.EnableHeadersVisualStyles = false;
            this.datagridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.datagridView1.Location = new System.Drawing.Point(0, 39);
            this.datagridView1.Name = "datagridView1";
            this.datagridView1.ReadOnly = true;
            this.datagridView1.RowHeadersVisible = false;
            this.datagridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(135)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.datagridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridView1.Size = new System.Drawing.Size(876, 170);
            this.datagridView1.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(342, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 23);
            this.label8.TabIndex = 100;
            this.label8.Text = "Cliente:";
            // 
            // Lb_Cliente
            // 
            this.Lb_Cliente.AutoSize = true;
            this.Lb_Cliente.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Cliente.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cliente.Location = new System.Drawing.Point(395, 85);
            this.Lb_Cliente.Name = "Lb_Cliente";
            this.Lb_Cliente.Size = new System.Drawing.Size(24, 23);
            this.Lb_Cliente.TabIndex = 101;
            this.Lb_Cliente.Text = "--";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(342, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 23);
            this.label15.TabIndex = 103;
            this.label15.Text = "Cod. Fact:";
            // 
            // Lb_Cod_Factu
            // 
            this.Lb_Cod_Factu.AutoSize = true;
            this.Lb_Cod_Factu.BackColor = System.Drawing.Color.Transparent;
            this.Lb_Cod_Factu.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Cod_Factu.ForeColor = System.Drawing.Color.Black;
            this.Lb_Cod_Factu.Location = new System.Drawing.Point(423, 53);
            this.Lb_Cod_Factu.Name = "Lb_Cod_Factu";
            this.Lb_Cod_Factu.Size = new System.Drawing.Size(24, 23);
            this.Lb_Cod_Factu.TabIndex = 102;
            this.Lb_Cod_Factu.Text = "--";
            // 
            // Txt_IDFactura
            // 
            this.Txt_IDFactura.Location = new System.Drawing.Point(864, 71);
            this.Txt_IDFactura.Name = "Txt_IDFactura";
            this.Txt_IDFactura.Size = new System.Drawing.Size(32, 20);
            this.Txt_IDFactura.TabIndex = 105;
            // 
            // Txt_IDCredito
            // 
            this.Txt_IDCredito.Location = new System.Drawing.Point(864, 45);
            this.Txt_IDCredito.Name = "Txt_IDCredito";
            this.Txt_IDCredito.Size = new System.Drawing.Size(32, 20);
            this.Txt_IDCredito.TabIndex = 104;
            // 
            // EstadoDelCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 370);
            this.Controls.Add(this.Txt_IDFactura);
            this.Controls.Add(this.Txt_IDCredito);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Lb_Cod_Factu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Lb_Cliente);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.Lb_FechaFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Lb_FechaInicial);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstadoDelCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EstadoDelCredito";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageDialogInfo;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Ok;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Warnings;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Import;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox_Question;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBoxError;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageInformation;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageWarning;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.Label Lb_FechaFin;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label Lb_FechaInicial;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.DataGridView datagridView1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label Lb_Cliente;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label Lb_Cod_Factu;
        public System.Windows.Forms.TextBox Txt_IDFactura;
        public System.Windows.Forms.TextBox Txt_IDCredito;
    }
}