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
                sql = "SELECT * FROM Clientes WHERE ID != 1 AND Nombre LIKE '%"+ dato +"%' ORDER BY Nombre ASC;";
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

        public bool Insertar(Cliente datos)
        {
            bool bandera = false;
            string sql = "INSERT INTO Clientes (Nombre, Telefono, Direccion, Cedula) VALUES ('" + datos.Nombre + "','" + datos.Telefono + "','" + datos.Direccion + "','" + datos.Cedula + "')";
            
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

        public bool Actualizar(Cliente datos)
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

        public bool Eliminar(int id)
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

        public bool Insertar_NombreCliente(string nombre)
        {
            bool bandera = false;
            string sql = "INSERT INTO Clientes(Nombre, Telefono, Direccion, Cedula) VALUES('"+ nombre +"','Ninguno', 'Ninguno', 'Ninguno')";

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

        public string Nombre_Cliente(int id)
        {
            string nombreCliente = "";
            string SQL = "SELECT Nombre FROM Clientes WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                nombreCliente = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                nombreCliente = "";
            }
            return nombreCliente;
        }

        public string Cedula_Cliente(int id)
        {
            string cedulaCliente = "";
            string SQL = "SELECT Cedula FROM Clientes WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                cedulaCliente = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                cedulaCliente = "";
            }
            return cedulaCliente;
        }

        public string Telefono_Cliente(int id)
        {
            string telefonoCliente = "";
            string SQL = "SELECT Telefono FROM Clientes WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                telefonoCliente = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                telefonoCliente = "";
            }
            return telefonoCliente;
        }

        public string Direccion_Cliente(int id)
        {
            string direccionCliente = "";
            string SQL = "SELECT Direccion FROM Clientes WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                direccionCliente = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                direccionCliente = "";
            }
            return direccionCliente;
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
