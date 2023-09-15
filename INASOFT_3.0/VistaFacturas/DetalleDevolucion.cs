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
            Txt_Devolucion.Text = id_devolucion;
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            txtDescripcion.Text = ctrlDevolucion.Desc_Devolucion(int.Parse(id_devolucion));
            CargarDetalleDevolucion();

            foreach (DataGridViewBand band in datagridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }
        public void CargarDetalleDevolucion()
        {
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            datagridView1.DataSource = ctrlDevolucion.DetalleDevolución(Txt_Devolucion.Text);
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void DatagridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int pos = datagridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1 && pos != null)
                {
                    if (GroupB_Detalle.Text == datagridView1.Rows[pos].Cells[0].Value.ToString())
                    {
                        MessageBoxError.Show("Ya estás trabajando con esté producto");
                    }
                    else
                    {
                        GroupB_Detalle.Text = datagridView1.Rows[pos].Cells[1].Value.ToString();
                        int limite = 25;
                        if (GroupB_Detalle.Text.Length > limite)
                        {
                            GroupB_Detalle.Text = "Detalle de " + GroupB_Detalle.Text.Substring(0, limite) + "...";
                        }
                        else
                        {
                            GroupB_Detalle.Text = "Detalle de " + GroupB_Detalle.Text;
                        }
                        lbCodProdu.Text = datagridView1.Rows[pos].Cells[0].Value.ToString();
                        lbExistencias.Text = datagridView1.Rows[pos].Cells[3].Value.ToString();
                        //GroupB_Detalle.Text = datagridView1.Rows[pos].Cells[1].Value.ToString();
                    }
                }
            }
        }
    }
}
