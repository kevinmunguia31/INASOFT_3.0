using INASOFT_3._0.Modelos;
using INASOFT_3._0.Controladores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace INASOFT_3._0.Controladores
{
    class CtrlProductos
    {
        public DataTable CargarProductos(string dato)
        {
            DataTable dt = new DataTable();
            string sql;

            if (dato == "")
            {
                sql = "SELECT * FROM Mostrar_Producto";
            }
            else
            {
                sql = "SELECT * FROM Mostrar_Producto WHERE Código LIKE '"+dato+"%' OR Producto LIKE '"+dato+"%' ORDER BY Código ASC;";
            }

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

        public bool Insertar(Productos datos)
        {
            bool bandera = false;
            string sql = "CALL Insertar_Producto('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Existencias + "','" + datos.Precio_compra + "', '" + datos.Precio_venta + "', '" + datos.Observacion + "', '" + datos.Id_proveedor + "')";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            try
            { 
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

        public bool Actualizar(Productos datos)
        {
            bool bandera = false;
            string sql = "CALL Actualizar_Producto('" + datos.Id + "', '" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Existencias + "','" + datos.Precio_compra + "', '" + datos.Precio_venta + "', '" + datos.Observacion + "', '" + datos.Id_proveedor + "')";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            try
            {
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
            string sql = "DELETE FROM Productos WHERE ID = '" + id + "'";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            try
            {
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

        public DataTable Cargar_NombreProducto()
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT ID, Nombre FROM Productos;";

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

        public DataTable Buscar_NombreProducto(string dato)
        {
            DataTable dt = new DataTable();
            string SQL = "SELECT * FROM Productos WHERE Nombre LIKE '%" + dato + "%' OR Codigo LIKE '%" + dato + "%'";

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
        public string Nombre_Producto(int id)
        {
            string nombre_producto = "";
            string SQL = "SELECT Nombre FROM Productos WHERE ID = "+ id +";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                nombre_producto = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                nombre_producto = "";
            }
            return nombre_producto;
        }

        public double Precio_Producto(int id)
        {
            double precio_producto = 0.00;
            string SQL = "SELECT Precio_Venta FROM Productos WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                precio_producto = Convert.ToDouble(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                precio_producto = 0.00;
            }
            return precio_producto;
        }

        public double Precio_Compra(int id)
        {
            double precio_producto = 0.00;
            string SQL = "SELECT Precio_Compra FROM Productos WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                precio_producto = Convert.ToDouble(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                precio_producto = 0.00;
            }
            return precio_producto;
        }

        public string Codigo_Producto(int id)
        {
            string codigo = "";
            string SQL = "SELECT Codigo FROM Productos WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                codigo = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                codigo = "";
            }
            return codigo;
        }

        public int Existencias_Producto(int id)
        {
            int existencia_producto = 0;
            string SQL = "SELECT Existencias FROM Productos WHERE ID = " + id + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                existencia_producto = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                existencia_producto = 0;
            }
            return existencia_producto;
        }

        public string CapitalInvertido()
        {
            string capital = "";
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;
            string SQL = "SELECT ROUND(SUM(precio_total), 2) FROM productos";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                double d = Convert.ToInt32(comando.ExecuteScalar());
                capital = d.ToString("C", culturaLocal);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                capital = "";
            }
            return capital;
        }

        public string TotalProductos()
        {
            string total = "";
            string SQL = "SELECT count(*) FROM productos";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                double aux = Convert.ToInt32(comando.ExecuteScalar());
                total = aux.ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                total = "";
            }
            return total;
        }
    }
}
