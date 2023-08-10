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
    public partial class RealizarAbono : Form
    {
        public RealizarAbono()
        {
            InitializeComponent();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAceppt_Click(object sender, EventArgs e)
        {
            if(TxtMonto.Text == "")
            {
                MessageBoxError.Show("Debe dejar una cantidad del monto para realizar la acción", "Error");                
            }
            else
            {
                string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
                string hora = DateTime.Now.ToString("hh:mm:ss");
                string Fecha_final = fecha + " " + hora;
                string User = Sesion.id.ToString();
                double monto = double.Parse(TxtMonto.Text);
                string desc = "";
                int idfactura = int.Parse(Txt_IDFactura.Text);
                int idcredito = int.Parse(Txt_IDCredito.Text);
                double saldo_nuevo = 0.00;
                double saldo_anterior = 0.00;

                if (txtDescripcion.Text == "")
                {
                    desc = "Se realizo un abono de: C$" + monto;
                }
                else
                {
                    desc = txtDescripcion.Text;
                }
                
                Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
                saldo_anterior = ctrlCredito_Abono.Saldo_Credito(idcredito);
                saldo_nuevo = saldo_anterior - monto;
                bool bandera = ctrlCredito_Abono.Realizar_Abono(Fecha_final, monto, saldo_anterior, saldo_nuevo, desc, idcredito, idfactura);
                if (bandera)
                {

                    MessageBox_Import.Show("Se ha realizado correctamnete el abono","Importante");
                    int bandera2 = ctrlCredito_Abono.Actualizar_FacturaCredito(idcredito, idfactura);
                    if (bandera2 == 1)
                    {
                        MessageBox_Import.Show("Ya se completo la factura al crédito", "Importante");
                    }
                    this.Close();
                }
            }
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!TxtMonto.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
    }
}
