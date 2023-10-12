using INASOFT_3._0.Modelos;
using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Reportes : UserControl
    {
        public UC_Reportes()
        {
            InitializeComponent();
            CargarReporteGanancias(4);
            CargarReporteProductoMasVendidos(4);
            CargarReporteProductoMenosVendidos(4);
            ObtenerMovimientosProductos(4);
            CargarReporteProductoMasCaros();
            CargarReporteProductosActivoNoActivo();
            CargarReporteProductosCambioPrecio();

            GraficaGananciasUltimos6Dias();
            GraficaRangoFecha();
            GraficaGProductosMasVendidos();
            GraficaGProductosMenosVendidos();
            GraficasProductoBajoInventario();            
            InicarDatosGanancias();
        }
        public void CargarReporteGanancias(int dato)
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dgvUnderstock.DataSource = ctrl.CargarReporteGanancias(dato);
        }

        public void CargarReporteProductoMasVendidos(int dato)
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dataGridView1.DataSource = ctrl.CargarReporteProductosMasVendidos(dato);
        }

        public void CargarReporteProductoMenosVendidos(int dato)
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dataGridView4.DataSource = ctrl.CargarReporteProductosMenosVendidos(dato);
        }
        public void CargarReporteProductoMasCaros()
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dataGridView5.DataSource = ctrl.CargarProductosNoVendidos();
        }

        public void CargarReporteProductosActivoNoActivo()
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dataGridView2.DataSource = ctrl.CargarProductosActivoNoActivo();
        }

        public void CargarReporteProductosCambioPrecio()
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dataGridView6.DataSource = ctrl.CargarProductosCambioPrecio();
        }

        public void ObtenerMovimientosProductos(int dato)
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            dataGridView3.DataSource = ctrl.HistorialTrasacciones();
        }
        public void InicarDatosGanancias()
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            Lb_CantFactPendiente.Text = ctrl.CantFactPendiente();
            Lb_DineroPendiente.Text = ctrl.CantPendienteFactCredito();
            Lb_TotalGanancias.Text = ctrl.TotalGanancias();
        }
        public void GraficaGananciasUltimos6Dias()
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            List<Reporte> ganancias = ctrl.CargarGananciasDe6UltimosDias();

            ArrayList fechas = new ArrayList();
            ArrayList Ganancias = new ArrayList();

            foreach (Reporte ganancia in ganancias)
            {
                fechas.Add(ganancia.Fecha);
                Ganancias.Add(ganancia.Ganancias);
            }

            chartTopProducts.Series[0].Points.DataBindXY(fechas, Ganancias);
        }
        
        public void GraficaRangoFecha()
        {
            ArrayList nombreProducto = new ArrayList();
            ArrayList cantidad = new ArrayList();
            foreach (DataGridViewRow fila in dgvUnderstock.Rows)
            {
                nombreProducto.Add(fila.Cells[0].Value);
                cantidad.Add(fila.Cells[1].Value);
            }
            chart1.Series[0].Points.DataBindXY(nombreProducto, cantidad);
        }

        public void GraficasProductoBajoInventario()
        {
            Controladores.CtrlReporteGraficos ctrl = new Controladores.CtrlReporteGraficos();
            List<Reporte> ganancias = ctrl.CargarProductosBajoInventario();

            ArrayList nombre = new ArrayList();
            ArrayList cantidad = new ArrayList();

            foreach (Reporte ganancia in ganancias)
            {
                nombre.Add(ganancia.Nombre);
                cantidad.Add(ganancia.Canitdad);
            }

            chart5.Series[0].Points.DataBindXY(nombre, cantidad);
        }
        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            CargarReporteGanancias(1);
            GraficaRangoFecha();
        }
        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            CargarReporteGanancias(2);
            GraficaRangoFecha();
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            CargarReporteGanancias(3);
            GraficaRangoFecha();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            CargarReporteGanancias(4);
            GraficaRangoFecha();
        }


        // Productos más y menos vendidos
        public void GraficaGProductosMasVendidos()
        {
            ArrayList nombreProducto = new ArrayList();
            ArrayList cantidad = new ArrayList();
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                nombreProducto.Add(fila.Cells[0].Value);
                cantidad.Add(fila.Cells[1].Value);
            }
            chart2.Series[0].Points.DataBindXY(nombreProducto, cantidad);
        }


        public void GraficaGProductosMenosVendidos()
        {
            ArrayList nombreProducto = new ArrayList();
            ArrayList cantidad = new ArrayList();
            foreach (DataGridViewRow fila in dataGridView4.Rows)
            {
                nombreProducto.Add(fila.Cells[0].Value);
                cantidad.Add(fila.Cells[1].Value);
            }
            chart8.Series[0].Points.DataBindXY(nombreProducto, cantidad);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CargarReporteProductoMasVendidos(4);
            CargarReporteProductoMenosVendidos(4);
            GraficaGProductosMasVendidos();
            GraficaGProductosMenosVendidos();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            CargarReporteProductoMasVendidos(3);
            CargarReporteProductoMenosVendidos(3);
            GraficaGProductosMasVendidos();
            GraficaGProductosMenosVendidos();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            CargarReporteProductoMasVendidos(2);
            CargarReporteProductoMenosVendidos(2);
            GraficaGProductosMasVendidos();
            GraficaGProductosMenosVendidos();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            CargarReporteProductoMasVendidos(1);
            CargarReporteProductoMenosVendidos(1);
            GraficaGProductosMasVendidos();
            GraficaGProductosMenosVendidos();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            ObtenerMovimientosProductos(4);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ObtenerMovimientosProductos(3);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ObtenerMovimientosProductos(2);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            ObtenerMovimientosProductos(1);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrlReporte = new Controladores.CtrlReporte();
            ctrlReporte.ReporteGanancias(dgvUnderstock);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrlReporte = new Controladores.CtrlReporte();
            ctrlReporte.ReporteProductosMasMenosVendidos(dataGridView1, dataGridView4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrlReporte = new Controladores.CtrlReporte();
            ctrlReporte.ReporteKardexInventario(dataGridView2, dataGridView6, dataGridView5);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrlReporte = new Controladores.CtrlReporte();
            ctrlReporte.ReporteSalidasEntradas(dataGridView3);
        }
    }
}
