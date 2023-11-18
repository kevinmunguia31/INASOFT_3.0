using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace INASOFT_3._0.Modelos
{
    public class Credito
    {
        private string dia_Inicio;
        private string dia_Vencimiento;
        private double cargo;
        private string estado;
        private string descripcion;
        private int id_Factura;
        private int id_Cliente;
        private int id_TipoPago;
        private double monto;
        private string fecha;
        private double saldo_Anterior;
        private double saldo_Nuevo;
        private string descripcion_Abono;
        private int id_Credito;

        public string Dia_Inicio { get => dia_Inicio; set => dia_Inicio = value; }
        public string Dia_Vencimiento { get => dia_Vencimiento; set => dia_Vencimiento = value; }
        public double Cargo { get => cargo; set => cargo = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Id_Factura { get => id_Factura; set => id_Factura = value; }
        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public int Id_TipoPago { get => id_TipoPago; set => id_TipoPago = value; }
        public double Monto { get => monto; set => monto = value; }
        public double Saldo_Anterior { get => saldo_Anterior; set => saldo_Anterior = value; }
        public double Saldo_Nuevo { get => saldo_Nuevo; set => saldo_Nuevo = value; }
        public int Id_Credito { get => id_Credito; set => id_Credito = value; }
        public string Descripcion_Abono { get => descripcion_Abono; set => descripcion_Abono = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
