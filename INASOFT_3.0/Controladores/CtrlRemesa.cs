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
    internal class CtrlRemesa
    {
        
        public bool RealizarRemesa(Productos productos)
        {
            bool bandera = false;
             
            string sql = "CALL Insertar_Remesa("+ productos.Id +", '"+ productos.Codigo +"', '"+ productos.Nombre +"', "+ productos.Existencias+", "+ productos.Existencias_min +", "+ productos.Precio_compra +", "+ productos.Precio_venta +", '"+ productos.Observacion +"', 2);";

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
    }
}
