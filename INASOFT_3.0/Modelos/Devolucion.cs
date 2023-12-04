using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    public class Devolucion
    {
		private int id;
		private string fecha;
		private string descripcion;
		private int id_Factura;
		private double cantidad;
		private int id_devolucion;
		private int id_producto;

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Id_Factura { get => id_Factura; set => id_Factura = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_devolucion { get => id_devolucion; set => id_devolucion = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
    }
}
