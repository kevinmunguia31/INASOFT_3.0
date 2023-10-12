using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    public class Remision
    {
        private int id;
        private int cantidad;
        private string fecha;
        private string descripcion;
        private int id_Producto;
        private int id_Entrada;

        public int Id { get => id; set => id = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public int Id_Entrada { get => id_Entrada; set => id_Entrada = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
