using Guna.UI2.WinForms;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.Properties;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
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
            Cargar_TotalxMes();
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
        }

        //Cargar el dataGridView
        public void Cargar_TotalxMes()
        {
            Controladores.CtrlHome ctrlHome = new Controladores.CtrlHome();
            dataGridView1.DataSource = ctrlHome.Cargar_TotalxMes();
        }

        public void Grafica()
        {
            Series series = new Series("Datos del DataGridView");
            series.ChartType = SeriesChartType.Column; // Tipo de gráfico (puede ser diferente)

            // Recorrer las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Obtener el valor de la celda deseada (supongamos que es la columna 1)
                if (fila.Cells[1].Value != null)
                {
                    double valor = Convert.ToDouble(fila.Cells[2].Value);
                    series.Points.AddXY(fila.Index, valor); // Añadir el punto a la serie
                }
            }

            // Agregar la serie al Chart
            chart2.Series.Add(series);
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
    }
}
