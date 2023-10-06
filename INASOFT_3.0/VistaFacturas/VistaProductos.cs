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
    public partial class VistaProductos : Form
    {
        public VistaProductos()
        {
            InitializeComponent();
            Cargar_TablaProductos();

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }

        public void Cargar_TablaProductos()
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
