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

namespace INASOFT_3._0
{
    public partial class ADDEDIT : Form
    {
        public ADDEDIT()
        {
            InitializeComponent();
            CargarProveedor();
        }

        public void CargarProveedor()
        {
            cbProveedor.DataSource = null;
            cbProveedor.Items.Clear();
            string sql = "SELECT id, nombre FROM proveedor ORDER BY nombre ASC";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                MySqlDataAdapter data = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                data.Fill(dt);

                cbProveedor.ValueMember = "id";
                cbProveedor.DisplayMember = "nombre";
                cbProveedor.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Cargar" + ex.Message);
            }
            finally { conexioBD.Close(); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPrecioCompra.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPrecioVenta.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            if (txtCodBarra.Text != "" && txtNameP.Text != "" && SpinExist.Value != 0 && txtPrecioCompra.Text != "" && txtPrecioVenta.Text != "" &&  txtObservacion.Text != "")
            {
                Productos _producto = new Productos();
                _producto.Codigo = txtCodBarra.Text;
                _producto.Nombre = txtNameP.Text;
                _producto.Existencias = int.Parse(SpinExist.Value.ToString());
                _producto.Precio_compra = double.Parse(txtPrecioCompra.Text);
                _producto.Precio_venta = double.Parse(txtPrecioVenta.Text);
                _producto.Observacion = txtObservacion.Text;
                _producto.Id_proveedor = Convert.ToInt32(cbProveedor.SelectedValue.ToString());


                CtrlProductos ctrl = new CtrlProductos();
                if (txtId.Text != "")
                {
                    _producto.Id = int.Parse(txtId.Text);
                    bandera = ctrl.Actualizar(_producto);
                    MessageBox.Show("Registro Actualizado Con Exito", "Actualizar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(_producto.Codigo + "\n" + _producto.Nombre + "\n" + _producto.Existencias + "\n" + _producto.Precio_compra + "\n" + _producto.Precio_venta + "\n" + _producto.Observacion + "\n" + _producto.Id_proveedor);
                    this.Dispose();
                }
                else
                {
                    try
                    {
                        bandera = ctrl.Insertar(_producto);
                        MessageBox.Show("Registro Guardado Con Exito", "Guardar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        this.Dispose();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Rellene Todos los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            txtCodBarra.Text = "";
            txtNameP.Text = "";
            SpinExist.Value = 0;
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtObservacion.Text = "";
            cbProveedor.SelectedIndex = -1;
        }
    }
}
