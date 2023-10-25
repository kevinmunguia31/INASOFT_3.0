using DevExpress.XtraPrinting.Export.Pdf;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0
{
    public partial class Login : Form
    {
        private bool exitConfirmed = false;
        public Login()
        {
            InitializeComponent();
            // InfoNegocio();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Limpiar()
        {
            txtPassword.Text = "";
            txtUser.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text;
            string password = txtPassword.Text;
            System.Security.Principal.WindowsIdentity user = System.Security.Principal.WindowsIdentity.GetCurrent();
            string PcUser = user.Name;

            try
            {
                Controladores.ctrlUsuarios ctrl = new Controladores.ctrlUsuarios();
                Controladores.CtrlInfo ctrlInfo = new Controladores.CtrlInfo();
                string respuesta = ctrl.ctrlLogin(usuario, password);

                if (respuesta.Length > 0)
                {
                    guna2MessageWar.Show(respuesta, "Aviso");
                    string log = "[" + DateTime.Now + "] " + "Intento Fallido de inicio de Sesion" + " por la PC: " + PcUser;
                    ctrlInfo.InsertarLog(log);
                    Limpiar();
                }
                else
                {
                    Principal frm = new Principal();
                    frm.Visible = true;
                    this.Visible = false;

                    string log = "[" + DateTime.Now + "] " + "Inicio de Sesion " + " por: " + Sesion.nombre;
                    ctrlInfo.InsertarLog(log);
                }
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                guna2MessageWar.Show("No existe base de datos creada! :( \n" +
                    "Exporte un respaldo en Configuraciones ⚙️");
            }
        }

        private void Guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !guna2ToggleSwitch1.Checked;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ImportBD importBD = new ImportBD();
            importBD.Show();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string usuario = txtUser.Text;
                string password = txtPassword.Text;
                System.Security.Principal.WindowsIdentity user = System.Security.Principal.WindowsIdentity.GetCurrent();
                string PcUser = user.Name;

                try
                {
                    Controladores.ctrlUsuarios ctrl = new Controladores.ctrlUsuarios();
                    Controladores.CtrlInfo ctrlInfo = new Controladores.CtrlInfo();
                    string respuesta = ctrl.ctrlLogin(usuario, password);

                    if (respuesta.Length > 0)
                    {
                        guna2MessageWar.Show(respuesta, "Aviso");
                        string log = "[" + DateTime.Now + "] " + "Intento Fallido de inicio de Sesion" + " por la PC: " + PcUser;
                        ctrlInfo.InsertarLog(log);
                        Limpiar();
                    }
                    else
                    {
                        Principal frm = new Principal();
                        frm.Visible = true;
                        this.Visible = false;

                        string log = "[" + DateTime.Now + "] " + "Inicio de Sesion " + " por: " + Sesion.nombre;
                        ctrlInfo.InsertarLog(log);
                    }
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show(ex.Message);
                    guna2MessageWar.Show("No existe base de datos creada! :( \n" +
                        "Exporte un respaldo en Configuraciones ⚙️");
                }
                // MessageBox.Show("Se presionó Enter en el cuadro de texto.");
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitConfirmed)
            {
                DialogResult resultado = MessageBox_Import.Show("¿Seguro que desea salir del Programa?", "Aviso");

                if (resultado == DialogResult.Yes)
                {
                    // Puedes realizar acciones de limpieza o cierre del programa aquí.
                    // Application.Exit();
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true; // Cancela el cierre del formulario.
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            exitConfirmed = true;
            Close(); // Cierra el formulario.
        }
    }
}
