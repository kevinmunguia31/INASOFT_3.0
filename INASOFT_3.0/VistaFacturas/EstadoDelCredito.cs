using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class EstadoDelCredito : Form
    {
        public EstadoDelCredito(int id_Credito, int id_factura)
        {
            InitializeComponent();
            Txt_IDCredito.Text = id_Credito.ToString();
            Txt_IDFactura.Text = id_factura.ToString();
            CargarDetalleCredito();

            foreach (DataGridViewBand band in datagridView1.Columns)
            {
                band.ReadOnly = true;
            }
            datagridView1.Columns[7].Visible = false;
        }
        public void CargarDetalleCredito()
        {
            Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
            datagridView1.DataSource = ctrlCredito_Abono.Cargar_EstadoDeCredito(int.Parse(Txt_IDCredito.Text));
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstadoDelCredito_Load(object sender, EventArgs e)
        {
            int diasvencidos = int.Parse(Lb_DiasVencidos.Text);
            string estado = Lb_Estado.Text;
            double pendiente = double.Parse(Lb_Pendiente.Text);
            if(diasvencidos > 0)
            {
                Lb_DiasVencidos.ForeColor = Color.Red;
            }
            if(estado == "Cancelado")
            {
                Lb_Estado.ForeColor = Color.Green;
            }
            else
            {
                Lb_Estado.ForeColor = Color.Orange;
            }
            if(pendiente > 0)
            {
                Lb_Pendiente.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
            }
            else
            {
                Lb_Pendiente.ForeColor = Color.Green;
                label6.ForeColor = Color.Green;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            InfoNegocio infoNegocio = new InfoNegocio();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Estado_Cuenta_" + lbCliente.Text + ".pdf";

            string paginaHtml_texto = Properties.Resources.EstadoCuentaTemplate.ToString();
            paginaHtml_texto = paginaHtml_texto.Replace("@NombreNegocio", infoNegocio.Nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@Direccion", infoNegocio.Direccion);
            paginaHtml_texto = paginaHtml_texto.Replace("@Telefono", infoNegocio.Telefono);
            paginaHtml_texto = paginaHtml_texto.Replace("@Usuario", Sesion.nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            paginaHtml_texto = paginaHtml_texto.Replace("@Cliente", lbCliente.Text);
            paginaHtml_texto = paginaHtml_texto.Replace("@FACTURA", lbFactura.Text);

            string filas = string.Empty;
            foreach (DataGridViewRow row in datagridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["ID"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Concepto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cargo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Saldo anterior"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Abono"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Saldo nuevo"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            paginaHtml_texto = paginaHtml_texto.Replace("@FILAS", filas);

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
                    MessageBox_Import.Show("Exportando Estado de Cuenta a PDF.....\n" +
                        "Espere un momento.....", "Exportando a PDF");
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox_Ok.Show("Reporte de Estado de Cuenta Exportado a PDF", "Exportando a PDF");
                    string log = Sesion.nombre + " Exporto el Detalle de Cuenta de " + lbCliente.Text + " a PDF";
                    string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    ctrlInfo.InsertarLog(fecha, log);

                }

            }
        }

        private void lbFactura_Click(object sender, EventArgs e)
        {

        }
    }
}
