using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INASOFT_3._0.VistaFacturas;
using SpreadsheetLight;
using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using iTextSharp.tool.xml;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using System.Globalization;
using System.Security.Policy;
using DevExpress.XtraCharts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DevExpress.Charts.Native;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Creditos : UserControl
    {
        CultureInfo culturaNicaragua = new CultureInfo("es-NI");
        public UC_Creditos()
        {
            InitializeComponent();
            Cargar_credito();
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.ReadOnly = true;
            }
            dataGridView1.Columns[10].Visible = false;

            datagridView2.Rows.Add("Total", "", "", "", "", "", "", "", "C$ 0.00", "C$ 0.00");
            foreach (DataGridViewColumn columna in datagridView2.Columns)
            {
                columna.ReadOnly = true;
            }
            Cargar_Total();
        }
        public void Cargar_Total()
        {
            CultureInfo culture = new CultureInfo("es-NI");
            double Total_Pendiente = 0.00;
            double Total_Monto = 0.00;
            try
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total_Pendiente += double.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString(), NumberStyles.Currency, culture);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total_Monto += double.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString(), NumberStyles.Currency, culture);
                }
                double valorRedondeado1 = Math.Round(Total_Pendiente, 2);

                // Formatea el valor redondeado con el formato "C$ 10,000.00"
                string valorFormateado1 = valorRedondeado1.ToString("C", new CultureInfo("es-NI"));

                double valorRedondeado2 = Math.Round(Total_Monto, 2);

                // Formatea el valor redondeado con el formato "C$ 10,000.00"
                string valorFormateado2 = valorRedondeado2.ToString("C", new CultureInfo("es-NI"));

                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = "";
                datagridView2.Rows[0].Cells[5].Value = "";
                datagridView2.Rows[0].Cells[6].Value = "";
                datagridView2.Rows[0].Cells[7].Value = "";
                datagridView2.Rows[0].Cells[8].Value = valorFormateado1;
                datagridView2.Rows[0].Cells[9].Value = valorFormateado2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void Cargar_credito()
        {
            Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
            dataGridView1.DataSource = ctrlCredito_Abono.Cargar_Creditos();
        }

        public void Credito_Filtro(int op, string fechaIni, string fechaFin, string nombreCliente, string estado, int diasVencidos)
        {
            Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
            dataGridView1.DataSource = ctrlCredito_Abono.Creditos_BuscarNombreRangoFechaEstado(op, fechaIni, fechaFin, nombreCliente, estado, diasVencidos);
        }

        private void Realizar_Abono(int id_pos)
        {
            try
            {
                if (id_pos < 0 || id_pos >= dataGridView1.Rows.Count)
                {
                    // Manejo de índices inválidos
                    return;
                }

                string estado = dataGridView1.Rows[id_pos].Cells[3].Value.ToString();

                if (estado == "Cancelado")
                {
                    MessageBox_Import.Show("Ya completó el crédito de esta factura", "Aviso");
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[id_pos];

                    RealizarAbono frm = new RealizarAbono();
                    frm.Lb_FechaCredito.Text = selectedRow.Cells[3].Value.ToString();

                    string fechaInicio = selectedRow.Cells[4].Value.ToString().Split(' ')[0];
                    string fechaFin = selectedRow.Cells[5].Value.ToString().Split(' ')[0];
                    frm.Lb_FechaCredito.Text = fechaInicio + " - " + fechaFin;

                    string cargo = selectedRow.Cells[7].Value.ToString().Split(' ')[1];
                    frm.Lb_Cargo.Text = cargo;

                    string pendiente = selectedRow.Cells[8].Value.ToString().Split(' ')[1];
                    frm.Lb_Pendiente.Text = pendiente;
                    frm.Lb_Pendiente_aux.Text = pendiente;

                    frm.Lb_Cliente.Text = selectedRow.Cells[2].Value.ToString();
                    frm.GBox_Cod_Fact.Text = selectedRow.Cells[1].Value.ToString();
                    frm.Txt_IDCredito.Text = selectedRow.Cells[0].Value.ToString();
                    frm.Txt_IDFactura.Text = selectedRow.Cells[10].Value.ToString();
                    frm.ShowDialog();
                    Cargar_credito();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes mostrar un mensaje de error si es necesario
                // MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void Ver_Estado_Credito(int id_pos)
        {
            try
            {
                if (id_pos < 0 || id_pos >= dataGridView1.Rows.Count)
                {
                    // Manejo de índices inválidos
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.Rows[id_pos];
                int clienteId = int.Parse(selectedRow.Cells[0].Value.ToString());
                int facturaId = int.Parse(selectedRow.Cells[10].Value.ToString());

                string fechaInicial = selectedRow.Cells[4].Value.ToString().Split(' ')[0];
                string fechaFinal = selectedRow.Cells[5].Value.ToString().Split(' ')[0];

                string estado = selectedRow.Cells[3].Value.ToString();
                string diasVencidos = selectedRow.Cells[6].Value.ToString();
                string cargo = selectedRow.Cells[7].Value.ToString();
                string pendiente = selectedRow.Cells[8].Value.ToString().Split(' ')[1];
                string monto = selectedRow.Cells[9].Value.ToString();

                string clienteNombre = selectedRow.Cells[2].Value.ToString();
                string facturaNumero = selectedRow.Cells[1].Value.ToString();

                EstadoDelCredito frm = new EstadoDelCredito(clienteId, facturaId);
                frm.Lb_FechaInicial.Text = fechaInicial;
                frm.Lb_FechaFin.Text = fechaFinal;
                frm.Lb_Estado.Text = estado;
                frm.Lb_DiasVencidos.Text = diasVencidos;
                frm.Lb_Cargo.Text = cargo;
                frm.Lb_Pendiente.Text = pendiente;
                frm.Lb_Monto.Text = monto;
                frm.groupBox1.Text = $"Detalle del crédito del cliente {clienteNombre}";
                frm.lbCliente.Text = clienteNombre;
                frm.guna2GroupBox2.Text = $"Estado de cuenta de la factura {facturaNumero}";
                frm.lbFactura.Text = facturaNumero;
                frm.Show();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes mostrar un mensaje de error si es necesario
                // MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();
            if (id_pos.Contains("Realizar abono"))
            {
                id_pos = id_pos.Replace("Realizar abono", "");
                Realizar_Abono(int.Parse(id_pos));
            }
            if (id_pos.Contains("Ver estado del crédito"))
            {
                id_pos = id_pos.Replace("Ver estado del crédito", "");
                Ver_Estado_Credito(int.Parse(id_pos));
            }
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            Cargar_credito();
            Cargar_Total();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox_Import.Show(
             "1. Tendrá una tabla donde se muestra todas las facturas al créditos que se han hecho.\n" +
             "2. Al dar click derecho se desplega un menú con dos opciones: Ver estado del crédito y realizar abono.\n" +
             "    * Ver estado del crédito: Nos mostrará una tabla donde estará más detalado la información del estado del crédito.\n" +
             "    * Realizar abono: Podrá generar un nuevo abono a la factura establecida.\n" +
             "3. Tendrá al lado derecho opciones de busquedas detalladas (Filtros).\n\n\n\n" +
             "\n", "Modúlo de créditos y abonos");
        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;
            string nombre_cliente = txt_NonbCliente.Text;
            if (txt_NonbCliente.Text == "")
            {
                MessageBox_Error.Show("Por favor ingrese el nombre del cliente a buscar", "Error");
            }
            else
            {
                Credito_Filtro(2, fecha_Ini, fecha_End, nombre_cliente, "", 0);
            }
            txt_NonbCliente.Text = "";
            Cargar_Total();
        }


        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrl = new Controladores.CtrlReporte();
            ctrl.Reporte_Credito(dataGridView1);
            /*
            SLDocument sL = ctrl.Reporte_Credito(dataGridView1);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sL.SaveAs(saveFileDialog1.FileName + ".xlsx");
            }*/
        }

        private void Guna2Button3_Click_1(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;
            //MessageBox.Show(fecha_Ini + " " + fecha_End);

            Credito_Filtro(1, fecha_Ini, fecha_End, "", "", 0);
            Cargar_Total();
        }

        private void Guna2Button5_Click_1(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;
            string estado = "";
            if (Rbtn_Pendientes.Checked == false && Rbtn_Canceladas.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar una de las dos opciones", "Error");
            }
            else if (Rbtn_Pendientes.Checked == true && Rbtn_Canceladas.Checked == false)
            {
                estado = "Pendiente";
                Credito_Filtro(3, fecha_Ini, fecha_End, "", estado, 0);
            }
            else if (Rbtn_Pendientes.Checked == false && Rbtn_Canceladas.Checked == true)
            {
                estado = "Cancelado";
                Credito_Filtro(3, fecha_Ini, fecha_End, "", estado, 0);
            }
            Rbtn_Canceladas.Checked = false;
            Rbtn_Pendientes.Checked = false;
            Cargar_Total();
        }

        private void Guna2Button7_Click(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;
            int bandera = 0;
            if (Rbtn_DiasVencidos.Checked == false && Rbtn_DiasEstables.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar una de las dos opciones", "Error");
            }
            else if (Rbtn_DiasVencidos.Checked == true && Rbtn_DiasEstables.Checked == false)
            {
                bandera = 1;
                Credito_Filtro(4, fecha_Ini, fecha_End, "", "", bandera);
            }
            else if (Rbtn_DiasVencidos.Checked == false && Rbtn_DiasEstables.Checked == true)
            {
                bandera = 2;
                Credito_Filtro(4, fecha_Ini, fecha_End, "", "", bandera);
            }
            Rbtn_DiasVencidos.Checked = false;
            Rbtn_DiasEstables.Checked = false;
            Cargar_Total();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Realizar abono").Name = "Realizar abono" + pos;
                    menu.Items.Add("Ver estado del crédito").Name = "Ver estado del crédito" + pos;
                }
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 8)
            {
                if (e.Value.GetType() != typeof(System.DBNull))
                {
                    if (e.Value.ToString() == "C$ 0.00")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Index == 6)
            {
                if (e.Value.GetType() != typeof(System.DBNull))
                {
                    if (int.Parse(e.Value.ToString()) > 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Index == 3)
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (e.Value.ToString() == "Cancelado")
                        {
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.White;
                        }
                        else if (e.Value.ToString() == "Pendiente")
                        {
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            InfoNegocio infoNegocio = new InfoNegocio();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Reporte de Fact_Credito - " + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            string paginaHtml_texto = Properties.Resources.CreditoTemplate.ToString();
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
                filas += "<td>" + row.Cells["Cod. Factura"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cliente"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Estado"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cargo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Pendiente"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Fin del credito"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Dias vencidos"].Value.ToString() + "</td>";
                filas += "</tr>";

                //Total += double.Parse(row.Cells["Total Final"].Value.ToString());
            }
            if (dataGridView1.RowCount == 0)
            {
                Total = 0.00;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string aux1 = dataGridView1.Rows[i].Cells[8].Value.ToString();
                    string[] words1 = aux1.Split('$');
                    string aux_Total = words1[1];
                    Total += double.Parse(aux_Total);
                }
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
                    string RutaImagen = Properties.Settings.Default.RutaImagen;
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(RutaImagen);
                    img.ScaleToFit(100, 100);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(10,100);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);


                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(paginaHtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    MessageBox_Import.Show("Exportando Facturas al Cretido a PDF.....\n" +
                        "Espere un momento.....", "Exportando a PDF");
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox_Ok.Show("Reporte de Facturas al Credito Exportado a PDF", "Exportando a PDF");
                    string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Exporto un Reporte de Facturas al Credito en PDF";
                    ctrlInfo.InsertarLog(log);

                }

            }
        }
    }
}
