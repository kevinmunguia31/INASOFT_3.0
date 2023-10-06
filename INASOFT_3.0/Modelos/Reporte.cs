using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    public class Reporte
    {
        private string fecha;
        private string nombre;
        private int canitdad;
        private double ganancias;
        private string ganancias_string;

        public string Fecha { get => fecha; set => fecha = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Canitdad { get => canitdad; set => canitdad = value; }
        public double Ganancias { get => ganancias; set => ganancias = value; }
        public string Ganancias_string { get => ganancias_string; set => ganancias_string = value; }
    }
}
