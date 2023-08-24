using INASOFT_3._0.Controladores;
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
    public partial class Anular_Factura : Form
    {
        public Anular_Factura(string id_Factura)
        {
            InitializeComponent();
            Txt_Facturar.Text = id_Factura;
            CargarDetalleDevolucion();

            foreach (DataGridViewBand band in datagridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        public void CargarDetalleDevolucion()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            datagridView1.DataSource = ctrlFactura.DetalleFactura(Txt_Facturar.Text);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnularFactura_Click(object sender, EventArgs e)
        {
            Controladores.CtrlFactura ctrl = new CtrlFactura();            

            for (int i = 0; i < datagridView1.Rows.Count; i++)
            {
                DataGridViewRow row = datagridView1.Rows[i];
                ctrl.AnularFactura(double.Parse(row.Cells[2].Value.ToString()), int.Parse(row.Cells[3].Value.ToString()), row.Cells[0].Value.ToString(), int.Parse(Txt_Facturar.Text));
            }
            if(txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "La fact. "+Lb_Factura.Text+" queda anulada por algún tipo de error no detallada";
            }
            else
            {
                txtDescripcion.Text = txtDescripcion.Text;
            }
            if (ctrl.Actualizar_FacturaAnulada(txtDescripcion.Text, int.Parse(Txt_Facturar.Text)))
            {
                UserControls.UC_Factura uc_Factura = new UserControls.UC_Factura();
                uc_Factura.CargarFacturas();
                MessageBox.Show("La fact. "+ Lb_Factura.Text + " fue anulada con éxito\n");
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_Fecha.Text = "Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
