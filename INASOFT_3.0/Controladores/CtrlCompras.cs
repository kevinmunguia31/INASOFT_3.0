using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string sql = "CALL Realizar_Compra('" + compra.Nombre_venderdor + "', " + compra.Subtotal + ", " + compra.Descuento + "," + compra.Iva + ", '" + compra.Descripcion + "', '" + compra.Tipo_pago + "', " + compra.Id_usuario + ", "+ compra.Id_proveedor +");";

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

        public bool Productos_Comprados(Productos productos)
        {
            bool bandera = false;
            string sql = "CALL Productos_Comprados("+ productos.Id +", '"+ productos.Codigo +"', '"+ productos.Nombre +"', "+ productos.Existencias +", "+ productos.Precio_compra +", "+ productos.Precio_total + ", "+ productos.Precio_venta +", '"+ productos.Observacion +"');";

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
    }
}
