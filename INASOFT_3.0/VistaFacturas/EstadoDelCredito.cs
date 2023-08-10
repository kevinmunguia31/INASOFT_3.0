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
    public partial class EstadoDelCredito : Form
    {
        public EstadoDelCredito(int id_Credito, int id_factura)
        {
            InitializeComponent();
            Txt_IDCredito.Text = id_Credito.ToString();
            Txt_IDFactura.Text = id_factura.ToString();
            CargarDetalleCredito();

            foreach (DataGridViewBand band in datagridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        public void CargarDetalleCredito()
        {
            Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
            datagridView1.DataSource = ctrlCredito_Abono.Cargar_EstadoDeCredito(int.Parse(Txt_IDCredito.Text));
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
