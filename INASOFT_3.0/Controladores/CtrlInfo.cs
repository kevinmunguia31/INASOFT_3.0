using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.Controladores
{
    class CtrlInfo
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            try
            {
                string sql ="";
                if (dato == null)
                {
                    sql = "SELECT idinfogeneral, nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono FROM infogeneral";
                }
                MySqlConnection conexionBD = Conexion.getConexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                //Console.WriteLine(reader);
                while (reader.Read())
                {
                    InfoNegocio _infoNegocio = new InfoNegocio();
                    _infoNegocio.Id = int.Parse(reader.GetString(0));
                    _infoNegocio.Nombre = reader.GetString(1);
                    _infoNegocio.Telefono = reader.GetString(5);
                    _infoNegocio.Direccion = reader.GetString(2);
                    _infoNegocio.NumRUC = reader.GetString(3);
                    _infoNegocio.NombreAdmin = reader.GetString(4);

                    lista.Add(_infoNegocio);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }
        public bool Insertar(InfoNegocio datos)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "INSERT INTO infogeneral (nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono) VALUES (@Nombre, @Direccion, @NumRUC, @NombreAdmin, @Telefono)";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Nombre", datos.Nombre);
                comando.Parameters.AddWithValue("@Direccion", datos.Direccion);
                comando.Parameters.AddWithValue("@NumRUC", datos.NumRUC);
                comando.Parameters.AddWithValue("@NombreAdmin", datos.NombreAdmin);
                comando.Parameters.AddWithValue("@Telefono", datos.Telefono);

                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                bandera = false;
            }

            return bandera;
        }

        public bool Actualizar(InfoNegocio datos)
        {
            bool bandera = false;

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();

                string sql = "UPDATE infogeneral SET nombre_negocio=@Nombre, direccion_negocio=@Direccion, num_ruc=@NumRUC, nombre_admin=@NombreAdmin, telefono=@Telefono WHERE idinfogeneral=@Id";

                MySqlCommand comando = new MySqlCommand(sql, conexioBD);

                // Agregar parámetros
                comando.Parameters.AddWithValue("@Nombre", datos.Nombre);
                comando.Parameters.AddWithValue("@Direccion", datos.Direccion);
                comando.Parameters.AddWithValue("@NumRUC", datos.NumRUC);
                comando.Parameters.AddWithValue("@NombreAdmin", datos.NombreAdmin);
                comando.Parameters.AddWithValue("@Telefono", datos.Telefono);
                comando.Parameters.AddWithValue("@Id", datos.Id);

                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                bandera = false;
            }

            return bandera;
        }

        public bool InsertarLog(string fecha, string desc)
        {
            bool bandera = false;

            string sql = "INSERT INTO logs (fecha,descripcion) VALUES ('" + fecha + "', '" + desc + "')";
             
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
                MessageBox.Show(ex.Message.ToString());
                bandera = false;
            }

            return bandera;
        }

        public DataTable BuscarLogs(string dato)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT fecha, descripcion FROM logs WHERE DATE_FORMAT(Fecha, '%Y/%m/%d') = '" + dato + "';";

            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
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

        /* public bool eliminar(int id)
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
         }*/
    }
}
