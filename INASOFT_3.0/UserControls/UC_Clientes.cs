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

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Clientes : UserControl
    {
        public UC_Clientes()
        {
            InitializeComponent();
            CargarTablaClient(null);
            Controladores.CtrlClientes ctrlClientes = new CtrlClientes();
            lbClientes.Text = ctrlClientes.TotalClientes().ToString();
        }

        public void CargarTablaClient(string dato)
        {
            CtrlClientes _ctrlCliente = new CtrlClientes();
            dataGridView1.DataSource = _ctrlCliente.CargarClientes(dato);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            if (txtNombreYapellido.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "" && txtCedula.Text != "")
            {
                Cliente _cliente = new Cliente();
                _cliente.Nombre = txtNombreYapellido.Text;
                _cliente.Telefono = txtTelefono.Text;
                _cliente.Direccion = txtDireccion.Text;
                _cliente.Cedula = txtCedula.Text;
               
                CtrlClientes ctrlClientes = new CtrlClientes();
                if (txtId.Text != "")
                {
                    _cliente.Id = int.Parse(txtId.Text);
                    bandera = ctrlClientes.Actualizar(_cliente);
                    MessageBox_Import.Show("Registro Actualizado Con Exito", "Actualizar Cliente");
                    CargarTablaClient(null);
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCedula.Text = "";
                    txtId.Text = "";
                }
                else
                {
                    bandera = ctrlClientes.Insertar(_cliente);
                    MessageBox_Import.Show("Registro Guardado Con Exito", "Guardar Cliente");
                    CargarTablaClient(null);
                    lbClientes.Text = ctrlClientes.TotalClientes().ToString();
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCedula.Text = "";
                    txtId.Text = "";
                }
            }
            else
            {
                MessageBox_Error.Show("Rellene Todos los campos", "Error");
            }
        }

        private void editInfo_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string telefono = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string direccion = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string cedula = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            txtId.Text = id;
            txtNombreYapellido.Text = nombre;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtCedula.Text = cedula;
        }

        private void deleteClient_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = guna2MessageDialog6.Show("¿Seguro que desea eliminar el registro?", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlClientes _ctrl = new CtrlClientes();
                bandera = _ctrl.Eliminar(id);
                if (bandera)
                {
                    MessageBox.Show("Registro Eliminado con exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaClient(null);
                    Controladores.CtrlClientes ctrlClientes = new CtrlClientes();
                    lbClientes.Text = ctrlClientes.TotalClientes().ToString();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CargarTablaClient(null);
        }

        private void Bttn_Info_Click(object sender, EventArgs e)
        {
            MessageBox_Import.Show(
             "1. Tendrá la opción de añadir un nuevo usuario.\n" +
             "2. Al dar click derecho se desplega un menú con dos opciones: Editar y Eliminar.\n" +
             "3. Tiene que rellenar todos los campos que se le pide en el formulario.\n\n" +
             "\n", "Modúlo de cliente");
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            CargarTablaClient(dato);
        }
    }
}
