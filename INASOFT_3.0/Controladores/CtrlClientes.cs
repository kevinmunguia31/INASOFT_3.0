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

            try
            {
                using (MySqlConnection conexionBD = Conexion.getConexion())
                {
                    conexionBD.Open();
                    if (string.IsNullOrEmpty(dato))
                    {
                        sql = "SELECT * FROM Clientes WHERE ID != 1;";
                    }
                    else
                    {
                        sql = "SELECT * FROM Clientes WHERE ID != 1 AND Nombre LIKE @dato ORDER BY Nombre ASC;";
                    }

                    using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                    {
                        if (!string.IsNullOrEmpty(dato))
                        {
                            comando.Parameters.AddWithValue("@dato", "%" + dato + "%");
                        }

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            adaptador.Fill(dt);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public bool Insertar(Cliente datos)
        {
            bool bandera = false;

            using (MySqlConnection conexioBD = Conexion.getConexion())
            {
                try
                {
                    conexioBD.Open();
                    string sql = "INSERT INTO Clientes (Nombre, Telefono, Direccion, Cedula) VALUES (@Nombre, @Telefono, @Direccion, @Cedula)";
                    MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                    // Agregar parámetros
                    comando.Parameters.AddWithValue("@Nombre", datos.Nombre);
                    comando.Parameters.AddWithValue("@Telefono", datos.Telefono);
                    comando.Parameters.AddWithValue("@Direccion", datos.Direccion);
                    comando.Parameters.AddWithValue("@Cedula", datos.Cedula);

                    comando.ExecuteNonQuery();
                    bandera = true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    bandera = false;
                }
            }
            return bandera;
        }

        public bool Actualizar(Cliente datos)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "UPDATE clientes SET nombre = @Nombre, telefono = @Telefono, direccion = @Direccion, cedula = @Cedula WHERE id = @Id";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Nombre", datos.Nombre);
                comando.Parameters.AddWithValue("@Telefono", datos.Telefono);
                comando.Parameters.AddWithValue("@Direccion", datos.Direccion);
                comando.Parameters.AddWithValue("@Cedula", datos.Cedula);
                comando.Parameters.AddWithValue("@Id", datos.Id);

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

        public bool Eliminar(int id)
        {
            bool bandera = false;
            string sql = "CALL Eliminarcliente(" + id + ");";

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


        public DataTable Buscar_NombreCliente(string dato)
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT * FROM Clientes WHERE ID !=1 AND Nombre LIKE '%" + dato + "%' OR Cedula LIKE '%" + dato + "%'";

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

        public bool Insertar_NombreCedulaCliente(Cliente cliente)
        {
            using (MySqlConnection conexioBD = Conexion.getConexion())
            {
                string sql = "INSERT INTO Clientes (Nombre, Telefono, Direccion, Cedula) VALUES (@Nombre, 'Ninguno', 'Ninguno', @Cedula)";
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);

                try
                {
                    conexioBD.Open();
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public DataTable Cargar_NombreClientes()
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT ID, Nombre FROM Clientes WHERE ID != 1 ORDER BY ID DESC;";

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

        public Cliente MostrarDatosClientes(int id)
        {
            Cliente cliente = null; // Inicializamos producto como nulo
            string sql = "SELECT Nombre, Telefono, Direccion, Cedula FROM Clientes WHERE ID = " + id + " LIMIT 1;";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente()
                        {
                            Nombre = reader[0].ToString(),
                            Telefono = reader[1].ToString(),
                            Direccion = reader[2].ToString(),
                            Cedula = reader[3].ToString()
                        };
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conexionBD.Close();
            }
            return cliente; // Retornamos un solo objeto en lugar de una lista
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
