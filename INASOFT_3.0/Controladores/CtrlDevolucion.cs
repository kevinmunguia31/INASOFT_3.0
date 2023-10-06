using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace INASOFT_3._0.Controladores
{
    class CtrlDevolucion
    {
        public DataTable Mostrar_Devolucion()
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT * FROM Mostrar_Devoluciones;";
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

        public DataTable Devoluciones_RangoFecha(string fecha_ini, string fecha_end)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "CALL Devoluciones_RangoFecha('"+ fecha_ini +"', '"+ fecha_end +"');";
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

        public DataTable Devoluciones_NombreCliente(string nombre)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "CALL Devoluciones_NombreCliente('" + nombre + "');";
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

        public DataTable Devoluciones_EstadoFact(string estado)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "CALL Devoluciones_EstadoFact('" + estado + "');";
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

        public DataTable DetalleDevolución(string idDevolucion)
        {
            DataTable dt = new DataTable();
            string sql;

            sql = "SELECT c.ID, c.Codigo AS 'Codigo', c.Nombre AS 'Nombre', c.Precio_Venta, b.Cantidad, (c.Precio_Venta * b.Cantidad) AS 'Total' FROM Devoluciones a INNER JOIN Detalle_Devolucion b ON a.ID = b.ID_Devolucion INNER JOIN Productos c ON c.ID = b.ID_Producto WHERE a.ID = " + idDevolucion + ";"; 
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

        public bool Agregar_Devolucion(Devolucion devolucion)
        {
            bool bandera = false;
            string sql = "CALL Agregar_Devolucion('"+ devolucion.Descripcion +"', "+ devolucion.Id_Factura +");";

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

        public bool Devolucion_productos(Devolucion devolucion)
        {
            bool bandera = false;
            
            string sql = "CALL Devolver_Productos("+ devolucion.Cantidad +", "+ devolucion.Id_devolucion +", "+ devolucion.Id_producto +", "+ devolucion.Id_Factura +");";

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

        public bool Actualizar_Factura(Devolucion devolucion)
        {
            bool bandera = false;
       
            string sql = "CALL Actualizar_facturacion("+ devolucion.Id_devolucion +", "+ devolucion.Id_Factura +");";

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

        public int ID_Devolucion()
        {
            int id_devolucion = 0;
            string SQL = "SELECT ID FROM Devoluciones ORDER BY ID DESC LIMIT 1;";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_devolucion = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_devolucion = 0;
            }
            return id_devolucion;
        }

        public string Desc_Devolucion(int id_devolucion)
        {
            string desc = "";
            string SQL = "SELECT Descripcion FROM Devoluciones WHERE ID = " + id_devolucion + ";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                desc = comando.ExecuteScalar().ToString();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                desc = "";
            }
            return desc;
        }

        public int ID_Devolucion(int id_factura)
        {
            int id_devolucion = 0;
            string SQL = "SELECT ID FROM Devoluciones WHERE ID_Factura = "+ id_factura +";";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(SQL, conexionDB);
                id_devolucion = Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                id_devolucion = 0;
            }
            return id_devolucion;
        }

        public int Verificar_Devolucion(int ID_Factura)
        {
            int bandera = 0;
            string SQL = "CALL Verificar_Devolucion(" + ID_Factura + ");";

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
                bandera = 3;
            }
            return bandera;
        }
    }
}
