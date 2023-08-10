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
    class CtrlCredito_Abono
    {
        public DataTable Cargar_Creditos()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT * FROM Mostrar_Creditos;";
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

        public DataTable Cargar_EstadoDeCredito(int idCredito)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT * FROM Mostrar_EstadoCredito WHERE ID_Credito = "+ idCredito +";";
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

        public bool Insertar_Credito(string DiaDeCredito , string DiaDeVencimiento, double Cargo, string Estado, string Desc, int ID_Factura, int ID_Cliente)
        {
            bool bandera = false;
            string sql = "CALL Agregar_Credito('" + DiaDeCredito + "', '" + DiaDeVencimiento + "', " + Cargo + ", '" + Estado + "', '" + Desc + "'," + ID_Factura + ", " + ID_Cliente + ");";

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

        public bool Realizar_Abono(string Fecha, double Monto, double SaldoAnterior, double SaldoNuevo, string Desc, int ID_Credito, int ID_Factura)
        {
            bool bandera = false;
            string sql = "CALL Realziar_Abono('" + Fecha + "', " + Monto + ", " + SaldoAnterior + ",  " + SaldoNuevo + ", '" + Desc + "', " + ID_Credito + ", " + ID_Factura + ");";

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

        public int Actualizar_FacturaCredito(int ID_Credito, int ID_Factura)
        {
            int bandera = 0;
            string SQL = "CALL Actualizar_FacturaCredito(" + ID_Credito + ", " + ID_Factura + ");";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                bandera = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                bandera = 0;
            }
            return bandera;
        }

        public int ID_Credito()
        {
            int id_credito = 0;
            string SQL = "SELECT ID FROM Credito ORDER BY ID DESC LIMIT 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_credito = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_credito = 0;
            }
            return id_credito;
        }

        public double Saldo_Credito(int id_credito)
        {
            double saldo = 0.00;
            string SQL = "SELECT Saldo_Nuevo FROM Abono WHERE ID_Credito = "+ id_credito + " ORDER BY ID DESC LIMIT 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                saldo = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                saldo = 0;
            }
            return saldo;
        }
    }
}
