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
    class CtrlProveedor
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT ID, Nombre, Telefono, Direccion, RUC FROM Proveedor WHERE ID != 1 ORDER BY ID ASC";
            }
            else
            {
                sql = "SELECT ID, Nombre, Telefono, Direccion, RUC FROM Proveedor WHERE ID != 1 AND Nombre LIKE '%" + dato + "%' ORDER BY ID ASC";
            }
            try
            {
                MySqlConnection conexionBD = Conexion.getConexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                Console.WriteLine(reader);
                while (reader.Read())
                {
                    Proveedor _proveedor = new Proveedor();
                    _proveedor.Id = int.Parse(reader.GetString(0));
                    _proveedor.Nombre = reader.GetString(1);
                    _proveedor.Telefono = reader.GetString(2);
                    _proveedor.Direccion = reader.GetString(3);
                    _proveedor.Ruc = reader.GetString(4);

                    lista.Add(_proveedor);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        public bool insertar(Proveedor datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO Proveedor (Nombre, Telefono, Direccion, RUC) VALUES ('" + datos.Nombre + "','" + datos.Telefono + "','" + datos.Direccion + "','" + datos.Ruc + "')";

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
        public bool actualizar(Proveedor datos)
        {
            bool bandera = false;

            string sql = "UPDATE Proveedor SET Nombre='" + datos.Nombre + "', Telefono='" + datos.Telefono + "', Direccion='" + datos.Direccion + "', RUC ='" + datos.Ruc + "' WHERE id= '" + datos.Id + "'";

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

            string sql = "DELETE FROM Proveedor WHERE ID= '" + id + "'";

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

        public DataTable CargarProveddores()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT id, nombre FROM proveedor WHERE ID != 1 ORDER BY nombre ASC";
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

        public string RUC(int id)
        {
            string ruc = "";
            string SQL = "SELECT RUC FROM Proveedor WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                ruc = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                ruc = "";
            }
            return ruc;
        }
    }
}
