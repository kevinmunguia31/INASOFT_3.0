using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

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
        public DataTable Creditos_BuscarNombreRangoFechaEstado(int op, string fechaIni, string fechaFin, string nombreCliente, string estado, int diasVencidos)
        {
            DataTable tabla = new DataTable();
            string SQL;

            SQL = "CALL ObtenerFacturasCredito(" + op + ", '" + fechaIni + "', '" + fechaFin + "', '" + nombreCliente + "', '" + estado + "', "+ diasVencidos +");";

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

        public bool Insertar_Credito(Credito credito)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Agregar_Credito(@DiaInicio, @DiaVencimiento, @Cargo, @Estado, @Descripcion, @IdFactura, @IdCliente, @IdTipoPago)";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@DiaInicio", credito.Dia_Inicio);
                comando.Parameters.AddWithValue("@DiaVencimiento", credito.Dia_Vencimiento);
                comando.Parameters.AddWithValue("@Cargo", credito.Cargo);
                comando.Parameters.AddWithValue("@Estado", credito.Estado);
                comando.Parameters.AddWithValue("@Descripcion", credito.Descripcion);
                comando.Parameters.AddWithValue("@IdFactura", credito.Id_Factura);
                comando.Parameters.AddWithValue("@IdCliente", credito.Id_Cliente);
                comando.Parameters.AddWithValue("@IdTipoPago", credito.Id_TipoPago);

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

        public bool Realizar_Abono(Credito credito)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "CALL Realziar_Abono(@Monto, @SaldoAnterior, @SaldoNuevo, @DescripcionAbono, @IdCredito, @IdFactura)";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Monto", credito.Monto);
                comando.Parameters.AddWithValue("@SaldoAnterior", credito.Saldo_Anterior);
                comando.Parameters.AddWithValue("@SaldoNuevo", credito.Saldo_Nuevo);
                comando.Parameters.AddWithValue("@DescripcionAbono", credito.Descripcion_Abono);
                comando.Parameters.AddWithValue("@IdCredito", credito.Id_Credito);
                comando.Parameters.AddWithValue("@IdFactura", credito.Id_Factura);

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

        public int Actualizar_FacturaCredito(Credito credito)
        {
            int bandera = 0;
            string SQL = "CALL Actualizar_FacturaCredito("+ credito.Id_Credito +", "+ credito.Id_Factura +");";

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
