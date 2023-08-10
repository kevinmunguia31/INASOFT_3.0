using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INASOFT_3._0.VistaFacturas;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Devoluciones : UserControl
    {
        public UC_Devoluciones()
        {
            InitializeComponent();
            Cargar_devolucion();
            dataGridDevolucion.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewBand band in dataGridDevolucion.Columns)
            {
                band.ReadOnly = true;
            }
        }

        public void Cargar_devolucion()
        {
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            dataGridDevolucion.DataSource = ctrlDevolucion.Mostrar_Devolucion();
        }

        private void Devolucion_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    DetalleDevolucion frm = new DetalleDevolucion(dataGridDevolucion.Rows[id_pos].Cells[0].Value.ToString());
                    frm.Lb_tipoFactura.Text = dataGridDevolucion.Rows[id_pos].Cells[3].Value.ToString();
                    frm.lbClienteName.Text = dataGridDevolucion.Rows[id_pos].Cells[7].Value.ToString();
                    frm.Lb_Trabajador.Text = dataGridDevolucion.Rows[id_pos].Cells[8].Value.ToString();
                    frm.Lb_Fecha.Text = dataGridDevolucion.Rows[id_pos].Cells[2].Value.ToString();
                    frm.lbIdFactura.Text = dataGridDevolucion.Rows[id_pos].Cells[1].Value.ToString();
                    Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
                    frm.txtDescripcion.Text = ctrlDevolucion.Desc_Devolucion(int.Parse(dataGridDevolucion.Rows[id_pos].Cells[0].Value.ToString()));
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();
            if (id_pos.Contains("Ver detalle devolución"))
            {
                id_pos = id_pos.Replace("Ver detalle devolución", "");
                Devolucion_Producto(int.Parse(id_pos));
            }
        }

        private void DataGridDevolucion_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridDevolucion.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Ver detalle devolución").Name = "Ver detalle devolución" + pos;
                }
                menu.Show(dataGridDevolucion, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            Cargar_devolucion();
        }
    }
}
