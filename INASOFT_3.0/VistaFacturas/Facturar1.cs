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
            txtIdUser.Text = Sesion.id.ToString();
            Cargar_Clientes();

            Cbx_Clientes.SelectedIndex = -1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Hide();
            this.Close();
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
                MessageBox_Import.Show("Por favor introduzca el nombre del cliente");
            }
            else
            {
                Controladores.CtrlClientes ctrlClientes = new Controladores.CtrlClientes();
                if (ctrlClientes.Insertar_NombreCliente(txtNombre.Text))
                {
                    MessageBox_Ok.Show("Cliente Registrado Correctamente", "Registrar Cliete");
                    txtNombre.Text = "";
                    Limpiar();
                    Cargar_Clientes();
                }
            }
        }

        private void btnAceppt_Click(object sender, EventArgs e)
        {
            if (Cbx_Clientes.SelectedIndex == -1)
            {
                MessageBox_Import.Show("Tiene que seleccionar a un cliente", "Importante");
            }
            else
            {
                DetalleFactura frm = new DetalleFactura();
                frm.txtIdCliente.Text = txtIdCliente.Text;
                int limite = 20;

                if (lbNombre.Text.Length > limite)
                {
                    frm.lbClienteName.Text = lbNombre.Text.Substring(0, limite) + "...";
                }
                else
                {
                    frm.lbClienteName.Text = lbNombre.Text;
                }

                if (Lb_User.Text.Length > limite)
                {
                    frm.Lb_User.Text = Lb_User.Text.Substring(0, limite) + "...";
                }
                else
                {
                    frm.Lb_User.Text = Lb_User.Text;
                }

                frm.Show();
                this.Hide();
                this.Close();
            }
        }

        private void TxtBuscar_Clientes_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlClientes ctrl = new Controladores.CtrlClientes();
            Cbx_Clientes.DataSource = ctrl.Buscar_NombreCliente(TxtBuscar_Clientes.Text);
            Cbx_Clientes.ValueMember = "ID";
            Cbx_Clientes.DisplayMember = "Nombre";
        }

        public void Limpiar()
        {
            lbNombre.Text = "";
            lbCedula.Text = "";
            lbDireccion.Text = "";
            lbTelefono.Text = "";
            Cbx_Clientes.SelectedIndex = -1;
        }

        private void Cbx_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Clientes.SelectedIndex == -1)
                {
                    Limpiar();
                    txtIdCliente.Text = "";
                }
                else
                {
                    txtIdCliente.Text = Cbx_Clientes.SelectedValue.ToString();
                    int id = int.Parse(txtIdCliente.Text);
                    Controladores.CtrlClientes ctrlClientes = new Controladores.CtrlClientes();
                    lbNombre.Text = ctrlClientes.Nombre_Cliente(id);
                    lbTelefono.Text = ctrlClientes.Telefono_Cliente(id);
                    lbDireccion.Text = ctrlClientes.Direccion_Cliente(id);
                    lbCedula.Text = ctrlClientes.Cedula_Cliente(id);

                    int limite = 15;

                    if (lbDireccion.Text.Length > limite)
                    {
                        lbDireccion.Text = lbDireccion.Text.Substring(0, limite) + "...";
                    }
                    else
                    {
                        lbDireccion.Text = lbDireccion.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            Cargar_Clientes();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
