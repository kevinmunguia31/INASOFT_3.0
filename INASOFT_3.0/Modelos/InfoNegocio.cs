using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    class InfoNegocio
    {
        public static int id;
        public static string nombre;
        public static string direccion;
        public static string numRUC;
        public static string nombreAdmin;
        public static string telefono;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string NumRUC { get => numRUC; set => numRUC = value; }
        public string NombreAdmin { get => nombreAdmin; set => nombreAdmin = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public static implicit operator InfoNegocio(Proveedor v)
        {
            throw new NotImplementedException();
        }
    }
}
