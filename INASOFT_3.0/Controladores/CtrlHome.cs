using INASOFT_3._0.Modelos;
using iText.StyledXmlParser.Jsoup.Select;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public int Cant_FacturasRealizadasHoy()
        {
            int total = 0;
            string SQL = "SELECT COUNT(*) AS 'Total' FROM Facturas WHERE DATE(fecha) = CURDATE();";

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

        public int Total_FacturasAnuldasHoy()
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
        
        public string TotalFinal_FacturasHoy()
        {
            string total = "";
            string SQL = "SELECT CONCAT('C$ ',  COALESCE(FORMAT(SUM(Total_Final - Debe), 2), '0.00')) AS 'Total ingresado por fecha' FROM Facturas WHERE DATE(fecha) = CURDATE();";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = "";
            }
            return total;
        }
        
        
        public string Total_AbonoHoy()
        {
            string total = "";
            string SQL = "SELECT CONCAT('C$ ',  COALESCE(FORMAT(SUM(Monto), 2), '0.00')) AS 'Total ingresado' FROM Abono WHERE DATE(fecha) = CURDATE();";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = "";
            }
            return total;
        }

        public DataTable Cargar_VentasXDias()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT DATE_FORMAT(Fecha, '%Y-%m-%d'), COUNT(ID) FROM Facturas WHERE DATE_FORMAT(Fecha, '%Y-%m-%d') BETWEEN CURDATE() - INTERVAL 7 DAY AND CURDATE() GROUP BY DATE_FORMAT(Fecha, '%Y-%m-%d');";
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

        public DataTable Cargar_ProductosMasVendidosHoy()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT \r\n    c.Nombre AS 'Producto', \r\n    SUM(a.Cantidad) AS 'Cant. Vendida' \r\nFROM Detalle_Factura a\r\nINNER JOIN Facturas b ON a.ID_Factura = b.ID\r\nINNER JOIN Productos c ON a.ID_Producto = c.ID\r\nWHERE a.Cantidad > 0 AND DATE(b.Fecha) = CURDATE()\r\nGROUP BY c.Nombre  \r\nORDER BY SUM(a.Cantidad) DESC LIMIT 5;\r\n";
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

        public List<Reporte> Cargar_TotalVentasxDias()
        {
            List<Reporte> ganancias = new List<Reporte>();

            string sql = "SELECT DATE_FORMAT(Fecha, '%H:00') AS Hora, FORMAT(SUM(Total_Final - Debe), 2) AS 'Ganancias' FROM Facturas WHERE Fecha >= CURDATE() AND Fecha < CURDATE() + INTERVAL 1 DAY GROUP BY Hora ORDER BY Hora;";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reporte ganancia = new Reporte
                        {
                            Fecha = reader[0].ToString(),
                            Ganancias = Convert.ToDouble(reader[1])
                        };
                        ganancias.Add(ganancia);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conexionBD.Close();
            }
            return ganancias;
        }
    }
}