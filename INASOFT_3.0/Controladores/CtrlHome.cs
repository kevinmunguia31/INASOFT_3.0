using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Controladores
{
    class CtrlHome
    {
        public DataTable Cargar_TotalxMes()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT * FROM Total_x_MES;";
            try
            {
                MySqlConnection conexionBD = Conexion.getConexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return dt;
        }

        public MySqlDataReader Grafico_TotalxMes()
        {
            MySqlDataReader reader;

            string sql = "SELECT 'Año', 'Mes', 'Total vendido' FROM Total_x_MES;";
            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            MySqlCommand comando = new MySqlCommand(sql, conexioBD);
            reader = comando.ExecuteReader();

            return reader;
        }

        public int Total_Facturas_Realizads(string fecha_hoy)
        {
            int total = 0;
            string SQL = "SELECT COUNT(*) AS 'Total' FROM Facturas WHERE DATE_FORMAT(Fecha, '%Y/%m/%d') = '" + fecha_hoy + "'";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = 0;
            }
            return total;
        } 

        public int Total_FacturasAnuldas()
        {
            int total = 0;
            string SQL = "SELECT COUNT(ID) FROM Facturas WHERE Estado = 'Anulada';";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = 0;
            }
            return total;
        }
        public double TotalFinal_Facturas(string fecha_hoy)
        {
            double total = 0.00;
            string SQL = "SELECT CASE WHEN SUM(Total_Final - Debe) IS NULL THEN '0' ELSE SUM(Total_Final - Debe) END AS 'Total ingresado por fecha' FROM Facturas WHERE DATE_FORMAT(fecha, '%Y/%m/%d') = '" + fecha_hoy + "'";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total = Convert.ToDouble(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = 0.00;
            }
            return total;
        }
  
        public double TotalFinal()
        {
            double total = 0.00;
            string SQL = "SELECT CASE WHEN SUM(Total_Final - Debe) IS NULL THEN '0.00' ELSE SUM(Total_Final - Debe) END AS 'Total ingresado por fecha' FROM Facturas;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total = Convert.ToDouble(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = 0.00;
            }
            return total;
        }
    }
}
