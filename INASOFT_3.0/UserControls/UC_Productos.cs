﻿using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.VistaFacturas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Document = iTextSharp.text.Document;
using DevExpress.XtraEditors;
using DocumentFormat.OpenXml.Drawing;
using SpreadsheetLight;
using DocumentFormat.OpenXml.Spreadsheet;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Productos : UserControl
    {
        int tipoUser;
        public UC_Productos()
        {
            InitializeComponent();
            CargarTablaProduct();
            Cargar_Compras();
            CargarProveedor();
            CargarTablaRemisiones();
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            tipoUser = Modelos.Sesion.id_tipo;
            if (tipoUser != 2)
            {
                lbCapital.Text = ctrlProductos.CapitalInvertido();
            }            
            lbCantiTota.Text = ctrlProductos.TotalProductos();
            dataGridView1.Columns[9].Visible = false;

            dataGridView3.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
            foreach (DataGridViewBand band in dataGridView2.Columns)
            {
                band.ReadOnly = true;
            }
            foreach (DataGridViewBand band in dataGridView3.Columns)
            {
                band.ReadOnly = true;
            }
        }

        public void Cargar_Compras()
        {
            Controladores.CtrlCompras ctrlCompras = new Controladores.CtrlCompras();
            dataGridView2.DataSource = ctrlCompras.CargarCompras();
        }

        //Cargar el dataGridView
        public void CargarTablaProduct()
        {
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.CargarProductos();
        }
        public void CargarTablaRemisiones()
        {
            CtrlRemision ctrlRemision = new CtrlRemision();
            dataGridView3.DataSource = ctrlRemision.CargarRemisiones();
        } 
        public void CargarProveedor()
        {
            cbProveedor.DataSource = null;
            cbProveedor.Items.Clear();

            Controladores.CtrlProveedor ctrl = new Controladores.CtrlProveedor();
            cbProveedor.DataSource = ctrl.CargarProveddores();
            cbProveedor.ValueMember = "ID";
            cbProveedor.DisplayMember = "Nombre";
        }

        public void ComprarFiltro(int op, int id, string estado)
        {
            Controladores.CtrlCompras ctrl = new Controladores.CtrlCompras();
            dataGridView2.DataSource = ctrl.Compras_Filtro(op, id, estado);
        }

        //Buscador de productos
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.BuscarProducto(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ComprarProductos frm = new ComprarProductos();
            frm.ShowDialog();
        }

        public void Limpiar()
        {
            lbCodigo.Text = "...";
            lbNameP.Text = "...";
            lbExistencias.Text = "...";
            lbPrecioCompra.Text = "...";
            lbPrecioVenta.Text = "...";
            lbPrecioTotal.Text = "...";
            lbObservaciones.Text = "...";
            lbProveedor.Text = "...";
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Cambiar estado"))
            {
                id_pos = id_pos.Replace("Cambiar estado", "");
                CambiarEstado(int.Parse(id_pos));
                Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
                lbCapital.Text = ctrlProductos.CapitalInvertido();
                lbCantiTota.Text = ctrlProductos.TotalProductos();
            }

            if (id_pos.Contains("Editar"))
            {
                id_pos = id_pos.Replace("Editar", "");
                Editar_Producto(int.Parse(id_pos));
                Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
                lbCapital.Text = ctrlProductos.CapitalInvertido();
                lbCantiTota.Text = ctrlProductos.TotalProductos();
            }
        }

        private void Editar_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    string id = dataGridView1.Rows[id_pos].Cells[0].Value.ToString();
                    string codigo = dataGridView1.Rows[id_pos].Cells[1].Value.ToString();
                    string nombre = dataGridView1.Rows[id_pos].Cells[2].Value.ToString();
                    string estado = dataGridView1.Rows[id_pos].Cells[3].Value.ToString();
                    string existencia = dataGridView1.Rows[id_pos].Cells[4].Value.ToString();

                    string aux1 = dataGridView1.Rows[id_pos].Cells[5].Value.ToString();
                    string[] words1 = aux1.Split(' ');
                    string aux_PrecioCompra = words1[1];
                    string precio_compra = aux_PrecioCompra;

                    string aux2 = dataGridView1.Rows[id_pos].Cells[6].Value.ToString();
                    string[] words2 = aux2.Split(' ');
                    string aux_PrecioVenta = words2[1];

                    string precio_venta = aux_PrecioVenta;
                    string observaciones = dataGridView1.Rows[id_pos].Cells[8].Value.ToString();

                    Ver_EditarProducto update = new Ver_EditarProducto();
                    //update.labelTitle.Text = "Editar producto";
                    update.Lb_titulo.Text = "Editar el producto " + nombre;
                    update.GroupBox_EditarProd.Visible = true;
                    update.Txt_IDProd.Text = id;
                    update.txtCodBarra.Text = codigo;
                    update.txtNameP.Text = nombre;
                    update.Lb_CantStocks.Text = existencia;
                    update.txtPrecioCompra.Text = precio_compra;
                    update.txtPrecioVenta.Text = precio_venta;
                    update.txtObservacion.Text = observaciones;


                    update.GroupBox_EditarProd.Enabled = true;
                    update.GroupBox_EditarProd.Dock = DockStyle.Fill;
                    update.txtCodBarra.Enabled = false;
                    update.txtPrecioCompra.Enabled = false;
                    update.txtPrecioVenta.Enabled = false;
                    update.SpinExist.Enabled = false;
                    update.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void CambiarEstado(int id_pos)
        {
            try
            {
                if (id_pos >= 0 && id_pos < dataGridView1.Rows.Count)
                {
                    DialogResult resultado = MessageDialog.Show("¿Seguro que desea cambiar el estado del producto?", "Estado del producto");

                    if (resultado == DialogResult.Yes)
                    {
                        int Id = int.Parse(dataGridView1.Rows[id_pos].Cells[0].Value.ToString());
                        CtrlProductos _ctrl = new CtrlProductos();
                        bool bandera = _ctrl.CambiarEstado(Id);

                        if (bandera)
                        {
                            MessageDialogInfo.Show("El estado del registro ha sido cambiado con éxito.", "Aviso");
                            CargarTablaProduct(); // Asumiendo que esta función actualiza la tabla de productos.
                        }
                        else
                        {
                            MessageBox_Error.Show("No se pudo cambiar el estado del registro.", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox_Error.Show("Seleccione una fila válida en la tabla.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error");
            }
        }

        private void Bttn_Info_Click(object sender, EventArgs e)
        {
            MessageBox_Import.Show(
             "1. Tiene la opción de ver todos los productos que hay en el almacén.\n" +
             "2. Tiene la función de buscar un producto determinado ya sea por su nombre o por su código.\n" +
             "3. ." +
             "\n", "¿Cómo funciona este apartado?");
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            CargarTablaProduct();
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            lbCapital.Text = ctrlProductos.CapitalInvertido();
            lbCantiTota.Text = ctrlProductos.TotalProductos();
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Index == 4)
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (Convert.ToInt32(e.Value) > 0)
                        {
                            e.CellStyle.BackColor = System.Drawing.Color.Green;
                            e.CellStyle.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            e.CellStyle.BackColor = System.Drawing.Color.Red;
                            e.CellStyle.ForeColor = System.Drawing.Color.White;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
            int limite = 20;
            int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (pos < 0)
                return;

            groupBox_Detalle.Text = "Producto " + lbNameP.Text;
            txtID.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            lbCodigo.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            lbNameP.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            lbExistencias.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            lbPrecioCompra.Text = dataGridView1.Rows[pos].Cells[5].Value.ToString();
            lbPrecioVenta.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
            lbPrecioTotal.Text = dataGridView1.Rows[pos].Cells[7].Value.ToString();
            lbObservaciones.Text = dataGridView1.Rows[pos].Cells[8].Value.ToString();
            lbProveedor.Text = dataGridView1.Rows[pos].Cells[10].Value.ToString();

            if (int.Parse(dataGridView1.Rows[pos].Cells[4].Value.ToString()) <= 0)
            {
                lbExistencias.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lbExistencias.ForeColor = System.Drawing.Color.Red;
            }

            if (lbNameP.Text.Length > limite)
            {
                lbNameP.Text = lbNameP.Text.Substring(0, limite) + "...";
            }

            if (lbObservaciones.Text.Length > limite)
            {
                lbObservaciones.Text = lbObservaciones.Text.Substring(0, limite) + "...";
            }

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Cambiar estado").Name = "Cambiar estado" + pos;
                tipoUser = Modelos.Sesion.id_tipo;
                if (tipoUser != 2)
                {
                    menu.Items.Add("Editar").Name = "Editar" + pos;
                }
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void menuClick_OpcionesRemsiones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Ver detalle"))
            {
                id_pos = id_pos.Replace("Ver detalle", "");
                VerDetalleRemision(int.Parse(id_pos));
            }
        }

        private void VerDetalleRemision(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    DetalleRemision remision = new DetalleRemision(int.Parse(dataGridView3.Rows[id_pos].Cells[0].Value.ToString()));                    
                    remision.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            InfoNegocio infoNegocio = new InfoNegocio();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Reporte de Inventario - " + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            string paginaHtml_texto = Properties.Resources.ProductTemplate.ToString();
            paginaHtml_texto = paginaHtml_texto.Replace("@NombreNegocio", infoNegocio.Nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@Direccion", infoNegocio.Direccion);
            paginaHtml_texto = paginaHtml_texto.Replace("@Telefono", infoNegocio.Telefono);
            paginaHtml_texto = paginaHtml_texto.Replace("@Usuario", Sesion.nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            double Total = 0.00;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Codigo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Estado"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Existencias"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Tipo de entrada"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio de compra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio de venta"].Value.ToString() + "</td>";
                filas += "</tr>";

               // Total += double.Parse(row.Cells["Total de compra"].Value.ToString());
            }
            if (dataGridView1.RowCount == 0)
            {
                Total = 0.00;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string aux1 = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    string[] words1 = aux1.Split('$');
                    string aux_Total = words1[1];
                    Total += double.Parse(aux_Total);
                }
            }
            paginaHtml_texto = paginaHtml_texto.Replace("@FILAS", filas);
            paginaHtml_texto = paginaHtml_texto.Replace("@TOTAL", Total.ToString("C"));
            //paginaHtml_texto = paginaHtml_texto.Replace("@FILAS", filas);


            if (guardar.ShowDialog() == DialogResult.OK)
            {
                CtrlInfo ctrlInfo = new CtrlInfo();
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    // Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Agregamos la imagen del banner al documento si la ruta es válida
                    string RutaImagen = Properties.Settings.Default.RutaImagen;
                    if (!string.IsNullOrEmpty(RutaImagen) && File.Exists(RutaImagen))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(RutaImagen);
                        img.ScaleToFit(100, 100);
                        img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(paginaHtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    MessageBox_Import.Show("Exportando Productos a PDF.....\n" +
                        "Espere un momento.....", "Exportando a PDF");
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox_Ok.Show("Reporte de Inventario Exportado a PDF", "Exportando a PDF");
                    string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Exporto un Reporte de Inventario en PDF";
                    ctrlInfo.InsertarLog(log);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrl = new CtrlReporte();
            ctrl.Reporte_Productos(dataGridView1);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Cargar_Compras();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedIndex == -1)
            {
                MessageBox_Error.Show("Error, tiene que marcar el proveedor", "Error");
            }
            else
            {
                int Id_proveedor = int.Parse(cbProveedor.SelectedValue.ToString());
                ComprarFiltro(1, Id_proveedor, "");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (Rbtn_Pendientes.Checked == false && Rbtn_Canceladas.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar una de las dos opciones", "Error");
            }
            else if (Rbtn_Pendientes.Checked == true && Rbtn_Canceladas.Checked == false)
            {
                estado = "Pendiente";
                ComprarFiltro(2, 0, estado);
            }
            else if (Rbtn_Pendientes.Checked == false && Rbtn_Canceladas.Checked == true)
            {
                estado = "Cancelada";
                ComprarFiltro(2, 0, estado);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            int pos = dataGridView2.HitTest(e.X, e.Y).RowIndex;

            if (pos < 0)
                return;


            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Cancelar compra").Name = "Cancelar compra" + pos;
                menu.Show(dataGridView2, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_OpcionesCompras);
            }
        }

        private void menuClick_OpcionesCompras(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Cancelar compra"))
            {
                id_pos = id_pos.Replace("Cancelar compra", "");
                CancelarCompra(int.Parse(id_pos));
            }
        }

        private void CancelarCompra(int id_pos)
        {
            try
            {
                if (id_pos >= 0 && id_pos < dataGridView2.Rows.Count)
                {
                    DialogResult resultado = MessageDialog.Show("¿Seguro que desea cancelar el estado de la compra?", "Estado de la compra");

                    if (resultado == DialogResult.Yes)
                    {
                        int Id = int.Parse(dataGridView2.Rows[id_pos].Cells[0].Value.ToString());
                        CtrlCompras _ctrl = new CtrlCompras();
                        bool bandera = _ctrl.CancelarCompra(Id);

                        if (bandera)
                        {
                            MessageDialogInfo.Show("El estado de la compra ha sido cambiado con éxito.", "Aviso");
                            Cargar_Compras(); // Asumiendo que esta función actualiza la tabla de productos.
                        }
                        else
                        {
                            MessageBox_Error.Show("No se pudo cambiar el estado de la compra.", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox_Error.Show("Seleccione una fila válida en la tabla.", "Error");
                }
            } catch (Exception ex)
            {
                MessageBox_Error.Show("Error: " + ex.Message, "Error");
            }

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            RealizarRemision add = new RealizarRemision();
            add.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;

            CtrlRemision ctrl = new CtrlRemision();
            dataGridView3.DataSource = ctrl.CargarRemisionesxFecha(fecha_Ini, fecha_End);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            CargarTablaRemisiones();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            CtrlRemision ctrl = new CtrlRemision();
            if (Rbt_RemisionEntrada.Checked == false && Rbt_RemisionSalida.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar una de las dos opciones", "Error");
            }
            else if (Rbt_RemisionEntrada.Checked == true && Rbt_RemisionSalida.Checked == false)
            {
                dataGridView3.DataSource = ctrl.CargarFiltroRemisiones(1);
            }
            else if (Rbt_RemisionEntrada.Checked == false && Rbt_RemisionSalida.Checked == true)
            {
                dataGridView3.DataSource = ctrl.CargarFiltroRemisiones(2);
            }
            Rbt_RemisionEntrada.Checked = false;
            Rbt_RemisionSalida.Checked = false;
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            int pos = dataGridView3.HitTest(e.X, e.Y).RowIndex;

            if (pos < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Ver detalle").Name = "Ver detalle"+ pos;
                menu.Show(dataGridView3, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_OpcionesRemsiones);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos Excel|*.xls;*.xlsx|Todos los archivos|*.*";
            openFileDialog.Title = "Seleccionar archivo Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    SLDocument sl = new SLDocument(filePath);
                    SLWorksheetStatistics propiedades = sl.GetWorksheetStatistics();

                    int ultimafila = propiedades.EndRowIndex;

                    MySqlConnection conexionBD = Conexion.getConexion();
                    conexionBD.Open();

                    string error = "";
                    Controladores.CtrlRemision ctrl = new Controladores.CtrlRemision();
                    Modelos.Remision remision = new Modelos.Remision();
                    remision.Descripcion = "El usuario: " + Sesion.nombre + " ha realizado una remisión de entrada";
                    remision.Id_Usuario = Sesion.id;
                    remision.Tipo_Remision = "Remisión de Entrada";
                    bool bandera = ctrl.RealizarRemesa(remision);

                    for (int x = 2; x <= ultimafila; x++)
                    {
                        string codigo = sl.GetCellValueAsString("A" + x);

                        if (existeProducto(codigo))
                        {
                            error = "Ya hay productos con el mismo codigo " + codigo + "\n";
                        }
                        else
                        {
                            string sql = "CALL Detalle_RemisionEntrada(@Id,@Codigo, @Nombre, @Existencias, @ExistenciasMin, @PrecioCompra, @PrecioVenta, @Observacion, @IdRemision);";
                            try
                            {
                                MySqlCommand comando = new MySqlCommand(sql, conexionBD);

                                // Agregar parámetros
                                comando.Parameters.AddWithValue("@Id", sl.GetCellValueAsString("A" + x));
                                comando.Parameters.AddWithValue("@Codigo", sl.GetCellValueAsString("B" + x));
                                comando.Parameters.AddWithValue("@Nombre", sl.GetCellValueAsString("C" + x));
                                comando.Parameters.AddWithValue("@Existencias", sl.GetCellValueAsString("D" + x));
                                comando.Parameters.AddWithValue("@ExistenciasMin", sl.GetCellValueAsString("E" + x));
                                comando.Parameters.AddWithValue("@PrecioCompra", sl.GetCellValueAsString("F" + x));
                                comando.Parameters.AddWithValue("@PrecioVenta", sl.GetCellValueAsString("G" + x));
                                comando.Parameters.AddWithValue("@Observacion", sl.GetCellValueAsString("H" + x));
                                comando.Parameters.AddWithValue("@IdRemision", ctrl.ID_Remision());
                                comando.ExecuteNonQuery();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    MessageBox_Import.Show("Plantilla Cargada Correctamente \n", "Aviso importante");
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show("Cierre el Archivo de Plantilla para poder Importar los datos", "Error Al Importar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private bool existeProducto(string codigo)
        {
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            string sql = "select id from productos WHERE codigo='" + codigo + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            int num = Convert.ToInt32(comando.ExecuteScalar());

            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
