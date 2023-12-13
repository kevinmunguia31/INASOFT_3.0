using DevExpress.XtraCharts;
using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using MySqlX.XDevAPI;
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
    public partial class ReporteVentasDiario : Form
    {
        public ReporteVentasDiario()
        {
            InitializeComponent();
            InstalledPrintersCombo();
            CargarDatos();

            string rutaImagen = Properties.Settings.Default.RutaImagen;
            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                // Carga la imagen desde la ruta especificada
                Image imagen = Image.FromFile(rutaImagen);
                pbImagen.Image = imagen;
            }
            else
            {
                MessageBox.Show("La imagen no se encontró en la ruta especificada. Cargue el logo desde las configuraciones\n", "Información");
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

        public void CargarDatos()
        {

            InfoNegocio infoNegocio = new InfoNegocio();
            lbDireccion.Text = infoNegocio.Direccion;
            lbTelefono.Text = infoNegocio.Telefono;
            lbHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lbUsuario.Text = Sesion.nombre;

            Controladores.CtrlHome ctrlHomre = new Controladores.CtrlHome();
            dataGridView1.DataSource = ctrlHomre.CargarVentasHoy();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal sumaTotal = 0;

            // Recorrer cada fila del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Verificar si la celda no está vacía y es un valor numérico
                if (fila.Cells[2].Value != null && decimal.TryParse(fila.Cells[2].Value.ToString(), out decimal valor))
                {
                    // Sumar el valor de la celda a la suma total
                    sumaTotal += valor;
                }
            }

            // Mostrar la suma total en el TextBox
            txtTotal.Text = sumaTotal.ToString("0,0", CultureInfo.InvariantCulture);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtrlInfo ctrlInfo = new CtrlInfo();
            //////////////// IMPRESION DE LA FACTURA /////////////////////////////////////////////////
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = cbImpresoras.Text;
            printDocument1.PrinterSettings = ps;
            ps.Copies = 1; // Esto imprimirá dos copias
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();

            MessageBox.Show("Se imprio el Tikect Correctamente","Impresión");
            string log = Sesion.nombre + " Imprimio un Tiket de Reporte de Ventas con un Total de: " + txtTotal.Text;
            string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            ctrlInfo.InsertarLog(fecha, log);
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
            e.Graphics.DrawString("Fecha:" + lbFecha.Text, font2, Brushes.Black, new RectangleF(0, y += 15, width, 20));
            e.Graphics.DrawString("Fecha:" + lbHora.Text, font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Operador: " + Sesion.nombre, font3, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("Fecha            Descripción              Total", font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
            e.Graphics.DrawString("**************************************", font2, Brushes.Black, new RectangleF(0, y += 18, width, 20));
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                // FECHA                     //CONCEPTO                                 //TOTAL                    
                try
                {
                    DateTime fecha = (DateTime)r.Cells[0].Value;
                    string strFecha = fecha.ToString("dd/MM/yyyy");
                    string Concepto = r.Cells[1].Value.ToString();
                    e.Graphics.DrawString(fecha + new string(' ', 5) + Concepto.ToString().PadRight(4, ' ') + new string(' ', 10) + float.Parse(r.Cells[2].Value.ToString().PadRight(4, ' ')) + new string(' ', 8), font4, Brushes.Black, new RectangleF(0, y += 20, width, 20));
                }
                catch (ArgumentOutOfRangeException ex) { Console.WriteLine("Error: " + ex.Message); }
                catch (ArgumentNullException ex) { Console.WriteLine("Error: " + ex.Message); }
            }

            float total = float.Parse(txtTotal.Text, CultureInfo.InvariantCulture);
            e.Graphics.DrawString("________________________", font3, Brushes.Black, new RectangleF(140, y += 20, width, 20));
            e.Graphics.DrawString("Total:     C$" + total.ToString("0,0", CultureInfo.InvariantCulture), font2, Brushes.Black, new RectangleF(140, y += 20, width, 20));
           

            e.Graphics.DrawString("________________________________", font3, Brushes.Black, new RectangleF(45, y += 80, width, 20));
            e.Graphics.DrawString("        Recibi Conforme     ", font3, Brushes.Black, new RectangleF(45, y += 20, width, 20));
        }
    }
}
