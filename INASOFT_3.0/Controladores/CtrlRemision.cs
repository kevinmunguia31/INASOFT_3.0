using INASOFT_3._0.Modelos;
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
    internal class CtrlRemision
    {
        public DataTable CargarRemisiones()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Mostrar_Remisiones";

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

        public DataTable CargarDetalleRemisiones(int id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT\r\n    b.ID AS 'ID',\r\n    c.Codigo AS 'Codigo',\r\n    c.Nombre AS 'Nombre producto',\r\n    c.Precio_Venta AS 'Precio de venta',\r\n    c.Precio_Compra AS 'Precio de compra',\r\n    b.Cantidad AS 'Cant. Productos',\r\n    a.Tipo_Remision AS 'Tipo de remisión'\r\nFROM Remisiones a \r\nINNER JOIN Detalle_Remision b ON a.ID = b.ID_Remision\r\nINNER JOIN Productos c ON b.ID_Producto = c.ID\r\nWHERE a.ID = "+id+"\r\nORDER BY b.ID;";

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

        public DataTable CargarFiltroRemisiones(int op)
        {
            DataTable dt = new DataTable();
            string sql = "CALL Filtro_Remisiones("+op+")";

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

        public DataTable CargarRemisionesxFecha(string fecha_Ini, string fecha_Fin )
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Mostrar_Remisiones WHERE DATE_FORMAT(Fecha, '%Y/%m/%d') BETWEEN '"+fecha_Ini+"' AND '"+fecha_Fin+"';";

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

        public bool RealizarRemesa(Remision remision)
        {
            bool bandera = false;
             
            string sql = "CALL Realizar_Remision('"+ remision.Descripcion + "', '"+ remision.Tipo_Remision + "', "+ remision.Id_Usuario +")";

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
            return bandera;
        }

        public bool Remision_ProductosSalida(Productos productos)
        {
            bool bandera = false;

            string descripcion = MySqlHelper.EscapeString(productos.Nombre); // Escapa las comillas simples

            string sql = $"CALL Detalle_RemisionSalida({productos.Id}, '{descripcion}', {productos.Existencias}, {productos.Id_remision});";

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

        public bool Remision_ProductosEntrada(Productos productos)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Detalle_RemisionEntrada(@Id, @Codigo, @Nombre, @Existencias, @ExistenciasMin, @PrecioCompra, @PrecioVenta, @Observacion, @IdRemision);";

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
                comando.Parameters.AddWithValue("@IdRemision", productos.Id_remision);

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

        public int ID_Remision()
        {
            int id = 0;
            string SQL = "SELECT ID FROM Remisiones ORDER BY ID DESC LIMIT 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id = 0;
            }
            return id;
        }
    }
}
