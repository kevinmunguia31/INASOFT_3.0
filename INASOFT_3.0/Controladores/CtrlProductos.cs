using INASOFT_3._0.Modelos;
using INASOFT_3._0.Controladores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace INASOFT_3._0.Controladores
{
    class CtrlProductos
    {
        public DataTable CargarProductos(string dato)
        {
            DataTable dt = new DataTable();
            string sql;

            if (dato == null)
            {
                sql = "SELECT * FROM Mostrar_Producto";
                //sql = "SELECT a.ID, a.Codigo, a.Nombre, a.Existencias, a.Precio_Compra, a.Precio_Venta, a.Precio_Total, a.Observacion, b.Nombre FROM Productos a INNER JOIN Proveedor b ON a.ID_Proveedor = b.ID ORDER BY a.Nombre ASC";
            }
            else
            {
                sql = "SELECT * FROM Mostrar_Producto WHERE Codigo LIKE '%" + dato + "%' OR Producto LIKE '%" + dato + "%' ORDER BY Producto ASC;";
                //sql = "SELECT a.ID, a.Codigo, a.Nombre, a.Existencias, a.Precio_Compra, a.Precio_Venta, a.Precio_Total, a.Observacion, b.Nombre FROM Productos a INNER JOIN Proveedor b ON a.ID_Proveedor = b.ID WHERE a.Codigo LIKE '%" + dato + "%' OR a.Nombre LIKE '%" + dato + "%' ORDER BY a.Nombre ASC";
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

        public bool insertar(Productos datos)
        {
            bool bandera = false;
            string sql = "CALL Insertar_Producto('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Existencias + "','" + datos.Precio_compra + "', '" + datos.Precio_venta + "', '" + datos.Observacion + "', '" + datos.Id_proveedor + "')";

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

        public bool VerificarCodigo(int codigo)
        {
            bool bandera = false;
            string SQL = "SELECT * FROM Productos WHERE Codigo = '"+ codigo +"';";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                //total_clientes = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //total_clientes = 0;
            }
            return bandera;
        }

        public bool actualizar(Productos datos)
        {
            bool bandera = false;

            //string sql = "UPDATE productos SET codigo='" + datos.Codigo + "', nombre='" + datos.Nombre + "', existencias='" + datos.Existencias + "', precio_compra='" + datos.Precio_compra + "', precio_venta='" + datos.Precio_venta + "', precio_dolar='" + datos.Precio_dolar + "', observacion='" + datos.Observacion + "' WHERE id= '" + datos.Id + "'";
            //string sql = "CALL Actualizar_Producto('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Existencias + "','" + datos.Precio_compra + "', '" + datos.Precio_venta + "', '" + datos.Precio_dolar + "', '" + datos.Observacion + "', '" + datos.Id_proveedor + "')";
            string sql = "CALL Actualizar_Producto('" + datos.Id + "', '" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Existencias + "','" + datos.Precio_compra + "', '" + datos.Precio_venta + "', '" + datos.Observacion + "', '" + datos.Id_proveedor + "')";

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

            string sql = "DELETE FROM Productos WHERE ID = '" + id + "'";

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
