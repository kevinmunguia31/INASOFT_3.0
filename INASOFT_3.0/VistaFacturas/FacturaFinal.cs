using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class FacturaFinal : Form
    {
        string imagen = "C:\\Users\\DELL 5410\\Desktop\\Ferreteria\\logo.png";
        public FacturaFinal()
        {
            InitializeComponent();
            InstalledPrintersCombo();
            InfoNegocio();
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            txtIdFactura.Text = ctrlFactura.ID_Factura().ToString();
            lbUser.Text = Sesion.nombre;
            Txt_descuento.Text = "0";
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

        public DataTable InfoProducts()
        {
            string dato = txtIdCliente.Text;
            string idFact = txtIdFactura.Text;
            //MySqlDataReader reader = null;
            //string sql = " SELECT a.Cantidad, b.Nombre, a.Precio, a.Total FROM Detalle_Factura a INNER JOIN Productos b ON a.ID_Producto = b.ID INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID WHERE d.ID = '"+ dato +"' && a.ID_Factura = '" + idFact +"'";
            string sql = "SELECT b.Nombre, a.Precio, a.Cantidad, a.Total FROM Detalle_Factura a INNER JOIN Productos b ON a.ID_Producto = b.ID INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID WHERE d.ID = '" + dato + "' && a.ID_Factura = '" + idFact + "'";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            //MySqlCommand comando = new MySqlCommand(sql, conexioBD);
            // reader = comando.ExecuteReader();
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexioBD);
            DataTable consulta = new DataTable();
            adp.Fill(consulta);

            return consulta;
        }

        private void InstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbImpresoras.Items.Add(pkInstalledPrinters);

            }
            cbImpresoras.Text = "POS-80";
        }

        private void FacturaFinal_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = InfoProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            ctrlFactura.Cancelar_Factura(ctrlFactura.ID_Factura());
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void SpinDescuento_ValueChanged(object sender, EventArgs e)
        {
            //int iva = int.Parse(SpinDescuento.Value.ToString());
            //float subtotal = float.Parse(lbSubtotal.Text);
            //float total;
            //float descuento;

            //float desc = descuento = (float.Parse(iva.ToString()) / 100);

            //descuento = (float.Parse(iva.ToString()) / 100) * subtotal;
            //total = subtotal - descuento;

            //lbTotal.Text = total.ToString();
            //lbPrecDesc.Text = descuento.ToString();
            //lbDescCant.Text = iva.ToString();
            //lbDesc.Text = desc.ToString();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbDevolucion.Text = (float.Parse(Txt_Efectivo.Text) - float.Parse(lbTotal.Text)).ToString();
            }
            catch
            {
                lbDevolucion.Text = "0.00";
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            string tipoPago = "";
            if (radioButton1.Checked == true)
            {
                tipoPago = "Dolares";
            }

            if(radioButton2.Checked == true)
            {
                tipoPago = "Cordobas";
            }
            //string sql = "CALL Facturacion_Final('" + Txt_descuento.Text + "','" + lbSubtotal.Text + "','" + guna2TextBox1.Text + "', '" + lbIdFactura.Text + ", '" + tipoPago + "')";
            string sql = "CALL Facturacion_Final(" + Txt_descuento.Text + ", " + lbSubtotal.Text + ", " + Txt_Efectivo.Text + ", "+ txtIdFactura.Text +", '"+ tipoPago +"');";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                MessageDialogInfo.Show("Se actualizo la Factura");

                //////////////// IMPRESION DE LA FACTURA /////////////////////////////////////////////////
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = cbImpresoras.Text;
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += Imprimir;
                printDocument1.Print();

                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                this.Dispose();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Txt_descuento_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //lbTotal.Text = (float.Parse(lbTotal.Text) - float.Parse(Txt_descuento.Text)).ToString();
                double subtotal = Convert.ToDouble(lbSubtotal.Text);
                double total = Convert.ToDouble(lbTotal.Text);
                double desc = Convert.ToDouble(Txt_descuento.Text);

                total = subtotal - desc;
                lbTotal.Text = total.ToString();
            }
            catch
            {
                double subtotal = Convert.ToDouble(lbSubtotal.Text);
                Txt_descuento.Text = "0";
                lbSubtotal.Text = subtotal.ToString();
            }

        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            int width = 280;
            int y = 20;
            Font font2 = new Font("Consolas", 10, FontStyle.Regular, GraphicsUnit.Point);
            Font font3 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);
            Font font4 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);

            Image img = Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new Rectangle(40, y += 20, 200, 90));
            e.Graphics.DrawString(lbDireccionNegocio.Text, font2, Brushes.Black, new RectangleF(20, y += 100, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(lbTelefono.Text, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
            e.Graphics.DrawString("Factura: FAC" +      lbIdFactura.Text, font2, Brushes.Black, new RectangleF(0, y += 25, width, 20));
            e.Graphics.DrawString("Cliente: " + lbNombreCliente.Text, font2, Brushes.Black, new RectangleF(0, y += 25, width, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now + " Caja: " + Sesion.nombre, font3, Brushes.Black, new RectangleF(0, y += 25, width, 20));
            e.Graphics.DrawString("-------------------------------------", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Producto            Cant.       Precio      Total", font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("-------------------------------------", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            //e.Graphics.DrawString("LAM. GYPSUM REG      3         C$ 345      C$1,035", font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                // PROD                     //Cant                                 //Precio                         TOTAL
                try
                {
                    string str = r.Cells[0].Value.ToString();
                    int desiredLength = 18;
                    string subStr = str.Substring(0, Math.Min(desiredLength, str.Length));
                    float cant = float.Parse(r.Cells[2].Value.ToString());
                    e.Graphics.DrawString(subStr.PadRight(desiredLength, ' ') + new string(' ', 3) + cant.ToString().PadRight(4, ' ') + new string(' ', 8) + float.Parse(r.Cells[1].Value.ToString().PadRight(4, ' ')) + new string(' ', 8) + float.Parse(r.Cells[3].Value.ToString().PadRight(5, ' ')), font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
                }
                catch (ArgumentOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch(ArgumentNullException ex) { Console.WriteLine("Error: " + ex.Message); }
            }

            float subtotal = float.Parse(lbSubtotal.Text, CultureInfo.InvariantCulture);
            float descuento = float.Parse(Txt_descuento.Text, CultureInfo.InvariantCulture);
            float total = float.Parse(lbTotal.Text, CultureInfo.InvariantCulture);
            float recibido = float.Parse(Txt_Efectivo.Text, CultureInfo.InvariantCulture);
            float cambio = float.Parse(lbDevolucion.Text, CultureInfo.InvariantCulture);

            e.Graphics.DrawString("SubTotal:  C$" + subtotal.ToString("0,00", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(120, y += 30, width, 20));
            e.Graphics.DrawString("Descuento: C$" + descuento.ToString("0,00", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(120, y += 20, width, 20));
            e.Graphics.DrawString("Total:     C$" + total.ToString("0,00", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(120, y += 20, width, 20));
            e.Graphics.DrawString("---------------------------------", font3, Brushes.Black, new RectangleF(95, y += 20, width, 20));
            e.Graphics.DrawString("Recibido:  C$" + recibido.ToString("0,00", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(120, y += 20, width, 20));
            e.Graphics.DrawString("Cambio:    C$" + cambio.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(120, y += 20, width, 20));

            e.Graphics.DrawString("------------------------------", font3, Brushes.Black, new RectangleF(50, y += 50, width, 20));
            e.Graphics.DrawString("*  ¡GRACIAS POR SU COMPRA!   *", font3, Brushes.Black, new RectangleF(50, y += 20, width, 20));
            e.Graphics.DrawString("------------------------------", font3, Brushes.Black, new RectangleF(50, y += 20, width, 20));

        }
    }
}
