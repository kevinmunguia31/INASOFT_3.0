using INASOFT_3._0.Modelos;
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

namespace INASOFT_3._0.VistaFacturas
{
    public partial class Facturar1 : Form
    {
        public Facturar1()
        {
            InitializeComponent();
            string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
            string hora = DateTime.Now.ToString("hh:mm:ss");
            lbFecha.Text = fecha + " " + hora;
            txtIdUser.Text = Sesion.id.ToString();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            MySqlDataReader reader = null;
            string consulta = "SELECT * FROM clientes WHERE nombre='" + dato + "'";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIdCliente.Text = reader.GetString("id");
                        lbNombre.Text = reader.GetString("nombre");
                    }
                }
                else
                {
                    MessageDialogWar.Show("No se encontro Cliente Con ese Nombre", "Aviso");
                    txtIdCliente.Text = "";
                    lbNombre.Text = "";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error Al Buscar: " + ex.Message);
            }
            finally { conexionBD.Close(); }
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO clientes(nombre, telefono, direccion, cedula) VALUES('" + txtNombre.Text + "','Ninguno', 'Ninguno', 'Ninguno')";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                MessageDialogInfo.Show("Cliente Registrado Correctamente", "Registrar Cliete");
                txtNombre.Text = "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAceppt_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Facturas VALUES(NULL, '" + lbFecha.Text + "', NULL, NULL, NULL, NULL, NULL, NULL, '" + txtIdUser.Text + "', '" + txtIdCliente.Text + "')";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                MessageDialogInfo.Show("Factura Almacenada", "Facturación");
                DetalleFactura frm = new DetalleFactura();
                frm.lbClienteName.Text = lbNombre.Text;
                frm.txtIdCliente.Text = txtIdCliente.Text;
                frm.ShowDialog();
                this.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Facturar1_Load(object sender, EventArgs e)
        {

        }
    }
}
