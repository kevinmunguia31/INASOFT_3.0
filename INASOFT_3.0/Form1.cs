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
    public partial class Principal : Form
    {
        int tipoUser;
        public Principal()
        {
            InitializeComponent();

            // VScrollBar vScrollBar = new VScrollBar();
            ///vScrollBar.Height = 15;
            //vScrollBar.Width = 200;
            //vScrollBar.Dock = DockStyle.Bottom;
            //this.Controls.Add(vScrollBar);

            //Cargar El Dashboard
            UC_HOME uc = new UC_HOME();
            addUserControl(uc);

            //Monstra Usuario Logueado
            lbUserName.Text = Modelos.Sesion.nombre;
            tipoUser = Modelos.Sesion.id_tipo;
            if (tipoUser == 1)
            {
                lbTipoUser.Text = "(Administrador)";
                //.ForeColor = Color.Green;
            }
            else
            {
                lbTipoUser.Text = "(Empleado)";
            }
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_HOME uc = new UC_HOME();
            addUserControl(uc);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            UC_Productos uc = new UC_Productos();
            addUserControl(uc);
        }

        private void btnLogaut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login frm = new Login();
            frm.Visible = true;
            Modelos.Sesion sesion = new Modelos.Sesion();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            UC_Clientes uc = new UC_Clientes();
            addUserControl(uc);
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            UC_Proveedor uc = new UC_Proveedor();
            addUserControl(uc);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (tipoUser == 1)
            {
                UC_Usuarios uc = new UC_Usuarios();
                addUserControl(uc);
            }
            else
            {
                guna2MessageDialogErr.Show("Lo siento :( no tienes permisos para acceder aqui", ":(");

                string log = "[" + DateTime.Now + "] " + "Intento de acceso a Registro de Usuarios"+ " por: " + Sesion.nombre;
                MySqlConnection conexionDB = Conexion.getConexion();
                conexionDB.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand("INSERT INTO logs (descripcion) VALUES ('" + log + "')", conexionDB);
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Logs Almacenado");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al guardar el Log" + ex);
                }
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            UC_Factura uc = new UC_Factura();
            addUserControl(uc);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (tipoUser == 1)
            {
                UC_Settings uc = new UC_Settings();
                addUserControl(uc);
            }
            else
            {
                guna2MessageDialogErr.Show("Lo siento :( no tienes permisos para acceder aqui", ":(");

                string log = "[" + DateTime.Now + "] " + "Intento de acceso a Configuraciones" + " por: " + Sesion.nombre;
                MySqlConnection conexionDB = Conexion.getConexion();
                conexionDB.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand("INSERT INTO logs (descripcion) VALUES ('" + log + "')", conexionDB);
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Logs Almacenado");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al guardar el Log" + ex);
                }
            }
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            UC_Devoluciones uc = new UC_Devoluciones();
            addUserControl(uc);
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Creditos uc = new UC_Creditos();
            addUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_Reportes uc = new UC_Reportes();
            addUserControl(uc);
        }
    }
}
