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
using System.IO;
using DevExpress.Utils;
using INASOFT_3._0.UserControls;
using DevExpress.XtraCharts;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;


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

        public DataTable dataTable = new DataTable();
        private Timer timer;

        public FacturaFinal()
        {
            InitializeComponent();
            //InfoProducts();
            InstalledPrintersCombo();
            InfoNegocio();
            Cargar_CbxProductos();
            CargarTiposPagos();
            Cargar_TablaProducto();
            Limpiar();

            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            lbIdFactura.Text = lbIdFactura.Text + " " + ctrlFactura.Codigo_Factura().ToString();
            Lb_AuxCodFac.Text = ctrlFactura.Codigo_Factura().ToString();
            txtIdUsuario.Text = Sesion.id.ToString();
            Lb_User.Text = Sesion.nombre;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            datagridView2.Rows.Add("Total", "", "", "", 0, "");

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();

            Txt_descuento.Enabled = false;
            RBtn_AlContado.Checked = true;
            radioButton1.Checked = true;
            btnFacturar.Enabled = false;
            Groupbox_fact.Enabled = false;

            timer = new Timer();
            timer.Interval = 5000; // 5000 milisegundos = 5 segundos
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            errorProvider1.SetError(SpinCantidad, "");
            timer.Stop();
        }

        private void Cargar_CbxProductos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProductoActivo();
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        public void CargarTiposPagos()
        {
            CbxTipoPagos.DataSource = null;
            CbxTipoPagos.Items.Clear();

            Controladores.CtrlTipo_Pago ctrl = new Controladores.CtrlTipo_Pago();
            CbxTipoPagos.DataSource = ctrl.Cargar_Tipos_Pago();
            CbxTipoPagos.ValueMember = "ID";
            CbxTipoPagos.DisplayMember = "Tipos";
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

                lbSubtotal.Text = numeroRedondeado.ToString();
                lbTotal.Text = numeroRedondeado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void Cargar_TablaProducto()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");
            dataTable.Columns.Add("ID");

            dataGridView1.DataSource = dataTable;
        }

        public void Limpiar()
        {
            Lb_Precio_Venta.Text = "...";
            lbExistencias.Text = "...";
            lbProductName.Text = "...";
            Cbx_Productos.SelectedIndex = -1;
            SpinCantidad.Value = 0;
            lbCodProdu.Text = "...";
            txtIdProduc.Text = "";
            TxtBuscar_Productos.Text = "";
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
                        lbNombreNegocio = reader.GetString("nombre_negocio");
                        lbDireccionNegocio = reader.GetString("direccion_negocio");
                        lbNmRUC = reader.GetString("num_ruc");
                        lbTelefono = reader.GetString("telefono");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /*
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
        */
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

        private void FacturaFinal_Load(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "1")
            {
                MessageBox_Import.Show("En está opción no se permitirá facturar al crédito", "AVISO");
                lbNombreCliente.Text = "Cliente génerico";

                RBtn_Credito.Visible = false;
                RBtn_AlContado.Checked = true;
                groupBox2.Enabled = false;
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
                RBtn_Credito.Visible = true;
            }
            Txt_descuento.Text = "0";
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

            if (!RBtn_Credito.Checked && !RBtn_AlContado.Checked)
            {
                MessageBox_Error.Show("Tiene que marcar el tipo de factura que se realizará");
                return;
            }

            if (cbImpresoras.SelectedIndex == -1)
            {
                MessageBox_Error.Show("Debe seleccionar un tipo de impresora.", "Error");
                return;
            }

            if (CbxTipoPagos.SelectedIndex == -1)
            {
                MessageBox_Error.Show("No deje la opción de 'Tipo de pago' sin marcar.", "Error");
                return;
            }

            try
            {
                Modelos.Facturas facturas = new Modelos.Facturas
                {
                    Estado = RBtn_Credito.Checked ? "Pendiente" : "Cancelado",
                    Descuento = RBtn_Credito.Checked ? 0.00 : double.Parse(Txt_descuento.Text),
                    Subtotal = double.Parse(lbSubtotal.Text),
                    Efectivo = RBtn_Credito.Checked ? 0.00 : double.Parse(Txt_Efectivo.Text),
                    Debe = RBtn_Credito.Checked ? double.Parse(lbSubtotal.Text) : 0.00,
                    Tipo_Factura = RBtn_Credito.Checked ? "Crédito" : "Al contado",
                    Id_Usuario = int.Parse(txtIdUsuario.Text),
                    Id_Cliente = int.Parse(txtIdCliente.Text),
                    Id_TipoPago = int.Parse(CbxTipoPagos.SelectedValue.ToString())
                };

                Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
                bool bandera = ctrlFactura.Facturacion_Final(facturas);

                if (bandera)
                {
                    facturas.Id_Factura = ctrlFactura.ID_Factura();
                    List<Modelos.Facturas> lista = new List<Modelos.Facturas>();

                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            Modelos.Facturas facturas1 = new Modelos.Facturas
                            {
                                Cantidad = int.Parse(fila.Cells[2].Value.ToString()),
                                Id_Factura = ctrlFactura.ID_Factura(),
                                Id_Producto = int.Parse(fila.Cells[5].Value.ToString())
                            };
                            lista.Add(facturas1);
                        }
                    }

                    foreach (Modelos.Facturas facturas2 in lista)
                    {
                        ctrlFactura.Facturar_Productos(facturas2);
                    }

                    if (RBtn_Credito.Checked)
                    {
                        double monto = (string.IsNullOrEmpty(TxtMonto.Text) ? 0.00 : double.Parse(TxtMonto.Text));
                        double saldo_anterior = double.Parse(lbSubtotal.Text);
                        double saldo_nuevo = saldo_anterior - monto; ;
                        string desc_credito = (string.IsNullOrEmpty(txtDescripcion.Text) ? "Factura realizada al crédito al cliente " + lbNombreCliente.Text + " con un saldo pendiente de: " + lbTotal.Text : txtDescripcion.Text);
                        string desc_abono = (monto > 0 ? "Primer abono realizado es de C$" + monto + " el mismo día que se hizo la factura." : "Primer abono realizado es de C$ 0.00 el mismo día que se hizo la factura.");

                        Credito credito = new Credito
                        {
                            Dia_Inicio = DateTime_inicio.Text,
                            Dia_Vencimiento = DateTime_vencimiento.Text,
                            Cargo = double.Parse(lbSubtotal.Text),
                            Estado = "Pendiente",
                            Descripcion = desc_credito,
                            Id_Factura = ctrlFactura.ID_Factura(),
                            Id_Cliente = int.Parse(txtIdCliente.Text),
                            Id_TipoPago = int.Parse(CbxTipoPagos.SelectedValue.ToString())
                        };

                        Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
                        bool bandera1 = ctrlCredito_Abono.Insertar_Credito(credito);

                        if (bandera1)
                        {
                            Credito credito1 = new Credito();
                            credito1.Monto = monto;
                            credito1.Saldo_Anterior = saldo_anterior;
                            credito1.Saldo_Nuevo = saldo_nuevo;
                            credito1.Descripcion_Abono = desc_abono;
                            credito1.Id_Credito = ctrlCredito_Abono.ID_Credito();
                            credito1.Id_Factura = ctrlFactura.ID_Factura();

                            ctrlCredito_Abono.Realizar_Abono(credito1);

                            MessageBox_Import.Show("Se realizó la acción con éxito, el cliente debe C$ " + lbTotal.Text + "\n", "Importante");

                            string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero la Factura al Crédito: Fact." + ctrlFactura.ID_Factura();
                            ctrlInfo.InsertarLog(log);
                        }
                    }

                    DialogResult result = RBtn_Credito.Checked ? DialogResult.No : MessageBox_Question.Show("¿Desea Imprimir la factura?");

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
                        string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero la Factura: Fact." + ctrlFactura.ID_Factura();
                        ctrlInfo.InsertarLog(log);
                        UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                        uC_Factura.CargarFacturas();
                        this.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                        string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero la Factura: Fact." + ctrlFactura.ID_Factura();
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
            e.Graphics.DrawString("Factura:" + lbIdFactura.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
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
                catch (ArgumentNullException ex) { Console.WriteLine("Error: " + ex.Message); }
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
            double subtotal = double.Parse(datagridView2.Rows[0].Cells[4].Value.ToString());
            double total;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    Limpiar();
                    SpinCantidad.Enabled = false; // Si no hay selección, desactiva SpinCantidad
                    return; // Salir del método ya que no hay selección válida
                }

                int id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                Productos productos = ctrlProductos.MostrarDatosProductos(id);

                txtIdProduc.Text = id.ToString();
                lbCodProdu.Text = productos.Codigo.ToString();
                lbProductName.Text = LimitarLongitud(productos.Nombre, 15);
                lbExistencias.Text = productos.Existencias.ToString();
                Lb_Precio_Venta.Text = productos.Precio_venta.ToString();

                errorProvider1.SetError(lbExistencias, (int.Parse(lbExistencias.Text) <= 0) ? "Ya no hay productos en el almacén." : "");
                lbExistencias.ForeColor = (int.Parse(lbExistencias.Text) <= 0) ? Color.Red : Color.Black;

                SpinCantidad.Enabled = true; // Habilitar SpinCantidad después de seleccionar un producto
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                // MessageBox.Show("Error: " + ex);
            }
        }

        // Función para limitar la longitud de una cadena y agregar "..." si es necesario
        private string LimitarLongitud(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                return input.Substring(0, maxLength) + "...";
            }
            return input;
        }

        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.BuscarProductoActivo(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            if (Cbx_Productos.SelectedIndex == -1)
            {
                MessageBox_Error.Show("Tiene que escoger un producto a facturar", "Error");
                Limpiar();
                return; // Salir del método si no se ha seleccionado un producto.
            }

            if (SpinCantidad.Value == 0)
            {
                MessageBox_Error.Show("Tiene que indicar la cantidad.", "Error");
                errorProvider1.SetError(SpinCantidad, "Debe indicar la cantidad que desea facturar.");
                return; // Salir del método si la cantidad es cero.
            }

            if (lbExistencias.Text == "0" || lbCodProdu.Text == "..." || lbProductName.Text == "...")
            {
                MessageBox_Error.Show("No ha seleccionado un producto a facturar.", "Error");
                return; // Salir del método si hay problemas con el producto.
            }

            bool seRepite = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Any(fila => fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == lbCodProdu.Text);

            if (seRepite)
            {
                MessageBox_Import.Show("Ya se agregó ese producto, puede editarlo o borrarlo si desea.", "Importante");
                Limpiar();
                return; // Salir del método si el producto ya está en la lista.
            }

            if(SpinCantidad.Value > int.Parse(lbExistencias.Text))
            {
                MessageBox_Error.Show("No hay esa cantidad en el Stock.", "Errir");
                Limpiar();
                return;
            }

            int id = int.Parse(txtIdProduc.Text);
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            Productos productos = ctrlProductos.MostrarDatosProductos(id);

            DataRow newRow = dataTable.NewRow();
            newRow[0] = productos.Codigo.ToString();
            newRow[1] = productos.Nombre.ToString();
            newRow[2] = SpinCantidad.Value.ToString();
            newRow[3] = double.Parse(Lb_Precio_Venta.Text);
            newRow[4] = double.Parse(Lb_Precio_Venta.Text) * int.Parse(SpinCantidad.Value.ToString());
            newRow[5] = int.Parse(Cbx_Productos.SelectedValue.ToString());

            dataTable.Rows.Add(newRow);

            dataGridView1.DataSource = dataTable;
            Limpiar();
            Cargar_Total();
            Groupbox_fact.Enabled = true;
            btnFacturar.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cargar_CbxProductos();
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Borrar"))
            {
                id_pos = id_pos.Replace("Borrar", "");
                Eliminar_Producto(int.Parse(id_pos));
            }
        }
        private void Eliminar_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    bool bandera = false;
                    DialogResult resultado = MessageDialogError.Show("Seguro que desea eliminar el registro?", "Eliminar");
                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show(id_pos.ToString());
                        dataGridView1.Rows.RemoveAt(id_pos);
                        Limpiar();
                        Cargar_Total();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Borrar").Name = "Borrar" + pos;
                }
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Cantidad"].Index && e.RowIndex >= 0)
                {
                    DataGridViewCell CantidadCell = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"];
                    DataGridViewCell PrecioCell = dataGridView1.Rows[e.RowIndex].Cells["Precio"];
                    DataGridViewCell TotalCell = dataGridView1.Rows[e.RowIndex].Cells["Total"];

                    decimal cantidad = Convert.ToDecimal(CantidadCell.Value);
                    decimal precio = Convert.ToDecimal(PrecioCell.Value);
                    decimal total = precio * cantidad;
                    TotalCell.Value = total;
                }
                if (e.ColumnIndex == dataGridView1.Columns["Precio"].Index && e.RowIndex >= 0)
                {
                    DataGridViewCell CantidadCell = dataGridView1.Rows[e.RowIndex].Cells["Cantidad"];
                    DataGridViewCell PrecioCell = dataGridView1.Rows[e.RowIndex].Cells["Precio"];
                    DataGridViewCell TotalCell = dataGridView1.Rows[e.RowIndex].Cells["Total"];

                    decimal cantidad = Convert.ToDecimal(CantidadCell.Value);
                    decimal precio = Convert.ToDecimal(PrecioCell.Value);
                    decimal total = precio * cantidad;
                    TotalCell.Value = total;
                }
            }
            catch (Exception ex)
            {
                MessageBoxError.Show("Error: " + ex.Message);
            }
            Cargar_Total();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                bool isINT = int.TryParse(e.FormattedValue.ToString(), out int resultado);
                if (isINT == false)
                {
                    e.Cancel = true;
                    MessageBox_Error.Show("El dato debe ser numérico", "Error");
                }
            }
            if (e.ColumnIndex == 3)
            {
                bool isDouble = double.TryParse(e.FormattedValue.ToString(), out double resultado);
                if (isDouble == false)
                {
                    e.Cancel = true;
                    MessageBox_Error.Show("El dato debe ser numérico", "Error");
                }
            }
        }

        private void CbxTipoPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

