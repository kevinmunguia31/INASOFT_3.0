﻿using INASOFT_3._0.Modelos;
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
        public Login()
        {
            InitializeComponent();
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
                    string log = "Intento Fallido de inicio de Sesion a las " + DateTime.Now + " por la PC: " + PcUser;                    
                    ctrlInfo.InsertarLog(log);
                    Limpiar();
                }
                else
                {
                    Principal frm = new Principal();
                    frm.Visible = true;
                    this.Visible = false;

                    string log = "Inicio de Sesion a las " + DateTime.Now + " por: " + Sesion.nombre;
                    ctrlInfo.InsertarLog(log);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !guna2ToggleSwitch1.Checked;
        }
    }
}
