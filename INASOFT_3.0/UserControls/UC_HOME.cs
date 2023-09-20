using DevExpress.XtraBars.Controls.Internal;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Guna.UI2.WinForms;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.Properties;
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
            HayInternet();
            GraficoVentasDiarias();
            Cargar_VentasxDias();
            Cargar_ProductosMasVendidos();
            GraficaProductos();
            Grafica();
            Controladores.CtrlHome ctrlHome = new Controladores.CtrlHome();
            lbCantInvoice.Text = ctrlHome.Total_Facturas_Realizads(fecha).ToString();
            lbTotalHoy.Text = ctrlHome.TotalFinal_Facturas(fecha).ToString();
            Lb_FactAnuladas.Text = ctrlHome.Total_FacturasAnuldas().ToString();
            Lb_Total.Text = ctrlHome.TotalFinal().ToString();
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            lbNameNeg.Text = Modelos.InfoNegocio.nombre;
        }

        //Cargar el dataGridView
        /*public void Cargar_TotalxMes()
        {
            Controladores.CtrlHome ctrlHome = new Controladores.CtrlHome();
            dataGridView1.DataSource = ctrlHome.Cargar_TotalxMes();
        }*/

        public void Cargar_VentasxDias()
        {
            Controladores.CtrlHome ctrlHomre = new Controladores.CtrlHome();
            dataGridView1.DataSource = ctrlHomre.Cargar_VentasXDias();
        }

        public void Cargar_ProductosMasVendidos()
        {
            Controladores.CtrlHome ctrlHomre = new Controladores.CtrlHome();
            dataGridView2.DataSource = ctrlHomre.Cargar_ProductosMasVendidos();
        }

        public void Grafica()
        {
            ArrayList fehca = new ArrayList();
            ArrayList cantidad = new ArrayList();
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                fehca.Add(fila.Cells[0].Value);
                cantidad.Add(fila.Cells[1].Value);
            }
            chart2.Series[0].Points.DataBindXY(fehca, cantidad);
        }

        public void GraficaProductos()
        {
            ArrayList nombreProducto = new ArrayList();
            ArrayList cantidad = new ArrayList();
            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                nombreProducto.Add(fila.Cells[0].Value);
                cantidad.Add(fila.Cells[1].Value);
            }
            chart3.Series[0].Points.DataBindXY(nombreProducto, cantidad);
        }
        private void UC_HOME_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
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

        private void chart2_Click(object sender, EventArgs e)
        {

        }
        private int imagenNumber = 1;

        private void LoadNextImagen()
        {
            if(imagenNumber == 6)
            {
                imagenNumber = 1;
            }
            PictureBox_Slider.ImageLocation = string.Format(@"Imag\{0}.jpg", imagenNumber);
            imagenNumber++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadNextImagen();
        }
    }
}
