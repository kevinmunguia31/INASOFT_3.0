using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.awt.geom.Point2D;

namespace INASOFT_3._0.Modelos
{
    internal class Detalle_Compras
    {
		private int id;
		private string cod_producto;
        private string nombre_producto;
        private double cantidad;
		private double precio_compra;
		private double iva;
		private double descuento;
		private double total;
		private int id_compra;

        public int Id { get => id; set => id = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio_compra { get => precio_compra; set => precio_compra = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Total { get => total; set => total = value; }
        public int Id_compra { get => id_compra; set => id_compra = value; }
    }
}
