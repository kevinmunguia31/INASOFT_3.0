using INASOFT_3._0.Modelos;
using INASOFT_3._0.Controladores;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Controladores
{
    class CtrlProductos
    {
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT id, codigo, nombre, existencias, precio_compra, precio_venta," +
                 " precio_total, observacion, id_proveedor FROM productos ORDER BY nombre ASC";
                //sql = "SELECT a.ID, a.Codigo, a.Nombre, a.Existencias, a.Precio_Compra, a.Precio_Venta, a.Precio_Dolar, a.Precio_Total, a.Observacion, b.Nombre FROM Productos a INNER JOIN Proveedor b ON a.ID_Proveedor = b.ID  ORDER BY a.nombre ASC";
            }
            else
            {
                sql = "SELECT id, codigo, nombre, existencias, precio_compra, precio_venta," +
                     "precio_total, observacion, id_proveedor " +
                     "FROM productos WHERE codigo LIKE '%" + dato + "%' OR nombre LIKE '%" + dato + "%' ORDER BY nombre ASC";
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
                    Productos _producto = new Productos();
                    _producto.Id = int.Parse(reader.GetString(0));
                    _producto.Codigo = reader.GetString(1);
                    _producto.Nombre = reader.GetString(2);
                    _producto.Existencias = int.Parse(reader.GetString(3));
                    _producto.Precio_compra = double.Parse(reader.GetString(4));
                    _producto.Precio_venta = double.Parse(reader.GetString(5));
                    _producto.Precio_total = double.Parse(reader.GetString(6));
                    _producto.Observacion = reader.GetString(7);
                    _producto.Id_proveedor = int.Parse(reader.GetString(8));

                    lista.Add(_producto);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }

        public bool insertar(Productos datos)
        {
            bool bandera = false;

            //string sql = "INSERT INTO productos (codigo, nombre, existencias, precio_unidad, precio_dolar, precio_total, observacion) VALUES ('" + datos.Codigo + "','" + datos.Nombre + "','" + datos.Existencias + "','" + datos.Precio_unidad + "', '" + datos.Precio_dolar + "', '" + datos.Precio_total + "', '" + datos.Observacion + "')";

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

            string sql = "DELETE FROM productos WHERE id= '" + id + "'";

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
