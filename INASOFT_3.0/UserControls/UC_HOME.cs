using Guna.UI2.WinForms;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
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
        public UC_HOME()
        {
            InitializeComponent();
            lbUser.Text = Sesion.nombre;
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            lbdate.Text = fecha;
            
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
            string sql = "SELECT COUNT(*) FROM Facturas WHERE DATE_FORMAT(fecha, '%Y/%m/%d') = '" + lbdate.Text + "'";
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
    }
}
