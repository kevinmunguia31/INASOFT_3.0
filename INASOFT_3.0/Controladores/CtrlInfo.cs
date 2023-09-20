using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        public bool insertar(InfoNegocio datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO infogeneral (nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono) VALUES ('" + datos.Nombre + "','" + datos.Direccion + "','" + datos.NumRUC + "','" + datos.NombreAdmin + "','" + datos.Telefono + "')";

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
        public bool actualizar(InfoNegocio datos)
        {
            bool bandera = false;

            string sql = "UPDATE infogeneral SET nombre_negocio='" + datos.Nombre + "', direccion_negocio='" + datos.Direccion + "', num_ruc='" + datos.NumRUC + "', nombre_admin='" + datos.NombreAdmin + "', telefono='" + datos.Telefono + "' WHERE idinfogeneral= '" + datos.Id + "'";

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

        public bool InsertarLog(string desc)
        {
            bool bandera = false;

            string sql = "INSERT INTO logs (descripcion) VALUES ('" + desc + "')";

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
