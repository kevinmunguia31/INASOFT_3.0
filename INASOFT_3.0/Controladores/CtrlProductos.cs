using INASOFT_3._0.Modelos;
using INASOFT_3._0.Controladores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using iText.StyledXmlParser.Jsoup.Select;
using System.Windows.Forms;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using DevExpress.Utils.DirectXPaint;

namespace INASOFT_3._0.Controladores
{
    class CtrlProductos
    {
        public DataTable CargarProductos()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Mostrar_Producto;";

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
        public DataTable CargarDetalleProductos()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Codigo, Nombre, Estado, Existencias, Precio_Compra AS 'Precio de compra', Precio_Venta AS 'Precio de venta', Precio_Total AS 'Total' FROM Productos;";

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
       
        public DataTable BuscarProducto(string dato)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Mostrar_Producto WHERE Producto LIKE '%"+ dato +"%' OR Codigo LIKE '%"+ dato +"%';";

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
        
        public DataTable Cargar_NombreProductoActivo(string dato )
        {
            DataTable dt = new DataTable();
            string SQL = "";
            if (dato == "")
            {
                SQL = "SELECT ID, Nombre FROM Productos WHERE Estado = 'Activo'";
            }
            else
            {
                SQL = "SELECT ID, Nombre FROM Productos WHERE Estado = 'Activo' AND Nombre LIKE '%" + dato + "%' OR Codigo LIKE '%" + dato + "%';";
            }           

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        public bool VerificarCodigo(int codigo)
        {
            bool bandera = false;
            string SQL = "SELECT * FROM Productos WHERE Codigo = '"+ codigo +"';";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                //total_clientes = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //total_clientes = 0;
            }
            return bandera;
        }

        public bool Actualizar(Productos productos)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Actualizar_Producto(@Id, @Nombre, @Estado, @Existencias, @ExistenciasMin, @PrecioCompra, @PrecioVenta, @Observacion);";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Id", productos.Id);
                comando.Parameters.AddWithValue("@Nombre", productos.Nombre);
                comando.Parameters.AddWithValue("@Estado", productos.Estado);
                comando.Parameters.AddWithValue("@Existencias", productos.Existencias);
                comando.Parameters.AddWithValue("@ExistenciasMin", productos.Existencias_min);
                comando.Parameters.AddWithValue("@PrecioCompra", productos.Precio_compra);
                comando.Parameters.AddWithValue("@PrecioVenta", productos.Precio_venta);
                comando.Parameters.AddWithValue("@Observacion", productos.Observacion);

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

        public bool CambiarEstado(int id)
        {
            bool bandera = false;
            string sql = "UPDATE Productos " + 
                         "SET Estado = CASE " + 
                         "WHEN Estado = 'Activo' THEN 'No activo' " + 
                         "WHEN Estado = 'No activo' THEN 'Activo' " + 
                         "ELSE Estado " + 
                         "END " + 
                         "WHERE ID = " + id + ";";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            finally
            {
                conexioBD.Close();
            }
            return bandera;
        }

        public DataTable Cargar_NombreProducto()
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT ID, Nombre FROM Productos;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        public DataTable Cargar_NombreProducto_IDProveedor(int idProveedor)
        {
            DataTable dt = new DataTable();

            string SQL = "SELECT a.ID, a.Nombre FROM Productos a LEFT JOIN Detalle_Compra b ON a.ID = b.ID_Producto LEFT JOIN Compras c ON c.ID = b.ID_Compra LEFT JOIN Proveedor d ON c.ID_Proveedor = d.ID WHERE d.ID = " + idProveedor + ";";
            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;

        }

        public DataTable Buscar_NombreProducto(string dato)
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT * FROM Productos WHERE Nombre LIKE '%" + dato + "%' OR Codigo LIKE '%" + dato + "%'";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }
        public Productos MostrarDatosProductos(int id)
        {
            Productos producto = null; // Inicializamos producto como nulo
            string sql = "SELECT ID, Codigo, Nombre, Existencias, Existencias_Minimas, Precio_Compra, Precio_Venta, Observacion FROM Productos WHERE ID = " + id + " LIMIT 1;";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        producto = new Productos
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Codigo = reader[1].ToString(),
                            Nombre = reader[2].ToString(),
                            Existencias = Convert.ToInt32(reader[3]),
                            Existencias_min = Convert.ToInt32(reader[4]),
                            Precio_compra = Convert.ToDouble(reader[5]),
                            Precio_venta = Convert.ToDouble(reader[6]),
                            Observacion = reader[7].ToString()
                        };
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
            return producto; // Retornamos un solo objeto en lugar de una lista
        }

        public string CapitalInvertido()
        {
            string capital = "";
            CultureInfo culturaLocal = new CultureInfo("es-NI");
            string SQL = "SELECT CASE WHEN ROUND(SUM(precio_total), 2) IS NULL THEN '0' ELSE CONCAT('C$ ', FORMAT(ROUND(SUM(precio_total), 2), 2)) END AS 'Precio Total' FROM Productos;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                capital = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                capital = "";
            }
            return capital;
        }

        public string TotalProductos()
        {
            string total = "";
            string SQL = "SELECT CASE WHEN COUNT(*) IS NULL THEN '0' ELSE COUNT(*)  END 'Cantidad de productos' FROM productos;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                double aux = Convert.ToDouble(comando.ExecuteScalar());
                total = aux.ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = "";
            }
            return total;
        }

        public string EvaluacionCodigo(string codigo)
        {
            string mensaje = "";
            string SQL = "CALL EvaluacionCodigo('"+ codigo +"');";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                mensaje = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                mensaje = "";
            }
            return mensaje;
        }
    }
}
