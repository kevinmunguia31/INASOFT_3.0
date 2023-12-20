using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class DetalleFacturaRealizada : Form
    {
        string rutaImagen = Properties.Settings.Default.RutaImagen;
        public DetalleFacturaRealizada(string id)
        {
            InitializeComponent();
            InfoNegocio();
            CargarDatosIniciales(id);
            InfoProducts();
            InstalledPrintersCombo();
        }

        private void CargarDatosIniciales(string id)
        {
            txtIDFactura.Text = id;

            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                // Carga la imagen desde la ruta especificada
                Image imagen = Image.FromFile(rutaImagen);
                pictureBox1.Image = imagen;
            }
            else
            {
                MessageBox.Show("La imagen no se encontró en la ruta especificada. Cargue el logo desde las configuraciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InfoProducts()
        {
            string idFactura = txtIDFactura.Text;
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridView1.DataSource = ctrlFactura.DetalleFactura(int.Parse(idFactura));
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT direccion_negocio, telefono FROM infogeneral";
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
                        lbDireccion.Text = reader.GetString("direccion_negocio");
                        lbTelefono.Text = reader.GetString("telefono");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
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

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(cbImpresoras.SelectedIndex == -1){
                MessageBoxError.Show("Tiene que marcar una impresora", "Error");
            }
            else
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
        }

        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            int width = 280;
            int y = 20;
            Font font2 = new Font("Consolas", 9, FontStyle.Regular, GraphicsUnit.Point);
            Font font3 = new Font("Consolas", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font font4 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);
            Font font5 = new Font("Consolas", 7, FontStyle.Regular, GraphicsUnit.Point);

            Image img = Image.FromFile(rutaImagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(40, y += 0, 200, 90));
            e.Graphics.DrawString(lbDireccion.Text, font2, Brushes.Black, new RectangleF(20, y += 100, width, 20));
            //e.Graphics.DrawString("Norte, Sucursal - El Viejo", font2, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            e.Graphics.DrawString(lbTelefono.Text, font2, Brushes.Black, new RectangleF(80, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Factura:" + lbCodFactura.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
            e.Graphics.DrawString("Cliente: " + lbClient.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Fecha: " + DateTime.Now, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Caja: " + Sesion.nombre, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Producto            Cant.      P.Unit      Total", font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            //e.Graphics.DrawString("LAM. GYPSUM REG      3         C$ 345      C$1,035", font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                // PROD                     //Cant                                 //Precio                         TOTAL
                try
                {
                    string str = r.Cells[2].Value.ToString();
                    int desiredLength = 18;
                    string subStr = str.Substring(0, Math.Min(desiredLength, str.Length));
                    float cant = float.Parse(r.Cells[4].Value.ToString());
                    e.Graphics.DrawString(subStr.PadRight(desiredLength, ' ') + new string(' ', 3) + cant.ToString().PadRight(4, ' ') + new string(' ', 8) + float.Parse(r.Cells[3].Value.ToString().PadRight(4, ' ')) + new string(' ', 8) + float.Parse(r.Cells[5].Value.ToString().PadRight(5, ' ')), font4, Brushes.Black, new RectangleF(0, y += 18, width, 20));
                }
                catch (ArgumentOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (ArgumentNullException ex) { Console.WriteLine("Error: " + ex.Message); }
            }

            float subtotal = float.Parse(lbSubT.Text, CultureInfo.InvariantCulture);
            double descuento = double.Parse(lbDesc.Text, CultureInfo.InvariantCulture);
            float total = float.Parse(lbTotal.Text, CultureInfo.InvariantCulture);
            float recibido = float.Parse(lbRecivied.Text, CultureInfo.InvariantCulture);
            float cambio = float.Parse(lbChange.Text, CultureInfo.InvariantCulture);

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
    }
}
