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

        public bool Insertar_Factura(string Fecha, string Usuario, int ID_Cliente)
        {
            bool bandera = false;
            string sql = "CALL Insertar_Factura('" + Fecha + "', '" + Usuario + "', '" + ID_Cliente + "'); ";

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

        public DataTable DetalleFactura(string idFactura)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT a.Codigo_Prod AS 'Codigo', a.Nombre_Prod AS 'Nombre', a.Precio, a.Cantidad, a.Total FROM Detalle_Factura a INNER JOIN Facturas b ON a.ID_Factura = b.ID INNER JOIN Clientes c ON b.ID_Cliente = c.ID WHERE a.ID_Factura = " + idFactura + ";";
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

        public bool Facturar_Productos(int cantidad, double precio, string codigo_prod, string nombre_prod, int id_factura)
        {
            bool bandera = false;
            string sql = "CALL Facturar_Productos(" + cantidad + ", " + precio + ", '" + codigo_prod + "', '" + nombre_prod + "', " + id_factura + ");";

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

        public bool Facturacion_Final(string estado, double descuento, double subtotal, double efectivo, double debe, string tipoPago, string tipoFactura, int id_usuario, int id_cliente)
        {
            bool bandera = false;
            string sql = "CALL Facturacion_Final('"+ estado +"', "+ descuento +", "+ subtotal +", "+ efectivo+ ", "+ debe + ", '"+ tipoPago + "', '"+ tipoFactura + "', "+ id_usuario + ", "+ id_cliente +");";
            
            //string sql = "CALL Facturacion_Final('" + estado + "', " + descuento + ", " + subtotal + ", " + efectivo + ", " + debe + ", " + id_factura + ", '" + tipoPago + "', '" + tipoFactura + "');";

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

        public bool AnularFactura(double precio, int cantidad, string cod_prod, int id_factura)
        {
            bool bandera = false;
            string sql = "CALL Anular_Factura(" + precio + ", " + cantidad + ", '" + cod_prod + "', " + id_factura + ");";

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

        public bool Actualizar_FacturaAnulada(string desc, int id_factura)
        {
            bool bandera = false;
            string sql = "CALL Actualizar_FacturaAnulada('" + desc + "', " + id_factura + ")";

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

        public string Desc_FacturaAnulada(int id_factura)
        {
            string desc = "";
            string SQL = "SELECT descripcion FROM Facturas_Anuladas WHERE ID_Factura = "+ id_factura +";";

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
            string SQL = "CALL  Mostrar_Cod()";

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

        public DataTable Factura_NombreCliente(string dato)
        {
            DataTable tabla = new DataTable();
            string SQL;

            SQL = "CALL Factura_NombreCliente ('" + dato + "');";

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

        public DataTable Factura_Fecha(string dato1, string dato2)
        {
            DataTable tabla = new DataTable();
            string SQL;

            SQL = "CALL Factura_RangoFecha('"+ dato1 +"', '"+ dato2 +"')";

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
    }
}
