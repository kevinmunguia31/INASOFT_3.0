        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    public class Detalle_Factura
    {
        int id;
        int cantidad;
        double precio;
        string codigo_producto;
        string nombre_producto;
        int id_factura;
        double total;

        public int Id { get => id; set => id = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
        public string Codigo_producto { get => codigo_producto; set => codigo_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public double Total { get => total; set => total = value; }
    }
}
