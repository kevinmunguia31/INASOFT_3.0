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
       
        public bool insertar(InfoNegocio datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO infogeneral (nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono, logoNegocio) VALUES ('" + datos.Nombre + "','" + datos.Direccion + "','" + datos.NumRUC + "','" + datos.NombreAdmin + "','" + datos.Telefono + "', '"+ datos.Imagen + "')";

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

            string sql = "UPDATE infogeneral SET nombre_negocio='" + datos.Nombre + "', direccion_negocio='" + datos.Direccion + "', num_ruc='" + datos.NumRUC + "', nombre_admin='" + datos.NombreAdmin + "', telefono='" + datos.Telefono + "', logoNegocio='" + datos.Imagen + "' WHERE idinfogeneral= '" + datos.Id + "'";

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
