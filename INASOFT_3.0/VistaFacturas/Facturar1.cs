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
            Cargar_Clientes();

            Cbx_Clientes.SelectedIndex = -1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Cargar_Clientes()
        {
            Cbx_Clientes.DataSource = null;
            Cbx_Clientes.Items.Clear();

            Controladores.CtrlClientes ctrl = new Controladores.CtrlClientes();
            Cbx_Clientes.DataSource = ctrl.Cargar_NombreClientes();
            Cbx_Clientes.ValueMember = "ID";
            Cbx_Clientes.DisplayMember = "Nombre";

        }


        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Por favor introduzca el nombre del cliente");
            }
            else
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
                    Cargar_Clientes();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnAceppt_Click(object sender, EventArgs e)
        {
            if (Cbx_Clientes.SelectedIndex == -1)
            {
                MessageDialogInfo.Show("Tiene que seleccionar a un cliente", "Importante");
            }
            else
            {
                DetalleFactura frm = new DetalleFactura();
                frm.lbClienteName.Text = lbNombre.Text;
                frm.txtIdCliente.Text = txtIdCliente.Text;
                frm.ShowDialog();
                this.Dispose();
                /*Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
                int cod_fac = ctrlFactura.Codigo_Factura();
                //string sql = "CALL Insertar_Factura("+ cod_fac + ", '" + lbFecha.Text + "', '" + txtIdUser.Text + "', '" + txtIdCliente.Text + "');";
                string sql = "CALL Insertar_Factura(" + cod_fac + ", '" + lbFecha.Text + "', '" + txtIdUser.Text + "', '" + txtIdCliente.Text + "');";
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
                }*/
            }
        }

        private void TxtBuscar_Clientes_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlClientes ctrl = new Controladores.CtrlClientes();
            Cbx_Clientes.DataSource = ctrl.Buscar_NombreCliente(TxtBuscar_Clientes.Text);
            Cbx_Clientes.ValueMember = "ID";
            Cbx_Clientes.DisplayMember = "Nombre";
        }

        private void Cbx_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Clientes.SelectedIndex == -1)
                {
                    txtIdCliente.Text = "";
                }
                else
                {
                    txtIdCliente.Text = Cbx_Clientes.SelectedValue.ToString();
                    string sql = "SELECT nombre FROM clientes WHERE id='" + txtIdCliente.Text + "'";
                    MySqlDataReader reader = null;
                    try
                    {
                        MySqlConnection conexioBD = Conexion.getConexion();
                        conexioBD.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                        reader = comando.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                lbNombre.Text = reader.GetString("nombre");

                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            Cargar_Clientes();
        }
    }
}
