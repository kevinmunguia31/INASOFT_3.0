using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace INASOFT_3._0.Controladores
{
    public class CtrlReporteGraficos
    {
        public System.Data.DataTable CargarReporteGanancias(int dato)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = " CALL ConsultarIngresos("+ dato +");";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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


        public List<Reporte> CargarGananciasDe6UltimosDias()
        {
            List<Reporte> ganancias = new List<Reporte>();

            string sql = "SELECT CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0')) AS 'Año-Mes-Día',\r\n  FORMAT(SUM(Total_Final - Debe), 2) AS 'Total vendido'\r\nFROM Facturas\r\nWHERE DATE(Fecha) BETWEEN CURDATE() - INTERVAL 6 DAY AND CURDATE()\r\nGROUP BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0'))\r\nORDER BY CONCAT(YEAR(Fecha), '-', LEFT(CONVERT(MONTHNAME(Fecha) USING utf8), 3), '-', LPAD(DAY(Fecha), 2, '0'));";

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

        public string CantPendienteFactCredito()
        {
            string CantPendienteFactCredito = "";
            string SQL = "SELECT CASE WHEN SUM(Debe) IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(SUM(Debe), 2)) END 'Total' " +
                "FROM Facturas;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                CantPendienteFactCredito = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                CantPendienteFactCredito = "";
            }
            return CantPendienteFactCredito;
        }

        public string TotalGanancias()
        {
            string TotalGanancias = "";
            string SQL = "SELECT CASE WHEN SUM(Debe) IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(SUM(Total_Final - Debe), 2)) END 'Total' " +
                "FROM Facturas;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                TotalGanancias = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                TotalGanancias = "";
            }
            return TotalGanancias;
        }

        public string CantFactPendiente()
        {
            string CantPendiente = "";
            string SQL = "SELECT CASE WHEN COUNT(ID)  IS NULL THEN '0' ELSE COUNT(ID) END 'Cantidad'" +
                "FROM Facturas WHERE Estado = 'Pendiente';";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                CantPendiente = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                CantPendiente = "";
            }
            return CantPendiente;
        }

        // Reportes de porductos
        public System.Data.DataTable CargarReporteProductosMasVendidos(int dato)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = " CALL ConsultarProductosMasVendidos(" + dato + ");";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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

        public System.Data.DataTable CargarReporteProductosMenosVendidos(int dato)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = " CALL ConsultarProductosMenosVendidos(" + dato + ");";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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


        //Importes Kardex del inventario
        public System.Data.DataTable CargarProductosMasCaro()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "SELECT\r\n    a.Nombre AS 'Producto',\r\n\tCASE WHEN   a.Precio_Venta IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(a.Precio_Venta, 2))  END 'Precio más alto',\r\n    SUM(b.Cantidad) AS 'Cantidad de productos vendidos'\r\nFROM Productos a\r\nINNER JOIN Detalle_Factura b ON a.ID = b.ID_Producto\r\nINNER JOIN Facturas c ON c.ID = b.ID_Factura\r\nWHERE a.Precio_Venta = (SELECT MAX(Precio_Venta) FROM Productos)\r\nGROUP BY a.Nombre, a.Precio_Venta;";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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

        public System.Data.DataTable CargarProductosCambioPrecio()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "SELECT \r\n    a.Nombre,\r\n    DATE_FORMAT(b.Fecha_Cambio, '%d %b, %Y') AS 'Fecha del cambio',\r\n\tCASE WHEN  b.Precio_Antiguo IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT(b.Precio_Antiguo, 2)) END 'Precio Antiguo',\r\n\tCASE WHEN   b.Precio_Nuevo IS NULL THEN 'C$ 0.00' ELSE CONCAT('C$ ', FORMAT( b.Precio_Nuevo, 2)) END 'Precio Nuevo'   \r\nFROM Productos a \r\nINNER JOIN Historial_Precio b ON a.ID = b.ID_Producto;";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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

        public System.Data.DataTable CargarProductosActivoNoActivo()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "SELECT * FROM ProductosActivosNoActivos;";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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

        public List<Reporte> CargarProductosBajoInventario()
        {
            List<Reporte> ganancias = new List<Reporte>();

            string sql = "SELECT Nombre, Existencias FROM Productos WHERE Existencias <= 10;";

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
                            Nombre = reader[0].ToString(),
                            Canitdad = Convert.ToInt32(reader[1])
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

        public System.Data.DataTable CargarProductosNoVendidos()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "SELECT\r\n    p.Nombre AS 'Nombre del Producto',\r\n    p.Existencias AS 'Existencias Actuales'\r\nFROM Productos p\r\nLEFT JOIN Detalle_Factura df ON p.ID = df.ID_Producto\r\nWHERE df.ID_Producto IS NULL;";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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

        public System.Data.DataTable ObtenerMovimientosProductos(int op)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "CALL ObtenerMovimientosProductos("+ op +")";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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
    }
}
