using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Controladores
{
    internal class CtrlCompras
    {
        public bool Insertar_Compra(Compras compra)
        {
            bool bandera = false;
            string sql = "CALL Realizar_Compra('" + compra.Nombre_venderdor + "', " + compra.Subtotal + ", " + compra.Descuento + ", '" + compra.Descripcion + "', '" + compra.Tipo_pago + "', " + compra.Id_usuario + ", "+ compra.Id_proveedor +");";

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

        
        public bool Productos_Comprados(Detalle_Compras dt_compra, Productos productos)
        {
            bool bandera = false;
            string sql = "CALL Productos_Comprados("+ productos.Id +", '"+ productos.Codigo +"', '"+ productos.Nombre +"', "+ productos.Existencias +", "+ productos.Precio_compra +", "+ dt_compra.Iva +", "+ dt_compra.Descuento +", "+ productos.Precio_total + ", "+ productos.Precio_venta +", '"+ productos.Observacion +"');";

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
