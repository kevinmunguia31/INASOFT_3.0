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
            TotalClientes();
        }
        public void CargarTablaClient(string dato)
        {
            List<Productos> lista = new List<Productos>();
            CtrlClientes _ctrlCliente = new CtrlClientes();
            dataGridView1.DataSource = _ctrlCliente.consulta(dato);
        }

        public void TotalClientes()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT count(*) FROM clientes";
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
                        lbClientes.Text = reader.GetString(0);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                    bandera = ctrlClientes.actualizar(_cliente);
                    MessageBox.Show("Registro Actualizado Con Exito", "Actualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TotalClientes();
                    CargarTablaClient(null);
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCedula.Text = "";
                    txtId.Text = "";

                }
                else
                {
                    bandera = ctrlClientes.insertar(_cliente);
                    MessageBox.Show("Registro Guardado Con Exito", "Guardar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaClient(null);
                    TotalClientes();
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCedula.Text = "";
                    txtId.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Rellene Todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UC_Clientes_Load(object sender, EventArgs e)
        {

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
            DialogResult resultado = MessageBox.Show("Seguro que desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlClientes _ctrl = new CtrlClientes();
                bandera = _ctrl.eliminar(id);
                if (bandera)
                {
                    MessageBox.Show("Registro Eliminado con exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaClient(null);
                    TotalClientes();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            CargarTablaClient(dato);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CargarTablaClient(null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
