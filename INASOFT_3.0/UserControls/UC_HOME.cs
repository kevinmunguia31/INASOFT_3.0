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
            LoadSalesXMonth();
            GraficoVentasDiarias();

        }

        private void UC_HOME_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            TotalFacturadoHoy();
            TotalFacturasHoy();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        public void TotalFacturadoHoy()
        {
            MySqlDataReader reader = null;
            
            string sql = "SELECT SUM(Total_Final) FROM Facturas WHERE DATE_FORMAT(fecha, '%Y/%m/%d') = '" + lbdate.Text + "'";
            
            try
            {
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
                            double d = Convert.ToDouble(reader.GetString(0), CultureInfo.InvariantCulture);
                            lbTotalHoy.Text = d.ToString("0,0.00", CultureInfo.InvariantCulture);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            catch (SqlNullValueException)
            {
                //MessageDialogInfo.Show("Bienvenido " + user.ToString() + " Hoy sera un Gran Dia 🤗");
            }
            
        }

        public void TotalFacturasHoy()
        {
            MySqlDataReader reader = null;
            //string sql = "SELECT COUNT(Codigo_Fac) FROM Facturas WHERE DATE_FORMAT(fecha, '%Y/%m/%d') = '" + lbdate.Text + "' GROUP BY Codigo_Fac";
            string sql = "CALL Total_FacturasRealizadas('"+ lbdate.Text +"')";
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
                        lbCantInvoice.Text = (reader.GetString(0));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void LoadSalesXMonth()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MONTH(Fecha) AS Mes, SUM(Total_Final) AS Total_Vendido FROM Facturas GROUP BY MONTH(Fecha)";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);

                listViewVentas.Clear();
                listViewVentas.View = View.Details;

                listViewVentas.FullRowSelect = true;
                listViewVentas.Columns.Add(dt.Columns[0].ToString(), 100);
                listViewVentas.Columns.Add(dt.Columns[1].ToString(), 200);

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = new string[2];
                    ListViewItem item = new ListViewItem();

                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = row[i].ToString();
                        item = new ListViewItem(arr);
                    }
                    listViewVentas.Items.Add(item);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void GraficoVentasDiarias()
        {
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
