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
    public partial class UC_Creditos : UserControl
    {
        public UC_Creditos()
        {
            InitializeComponent();
            Cargar_credito();
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
        }

        public void Cargar_credito()
        {
            Controladores.CtrlCredito_Abono ctrlCredito_Abono = new Controladores.CtrlCredito_Abono();
            dataGridView1.DataSource = ctrlCredito_Abono.Cargar_Creditos();
        }

        private void Realizar_Abono(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    RealizarAbono frm = new RealizarAbono();
                    frm.Lb_FechaCredito.Text = dataGridView1.Rows[id_pos].Cells[3].Value.ToString();
                    string aux1 = dataGridView1.Rows[id_pos].Cells[3].Value.ToString();
                    string[] words1 = aux1.Split(' ');
                    string aux_fechaIni = words1[0];
                    string aux2 = dataGridView1.Rows[id_pos].Cells[4].Value.ToString();
                    string[] words2 = aux2.Split(' ');
                    string aux_fechaEnd = words2[0];
                    frm.Lb_FechaCredito.Text = aux_fechaIni + " - " + aux_fechaEnd;
                    frm.Lb_Cargo.Text = "C$ " + dataGridView1.Rows[id_pos].Cells[6].Value.ToString();
                    frm.Lb_Pendiente.Text = "C$ " + dataGridView1.Rows[id_pos].Cells[7].Value.ToString();
                    frm.Lb_Cliente.Text = dataGridView1.Rows[id_pos].Cells[2].Value.ToString();
                    frm.GBox_Cod_Fact.Text = dataGridView1.Rows[id_pos].Cells[1].Value.ToString();
                    frm.Txt_IDCredito.Text = dataGridView1.Rows[id_pos].Cells[0].Value.ToString();
                    frm.Txt_IDFactura.Text = dataGridView1.Rows[id_pos].Cells[10].Value.ToString();
                    frm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void Ver_Estado_Credito(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    EstadoDelCredito frm = new EstadoDelCredito(int.Parse(dataGridView1.Rows[id_pos].Cells[0].Value.ToString()), int.Parse(dataGridView1.Rows[id_pos].Cells[10].Value.ToString()));
                    string aux1 = dataGridView1.Rows[id_pos].Cells[3].Value.ToString();
                    string[] words1 = aux1.Split(' ');
                    string aux_fechaIni = words1[0];
                    string aux2 = dataGridView1.Rows[id_pos].Cells[4].Value.ToString();
                    string[] words2 = aux2.Split(' ');
                    string aux_fechaEnd = words2[0];
                    frm.Lb_FechaInicial.Text = aux_fechaIni;
                    frm.Lb_FechaFin.Text = aux_fechaEnd;
                    frm.Lb_Cliente.Text = dataGridView1.Rows[id_pos].Cells[2].Value.ToString();
                    frm.Lb_Cod_Factu.Text = dataGridView1.Rows[id_pos].Cells[1].Value.ToString();


                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                //MessageBox_Error.Show("Error:" + ex, "Error");
            }
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();
            if (id_pos.Contains("Realizar abono"))
            {
                id_pos = id_pos.Replace("Realizar abono", "");
                Realizar_Abono(int.Parse(id_pos));
            }
            if (id_pos.Contains("Ver estado del crédito"))
            {
                id_pos = id_pos.Replace("Ver estado del crédito", "");
                Ver_Estado_Credito(int.Parse(id_pos));
            }
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Realizar abono").Name = "Realizar abono" + pos;
                    menu.Items.Add("Ver estado del crédito").Name = "Ver estado del crédito" + pos;
                }
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            Cargar_credito();
        }
    }
}
