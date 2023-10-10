using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class Ver_EditarProducto : Form
    {
        public Ver_EditarProducto()
        {
            InitializeComponent();
            CargarProductos();
            Cbx_Productos.SelectedIndex = -1;
            GroupBox_EditarProd.Enabled = false;
        }

        private void CargarProductos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProducto();
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Limpiar()
        {
            txtNameP.Text = "";
            txtObservacion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtCodBarra.Text = "";
            Txt_IDProd.Text = "ID";
            SpinExist.Value = 0;
            SpinExis_Min.Value = 0;
            Cbx_Estados.SelectedIndex = -1;
        }

        private void Btn_AddProducto_Click_1(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrlProductos = new Controladores.CtrlProductos();
            string codigo = txtCodBarra.Text;
            string mensaje = "";

            if (Rbttn_NewProduct.Checked)
            {
                mensaje = ctrlProductos.EvaluacionCodigo(codigo);
                if (mensaje != "No existe")
                {
                    MessageBox_Error.Show("El código ya " + mensaje);
                    return; // No se ejecutan más acciones si el código ya existe.
                }
            }

            Modelos.Productos productos = new Modelos.Productos()
            {
                Id = int.Parse(Txt_IDProd.Text),
                Codigo = codigo,
                Nombre = txtNameP.Text.ToUpper(),
                Existencias = int.Parse(SpinExist.Value.ToString()),
                Existencias_min = int.Parse(SpinExis_Min.Value.ToString()),
                Precio_compra = double.Parse(txtPrecioCompra.Text),
                Precio_venta = double.Parse(txtPrecioVenta.Text),
                Observacion = txtObservacion.Text
            };

            CtrlRemision remesa = new CtrlRemision();
            bool bandera = remesa.RealizarRemesa(productos);

            if (bandera)
            {
                MessageBox_Import.Show("Se ha actualizado el inventario", "Aviso");

                // Obtén una referencia a la instancia existente de UC_Productos
                UC_Productos uC_Productos = Application.OpenForms.OfType<UC_Productos>().FirstOrDefault();

                if (uC_Productos != null)
                {
                    // Si se encuentra la instancia, actualiza la tabla de productos
                    uC_Productos.CargarTablaProduct();
                }

                CtrlInfo ctrlInfo = new CtrlInfo();

                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Modifico el producto con codigo: " + productos.Codigo;
                ctrlInfo.InsertarLog(log);

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VistaProductos vistaProductos = new VistaProductos();
            vistaProductos.ShowDialog();
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    Limpiar();
                }
                else
                {
                    Txt_IDProd.Text = Cbx_Productos.SelectedValue.ToString();
                    int id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                    Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                    Productos productos = new Productos();

                    productos = ctrlProductos.MostrarDatosProductos(id);

                    txtCodBarra.Text = productos.Codigo.ToString();
                    txtNameP.Text = productos.Nombre;
                    SpinExis_Min.Value = productos.Existencias_min;
                    Lb_CantStocks.Text = productos.Existencias.ToString();
                    txtPrecioVenta.Text = productos.Precio_venta.ToString();
                    txtPrecioCompra.Text = productos.Precio_compra.ToString();
                    txtObservacion.Text = productos.Observacion.ToString();
                    //Cbx_Estados.SelectedItem = productos.Estado.ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex);
            }
        }

        private void Rbttn_NewProduct_CheckedChanged(object sender, EventArgs e)
        {
            GroupBox_EditarProd.Enabled = true;
            txtCodBarra.Enabled = true;
            Txt_IDProd.Text = "0";
            Cbx_Productos.SelectedIndex = -1;
            Cbx_Productos.Enabled = false;
            TxtBuscar_Productos.Text = "";
            TxtBuscar_Productos.Enabled = false;
            button1.Enabled = false;
        }

        private void Rbttn_ExistProduct_CheckedChanged(object sender, EventArgs e)
        {
            txtCodBarra.Enabled = false;
            GroupBox_EditarProd.Enabled = true;
            Cbx_Productos.SelectedIndex = -1;
            Cbx_Productos.Enabled = true;
            TxtBuscar_Productos.Text = "";
            TxtBuscar_Productos.Enabled = true;
            button1.Enabled = true;
        }

        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Buscar_NombreProducto(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarProductos();
        }
    }
}
