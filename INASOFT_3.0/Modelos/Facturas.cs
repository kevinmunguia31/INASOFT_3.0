        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    public class Facturas
    {
		private int id;
		private int codigo_Fac;
		private string estado;
		private string fecha;
		private double descuento;
		private double subtotal;
		private double total;
		private double efectivo;
		private double devolucion;
		private double debe;
		private string tipo_Factura;
		private int id_Usuario;
		private int id_Cliente;
		private int id_TipoPago;
		private int cantidad;
        private double precio;
        private string detalle_Descuento;
        private string descripcion;
        private string descripcionPrecio;
		private int id_Factura;
		private int id_Producto;

        public int Id { get => id; set => id = value; }
        public int Codigo_Fac { get => codigo_Fac; set => codigo_Fac = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Total { get => total; set => total = value; }
        public double Efectivo { get => efectivo; set => efectivo = value; }
        public double Devolucion { get => devolucion; set => devolucion = value; }
        public double Debe { get => debe; set => debe = value; }
        public string Tipo_Factura { get => tipo_Factura; set => tipo_Factura = value; }
        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public int Id_TipoPago { get => id_TipoPago; set => id_TipoPago = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_Factura { get => id_Factura; set => id_Factura = value; }
        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Detalle_Descuento { get => detalle_Descuento; set => detalle_Descuento = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string DescripcionPrecio { get => descripcionPrecio; set => descripcionPrecio = value; }
    }
}
