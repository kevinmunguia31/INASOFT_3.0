using DevExpress.XtraBars.Controls.Internal;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Guna.UI2.WinForms;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.Properties;
using INASOFT_3._0.VistaFacturas;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_HOME : UserControl
    {
        public string user = Modelos.Sesion.nombre;
        public static bool NetworkAvailable = true;
        public UC_HOME()
        {
            InitializeComponent();
            lbUser.Text = Sesion.nombre;
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            lbdate.Text = fecha;

            Label_CantProductos.Visible = false;
            Label_Ganancias.Visible = false;
            HayInternet();
            GraficoVentasDiarias();
            Cargar_ProductosMasVendidos();
            GraficaCargar_ProductosMasVendidos();
            GraficaCargar_TotalVentasxDias();
            Controladores.CtrlHome ctrlHome = new Controladores.CtrlHome();

            Lb_CantFactHoy.Text = ctrlHome.Cant_FacturasRealizadasHoy().ToString();
            Lb_TotalIngresosHoy.Text = ctrlHome.TotalFinal_FacturasHoy().ToString();
            Lb_FactAnuladasHoy.Text = ctrlHome.Total_FacturasAnuldasHoy().ToString();
            Lb_TotalAbonoHoy.Text = ctrlHome.Total_AbonoHoy().ToString();

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            //lbNameNeg.Text = Modelos.InfoNegocio.nombre;
            string rutaImagen = Properties.Settings.Default.RutaImagen;
            string Dolar = Properties.Settings.Default.Dolar;
            txtDolar.Text = Dolar;

            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                // Carga la imagen desde la ruta especificada
                Image imagen = Image.FromFile(rutaImagen);
                pbImagen.Image = imagen;
            }
            else
            {
                MessageBox_Import.Show("La imagen no se encontró en la ruta especificada. Cargue el logo desde las configuraciones\n", "Información");
            }
        }

        private void InfoNegocio()
        {
            string sql = "SELECT idinfogeneral, nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono FROM infogeneral";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    InfoNegocio _infoNegocio = new InfoNegocio();
                    _infoNegocio.Id = int.Parse(reader.GetString(0));
                    _infoNegocio.Nombre = reader.GetString(1);
                    _infoNegocio.Telefono = reader.GetString(5);
                    _infoNegocio.Direccion = reader.GetString(2);
                    _infoNegocio.NumRUC = reader.GetString(3);
                    _infoNegocio.NombreAdmin = reader.GetString(4);
                    //MessageBox.Show(_infoNegocio.Nombre);
                }
                else
                {
                    MessageBox_Import.Show("No hay Información del Negocio, Por favor Agreguela en Configuraciones.\n", "AVISO");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void Cargar_ProductosMasVendidos()
        {
            Controladores.CtrlHome ctrlHomre = new Controladores.CtrlHome();
            dataGridView2.DataSource = ctrlHomre.Cargar_ProductosMasVendidosHoy();
        }

        public void GraficaCargar_TotalVentasxDias()
        {
            Controladores.CtrlHome ctrl = new Controladores.CtrlHome();
            List<Reporte> ganancias = ctrl.Cargar_TotalVentasxDias();

            ArrayList fechas = new ArrayList();
            ArrayList Ganancias = new ArrayList();

            if (ganancias.Count == 0)
            {
                Label_Ganancias.Visible = true;
                Label_Ganancias.Text = "No se ha hecho ninguna transacción hoy";
                Label_Ganancias.Location = new System.Drawing.Point(60, 70);
                chart2.Visible = false;

                // Agrega el TextBox al GroupBox
                guna2GroupBox1.Controls.Add(Label_Ganancias);
            }
            else
            {
                foreach (Reporte ganancia in ganancias)
                {
                    fechas.Add(ganancia.Fecha);
                    Ganancias.Add(ganancia.Ganancias);
                }
                chart2.Series[0].Points.DataBindXY(fechas, Ganancias);
            }               
        }

        public void GraficaCargar_ProductosMasVendidos()
        {
            ArrayList nombreProducto = new ArrayList();
            ArrayList cantidad = new ArrayList();

            if (dataGridView2.RowCount == 0) // Cambié "null" a "0" para verificar si no hay filas.
            {
                Label_CantProductos.Visible = true;
                Label_CantProductos.Text = "No se ha vendido ningún producto hoy";
                Label_CantProductos.Location = new System.Drawing.Point(10, 70);
                chartTopProducts.Visible = false;

                // Agrega el TextBox al GroupBox
                guna2GroupBox6.Controls.Add(Label_CantProductos);
            }
            else
            {
                foreach (DataGridViewRow fila in dataGridView2.Rows)
                {
                    nombreProducto.Add(fila.Cells[0].Value);
                    cantidad.Add(fila.Cells[1].Value);
                }
                chartTopProducts.Series[0].Points.DataBindXY(nombreProducto.ToArray(), cantidad.ToArray()); // Agregué "ToArray" para asegurarme de que los datos sean arreglos.
            }
        }
        private void UC_HOME_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            InfoNegocio();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        public void GraficoVentasDiarias()
        {
            /*
            string sql = "SELECT fecha, SUM(Total_Final) AS Total_Vendido FROM facturas GROUP BY fecha";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                chart1.DataSource = dataSet;
                chart1.Series[0].XValueMember = "fecha";
                chart1.Series[0].YValueMembers = "Total_Vendido";
                chart1.DataBind();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            };
            */
        }

        private bool HayInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                //MessageBox.Show(host.ToString());
                lbCN.ForeColor = System.Drawing.Color.Green;
                lbCN.Text = "Online";
                pbWifi.Image = Resources.icons8_wifi_50;
                return true;

            }
            catch
            {
                lbCN.ForeColor = System.Drawing.Color.Red;
                lbCN.Text = "Offline";
                pbWifi.Image = Resources.icons8_wifi_apagado_50;
                return false;
            }
        }

        private void btnSaveDolar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Dolar = txtDolar.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Información Guardada correctamente.");
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            ArqueoCaja arqueoCaja = new ArqueoCaja();
            arqueoCaja.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteVentasDiario frm = new ReporteVentasDiario();
            frm.ShowDialog();
        }
    }
}
