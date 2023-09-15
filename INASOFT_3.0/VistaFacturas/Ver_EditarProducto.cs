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
    }
}
