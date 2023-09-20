﻿using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
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
using System.IO;
using DevExpress.Utils;
using INASOFT_3._0.UserControls;


namespace INASOFT_3._0.VistaFacturas
{
    public partial class FacturaFinal : Form
    {
        //string imagen = "C:\\Users\\DELL 5410\\Desktop\\Ferreteria\\logo.png";
        //string imagen = "C:\\Usuarios\\jerem\\Imágenes\\logo.png";
        private string lbUser;
        private string lbNombreNegocio;
        private string lbDireccionNegocio;
        private string lbNmRUC;
        private string lbTelefono;

        private List<Detalle_Factura> lista_Productos;

        public FacturaFinal(List<Detalle_Factura> lista)
        {
            InitializeComponent();
            lista_Productos = lista;
            InfoProducts();
            InstalledPrintersCombo();
            InfoNegocio();
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            txtIdUsuario.Text = Sesion.id.ToString();
            //lbIdFactura.Text = ctrlFactura.Codigo_Factura().ToString();

            lbUser = Sesion.nombre;            

            datagridView2.Rows.Add("Total", "", "", "", 0);

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();
            Txt_descuento.Enabled = false;

            RBtn_AlContado.Checked = true;
            Rbtn_TipoCordobas.Checked = true;
            radioButton1.Checked = true;
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
                        lbNombreNegocio= reader.GetString("nombre_negocio");
                        lbDireccionNegocio= reader.GetString("direccion_negocio");
                        lbNmRUC= reader.GetString("num_ruc");
                        lbTelefono = reader.GetString("telefono");
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
            dataGridView1.AutoGenerateColumns = false;

            // Define las columnas que deseas mostrar en el DataGridView
            DataGridViewTextBoxColumn columnaCod = new DataGridViewTextBoxColumn();
            columnaCod.DataPropertyName = "Codigo_producto";
            columnaCod.HeaderText = "Cod. Producto";

            DataGridViewTextBoxColumn columnaProd = new DataGridViewTextBoxColumn();
            columnaProd.DataPropertyName = "Nombre_producto";
            columnaProd.HeaderText = "Nombre producto";

            DataGridViewTextBoxColumn columnaCant = new DataGridViewTextBoxColumn();
            columnaCant.DataPropertyName = "Cantidad";
            columnaCant.HeaderText = "Cantidad";

            DataGridViewTextBoxColumn columnaPrecio = new DataGridViewTextBoxColumn();
            columnaPrecio.DataPropertyName = "Precio";
            columnaPrecio.HeaderText = "Precio";

            DataGridViewTextBoxColumn columnaTotal = new DataGridViewTextBoxColumn();
            columnaTotal.DataPropertyName = "Total";
            columnaTotal.HeaderText = "Total";

            // Agrega las columnas al DataGridView
            dataGridView1.Columns.Add(columnaCod);
            dataGridView1.Columns.Add(columnaProd);
            dataGridView1.Columns.Add(columnaCant);
            dataGridView1.Columns.Add(columnaPrecio);
            dataGridView1.Columns.Add(columnaTotal);

            // Establece la lista de personas como origen de datos
            dataGridView1.DataSource = lista_Productos;   
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
            DialogResult resultado = guna2MessageDialog1.Show("¿Seguro que desea salir?", "Salir");
            if (resultado == DialogResult.Yes)
            {
                this.Hide();
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
            CtrlInfo ctrlInfo = new CtrlInfo();
            string tipoPago = "";
            string estado;
            string tipoFactura;
            double debe;
            double descuento;
            double efectivo;
            double total = double.Parse(lbTotal.Text);
            double subtotal = double.Parse(lbSubtotal.Text);
            double devolucion = double.Parse(lbDevolucion.Text);
            int id_cliente = int.Parse(txtIdCliente.Text);
            int id_usuario = int.Parse(txtIdUsuario.Text);

            if (RBtn_Credito.Checked == false && RBtn_AlContado.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar el tipo de factura que se realizará");
            }
            //FACTURA AL CRÉDITO
            else if (RBtn_Credito.Checked == true && RBtn_AlContado.Checked == false)
            {
                if (cbImpresoras.SelectedIndex == -1)
                {
                    MessageBox_Error.Show("Debe seleccionar un tipo de impresora.", "Error");
                }
                else if (Rbtn_TipoCordobas.Checked == false && Rbtn_TipoDolares.Checked == false)
                {
                    MessageBox_Error.Show("No deje la la opción de 'Tipo de pago' sin marcar.", "Error");
                }
                else
                {
                    tipoFactura = "Crédito";
                    estado = "Pendiente";
                    debe = double.Parse(lbSubtotal.Text);

                    efectivo = 0.00;
                    devolucion = 0.00;
                    descuento = 0.00;

                    if (Rbtn_TipoCordobas.Checked == true)
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

                        bool bandera = ctrlFactura.Facturacion_Final(estado, descuento, subtotal, efectivo, debe, tipoPago, tipoFactura, id_usuario, id_cliente);

                        int id_factura = ctrlFactura.ID_Factura();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewRow row = dataGridView1.Rows[i];
                            ctrlFactura.Facturar_Productos(int.Parse(row.Cells[2].Value.ToString()), double.Parse(row.Cells[3].Value.ToString()), row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), id_factura);
                        }
                        if (bandera)
                        {
                            string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
                            string hora = DateTime.Now.ToString("hh:mm:ss");

                            double monto = 0.00;
                            string fecha_vencimiento = DateTime_vencimiento.Text;
                            string fecha_inicioDevolucion = (fecha + " " + hora);
                            string fecha_inicio = DateTime_inicio.Text;
                            double cargo = double.Parse(lbSubtotal.Text);
                            double saldo_nuevo = 0.00;
                            double saldo_anterior = 0.00;
                            string desc_credito = "";
                            string desc_abono = "";

                            if (Rbtn_TipoCordobas.Checked == false && Rbtn_TipoDolares.Checked == false)
                            {
                                MessageBoxError.Show("No deje la casilla 'Tipo de pago' sin marcar", "Error");
                            }
                            else
                            {
                                if (txtDescripcion.Text == "")
                                {
                                    desc_credito = "Factura realizada al crédito al cliente " + lbNombreCliente.Text + " con un saldo pendiente de: " + lbTotal.Text;
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
                                    saldo_nuevo = double.Parse(lbSubtotal.Text);
                                }
                                else
                                {
                                    monto = double.Parse(TxtMonto.Text);
                                    desc_abono = "Primer abono realizado es de C$" + monto + " el mismo día que se hizo la factura.";
                                    saldo_nuevo = double.Parse(lbSubtotal.Text) - monto;
                                }
                                Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
                                bool bandera1 = ctrlCredito_Abono.Insertar_Credito(tipoPago, fecha_inicio, fecha_vencimiento, cargo, estado, desc_credito, id_factura, id_cliente);
                                //MessageBox.Show(fecha_inicio + "\n" + fecha_vencimiento + "\n" + cargo +"\n"+ saldo + "\n" +estado + "\n" + id_factura + "\n" + id_cliente);
                                //MessageBox.Show(fecha_inicio + "\n" + monto + "\n" + desc + "\n");
                                if (bandera1)
                                {
                                    int id_credito = ctrlCredito_Abono.ID_Credito();
                                    ctrlCredito_Abono.Realizar_Abono(fecha_inicioDevolucion, monto, saldo_anterior, saldo_nuevo, desc_abono, id_credito, id_factura);
                                    MessageBox_Import.Show("Se realizó la acción con éxito, el cliente debe C$ " + lbTotal.Text + "\n", "Importante");

                                    string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero la Factura al Credito: " + id_factura;
                                    ctrlInfo.InsertarLog(log);
                                    UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                                    uC_Factura.CargarFacturas();
                                    this.Close();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                   
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

                        bool bandera = ctrlFactura.Facturacion_Final(estado, descuento, subtotal, efectivo, debe, tipoPago, tipoFactura, id_usuario, id_cliente);
                        int id_factura = ctrlFactura.ID_Factura();

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewRow row = dataGridView1.Rows[i];
                            ctrlFactura.Facturar_Productos(int.Parse(row.Cells[2].Value.ToString()), double.Parse(row.Cells[3].Value.ToString()), row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), id_factura);
                        }

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
                                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero la Factura al Contado: " + id_factura;
                                ctrlInfo.InsertarLog(log);
                                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                                uC_Factura.CargarFacturas();
                                this.Close();
                            }
                            else if(result == DialogResult.No)
                            {
                                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero la Factura al Contado: " + id_factura;
                                ctrlInfo.InsertarLog(log);
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

            //Image img = Image.FromFile(imagen);
            //e.Graphics.DrawImage(img, new System.Drawing.Rectangle(40, y += 0, 200, 90));
            e.Graphics.DrawString(lbDireccionNegocio, font2, Brushes.Black, new RectangleF(20, y += 100, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(lbTelefono, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
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
            GroupBox_Credito.Visible = false;
            GroupBox_Alcontado.Visible = true;
            Groupbox_fact.Text = "Realizar fact. al contado";
        }

        private void RBtn_Credito_CheckedChanged(object sender, EventArgs e)
        {
            GroupBox_Credito.Visible = true;
            GroupBox_Alcontado.Visible = false;
            Groupbox_fact.Text = "Realizar fact. al credito";
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Txt_descuento.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Txt_descuento.Enabled = false;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Txt_descuento.Enabled = false;
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

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            double saldo = double.Parse(lbTotal.Text);
            double cargo = double.Parse(lbSubtotal.Text);
            double monto;
            try
            {
                if (TxtMonto.Text == "")
                {
                    lbTotal.Text = lbSubtotal.Text;
                }
                else
                {
                    monto = double.Parse(TxtMonto.Text);
                    saldo = cargo - monto;
                    lbTotal.Text = saldo.ToString();
                }
            }
            catch (Exception ex)
            {
                TxtMonto.Text = "";
                lbTotal.Text = lbSubtotal.Text;
            }
        }
    }
}
