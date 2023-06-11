        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    class Detalle_Factura
    {
        int id;
        int cantidad;
        double precio;
        int id_producto;
        int id_factura;

        public int Id { get => id; set => id = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_factura { get => id_factura; set => id_factura = value; }
    }
}
