using DevExpress.XtraCharts.GLGraphics.Platform;
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
            txtCodBarra.Enabled = false;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            TxtExistemcias.Text = "0.0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_AddProducto_Click_1(object sender, EventArgs e)
        {
            if (txtNameP.Text == "" || txtPrecioCompra.Text == "" || txtPrecioVenta.Text == "")
            {
                MessageBox_Error.Show("No deje casillas obligatorias sin marcar", "Error");
                return;
            }

            // Crear un objeto Productos con los datos del formulario
            Modelos.Productos productos = new Modelos.Productos()
            {
                Id = int.Parse(Txt_IDProd.Text),
                Nombre = txtNameP.Text.ToUpper(),
                Estado = "Activo",
                Existencias = 0.0,
                Existencias_min = double.Parse(TxtExistemcias.Text),
                Precio_compra = double.Parse(txtPrecioCompra.Text),
                Precio_venta = double.Parse(txtPrecioVenta.Text),
                Observacion = string.IsNullOrWhiteSpace(txtObservacion.Text) ? "Se ha modificado el producto" : txtObservacion.Text
            };

            Controladores.CtrlProductos ctrlProductos = new Controladores.CtrlProductos();
            bool bandera = ctrlProductos.Actualizar(productos);

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

                string log = Sesion.nombre + " Modifico el producto con codigo: " + productos.Codigo;
                string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                ctrlInfo.InsertarLog(fecha, log);
            }

            if (radioButton4.Checked)
            {
                // Realizar operaciones relacionadas con remesas
                Remision remision = new Remision();
                //remision.Descripcion = Txt_Descripcion.Text;
                remision.Descripcion = string.IsNullOrWhiteSpace(Txt_Descripcion.Text) ? "El usuario: " + Sesion.nombre + " ha realizado una remisión de entrada" : Txt_Descripcion.Text;
                remision.Id_Usuario = Sesion.id;
                remision.Tipo_Remision = "Remisión de Salida";

                CtrlRemision ctrlRemision = new CtrlRemision();
                bool bandera2 = ctrlRemision.RealizarRemesa(remision);

                if (bandera2)
                {
                    Productos productos1 = new Productos();
                    productos1.Id = int.Parse(Txt_IDProd.Text);
                    productos1.Nombre = txtNameP.Text;
                    productos1.Existencias = double.Parse(TxtCantidad.Text);
                    productos1.Id_remision = ctrlRemision.ID_Remision();
                    bool bandera3 = ctrlRemision.Remision_ProductosSalida(productos1);

                    if (bandera3)
                    {
                        MessageBox_Import.Show("Se ha realizado la remisión", "Aviso");
                    }
                }
            }
            this.Close();
        }

        private void Rbttn_ExistProduct_CheckedChanged(object sender, EventArgs e)
        {
            txtCodBarra.Enabled = false;
            GroupBox_EditarProd.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = true;
            txtPrecioVenta.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            TxtCantidad.Enabled = false;
            Txt_Descripcion.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            TxtCantidad.Enabled = true;
            Txt_Descripcion.Enabled = true;
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }

        private void TxtExistemcias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }
    }
}
