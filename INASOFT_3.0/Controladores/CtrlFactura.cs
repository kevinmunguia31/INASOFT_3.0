using DevExpress.XtraCharts;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using static iTextSharp.awt.geom.Point2D;

namespace INASOFT_3._0.Controladores
{
    class CtrlFactura
    {
        public DataTable CargarFactura()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT * FROM Mostrar_Factura;";
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

        public DataTable CargarTodasFacturas()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT * FROM Mostrar_TodasFactura;";
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

       
        public DataTable DetalleFactura(int idFactura)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT c.ID, c.Codigo AS 'Codigo', c.Nombre AS 'Nombre', c.Precio_Venta, b.Cantidad, (c.Precio_Venta * b.Cantidad) AS 'Total' FROM Facturas a INNER JOIN Detalle_Factura b ON b.ID_Factura = a.ID INNER JOIN Productos c ON c.ID = b.ID_Producto WHERE a.ID = "+ idFactura +"";

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

        public bool Facturar_Productos(Facturas facturas)
        {
            bool bandera = false;

            string sql = "CALL Facturar_Productos("+ facturas.Cantidad +", '"+facturas.DescripcionPrecio+"', "+ facturas.Id_Factura +", "+ facturas.Id_Producto+");";

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool Facturacion_Final(Facturas facturas)
        {
            bool bandera = false;

            string sql = "CALL Facturacion_Final('"+ facturas.Estado +"', "+ facturas.Descuento +", "+ facturas.Subtotal +", "+ facturas.Efectivo +", "+ facturas.Debe+", '"+ facturas.Tipo_Factura + "', '"+ facturas.Referencia + "', '"+ facturas.Fecha +"', " + facturas.Id_Usuario +", "+ facturas.Id_Cliente +", "+ facturas.Id_TipoPago +");";

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool AnularFactura(Facturas facturas)
        {
            bool bandera = false;

            string sql = "CALL Anular_Factura("+ facturas.Cantidad +", "+ facturas.Id_Producto +", "+ facturas.Id_Factura+");";

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool Actualizar_FacturaAnulada(Facturas facturas)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Actualizar_FacturaAnulada(@Descripcion, @IdFactura)";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Descripcion", facturas.Descripcion);
                comando.Parameters.AddWithValue("@IdFactura", facturas.Id_Factura);

                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public string Desc_FacturaAnulada(int id_factura)
        {
            string desc = "";
            string SQL = "SELECT Descripcion FROM Facturas_Anuladas WHERE ID_Factura = "+ id_factura +";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                desc = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                desc = "";
            }
            return desc;
        }

        public int ID_Factura()
        {
            int id_factura = 0;
            string SQL = "SELECT ID FROM Facturas ORDER BY ID DESC LIMIT 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_factura = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_factura = 0;
            }
            return id_factura;
        }

        public string Codigo_Factura()
        {
            string cod_factura = "";
            string SQL = "CALL Mostrar_Cod()";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                cod_factura = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                cod_factura = "";
            }
            return cod_factura;
        }

        public DataTable Factura_BuscarNombreRangoFecha(int op, string fechaIni, string fechaFin, string nombreCliente)
        {
            DataTable tabla = new DataTable();
            string SQL;

            SQL = "CALL SeleccionarProcedimiento("+ op +", '"+ fechaIni +"', '"+ fechaFin +"', '"+ nombreCliente +"');";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(tabla);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
            return tabla;
        }   

        public DataTable Factura_Mes(string dato)
        {
            DataTable tabla = new DataTable();
            string SQL;

            SQL = "SELECT * FROM Mostrar_Factura WHERE MONTH(fecha) = "+ dato +" GROUP BY Codigo;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(tabla);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
            return tabla;
        }
        public double Total_Cancelado()
        {
            double total = 0.00;
            string SQL = "SELECT CASE WHEN SUM(Total_Final) IS NULL THEN '0' ELSE SUM(Total_Final) END 'Total' FROM Facturas WHERE Estado = 'Cancelado';";

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

        public double Total_Pendiente()
        {
            double total = 0.00;
            string SQL = "SELECT CASE WHEN SUM(Efectivo) IS NULL THEN '0' ELSE SUM(Efectivo) END 'Total' FROM Facturas WHERE Estado = 'Pendiente';";

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
