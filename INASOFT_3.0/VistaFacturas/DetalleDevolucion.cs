using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class DetalleDevolucion : Form
    {
        public DetalleDevolucion(string id_devolucion)
        {
            InitializeComponent();
            CargarDatosIniciales(id_devolucion);
            CargarDetalleDevolucion();
        }

        private void CargarDatosIniciales(string id_devolucion)
        {
            Txt_Devolucion.Text = id_devolucion;
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            txtDescripcion.Text = ctrlDevolucion.Desc_Devolucion(int.Parse(id_devolucion));
        }

        public void CargarDetalleDevolucion()
        {
            foreach (DataGridViewBand band in datagridView1.Columns)
            {
                band.ReadOnly = true;
            }

            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            datagridView1.DataSource = ctrlDevolucion.DetalleDevolución(Txt_Devolucion.Text);
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void datagridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int rowIndex = datagridView1.HitTest(e.X, e.Y).RowIndex;

                if (rowIndex >= 0)
                {
                    string selectedProductName = datagridView1.Rows[rowIndex].Cells[2].Value.ToString();

                    if (GroupB_Detalle.Text == selectedProductName)
                    {
                        MessageBoxError.Show("Ya estás trabajando con este producto");
                    }
                    else
                    {
                        GroupB_Detalle.Text = "Detalle de " + selectedProductName.Substring(0, Math.Min(selectedProductName.Length, 25)) + "...";
                        lbCodProdu.Text = datagridView1.Rows[rowIndex].Cells[1].Value.ToString();
                        lbExistencias.Text = datagridView1.Rows[rowIndex].Cells[4].Value.ToString();
                    }
                }
            }
        }
    }
}
