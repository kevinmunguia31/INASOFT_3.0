using DevExpress.XtraCharts;
using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class RealizarAbono : Form
    {
        string imagen = "C:\\Users\\DELL 5410\\Desktop\\Ferreteria\\logo.png";
        public RealizarAbono()
        {
            InitializeComponent();
            InfoNegocio();
            InstalledPrintersCombo();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT nombre_negocio, direccion_negocio, num_ruc, telefono FROM infogeneral";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lbNombreNegocio.Text = reader.GetString("nombre_negocio");
                        lbDireccionNegocio.Text = reader.GetString("direccion_negocio");
                        lbNmRUC.Text = reader.GetString("num_ruc");
                        lbTelefono.Text = reader.GetString("telefono");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void InstalledPrintersCombo()
        {
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbImpresoras.Items.Add(pkInstalledPrinters);
            }
            cbImpresoras.Text = "POS-80";
        }

        private void BtnAceppt_Click(object sender, EventArgs e)
        {
            double monto;
            double efectivo;
            double saldoNuevo;
            double saldoAnterior;
            // Validación básica de entrada
            if (string.IsNullOrWhiteSpace(TxtMonto.Text) || string.IsNullOrWhiteSpace(Txt_Efectivo.Text))
            {
                MessageBoxError.Show("No deje ninguna casilla vacía", "Error");
                return;
            }

            if (!double.TryParse(TxtMonto.Text, out monto) || !double.TryParse(Txt_Efectivo.Text, out efectivo))
            {
                MessageBoxError.Show("Ingrese montos válidos", "Error");
                return;
            }

            if (monto > efectivo)
            {
                MessageBoxError.Show("El monto no puede ser mayor al efectivo que está dando", "Error");
                return;
            }

            if (double.Parse(Lb_Pendiente.Text) < 0)
            {
                MessageBoxError.Show("El monto se pasó a lo que debe.", "Error");
                return;
            }

            int idFactura = int.Parse(Txt_IDFactura.Text);
            int idCredito = int.Parse(Txt_IDCredito.Text);
            string desc = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? $"Se realizó un abono de: C${monto}" : txtDescripcion.Text;

            Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
            saldoAnterior = ctrlCredito_Abono.Saldo_Credito(idCredito);
            saldoNuevo = saldoAnterior - monto;

            Modelos.Credito credito = new Modelos.Credito
            {
                Monto = monto,
                Saldo_Anterior = saldoAnterior,
                Saldo_Nuevo = saldoNuevo,
                Descripcion_Abono = desc,
                Id_Credito = idCredito,
                Id_Factura = idFactura
            };

            bool bandera = ctrlCredito_Abono.Realizar_Abono(credito);

            if (bandera)
            {
                double vuelto = efectivo > monto ? efectivo - monto : 0.00;
                MessageBox_Import.Show($"Se ha realizado correctamente el abono, le debe devolver al cliente C$ {vuelto}\n\n", "Importante");
                int bandera2 = ctrlCredito_Abono.Actualizar_FacturaCredito(credito);

                if (bandera2 == 1)
                {
                    MessageBox_Import.Show("Ya se completó la factura al crédito", "Importante");
                }

                UserControls.UC_Creditos uC_Creditos = new UserControls.UC_Creditos();
                uC_Creditos.Cargar_credito();
                DialogResult result = MessageBox_Question.Show("¿Desea Imprimir el Recibo?");

                if (result == DialogResult.Yes)
                {
                    //////////////// IMPRESIÓN DEL RECIBO /////////////////////////////////////////////////
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cbImpresoras.Text;
                    printDocument1.PrinterSettings = ps;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();
                }

                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                uC_Factura.CargarFacturas();
                this.Close();
            }
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            int width = 280;
            int y = 20;
            Font font2 = new Font("Consolas", 9, FontStyle.Regular, GraphicsUnit.Point);
            Font font3 = new Font("Consolas", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font font4 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);
            Font font5 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);

            //Image img = Image.FromFile(imagen);
            //e.Graphics.DrawImage(img, new System.Drawing.Rectangle(40, y += 0, 200, 90));
            e.Graphics.DrawString(lbDireccionNegocio.Text, font2, Brushes.Black, new RectangleF(20, y += 100, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(lbTelefono.Text, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Factura:" + Txt_IDFactura.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
            e.Graphics.DrawString("Cliente: " + Lb_Cliente.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Caja: " + Sesion.nombre, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("            RECIBO DE CAJA", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            e.Graphics.DrawString("Saldo Incial: C$" + Lb_Cargo.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Saldo Pendiente: C$" + Lb_Pendiente_aux.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Abono: C$" + TxtMonto.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Nuevo Saldo: C$" + Lb_Pendiente.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));

            float Abono = float.Parse(TxtMonto.Text, CultureInfo.InvariantCulture);
            float recibido = float.Parse(Txt_Efectivo.Text, CultureInfo.InvariantCulture);
            double vuelto = double.Parse(Txt_Efectivo.Text) - double.Parse(TxtMonto.Text);

            e.Graphics.DrawString("Total:     C$" + Abono.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("-------------------------", font3, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Recibido:  C$" + recibido.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Cambio:    C$" + vuelto.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));

            e.Graphics.DrawString("________________________________", font3, Brushes.Black, new RectangleF(45, y += 80, width, 20));
            e.Graphics.DrawString("        Recibi Conforme     ", font3, Brushes.Black, new RectangleF(45, y += 20, width, 20));
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

        private void GBox_Cod_Fact_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
