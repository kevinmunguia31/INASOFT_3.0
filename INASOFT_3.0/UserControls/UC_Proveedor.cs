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
using System.Reflection;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Proveedor : UserControl
    {
        int tipoUser;
        public UC_Proveedor()
        {
            InitializeComponent();
            CargarTablaProvider(null);
            TotalProovedor();
        }

        public void CargarTablaProvider(string dato)
        {
            List<Productos> lista = new List<Productos>();
            CtrlProveedor _ctrlProveedor = new CtrlProveedor();
            dataGridView1.DataSource = _ctrlProveedor.consulta(dato);
        }

        public void TotalProovedor()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT count(*) FROM proveedor";
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
                        lbProveedores.Text = reader.GetString(0);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            CargarTablaProvider(dato);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            InfoNegocio infoNegocio = new InfoNegocio();
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "Reporte de Proveedores - " + DateTime.Now.ToString("ddMMyyyy") + ".pdf";

            string paginaHtml_texto = Properties.Resources.ProveedorTemplate.ToString();
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
                filas += "<td>" + row.Cells["Ruc"].Value.ToString() + "</td>";
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
                    MessageBox_Import.Show("Exportando Proveedores a PDF.....\n" +
                        "Espere un momento.....", "Exportando a PDF");
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox_Ok.Show("Reporte de Proveedores Exportado a PDF", "Exportando a PDF");
                    string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Exporto un Reporte de Proveedores en PDF";
                    ctrlInfo.InsertarLog(log);

                }

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (pos < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Editar").Name = "Editar" + pos;
                menu.Items.Add("Eliminar").Name = "Eliminar" + pos;
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Editar"))
            {
                id_pos = id_pos.Replace("Editar", "");
                Editar(int.Parse(id_pos));
            }

            if (id_pos.Contains("Eliminar"))
            {
                id_pos = id_pos.Replace("Eliminar", "");
                Eliminar(int.Parse(id_pos));
            }
        }

        private void Eliminar(int id_pos)
        {
            tipoUser = Modelos.Sesion.id_tipo;
            if (tipoUser == 1)
            {
                bool bandera = false;
                DialogResult resultado = guna2MessageDialog1.Show("¿Seguro que desea eliminar el registro?", "Eliminar");
                if (resultado == DialogResult.Yes)
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    CtrlProveedor _ctrl = new CtrlProveedor();
                    bandera = _ctrl.eliminar(id);
                    if (bandera)
                    {
                        MessageDialogInfo.Show("Registro Eliminado con exito", "Importante");
                        CargarTablaProvider(null);
                        TotalProovedor();
                    }
                }
            }
            else
            {
                MessageBox_Error.Show("No tiene permisos para Eliminar esta Información", "Administración de Permisos");
            }
        }
        private void Editar(int id_pos)
        {
            try
            {
                if (id_pos >= 0 && id_pos < dataGridView1.Rows.Count)
                {
                    bool bandera = false;
                    if (txtNombreYapellido.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "" && txtRuc.Text != "")
                    {
                        Proveedor _proveedor = new Proveedor();
                        _proveedor.Nombre = txtNombreYapellido.Text;
                        _proveedor.Telefono = txtTelefono.Text;
                        _proveedor.Direccion = txtDireccion.Text;
                        _proveedor.Ruc = txtRuc.Text;


                        CtrlProveedor ctrProveedor = new CtrlProveedor();
                        if (txtId.Text != "")
                        {
                            _proveedor.Id = int.Parse(txtId.Text);
                            bandera = ctrProveedor.actualizar(_proveedor);
                            MessageDialogInfo.Show("Registro Actualizado Con Exito", "Actualizar Proveedor");
                            TotalProovedor();
                            CargarTablaProvider(null);
                            txtNombreYapellido.Text = "";
                            txtTelefono.Text = "";
                            txtDireccion.Text = "";
                            txtRuc.Text = "";
                            txtId.Text = "";

                        }
                        else
                        {
                            bandera = ctrProveedor.insertar(_proveedor);
                            MessageDialogInfo.Show("Registro Guardado Con Exito", "Guardar Proveedor");
                            CargarTablaProvider(null);
                            TotalProovedor();
                            txtNombreYapellido.Text = "";
                            txtTelefono.Text = "";
                            txtDireccion.Text = "";
                            txtRuc.Text = "";
                            txtId.Text = "";
                        }
                    }
                    else
                    {
                        MessageDialogWar.Show("Rellene Todos los campos", "Aviso");
                    }
                }
                else
                {
                    MessageBox_Error.Show("Seleccione una fila válida en la tabla.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox_Error.Show("Error: " + ex.Message, "Error");
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            if (txtNombreYapellido.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "" && txtRuc.Text != "")
            {
                Proveedor _proveedor = new Proveedor();
                _proveedor.Nombre = txtNombreYapellido.Text;
                _proveedor.Telefono = txtTelefono.Text;
                _proveedor.Direccion = txtDireccion.Text;
                _proveedor.Ruc = txtRuc.Text;

                CtrlProveedor ctrProveedor = new CtrlProveedor();
                bandera = ctrProveedor.insertar(_proveedor);
                MessageDialogInfo.Show("Registro Guardado Con Exito", "Guardar Proveedor");
                CargarTablaProvider(null);
                TotalProovedor();
                txtNombreYapellido.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtRuc.Text = "";
                txtId.Text = "";
            }
        }
    }
}

