using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using iTextSharp.tool.xml;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class DetalleFactura : Form
    {
        public DataTable dataTable = new DataTable();
        private Timer timer;

        public DetalleFactura()
        {
            InitializeComponent();

            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            lbIdFactura.Text = lbIdFactura.Text + " " + ctrlFactura.Codigo_Factura().ToString();
            Lb_AuxCodFac.Text = ctrlFactura.Codigo_Factura().ToString();

            Cargar_Productos();
            cargar_tabla();
            Limpiar();

            datagridView1.Columns[0].ReadOnly = true;
            datagridView1.Columns[1].ReadOnly = true;
            datagridView1.Columns[4].ReadOnly = true;

            datagridView2.Rows.Add("Total", "", "", "", 0);

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();

            timer = new Timer();
            timer.Interval = 5000; // 5000 milisegundos = 5 segundos
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Al transcurrir el tiempo, limpiar el mensaje de error y detener el temporizador
            errorProvider1.SetError(SpinCantidad, "");
            timer.Stop();
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "1")
            {
                MessageBox_Import.Show("En está opción no se permitirá facturar al crédito", "AVISO");
            }
            if (txtIdCliente.Text == "1")
            {
                lbClienteName.Text = "Cliente génerico";
            }
            else
            {
                int limite = 25;
                if (lbClienteName.Text.Length > limite)
                {
                    lbClienteName.Text = lbClienteName.Text.Substring(0, limite) + "...";
                }
                else
                {
                    lbClienteName.Text = lbClienteName.Text;
                }
            }
        }

        private void Cargar_Productos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProducto();
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        public void Cargar_Total()
        {
            double Total = 0.00;
            
            try
            {
                for (int i = 0; i < datagridView1.Rows.Count; i++)
                {
                    Total += float.Parse(datagridView1.Rows[i].Cells[4].Value.ToString());                   
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Hide();
            this.Close();
        }

        public void cargar_tabla()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");

            datagridView1.DataSource = dataTable;
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
                MessageBox_Error.Show("Tiene que indicar la cantidad", "Error");
                errorProvider1.SetError(SpinCantidad, "Debe indicar la cantidad que desea facturar");
                return; // Salir del método si la cantidad es cero.
            }

            if (lbExistencias.Text == "0" || lbCodProdu.Text == "..." || lbProductName.Text == "...")
            {
                MessageBox_Error.Show("No ha seleccionado un producto a facturar.", "Error");
                return; // Salir del método si hay problemas con el producto.
            }

            bool seRepite = datagridView1.Rows.Cast<DataGridViewRow>()
                .Any(fila => fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == lbCodProdu.Text);

            if (seRepite)
            {
                MessageBox_Import.Show("Ya se agregó ese producto, puede editarlo o borrarlo si desea", "Importante");
                Limpiar();
                return; // Salir del método si el producto ya está en la lista.
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

            datagridView1.DataSource = dataTable;
            Limpiar();
            Cargar_Total();
        }

        public void Limpiar()
        {
            lbExistencias.Text = "...";
            lbProductName.Text = "...";
            Cbx_Productos.SelectedIndex = -1;
            SpinCantidad.Value = 0;
            lbCodProdu.Text = "...";
            txtIdProduc.Text = "";
            TxtBuscar_Productos.Text = "";
            Lb_PrecioCompra.Text = "...";
        }

        public void Subtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < datagridView1.Rows.Count; i++)
            {
                subtotal += float.Parse(datagridView1.Rows[i].Cells[4].Value.ToString());
            }
            lbSubtotal.Text = subtotal.ToString();
        }
        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Buscar_NombreProducto(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
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

                lbCodProdu.Text = productos.Codigo.ToString();
                lbProductName.Text = LimitarLongitud(productos.Nombre, 15);
                lbExistencias.Text = productos.Existencias.ToString();
                Lb_Precio_Venta.Text = productos.Precio_venta.ToString();
                Lb_PrecioCompra.Text = productos.Precio_compra.ToString();

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

        private void Button1_Click(object sender, EventArgs e)
        {
            Cargar_Productos();
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
                        datagridView1.Rows.RemoveAt(id_pos);
                        Subtotal();
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

        private void DatagridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = datagridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Borrar").Name = "Borrar" + pos;
                }
                menu.Show(datagridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void DatagridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagridView1.Columns["Cantidad"].Index && e.RowIndex >= 0)
                {
                    DataGridViewCell CantidadCell = datagridView1.Rows[e.RowIndex].Cells["Cantidad"];
                    DataGridViewCell PrecioCell = datagridView1.Rows[e.RowIndex].Cells["Precio"];
                    DataGridViewCell TotalCell = datagridView1.Rows[e.RowIndex].Cells["Total"];

                    decimal cantidad = Convert.ToDecimal(CantidadCell.Value);
                    decimal precio = Convert.ToDecimal(PrecioCell.Value);
                    decimal total = precio * cantidad;
                    TotalCell.Value = total;
                }
                if (e.ColumnIndex == datagridView1.Columns["Precio"].Index && e.RowIndex >= 0)
                {
                    DataGridViewCell CantidadCell = datagridView1.Rows[e.RowIndex].Cells["Cantidad"];
                    DataGridViewCell PrecioCell = datagridView1.Rows[e.RowIndex].Cells["Precio"];
                    DataGridViewCell TotalCell = datagridView1.Rows[e.RowIndex].Cells["Total"];

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
            Subtotal();
        }

        private void DatagridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                bool isINT = int.TryParse(e.FormattedValue.ToString(), out int resultado);
                if (isINT == false)
                {
                    e.Cancel = true;
                    MessageBox_Error.Show("El dato debe ser numérico", "Error");
                }
            }
            if(e.ColumnIndex == 3)
            {
                bool isDouble = double.TryParse(e.FormattedValue.ToString(), out double resultado);
                if (isDouble == false)
                {
                    e.Cancel = true;
                    MessageBox_Error.Show("El dato debe ser numérico", "Error");
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            InfoNegocio infoNegocio = new InfoNegocio();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Proforma_Cliente_" + txtNombreCliente.Text + ".pdf";

            string paginaHtml_texto = Properties.Resources.ProformaTemplate.ToString();
            paginaHtml_texto = paginaHtml_texto.Replace("@NombreNegocio", infoNegocio.Nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@Direccion", infoNegocio.Direccion);
            paginaHtml_texto = paginaHtml_texto.Replace("@Telefono", infoNegocio.Telefono);
            paginaHtml_texto = paginaHtml_texto.Replace("@CLIENTE", txtNombreCliente.Text);
            paginaHtml_texto = paginaHtml_texto.Replace("@Usuario", Sesion.nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            double Total = 0.00;
            foreach (DataGridViewRow row in datagridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Código"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Nombre Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Total"].Value.ToString() + "</td>";
                filas += "</tr>";

                Total += double.Parse(row.Cells["Total"].Value.ToString());

            }
            paginaHtml_texto = paginaHtml_texto.Replace("@FILAS", filas);
            paginaHtml_texto = paginaHtml_texto.Replace("@TOTAL", Total.ToString("C"));


            if (guardar.ShowDialog() == DialogResult.OK)
            {
                CtrlInfo ctrlInfo = new CtrlInfo();
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    //Agregamos la imagen del banner al documento
                    /*iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.icons8_wifi_apagado_50, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(10,100);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);*/


                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(paginaHtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    MessageBox_Import.Show("Exportando Proforma a PDF.....\n" +
                        "Espere un momento.....", "Exportando a PDF");
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox_Ok.Show("Proforma Exportada a PDF", "Exportando a PDF");
                    string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Realizo una Proforma a nombre de " + txtNombreCliente.Text + " en PDF";
                    ctrlInfo.InsertarLog(log);
                    this.Dispose();
                }
            }
        }
            
    }
}

 