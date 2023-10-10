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
            bool bandera = false; string sql = "CALL Realizar_Compra('" + compra.Nombre_venderdor + "', " + compra.Subtotal + ", " + compra.Descuento + "," + compra.Iva + ", '" + compra.Descripcion + "', '" + compra.Estado + "', " + compra.Id_usuario + ", "+ compra.Id_proveedor + ", "+ compra.Id_TipoPago +");";
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
            //ID_Producto - Codigo_Producto - Nombre_Producto - Cantidad - Existencias_Minimas - Precio_Compra - Total - Precio_Venta - Observacion - ID_Compra
            string sql = "CALL Productos_Comprados("+ productos.Id +", '"+ productos.Codigo +"', '"+ productos.Nombre +"', "+ productos.Existencias +", "+ productos.Existencias_min +", "+ productos.Precio_compra +", "+ productos.Precio_total +", "+ productos.Precio_venta +", '"+ productos.Observacion +"', "+ productos.Id_Compra +");";

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
    }
}
