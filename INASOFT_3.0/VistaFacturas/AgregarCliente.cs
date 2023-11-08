using INASOFT_3._0.Controladores;
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
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
            Cargar_Clientes();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            Cbx_Clientes.SelectedIndex = -1;
            txtIdUser.Text = Sesion.id.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
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
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox_Error.Show("Por favor introduzca el nombre del cliente", "Error");
                return;
            }

            Cliente cliente = new Cliente();
            cliente.Nombre = nombre;
            Controladores.CtrlClientes ctrlClientes = new Controladores.CtrlClientes();
            if (ctrlClientes.Insertar_NombreCedulaCliente(cliente))
            {
                MessageBox_Import.Show("Cliente registrado correctamente", "Aviso importante");

                string log = $"[{DateTime.Now}] {Sesion.nombre} Se registró un usuario de nombre: {nombre}";
                Controladores.CtrlInfo ctrlInfo = new Controladores.CtrlInfo();
                ctrlInfo.InsertarLog(log);

                Limpiar();
                Cargar_Clientes();
            }
        }

        private void btnAceppt_Click(object sender, EventArgs e)
        {
            if (Cbx_Clientes.SelectedIndex == -1)
            {
                MessageBox_Import.Show("Tiene que seleccionar a un cliente", "Importante");
                return;
            }

            FacturaFinal frm = new FacturaFinal();
            frm.txtIdCliente.Text = txtIdCliente.Text;
            int limite = 30;

            frm.lbNombreCliente.Text = TruncateString(lbNombre.Text, limite);
            frm.Lb_User.Text = TruncateString(Lb_User.Text, limite);

            frm.Show();
            this.Hide();
        }

        private string TruncateString(string input, int length)
        {
            return input.Length > length ? input.Substring(0, length) + "..." : input;
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
            txtNombre.Text = "";
            TxtBuscar_Clientes.Text = "";
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Cargar_Clientes();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void Cbx_Clientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Cbx_Clientes.SelectedIndex == -1)
            {
                Limpiar();
                txtIdCliente.Text = "";
                return;
            }

            try
            {
                int id = (int)Cbx_Clientes.SelectedValue;
                Controladores.CtrlClientes ctrlClientes = new Controladores.CtrlClientes();
                Cliente cliente = new Cliente();
                cliente = ctrlClientes.MostrarDatosClientes(id);

                txtIdCliente.Text = id.ToString();
                lbNombre.Text = cliente.Nombre;
                lbTelefono.Text = cliente.Telefono;
                lbDireccion.Text = TruncateString(cliente.Direccion, 30);
                lbCedula.Text = cliente.Cedula;
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes mostrar un MessageBox o hacer otra acción)
            }
        }
    }
}
