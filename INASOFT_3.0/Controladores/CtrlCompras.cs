using DevExpress.XtraCharts;
using DocumentFormat.OpenXml.Vml;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace INASOFT_3._0.Controladores
{
    internal class CtrlCompras
    {
        public DataTable CargarCompras()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Mostrar_Compras";

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

        public bool Insertar_Compra(Compras compra)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Realizar_Compra(@NombreVendedor, @Subtotal, @Descuento, @Iva, @Descripcion, @Estado, @IdUsuario, @IdProveedor, @IdTipoPago)";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@NombreVendedor", compra.Nombre_venderdor);
                comando.Parameters.AddWithValue("@Subtotal", compra.Subtotal);
                comando.Parameters.AddWithValue("@Descuento", compra.Descuento);
                comando.Parameters.AddWithValue("@Iva", compra.Iva);
                comando.Parameters.AddWithValue("@Descripcion", compra.Descripcion);
                comando.Parameters.AddWithValue("@Estado", compra.Estado);
                comando.Parameters.AddWithValue("@IdUsuario", compra.Id_usuario);
                comando.Parameters.AddWithValue("@IdProveedor", compra.Id_proveedor);
                comando.Parameters.AddWithValue("@IdTipoPago", compra.Id_TipoPago);

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
        public int ID_Compra()
        {
            int id_compra = 0;
            string SQL = "SELECT ID FROM Compras ORDER BY ID DESC LIMIT 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_compra = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_compra = 0;
            }
            return id_compra;
        }

        public bool Productos_Comprados(Productos productos)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Productos_Comprados(@Id, @Codigo, @Nombre, @Existencias, @ExistenciasMin, @PrecioCompra, @PrecioVenta, @Observacion, @IdCompra)";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Id", productos.Id);
                comando.Parameters.AddWithValue("@Codigo", productos.Codigo);
                comando.Parameters.AddWithValue("@Nombre", productos.Nombre);
                comando.Parameters.AddWithValue("@Existencias", productos.Existencias);
                comando.Parameters.AddWithValue("@ExistenciasMin", productos.Existencias_min);
                comando.Parameters.AddWithValue("@PrecioCompra", productos.Precio_compra);
                comando.Parameters.AddWithValue("@PrecioVenta", productos.Precio_venta);
                comando.Parameters.AddWithValue("@Observacion", productos.Observacion);
                comando.Parameters.AddWithValue("@IdCompra", productos.Id_Compra);

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

        public DataTable Compras_Filtro(int op, int id, string estado)
        {
            DataTable tabla = new DataTable();
            string SQL;

            SQL = "CALL FiltrarCompras(" + op + ", '" + estado + "', " + id + ");";

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

        public bool CancelarCompra(int id)
        {
            bool bandera = false;
            string sql = "UPDATE Compras " +
                         "SET Estado = CASE " +
                         "WHEN Estado = 'Pendiente' THEN 'Cancelada' " +
                         "WHEN Estado = 'Cancelada' THEN 'Pendiente' " +
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
        
        public int NumeroCompra()
        {
            int id_compra = 0;
            string SQL = "SELECT COALESCE((SELECT (ID + 1) FROM Compras ORDER BY ID DESC LIMIT 1), 1) AS 'Numero de compra';";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_compra = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_compra = 0;
            }
            return id_compra;
        }
    }
}
