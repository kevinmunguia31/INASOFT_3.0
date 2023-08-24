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
    public partial class FacturaAlCredito : Form
    {
        public FacturaAlCredito()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BttnConfirmar_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
            string hora = DateTime.Now.ToString("hh:mm:ss");

            double monto = 0.00;
            string fecha_vencimiento = DateTime_vencimiento.Text;
            string fecha_inicioDevolucion = (fecha +" "+ hora);
            string fecha_inicio = DateTime_inicio.Text;
            double cargo = double.Parse(Lb_Cargo.Text);
            double saldo_nuevo = 0.00;
            double saldo_anterior = 0.00;
            string estado = "Pendiente";
            int id_factura = int.Parse(Txt_IDFactura.Text);
            int id_cliente = int.Parse(Txt_IDCliente.Text);
            string desc_credito = "";
            string desc_abono = "";
            string tipoPago = "";

            if(Rbtn_TipoCordobas.Checked == false && Rbtn_TipoDolares.Checked == false)
            {
                MessageBoxError.Show("No deje la casilla 'Tipo de pago' sin marcar", "Error");
            }
            else
            {
                if (txtDescripcion.Text == "")
                {
                    desc_credito = "Factura realizada al crédito al cliente " + Lb_Cliente.Text + " con un saldo pendiente de: " + Lb_Saldo.Text;
                }
                else
                {
                    desc_credito = txtDescripcion.Text;
                }

                if (Rbtn_TipoCordobas.Checked == true)
                {
                    tipoPago = "Córdobas";
                }
                if (Rbtn_TipoDolares.Checked == true)
                {
                    tipoPago = "Dólares";
                }

                if (TxtMonto.Text == "")
                {
                    monto = 0.00;
                    desc_abono = "Primer abono realizado es de C$ 0.00 el mismo día que se hizo la factura.";
                    saldo_nuevo = double.Parse(Lb_Cargo.Text);
                }
                else
                {
                    monto = double.Parse(TxtMonto.Text);
                    desc_abono = "Primer abono realizado es de C$" + monto + " el mismo día que se hizo la factura.";
                    saldo_nuevo = double.Parse(Lb_Cargo.Text) - monto;
                }

                Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
                bool bandera = ctrlCredito_Abono.Insertar_Credito(tipoPago, fecha_inicio, fecha_vencimiento, cargo, estado, desc_credito, id_factura, id_cliente);
                //MessageBox.Show(fecha_inicio + "\n" + fecha_vencimiento + "\n" + cargo +"\n"+ saldo + "\n" +estado + "\n" + id_factura + "\n" + id_cliente);
                //MessageBox.Show(fecha_inicio + "\n" + monto + "\n" + desc + "\n");
                if (bandera)
                {
                    int id_credito = ctrlCredito_Abono.ID_Credito();
                    ctrlCredito_Abono.Realizar_Abono(fecha_inicioDevolucion, monto, saldo_anterior, saldo_nuevo, desc_abono, id_credito, id_factura);
                    MessageBox_Import.Show("Se realizó la acción con éxito, el cliente debe C$ " + Lb_Saldo.Text + "\n", "Importante");
                    UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                    uC_Factura.CargarFacturas();
                    this.Close();
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }
        private void FacturaAlCredito_Load(object sender, EventArgs e)
        {
            if(double.Parse(Lb_Descuento.Text) > 0.00)
            {
                Lb_Descuento.ForeColor = Color.Red;
            }
        }


        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            double saldo = double.Parse(Lb_Saldo.Text);
            double cargo = double.Parse(Lb_Cargo.Text);
            double monto;
            try
            {
                if (TxtMonto.Text == "")
                {
                    Lb_Saldo.Text = Lb_Cargo.Text;
                }
                else
                {
                    monto = double.Parse(TxtMonto.Text);
                    saldo = cargo - monto;
                    Lb_Saldo.Text = saldo.ToString();
                }
            }
            catch (Exception ex)
            {
                TxtMonto.Text = "";
                Lb_Saldo.Text = Lb_Cargo.Text;
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
