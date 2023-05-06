using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.Controladores
{
    class CtrlClientes
    {
        public DataTable CargarClientes(string dato)
        {
            DataTable dt = new DataTable();
            string sql;

            if (dato == null)
            {
                sql = "SELECT * FROM Clientes WHERE ID != 1;";
            }
            else
            {
                sql = "SELECT * FROM Clientes WHERE ID != 1 AND nombre LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' ORDER BY nombre ASC;";
            }
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
        public DataTable Cargar_NombreClientes ()
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT ID, Nombre FROM Clientes WHERE ID != 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        public DataTable Buscar_NombreCliente(string dato)
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT ID, Nombre FROM Clientes WHERE Nombre LIKE '%"+ dato +"%' AND ID != 1;";
            
            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        /*
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, nombre, telefono, direccion, cedula FROM clientes ORDER BY nombre ASC";
            }
            else
            {
                sql = "SELECT id, nombre, telefono, direccion, cedula FROM clientes WHERE nombre LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' ORDER BY nombre ASC";
            }
            try
            {
                try
                {
                    MySqlConnection conexionBD = Conexion.getConexion();
                    conexionBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    reader = comando.ExecuteReader();
                    Console.WriteLine(reader);
                    while (reader.Read())
                    {
                        Cliente _cliente = new Cliente();
                        _cliente.Id = int.Parse(reader.GetString(0));
                        _cliente.Nombre = reader.GetString(1);
                        _cliente.Telefono = reader.GetString(2);
                        _cliente.Direccion = reader.GetString(3);
                        _cliente.Cedula = reader.GetString(4);

                        lista.Add(_cliente);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            catch (SqlNullValueException)
            {
                MessageBox.Show("Faltan Datos de Clientes por Completar", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return lista;
        }
        */

        public bool insertar(Cliente datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO clientes (nombre, telefono, direccion, cedula) VALUES ('" + datos.Nombre + "','" + datos.Telefono + "','" + datos.Direccion + "','" + datos.Cedula + "')";

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
        public bool actualizar(Cliente datos)
        {
            bool bandera = false;

            string sql = "UPDATE clientes SET nombre='" + datos.Nombre + "', telefono='" + datos.Telefono + "', direccion='" + datos.Direccion + "', cedula='" + datos.Cedula + "' WHERE id= '" + datos.Id + "'";

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

        public bool eliminar(int id)
        {
            bool bandera = false;

            string sql = "DELETE FROM clientes WHERE id= '" + id + "'";

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

        public int TotalClientes()
        {
            int total_clientes = 0;
            string SQL = "SELECT COUNT(*) FROM clientes WHERE ID != 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                total_clientes = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total_clientes = 0;
            }
            return total_clientes;
        }
    }
}
