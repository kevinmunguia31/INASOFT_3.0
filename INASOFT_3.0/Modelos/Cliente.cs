﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string telefono;
        private string direccion;
        private string cedula;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }
}
