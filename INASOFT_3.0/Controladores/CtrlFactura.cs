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

        public int Codigo_Factura()
        {
            int id_codigo = 0;
            string SQL = "CALL Mostrar_Codigo();";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_codigo = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_codigo = 0;
            }
            return id_codigo;
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

        public bool Cancelar_Factura(int id)
        {
            bool bandera = false;
            string sql = "CALL Cancelar_Factura()";

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
