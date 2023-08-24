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
using SpreadsheetLight;

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

        public void Devolucion_NombreCliente(string dato)
        {
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            dataGridDevolucion.DataSource = ctrlDevolucion.Devoluciones_NombreCliente(dato);
        }

        public void Devolucion_Fechas(string dato1, string dato2)
        {
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            dataGridDevolucion.DataSource = ctrlDevolucion.Devoluciones_RangoFecha(dato1, dato2);
        }

        public void Devolucion_Estado(string dato)
        {
            Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
            dataGridDevolucion.DataSource = ctrlDevolucion.Devoluciones_EstadoFact(dato);
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

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            string nombre_cliente = txt_NonbCliente.Text;
            if (txt_NonbCliente.Text == "")
            {
                MessageBox_Error.Show("Por favor ingrese el nombre del cliente a buscar", "Error");
            }
            else
            {
                Devolucion_NombreCliente(nombre_cliente);
            }
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrl = new Controladores.CtrlReporte();

            SLDocument sL = ctrl.Reporte_Devolucion(dataGridDevolucion);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sL.SaveAs(saveFileDialog1.FileName + ".xlsx");
            }
        }
        
        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;
            MessageBox.Show(fecha_Ini + " " + fecha_End);

            Devolucion_Fechas(fecha_Ini, fecha_End);
        }

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (Rbtn_Pendientes.Checked == false && Rbtn_Canceladas.Checked == false)
            {
                MessageBox_Error.Show("Tiene que marcar una de las dos opciones", "Error");
            }
            else if (Rbtn_Pendientes.Checked == true && Rbtn_Canceladas.Checked == false)
            {
                estado = "Pendiente";
                Devolucion_Estado(estado);
            }
            else if (Rbtn_Pendientes.Checked == false && Rbtn_Canceladas.Checked == true)
            {
                estado = "Cancelado";
                Devolucion_Estado(estado);
            }
        }
    }
}
