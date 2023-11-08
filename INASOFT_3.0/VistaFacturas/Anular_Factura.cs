using DevExpress.XtraCharts.Native;
using DocumentFormat.OpenXml.Drawing;
using Guna.UI2.WinForms;
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
            CargarDatosIniciales(id_Factura);
            CargarDetalleDevolucion();
        }

        private void CargarDatosIniciales(string id_Factura)
        {
            Txt_Facturar.Text = id_Factura;

            foreach (DataGridViewBand band in datagridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        public void CargarDetalleDevolucion()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            datagridView1.DataSource = ctrlFactura.DetalleFactura(int.Parse(Txt_Facturar.Text));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnularFactura_Click(object sender, EventArgs e)
        {
            DialogResult resultado = guna2MessageDialog1.Show("¿Está seguro que desea anular la factura?\n\n", "Anulación de factura");

            if (resultado == DialogResult.Yes)
            {
                string descripcion = txtDescripcion.Text;
                if (string.IsNullOrEmpty(descripcion))
                {
                    descripcion = "La fecha: [" + DateTime.Now + "] - El empelado: " + Sesion.nombre + ", anuló la fact. " + Lb_Factura.Text + "";
                }

                int facturaId = int.Parse(Txt_Facturar.Text);

                Controladores.CtrlDevolucion ctrlDevolucion = new CtrlDevolucion();
                Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();

                Modelos.Devolucion devolucion = new Modelos.Devolucion
                {
                    Descripcion = descripcion,
                    Id_Factura = facturaId
                };

                if (ctrlDevolucion.Agregar_Devolucion(devolucion))
                {
                    List<Modelos.Devolucion> listaDevolucion = new List<Modelos.Devolucion>();

                    foreach (DataGridViewRow fila1 in datagridView1.Rows)
                    {
                        if (!fila1.IsNewRow)
                        {
                            Modelos.Devolucion devolucion1 = new Modelos.Devolucion
                            {
                                Cantidad = int.Parse(fila1.Cells[4].Value.ToString()),
                                Id_devolucion = ctrlDevolucion.ID_Devolucion(),
                                Id_producto = int.Parse(fila1.Cells[0].Value.ToString()),
                                Id_Factura = facturaId
                            };

                            listaDevolucion.Add(devolucion1);
                        }
                    }

                    foreach (Modelos.Devolucion devolucion2 in listaDevolucion)
                    {
                        ctrlDevolucion.Devolucion_productos(devolucion2);
                    }

                    List<Modelos.Facturas> listaFactura = new List<Modelos.Facturas>();

                    foreach (DataGridViewRow fila2 in datagridView1.Rows)
                    {
                        if (!fila2.IsNewRow)
                        {
                            Modelos.Facturas facturas = new Modelos.Facturas
                            {
                                Cantidad = int.Parse(fila2.Cells[4].Value.ToString()),
                                Id_Producto = int.Parse(fila2.Cells[0].Value.ToString()),
                                Id_Factura = facturaId
                            };

                            listaFactura.Add(facturas);
                        }
                    }

                    foreach (Modelos.Facturas facturas1 in listaFactura)
                    {
                        ctrlFactura.AnularFactura(facturas1);
                    }

                    devolucion.Id_devolucion = ctrlDevolucion.ID_Devolucion();
                    devolucion.Id_Factura = facturaId;

                    ctrlDevolucion.Actualizar_Factura(devolucion);

                    Facturas facturas2 = new Facturas
                    {
                        Descripcion = descripcion,
                        Id_Factura = facturaId
                    };

                    if (ctrlFactura.Actualizar_FacturaAnulada(facturas2))
                    {
                        UserControls.UC_Factura uc_Factura = new UserControls.UC_Factura();
                        uc_Factura.CargarFacturas();

                        CtrlInfo ctrlInfo = new CtrlInfo();
                        MessageBox_Import.Show("Se ha realizacón la anulación de la factura con éxito.\n", "Aviso");
                        string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Se ha anulado la Fact." + Lb_Factura.Text;
                        ctrlInfo.InsertarLog(log);
                        this.Close();
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_Fecha.Text = "Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
