using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
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
    public partial class Ver_EditarProducto : Form
    {
        public Ver_EditarProducto()
        {
            InitializeComponent();
            CargarProductos();
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
            txtCodBarra.Enabled = false;
            txtPrecioCompra.Enabled = false;
            SpinExist.Enabled = false;
        }

        public void CargarProductos()
        {
            Controladores.CtrlProductos ctrlProductos = new Controladores.CtrlProductos();
            dataGridView1.DataSource = ctrlProductos.CargarDetalleProductos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_AddProducto_Click(object sender, EventArgs e)
        {
            Modelos.Productos productos = new Modelos.Productos();
            //Actualizar_Producto(_ID_Producto INT, _Estado VARCHAR(50), _Existencias INT, _Precio_Compra DOUBLE,
            //_Precio_Venta DOUBLE, _Observacion VARCHAR(200))
            productos.Id = int.Parse(Txt_IDProd.Text);
            productos.Estado = Cbx_Estados.SelectedItem.ToString();
            productos.Existencias = int.Parse(SpinExist.Value.ToString());
            productos.Precio_compra = double.Parse(txtPrecioCompra.Text);
            productos.Precio_venta = double.Parse(txtPrecioVenta.Text);
            productos.Observacion = txtObservacion.Text;

            Controladores.CtrlProductos ctrlProductos = new Controladores.CtrlProductos();
            bool bandera = ctrlProductos.Actualizar(productos);

            if (bandera)
            {
                MessageBox_Import.Show("Se ha actualizado el producto", "Aviso");
                CtrlInfo ctrlInfo = new CtrlInfo();

                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Modifico el producto con codigo: " + productos.Codigo;
                ctrlInfo.InsertarLog(log);
                this.Close();
            }
        }
    }
}
