﻿using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.awt.geom.Point2D;

namespace INASOFT_3._0.Modelos
{
    internal class Compras
    {
		private int id;
		private string fehca;
        private string nombre_venderdor;
		private string descripcion;
        private string estado;
		private double subtotal;
        private double descuento;
        private double iva;
		private double total;		
		private int id_usuario;
		private int id_proveedor;
        private int id_tipoPago;

        public int Id { get => id; set => id = value; }
        public string Fehca { get => fehca; set => fehca = value; }
        public string Nombre_venderdor { get => nombre_venderdor; set => nombre_venderdor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Descuento { get => descuento; set => descuento = value; }
        public double Total { get => total; set => total = value; }
        public int Id_TipoPago { get => id_tipoPago; set => id_tipoPago = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public double Iva { get => iva; set => iva = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
