using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    internal class Conexion
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost";
            string puerto = "3307";
            string usuario = "root";
            string password = "mysql";
            string bd = "db_inasoftware";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;
        }
    }
}
