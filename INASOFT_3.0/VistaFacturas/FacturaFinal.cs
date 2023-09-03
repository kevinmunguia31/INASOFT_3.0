using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml;
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
            //lbIdFactura.Text = ctrlFactura.Codigo_Factura().ToString();

            InfoProducts();
            lbUser.Text = Sesion.nombre;            

            datagridView2.Rows.Add("Total", "", "", "", 0);

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();
            
        }

        public void Cargar_Total()
        {
            double Total = 0.00;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                int numeroRedondeado = (int)Math.Ceiling(Total);
                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = numeroRedondeado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void FacturaFinal_Load(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "1")
            {
                lbNombreCliente.Text = "Cliente generico";
            }
            else
            {
                int limite = 20;
                if (lbNombreCliente.Text.Length > limite)
                {
                    lbNombreCliente.Text = lbNombreCliente.Text.Substring(0, limite) + "...";
                }
                else
                {
                    lbNombreCliente.Text = lbNombreCliente.Text;
                }
            }
            if (txtIdCliente.Text == "1")
            {
                RBtn_Credito.Visible = false;
                RBtn_AlContado.Checked = true;
                groupBox2.Enabled = false;
            }
            else
            {
                RBtn_Credito.Visible = true;
            }

            Txt_descuento.Text = "0";
        }

        public void Subtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < datagridView2.Rows.Count; i++)
            {
                subtotal += float.Parse(datagridView2.Rows[i].Cells[4].Value.ToString());
                
            }
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

        public void InfoProducts()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridView1.DataSource = ctrlFactura.DetalleFactura(txtIdFactura.Text);    
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult resultado = guna2MessageDialog1.Show("¿Seguro que desea anular la factura?", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                this.Hide();
                Anular_Factura frm = new Anular_Factura(txtIdFactura.Text);
                frm.Txt_Facturar.Text = txtIdFactura.Text;
                frm.Lb_Factura.Text = lbIdFactura.Text;
                frm.Lb_Credito1.Visible = false;
                frm.Lb_Credito2.Visible = false;
                frm.Lb_Devolucion3.Visible = false;

                frm.ShowDialog();
                this.Close();
            }
            else
            {

            }
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbDevolucion.Text = (double.Parse(Txt_Efectivo.Text) - double.Parse(lbTotal.Text)).ToString();
            }
            catch
            {
                lbDevolucion.Text = "0.00";
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            string tipoPago = "";
            string estado = "";
            string tipoFactura = "";
            double debe = 0.00;
            double descuento = 0.00;
            double total = double.Parse(lbTotal.Text);
            double subtotal = double.Parse(lbSubtotal.Text);
            double efectivo;
            int id_factura = int.Parse(txtIdFactura.Text);
            double devolucion = double.Parse(lbDevolucion.Text);

            if (RBtn_Credito.Checked == false && RBtn_AlContado.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar el tipo de factura que se realizará");
            }
            //FACTURA AL CRÉDITO
            else if (RBtn_Credito.Checked == true && RBtn_AlContado.Checked == false)
            {
                tipoFactura = "Crédito";
                estado = "Pendiente";

                efectivo = 0.00;
                debe = double.Parse(lbTotal.Text);
                devolucion = 0.00;

                //Descuento
                if (Txt_descuento.Text == "")
                {
                    descuento = 0.00;
                }
                else if (double.Parse(Txt_descuento.Text) > double.Parse(lbTotal.Text) / 2)
                {
                    MessageBox_Error.Show("El descuento realizado es demasiado.", "Error");
                    Txt_descuento.Text = "";
                    Txt_Efectivo.Text = "";
                }
                else
                {
                    descuento = double.Parse(Txt_descuento.Text);
                }

                Controladores.CtrlFactura ctrlFactura = new CtrlFactura();

                bool bandera = ctrlFactura.Facturacion_Final(estado, descuento, subtotal, efectivo, debe, id_factura, tipoPago, tipoFactura);

                if (bandera)
                {
                    FacturaAlCredito frm = new FacturaAlCredito();
                    frm.Lb_Cargo.Text = total.ToString();
                    frm.Lb_Saldo.Text = total.ToString();
                    frm.Lb_Trabajador.Text = lbUser.Text;
                    frm.Lb_Cliente.Text = lbNombreCliente.Text;
                    frm.Lb_Descuento.Text = descuento.ToString();
                    frm.Txt_IDCliente.Text = txtIdCliente.Text;
                    frm.Txt_IDFactura.Text = txtIdFactura.Text;
                    frm.Show();
                    this.Hide();
                }
            }
            //FACTURA AL CONTADO
            else if (RBtn_Credito.Checked == false && RBtn_AlContado.Checked == true)
            {
                if (cbImpresoras.SelectedIndex == -1)
                {
                    MessageBox_Error.Show("Debe seleccionar un tipo de impresora.", "Error");
                }
                else if (Rbtn_TipoCordobas.Checked == false && Rbtn_TipoDolares.Checked == false)
                {
                    MessageBox_Error.Show("No deje la la opción de 'Tipo de pago' sin marcar.", "Error");
                }
                else if (Txt_Efectivo.Text == "")
                {
                    MessageBox_Error.Show("No deje la casilla de 'Efectivo' sin marcar", "Error");
                }
                else if (double.Parse(lbDevolucion.Text) < 0)
                {
                    MessageBox_Error.Show("Tiene que pagar completo la compra", "Error");
                }
                else if (Txt_descuento.Text != "" && double.Parse(Txt_descuento.Text) > double.Parse(lbTotal.Text) / 2)
                {
                    MessageBox_Error.Show("El descuento realizado es demasiado.", "Error");
                    Txt_descuento.Text = "";
                }
                else
                {
                    tipoFactura = "Al contado";
                    estado = "Cancelado";
                    debe = 0.00;
                    efectivo = double.Parse(Txt_Efectivo.Text);
                    //Descuento
                    if (Txt_descuento.Text == "")
                    {
                        descuento = 0.00;
                    }
                    else
                    {
                        descuento = double.Parse(Txt_descuento.Text);
                    }

                    if(Rbtn_TipoCordobas.Checked == true)
                    {
                        tipoPago = "Córdobas";
                    }
                    if (Rbtn_TipoDolares.Checked == true)
                    {
                        tipoPago = "Dólares";
                    }
                    try
                    {
                        Controladores.CtrlFactura ctrlFactura = new CtrlFactura();

                        bool bandera = ctrlFactura.Facturacion_Final(estado, descuento, subtotal, efectivo, debe, id_factura, tipoPago, tipoFactura);

                        if (bandera)
                        {
                            DialogResult result = MessageBox_Question.Show("¿Desea Imprimir la factura?");

                            if (result == DialogResult.Yes)
                            {
                                //////////////// IMPRESION DE LA FACTURA /////////////////////////////////////////////////
                                printDocument1 = new PrintDocument();
                                PrinterSettings ps = new PrinterSettings();
                                ps.PrinterName = cbImpresoras.Text;
                                printDocument1.PrinterSettings = ps;
                                printDocument1.PrintPage += Imprimir;
                                printDocument1.Print();

                                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                                uC_Factura.CargarFacturas();
                                this.Close();
                            }
                            else if(result == DialogResult.No)
                            {
                                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                                uC_Factura.CargarFacturas();
                                this.Close();
                            }
                           

                           
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
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

            Image img = Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(40, y += 0, 200, 90));
            e.Graphics.DrawString(lbDireccionNegocio.Text, font2, Brushes.Black, new RectangleF(20, y += 100, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(lbTelefono.Text, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Factura:" +      lbIdFactura.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
            e.Graphics.DrawString("Cliente: " + lbNombreCliente.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Caja: " + Sesion.nombre, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Producto            Cant.       P.Unit      Total", font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            //e.Graphics.DrawString("LAM. GYPSUM REG      3         C$ 345      C$1,035", font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                // PROD                     //Cant                                 //Precio                         TOTAL
                try
                {
                    string str = r.Cells[1].Value.ToString();
                    int desiredLength = 18;
                    string subStr = str.Substring(0, Math.Min(desiredLength, str.Length));
                    float cant = float.Parse(r.Cells[3].Value.ToString());
                    e.Graphics.DrawString(subStr.PadRight(desiredLength, ' ') + new string(' ', 3) + cant.ToString().PadRight(4, ' ') + new string(' ', 8) + float.Parse(r.Cells[2].Value.ToString().PadRight(4, ' ')) + new string(' ', 8) + float.Parse(r.Cells[4].Value.ToString().PadRight(5, ' ')), font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
                }
                catch (ArgumentOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch(ArgumentNullException ex) { Console.WriteLine("Error: " + ex.Message); }
            }

            float subtotal = float.Parse(lbSubtotal.Text, CultureInfo.InvariantCulture);
            double descuento = double.Parse(Txt_descuento.Text, CultureInfo.InvariantCulture);
            float total = float.Parse(lbTotal.Text, CultureInfo.InvariantCulture);
            float recibido = float.Parse(Txt_Efectivo.Text, CultureInfo.InvariantCulture);
            float cambio = float.Parse(lbDevolucion.Text, CultureInfo.InvariantCulture);

            e.Graphics.DrawString("SubTotal:  C$" + subtotal.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 35, width, 20));
            e.Graphics.DrawString("Descuento: C$" + descuento.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Total:     C$" + total.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("------------------------------", font3, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Recibido:  C$" + recibido.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Cambio:    C$" + cambio.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));

            e.Graphics.DrawString("******************************", font3, Brushes.Black, new RectangleF(45, y += 50, width, 20));
            e.Graphics.DrawString("*      ¡DIOS TE BENDIGA!     *", font3, Brushes.Black, new RectangleF(45, y += 20, width, 20));
            e.Graphics.DrawString("******************************", font3, Brushes.Black, new RectangleF(45, y += 20, width, 20));
        }

        private void RBtn_AlContado_CheckedChanged(object sender, EventArgs e)
        {
            btnFacturar.Text = "Facturar e Imprimir";
            label4.Visible = true;
            Txt_Efectivo.Visible = true;
            guna2GroupBox5.Enabled = true;
            cbImpresoras.Visible = true;
            groupBox1.Visible = true;
            guna2GroupBox4.Location = new Point(17, 154);
            guna2GroupBox5.Location = new Point(202, 154);
            label13.Location = new Point(12, 306);
            label6.Location = new Point(143, 306);
            Txt_descuento.Location = new Point(172, 302);
        }

        private void RBtn_Credito_CheckedChanged(object sender, EventArgs e)
        {
            btnFacturar.Text = "Continuar >>";
            lbDevolucion.Text = "0.00";
            label4.Visible = false;
            Txt_Efectivo.Visible = false;
            guna2GroupBox5.Enabled = false;
            cbImpresoras.Visible = false;
            groupBox1.Visible = false;
            guna2GroupBox4.Location = new Point(17, 110);
            guna2GroupBox5.Location = new Point(202, 110);
            label13.Location = new Point(12, 194);
            label6.Location = new Point(143, 194);
            Txt_descuento.Location = new Point(172, 194);
        }

        private void Txt_descuento_TextChanged(object sender, EventArgs e)
        {
            double subtotal = double.Parse(lbSubtotal.Text);
            double total = double.Parse(lbTotal.Text);
            double desc;
            try
            {
                if (Txt_descuento.Text == "")
                {
                    desc = 0.00;
                    Txt_descuento.Text = "";
                    lbTotal.Text = subtotal.ToString();
                }
                else
                {
                    desc = double.Parse(Txt_descuento.Text);
                    total = subtotal - desc;
                    lbTotal.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                Txt_descuento.Text = "";
                lbSubtotal.Text = subtotal.ToString();
            }
        }

        private void Txt_descuento_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!Txt_descuento.Text.Contains(".")))
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
