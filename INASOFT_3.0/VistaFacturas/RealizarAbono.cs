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
            if(TxtMonto.Text == "" && Txt_Efectivo.Text == "")
            {
                MessageBoxError.Show("No deje ninguna casilla vacía", "Error");                
            }
            else if(TxtMonto.Text != "" && Txt_Efectivo.Text == "")
            {
                MessageBoxError.Show("Debe ingresar el efectivo con el que pago", "Error");
            }
            else if(TxtMonto.Text == "" && Txt_Efectivo.Text != "")
            {
                MessageBoxError.Show("Debe dejar una cantidad del monto para realizar la acción", "Error");
            }
            else if(double.Parse(Txt_Efectivo.Text) < double.Parse(TxtMonto.Text))
            {
                MessageBoxError.Show("El monto no puede ser mayor al efectivo que está dando", "Error");
            }
            else if(double.Parse(Lb_Pendiente.Text) < 0)
            {
                MessageBoxError.Show("El monto se paso a lo que debe.", "Error");
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
                    double vuelto = 0.00;
                    if (double.Parse(Txt_Efectivo.Text) > double.Parse(TxtMonto.Text))
                    {
                        vuelto = double.Parse(Txt_Efectivo.Text) - double.Parse(TxtMonto.Text);
                    }
                    MessageBox_Import.Show("Se ha realizado correctamnete el abono, le debe devolver al cliente C$ " + vuelto +"\n\n","Importante");
                    int bandera2 = ctrlCredito_Abono.Actualizar_FacturaCredito(idcredito, idfactura);
                    if (bandera2 == 1)
                    {
                        MessageBox_Import.Show("Ya se completo la factura al crédito", "Importante");
                    }
                    UserControls.UC_Creditos uC_Creditos = new UserControls.UC_Creditos();
                    uC_Creditos.Cargar_credito();
                    this.Close();
                }
            }
        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtMonto_TextChanged_1(object sender, EventArgs e)
        {
            double pendiente = double.Parse(Lb_Pendiente.Text);
            double aux_pendiente = double.Parse(Lb_Pendiente_aux.Text);
            double monto;
            try
            {
                if (TxtMonto.Text == "")
                {
                    Lb_Pendiente.Text = Lb_Pendiente_aux.Text;
                }
                else
                {
                    monto = double.Parse(TxtMonto.Text);
                    Lb_Pendiente.Text = (aux_pendiente - monto).ToString();
                }
            }
            catch (Exception ex)
            {
                TxtMonto.Text = "";
                Lb_Pendiente.Text = Lb_Pendiente_aux.Text;
            }
        }

        private void TxtMonto_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void Txt_Efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!Txt_Efectivo.Text.Contains(".")))
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
