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
    public partial class UC_Proveedor : UserControl
    {
        public UC_Proveedor()
        {
            InitializeComponent();
            CargarTablaProvider(null);
            TotalProovedor();
        }

        public void CargarTablaProvider(string dato)
        {
            List<Productos> lista = new List<Productos>();
            CtrlProveedor _ctrlProveedor = new CtrlProveedor();
            dataGridView1.DataSource = _ctrlProveedor.consulta(dato);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombreYapellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_Proveedor_Load(object sender, EventArgs e)
        {

        }
        public void TotalProovedor()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT count(*) FROM proveedor";
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
                        lbProveedores.Text = reader.GetString(0);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            if (txtNombreYapellido.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "" && txtRuc.Text != "")
            {
                Proveedor _proveedor = new Proveedor();
                _proveedor.Nombre = txtNombreYapellido.Text;
                _proveedor.Telefono = txtTelefono.Text;
                _proveedor.Direccion = txtDireccion.Text;
                _proveedor.Ruc = txtRuc.Text;
                

                CtrlProveedor ctrProveedor = new CtrlProveedor();
                if (txtId.Text != "")
                {
                    _proveedor.Id = int.Parse(txtId.Text);
                    bandera = ctrProveedor.actualizar(_proveedor);
                    MessageDialogInfo.Show("Registro Actualizado Con Exito", "Actualizar Proveedor");
                    TotalProovedor();
                    CargarTablaProvider(null);
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtRuc.Text = "";
                    txtId.Text = "";

                }
                else
                {
                    bandera = ctrProveedor.insertar(_proveedor);
                    MessageDialogInfo.Show("Registro Guardado Con Exito", "Guardar Proveedor");
                    CargarTablaProvider(null);
                    TotalProovedor();
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtRuc.Text = "";
                    txtId.Text = "";
                }
            }
            else
            {
                MessageDialogWar.Show("Rellene Todos los campos", "Aviso");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            CargarTablaProvider(dato);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CargarTablaProvider(null);
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string telefono = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string direccion = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string ruc = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            txtId.Text = id;
            txtNombreYapellido.Text = nombre;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtRuc.Text = ruc;
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageDialog.Show("Seguro que desea eliminar el registro?", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlProveedor _ctrl = new CtrlProveedor();
                bandera = _ctrl.eliminar(id);
                if (bandera)
                {
                    MessageDialogInfo.Show("Registro Eliminado con exito", "Eliminar");
                    CargarTablaProvider(null);
                    TotalProovedor();
                }
            }
        }
    }
}
