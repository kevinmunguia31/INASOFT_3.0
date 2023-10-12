using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    class Productos
    {
        private int id;
        private string codigo;
        private string nombre;
        private string estado;
        private int existencias;
        private int existencias_min;
        private double precio_compra;
        private double precio_venta;
        private double precio_total;
        private string observacion;
        private int id_proveedor;
        private int id_compra;
        private int id_remision;
        private string nombre_proveedor;


        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Existencias { get => existencias; set => existencias = value; }
        public double Precio_compra { get => precio_compra; set => precio_compra = value; }
        public double Precio_venta { get => precio_venta; set => precio_venta = value; }
        public double Precio_total { get => precio_total; set => precio_total = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string Nombre_proveedor { get => nombre_proveedor; set => nombre_proveedor = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Existencias_min { get => existencias_min; set => existencias_min = value; }
        public int Id_Compra { get => id_compra; set => id_compra = value; }
        public int Id_remision { get => id_remision; set => id_remision = value; }
    }
}
