using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace INASOFT_3._0.Controladores
{
    internal class CtrlRemision
    {
        
        public bool RealizarRemesa(Remision remision)
        {
            bool bandera = false;
             
            string sql = "CALL Realizar_Remision('"+ remision.Descripcion + "')";

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
