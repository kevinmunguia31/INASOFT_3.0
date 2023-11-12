using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using iTextSharp.tool.xml;
using MySql.Data.MySqlClient;
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

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Clientes : UserControl
    {
        int tipoUser;
        public UC_Clientes()
        {
            InitializeComponent();
            CargarTablaClient(null);
            Controladores.CtrlClientes ctrlClientes = new CtrlClientes();
            lbClientes.Text = ctrlClientes.TotalClientes().ToString();
        }

        public void CargarTablaClient(string dato)
        {
            CtrlClientes _ctrlCliente = new CtrlClientes();
            dataGridView1.DataSource = _ctrlCliente.CargarClientes(dato);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            if (txtNombreYapellido.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "" && txtCedula.Text != "")
            {
                Cliente _cliente = new Cliente();
                _cliente.Nombre = txtNombreYapellido.Text;
                _cliente.Telefono = txtTelefono.Text;
                _cliente.Direccion = txtDireccion.Text;
                _cliente.Cedula = txtCedula.Text;
               
                CtrlClientes ctrlClientes = new CtrlClientes();
                if (txtId.Text != "")
                {
                    _cliente.Id = int.Parse(txtId.Text);
                    bandera = ctrlClientes.Actualizar(_cliente);
                    MessageBox_Import.Show("Registro Actualizado Con Exito", "Actualizar Cliente");
                    CargarTablaClient(null);
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCedula.Text = "";
                    txtId.Text = "";
                }
                else
                {
                    bandera = ctrlClientes.Insertar(_cliente);
                    MessageBox_Import.Show("Registro Guardado Con Exito", "Guardar Cliente");
                    CargarTablaClient(null);
                    lbClientes.Text = ctrlClientes.TotalClientes().ToString();
                    txtNombreYapellido.Text = "";
                    txtTelefono.Text = "";
                    txtDireccion.Text = "";
                    txtCedula.Text = "";
                    txtId.Text = "";
                }
            }
            else
            {
                MessageBox_Error.Show("Rellene Todos los campos", "Error");
            }
        }

        private void editInfo_Click(object sender, EventArgs e)
        {

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string telefono = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string direccion = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string cedula = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            txtId.Text = id;
            txtNombreYapellido.Text = nombre;
            txtTelefono.Text = telefono;
            txtDireccion.Text = direccion;
            txtCedula.Text = cedula;
           
        }

        private void deleteClient_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = guna2MessageDialog6.Show("¿Seguro que desea eliminar el registro?", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlClientes _ctrl = new CtrlClientes();
                bandera = _ctrl.Eliminar(id);
                if (bandera)
                {
                    MessageBox.Show("Registro Eliminado con exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaClient(null);
                    Controladores.CtrlClientes ctrlClientes = new CtrlClientes();
                    lbClientes.Text = ctrlClientes.TotalClientes().ToString();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CargarTablaClient(null);
        }

        private void Bttn_Info_Click(object sender, EventArgs e)
        {
            MessageBox_Import.Show(
             "1. Tendrá la opción de añadir un nuevo usuario.\n" +
             "2. Al dar click derecho se desplega un menú con dos opciones: Editar y Eliminar.\n" +
             "3. Tiene que rellenar todos los campos que se le pide en el formulario.\n\n" +
             "\n", "Modúlo de cliente");
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            CargarTablaClient(dato);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            InfoNegocio infoNegocio = new InfoNegocio();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Reporte de Clientes - " + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            string paginaHtml_texto = Properties.Resources.ClientesTemplate.ToString();
            paginaHtml_texto = paginaHtml_texto.Replace("@NombreNegocio", infoNegocio.Nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@Direccion", infoNegocio.Direccion);
            paginaHtml_texto = paginaHtml_texto.Replace("@Telefono", infoNegocio.Telefono);
            paginaHtml_texto = paginaHtml_texto.Replace("@Usuario", Sesion.nombre);
            paginaHtml_texto = paginaHtml_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));

            string filas = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["ID"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Telefono"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Direccion"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cedula"].Value.ToString() + "</td>";
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
                    MessageBox_Import.Show("Exportando Clientes a PDF.....\n" +
                        "Espere un momento.....", "Exportando a PDF");
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox_Ok.Show("Reporte de Clientes Exportado a PDF", "Exportando a PDF");
                    string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Exporto un Reporte de Clientes en PDF";
                    ctrlInfo.InsertarLog(log);

                }

            }
        }
    }
}
