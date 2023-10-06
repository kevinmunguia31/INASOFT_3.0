using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

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

            List<Modelos.Facturas> lista = new List<Modelos.Facturas>();

            foreach (DataGridViewRow fila in datagridView1.Rows)
            {
                if (!fila.IsNewRow)
                {
                    Modelos.Facturas facturas = new Modelos.Facturas
                    {
                        Cantidad = int.Parse(fila.Cells[4].Value.ToString()),
                        Id_Factura = int.Parse(Txt_Facturar.Text),
                        Id_Producto = int.Parse(fila.Cells[0].Value.ToString())
                    };
                    lista.Add(facturas);
                }
            }

            foreach (Facturas facturas1 in lista)
            {
                ctrl.AnularFactura(facturas1);
            }

            string descripcion = string.IsNullOrEmpty(txtDescripcion.Text)
                ? $"La fact. {Lb_Factura.Text} queda anulada por algún tipo de error no detallado"
                : txtDescripcion.Text;

            Facturas facturas2 = new Facturas
            {
                Descripcion = descripcion,
                Id_Factura = int.Parse(Txt_Facturar.Text)
            };

            if (ctrl.Actualizar_FacturaAnulada(facturas2))
            {
                UserControls.UC_Factura uc_Factura = new UserControls.UC_Factura();
                uc_Factura.CargarFacturas();
                MessageBox_Import.Show($"La fact. {Lb_Factura.Text} fue anulada con éxito\n", "Importante");
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_Fecha.Text = "Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
