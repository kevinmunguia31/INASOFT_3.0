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
using iTextSharp.text.pdf;
using DevExpress.Charts.Native;
using DocumentFormat.OpenXml.EMMA;
using INASOFT_3._0.VistaFacturas;


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
            InstalledPrintersCombo();
            InfoNegocio();
            Cargar_CbxProductos();
            CargarTiposPagos();
            CargarDatosIniciales();
            CargarDataGridView();
            Cargar_Total();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            errorProvider1.SetError(TxtCantidad, "");
            timer.Stop();
        }

        private void CargarDatosIniciales()
        {
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            lbIdFactura.Text = lbIdFactura.Text + " " + ctrlFactura.Codigo_Factura().ToString();
            Lb_AuxCodFac.Text = ctrlFactura.Codigo_Factura().ToString();
            txtIdUsuario.Text = Sesion.id.ToString();
            Lb_User.Text = Sesion.nombre;

            Txt_descuento.Enabled = false;
            RBtn_AlContado.Checked = true;
            radioButton1.Checked = true;
            btnFacturar.Enabled = false;
            Groupbox_fact.Enabled = false;
            CbxTipoPagos.SelectedIndex = 1;
            Cbx_Productos.SelectedIndex = -1;
            RbtCambioPrecNo.Checked = true;


            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
        }

        private void CargarDataGridView()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");

            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            datagridView2.Columns[5].Visible = false;

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            datagridView2.Rows.Add("Total", "", "", "", 0, "","");

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
        }

        private void Cargar_CbxProductos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProductoActivo("");
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
                Total = (float)Math.Round(Total, 2);
                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = Total;

                lbSubtotal.Text = Total.ToString();
                lbTotal.Text = Total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void Limpiar()
        {
            Lb_Precio_Venta.Text = "...";
            lbExistencias.Text = "...";
            lbProductName.Text = "...";
            Cbx_Productos.SelectedIndex = -1;
            TxtCantidad.Text = "";
            lbCodProdu.Text = "...";
            txtIdProduc.Text = "";
            TxtBuscar_Productos.Text = "";
            Lb_Observacion.Text = "...";
            txtPrecioVenta.Text = "";
        }

        public void LimpiarFactura()
        {
            Txt_Efectivo.Text = "";
            TxtMonto.Text = "";
            Txt_descuento.Text = "";
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
                MessageBox_Import.Show("En está opción no se permitirá facturar al crédito", "Aviso Importante");
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
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
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
            if (!RBtn_Credito.Checked && !RBtn_AlContado.Checked)
            {
                MessageBox_Error.Show("Tiene que marcar el tipo de factura que se realizará\n", "Error");
                return;
            }

            if (cbImpresoras.SelectedIndex == -1)
            {
                MessageBox_Error.Show("Debe seleccionar un tipo de impresora.", "Error");
                return;
            }

            try
            {
                if (RBtn_AlContado.Checked)
                {
                    FacturaAlContado();
                }

                if (RBtn_Credito.Checked)
                {
                    FacturaAlCredito();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FacturaAlContado()
        {
            CtrlInfo ctrlInfo = new CtrlInfo();
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            DateTime fechaSeleccionada = DateTimeFact.Value;

            if (CbxTipoPagos.SelectedIndex == -1)
            {
                MessageBox_Error.Show("No deje la opción de 'Tipo de pago' sin marcar.\n\n", "Error");
                return;
            }

            if (Txt_Efectivo.Text == "")
            {
                MessageBox_Error.Show("Al pagar al contado no puede dejar el campo 'Efectivo' en blanco\n\n.", "Error");
                return;
            }

            if (double.Parse(Txt_Efectivo.Text) < double.Parse(lbTotal.Text) || double.Parse(lbDevolucion.Text) < 0.00)
            {
                MessageBox_Error.Show("El pago debe ser completo.\n\n.", "Error");
                return;
            }

            Modelos.Facturas facturaAlContado = new Modelos.Facturas
            {
                Estado = "Cancelado",
                Descuento = string.IsNullOrEmpty(Txt_descuento.Text) ? 0.00 : double.Parse(Txt_descuento.Text),
                Subtotal = double.Parse(lbSubtotal.Text),
                Efectivo = double.Parse(Txt_Efectivo.Text),
                Debe = 0.00,
                Tipo_Factura = "Al contado",
                Referencia = string.IsNullOrEmpty(TxtReferencia.Text) ? "Ninguna referencia" : TxtReferencia.Text,
                Fecha = fechaSeleccionada.ToString("yyyy-MM-dd HH:mm:ss"),
                Id_Usuario = int.Parse(txtIdUsuario.Text),
                Id_Cliente = int.Parse(txtIdCliente.Text),
                Id_TipoPago = int.Parse(CbxTipoPagos.SelectedValue.ToString())
            };

            bool bandera = ctrlFactura.Facturacion_Final(facturaAlContado);

            if (bandera)
            {

                facturaAlContado.Id_Factura = ctrlFactura.ID_Factura();
                List<Modelos.Facturas> listaFacturaAlcontado = new List<Modelos.Facturas>();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        Modelos.Facturas factura = new Modelos.Facturas
                        {
                            Cantidad = double.Parse(fila.Cells[2].Value.ToString()),
                            Id_Factura = ctrlFactura.ID_Factura(),
                            Id_Producto = int.Parse(fila.Cells[5].Value.ToString()),
                            DescripcionPrecio = fila.Cells[6].Value.ToString()
                        };
                        listaFacturaAlcontado.Add(factura);
                    }
                }

                foreach (Modelos.Facturas facturas in listaFacturaAlcontado)
                {
                    ctrlFactura.Facturar_Productos(facturas);
                }

                DialogResult result = MessageBox_Question.Show("¿Desea Imprimir la factura?", "Importante");

                if (result == DialogResult.Yes)
                {
                    //////////////// IMPRESION DE LA FACTURA /////////////////////////////////////////////////
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cbImpresoras.Text;
                    printDocument1.PrinterSettings = ps;
                    ps.Copies = 1; // Esto imprimirá dos copias
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();
                }

                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                string log = Sesion.nombre + " Género la Factura al contado: Fact." + ctrlFactura.ID_Factura();
                string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                ctrlInfo.InsertarLog(fecha, log);

                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                uC_Factura.CargarFacturas();
                this.Close();
            }
        }

        private void FacturaAlCredito()
        {
            CtrlInfo ctrlInfo = new CtrlInfo();
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            DateTime fechaSeleccionada = DateTime_inicio.Value;

            if (DateTime_inicio.Text == DateTime_vencimiento.Text)
            {
                MessageBox_Error.Show("La fecha de vencimiento del crédito no puede ser igual a la fecha de inicio.\n\n", "Error");
                return;
            }
            double montoAux = (string.IsNullOrEmpty(TxtMonto.Text) ? 0.00 : double.Parse(TxtMonto.Text));

            if (montoAux >= double.Parse(lbSubtotal.Text))
            {
                MessageBox_Error.Show("El monto no puede ser igual o mayor al pago final.\n\n", "Error");
                return;
            }

            Modelos.Facturas facturaAlCredito = new Modelos.Facturas
            {
                Estado = "Pendiente",
                Descuento = 0.00,
                Subtotal = double.Parse(lbSubtotal.Text),
                Efectivo = 0.00,
                Debe = double.Parse(lbSubtotal.Text),
                Tipo_Factura = "Crédito",
                Referencia = (string.IsNullOrEmpty(txtDescripcion.Text) ? "Ninguna" : txtDescripcion.Text),
                Fecha = fechaSeleccionada.ToString("yyyy-MM-dd HH:mm:ss"),
                Id_Usuario = int.Parse(txtIdUsuario.Text),
                Id_Cliente = int.Parse(txtIdCliente.Text),
                Id_TipoPago = int.Parse(CbxTipoPagos.SelectedValue.ToString())
            };

            bool bandera = ctrlFactura.Facturacion_Final(facturaAlCredito);

            if (bandera)
            {
                facturaAlCredito.Id_Factura = ctrlFactura.ID_Factura();
                List<Modelos.Facturas> listaFacturaAlcredito = new List<Modelos.Facturas>();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        Modelos.Facturas factura = new Modelos.Facturas
                        {
                            Cantidad = int.Parse(fila.Cells[2].Value.ToString()),
                            Id_Factura = ctrlFactura.ID_Factura(),
                            Id_Producto = int.Parse(fila.Cells[5].Value.ToString()),
                            DescripcionPrecio = fila.Cells[6].Value.ToString()
                        };
                        listaFacturaAlcredito.Add(factura);
                    }
                }

                foreach (Modelos.Facturas facturas in listaFacturaAlcredito)
                {
                    ctrlFactura.Facturar_Productos(facturas);
                }

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

                CtrlCredito_Abono ctrlCredito_Abono = new CtrlCredito_Abono();
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
                }
                DialogResult result = MessageBox_Question.Show("¿Desea Imprimir el recibo?", "Importante");

                if (result == DialogResult.Yes)
                {
                    //////////////// IMPRESION DE LA FACTURA /////////////////////////////////////////////////
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = cbImpresoras.Text;
                    printDocument1.PrinterSettings = ps;
                    ps.Copies = 1; // Esto imprimirá dos copias
                    printDocument1.PrintPage += ImprimirRecibo;
                    printDocument1.Print();
                }

                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                string log = Sesion.nombre + " Generó una Factura al crédito: Fact." + ctrlFactura.ID_Factura();
                string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                ctrlInfo.InsertarLog(fecha, log);

                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                uC_Factura.CargarFacturas();
                this.Close();
            }
        }       

        private void ImprimirRecibo(object sender, PrintPageEventArgs e)
        {
            Modelos.Credito credito = new Modelos.Credito();
            CtrlCredito_Abono ctrlCredito_Abono = new CtrlCredito_Abono();
            credito = ctrlCredito_Abono.MostrarDatosCreditoAbono(ctrlCredito_Abono.ID_Credito());

            int width = 280;
            int y = 20;
            Font font2 = new Font("Consolas", 9, FontStyle.Regular, GraphicsUnit.Point);
            Font font3 = new Font("Consolas", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font font4 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);
            Font font5 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);
            string imagen = Properties.Settings.Default.RutaImagen;
            InfoNegocio info = new InfoNegocio();
            //Image img = Image.FromFile(imagen);
            //e.Graphics.DrawImage(img, new System.Drawing.Rectangle(40, y += 0, 200, 90));
            e.Graphics.DrawString(info.Direccion, font2, Brushes.Black, new RectangleF(20, y += 95, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(info.Telefono, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Factura:" + Lb_AuxCodFac.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
            e.Graphics.DrawString("Cliente: " + lbNombreCliente.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Caja: " + Sesion.nombre, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("            RECIBO DE CAJA", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            e.Graphics.DrawString("Saldo Incial: C$" + credito.Monto, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Saldo Pendiente: C$" + credito.Saldo_Anterior, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Abono: C$" + TxtMonto.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Nuevo Saldo: C$" + credito.Saldo_Nuevo, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            
            double Abono = (string.IsNullOrEmpty(TxtMonto.Text) ? 0.00 : double.Parse(TxtMonto.Text, CultureInfo.InvariantCulture));
            double recibido = (string.IsNullOrEmpty(TxtMonto.Text) ? 0.00 : double.Parse(TxtMonto.Text, CultureInfo.InvariantCulture));
            double vuelto = 0.0;

            e.Graphics.DrawString("Total:     C$" + Abono.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("-------------------------", font3, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Recibido:  C$" + recibido.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Cambio:    C$" + vuelto.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));

            e.Graphics.DrawString("________________________________", font3, Brushes.Black, new RectangleF(45, y += 80, width, 20));
            e.Graphics.DrawString("        Recibi Conforme     ", font3, Brushes.Black, new RectangleF(45, y += 20, width, 20));
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            int width = 280;
            int y = 20;
            Font font2 = new Font("Consolas", 9, FontStyle.Regular, GraphicsUnit.Point);
            Font font3 = new Font("Consolas", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font font4 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);
            Font font5 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);

            string imagen = Properties.Settings.Default.RutaImagen;
            InfoNegocio info = new InfoNegocio();
            Image img = Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(40, y += 0, 200, 90));
            e.Graphics.DrawString(info.Direccion, font2, Brushes.Black, new RectangleF(20, y += 100, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(info.Telefono, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Factura:" + Lb_AuxCodFac.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
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
                    float cant = float.Parse(r.Cells[2].Value.ToString());
                    e.Graphics.DrawString(subStr.PadRight(desiredLength, ' ') + new string(' ', 3) + cant.ToString().PadRight(4, ' ') + new string(' ', 8) + float.Parse(r.Cells[3].Value.ToString().PadRight(4, ' ')) + new string(' ', 8) + float.Parse(r.Cells[4].Value.ToString().PadRight(5, ' ')), font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
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
            LimpiarFactura();
            GroupBox_Credito.Visible = false;
            GroupBox_Alcontado.Visible = true;
            Groupbox_fact.Text = "Realizar fact. al contado";            
        }

        private void RBtn_Credito_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarFactura();
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
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
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
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
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
                int id;
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    Limpiar();
                    TxtCantidad.Enabled = false;// Si no hay selección, desactiva SpinCantidad
                    id = 0; 
                    return; // Salir del método ya que no hay selección válida
                }
                else
                {
                    id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                    Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                    Productos productos = ctrlProductos.MostrarDatosProductos(id);

                    txtIdProduc.Text = id.ToString();
                    lbCodProdu.Text = productos.Codigo.ToString();
                    lbProductName.Text = LimitarLongitud(productos.Nombre, 15);
                    lbExistencias.Text = productos.Existencias.ToString();
                    Lb_Precio_Venta.Text = productos.Precio_venta.ToString();
                    txtPrecioVenta.Text = productos.Precio_venta.ToString();
                    Lb_Observacion.Text = LimitarLongitud(productos.Observacion.ToString(), 20);

                    errorProvider1.SetError(lbExistencias, (int.Parse(lbExistencias.Text) <= 0) ? "Ya no hay productos en el almacén." : "");
                    lbExistencias.ForeColor = (int.Parse(lbExistencias.Text) <= 0) ? Color.Red : Color.Black;

                    TxtCantidad.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                //MessageBox.Show("Error: " + ex);
            }
        }

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
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProductoActivo(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            string descPrecio = "";
            string precioVenta = "";
            if (Cbx_Productos.SelectedIndex == -1)
            {
                MessageBox_Error.Show("Tiene que escoger un producto a facturar", "Error");
                Limpiar();
                return; // Salir del método si no se ha seleccionado un producto.
            }

            if (TxtCantidad.Text == "")
            {
                MessageBox_Error.Show("Tiene que indicar la cantidad.", "Error");
                errorProvider1.SetError(TxtCantidad, "Debe indicar la cantidad que desea facturar.");
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

            if(double.Parse(TxtCantidad.Text) > double.Parse(lbExistencias.Text))
            {
                MessageBox_Error.Show("No hay esa cantidad en el Stock.", "Errir");
                Limpiar();
                return;
            }

            if (Lb_Precio_Venta.Text != txtPrecioVenta.Text)
            {
                precioVenta = txtPrecioVenta.Text;
                if(txtDescripcion.Text == "")
                {
                    descPrecio = "Se ha realizado un descuento en este producto";
                }
                else
                {
                    descPrecio = txtDescripcion.Text;
                }
            }
            else
            {
                precioVenta = Lb_Precio_Venta.Text;
                descPrecio = "Se ha vendido por su precio estandar";
            }

            int id = int.Parse(txtIdProduc.Text);
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            Productos productos = ctrlProductos.MostrarDatosProductos(id);

            DataRow newRow = dataTable.NewRow();
            newRow[0] = productos.Codigo.ToString();
            newRow[1] = productos.Nombre.ToString();
            newRow[2] = TxtCantidad.Text;
            newRow[3] = double.Parse(precioVenta);
            newRow[4] = double.Parse(precioVenta) * double.Parse(TxtCantidad.Text);
            newRow[5] = int.Parse(Cbx_Productos.SelectedValue.ToString());
            newRow[6] = descPrecio;

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
                        //MessageBox.Show(id_pos.ToString());
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

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }

        private void RbtCambioPrecSi_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioVenta.Enabled = true;
        }

        private void RbtCambioPrecNo_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioVenta.Enabled = false;
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }
    }
}

