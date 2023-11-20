﻿using System;
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
        private string tipo_Remision;
        private string nombreProducto;
        private int id_Producto;
        private int id_Entrada;
        private int id_Usuario;

        public int Id { get => id; set => id = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public int Id_Entrada { get => id_Entrada; set => id_Entrada = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tipo_Remision { get => tipo_Remision; set => tipo_Remision = value; }
        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
    }
}
