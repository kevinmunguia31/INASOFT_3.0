using INASOFT_3._0.Modelos;
using INASOFT_3._0.VistaFacturas;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Factura : UserControl
    {
        //public DataGridViewButtonColumn GB = new DataGridViewButtonColumn();
        public UC_Factura()
        {
            InitializeComponent();
            CargarFacturas();
            foreach (DataGridViewBand band in dataGridFatura.Columns)
            {
                band.ReadOnly = true;
            }
            dataGridFatura.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void CargarFacturas()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridFatura.DataSource = ctrlFactura.CargarFactura();
        }

        public void Factura_NombreCliente(string dato)
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridFatura.DataSource = ctrlFactura.Factura_NombreCliente(dato);
        }

        public void Factura_Fechas(string dato1, string dato2)
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridFatura.DataSource = ctrlFactura.Factura_Fecha(dato1, dato2);
        }

        public void Todas_Facturas()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridFatura.DataSource = ctrlFactura.CargarTodasFacturas();
        }

        public void Factura_Mes(string dato)
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridFatura.DataSource = ctrlFactura.Factura_Mes(dato);
        }

        private void txtNewInvoice_Click(object sender, EventArgs e)
        {
            Facturar1 facturar = new Facturar1();
            facturar.Lb_User.Text = Modelos.Sesion.nombre;
            facturar.Show();
        }

        private void UC_Factura_Load(object sender, EventArgs e)
        {
            //Boton en Datagrid
            /*GB.Name = "GB";
            GB.Text = "Detalles →";
            GB.HeaderText = "Ver Detalles";
            GB.UseColumnTextForButtonValue = true;
            dataGridFatura.Columns.Add(GB);
            dataGridFatura.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;*/
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            DetalleFactura frm = new DetalleFactura();
            frm.lbClienteName.Text = "";
            frm.Lb_User.Text = Modelos.Sesion.nombre;
            frm.txtIdCliente.Text = "1";
            frm.Show();
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            string nombre_cliente = txt_NonbCliente.Text;
            if (txt_NonbCliente.Text == "")
            {
                MessageBox_Error.Show("Por favor ingrese el nombre del cliente a buscar", "Error");
            }
            else
            {
                Factura_NombreCliente(nombre_cliente);
            }
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            string fecha_Ini = DateTimeTimer_Ini.Text;
            string fecha_End = DateTimeTimer_End.Text;
            MessageBox.Show(fecha_Ini + " " + fecha_End);

            Factura_Fechas(fecha_Ini, fecha_End);
        }

        private void VerFactura(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    DetailsInvoice frm = new DetailsInvoice(dataGridFatura.Rows[id_pos].Cells[0].Value.ToString());

                    frm.lbCodFactura.Text = dataGridFatura.Rows[id_pos].Cells[1].Value.ToString();
                    frm.lbFecha.Text = dataGridFatura.Rows[id_pos].Cells[3].Value.ToString();
                    frm.lbClient.Text = dataGridFatura.Rows[id_pos].Cells[4].Value.ToString();

                    string aux1 = dataGridFatura.Rows[id_pos].Cells[8].Value.ToString();
                    string[] words1 = aux1.Split(' ');
                    double aux_desc = Double.Parse(words1[1]);

                    string aux2 = dataGridFatura.Rows[id_pos].Cells[9].Value.ToString();
                    string[] words2 = aux2.Split(' ');
                    double aux_total = Double.Parse(words2[1]);

                    double subtotal = (aux_desc + aux_total);

                    frm.lbSubT.Text = subtotal.ToString();
                    frm.lbTotal.Text = aux_total.ToString();
                    frm.lbDesc.Text = aux_desc.ToString();

                    string aux3 = dataGridFatura.Rows[id_pos].Cells[10].Value.ToString();
                    string[] words3 = aux3.Split(' ');
                    double aux_efectivo = Double.Parse(words3[1]);

                    frm.lbRecivied.Text = aux_efectivo.ToString();

                    string aux4 = dataGridFatura.Rows[id_pos].Cells[11].Value.ToString();
                    string[] words4 = aux4.Split(' ');
                    double aux_devolucion = Double.Parse(words4[1]);

                    frm.lbChange.Text = aux_devolucion.ToString();
                    frm.lbUser.Text = dataGridFatura.Rows[id_pos].Cells[13].Value.ToString();
                    frm.Lb_CodFact.Text = dataGridFatura.Rows[id_pos].Cells[1].Value.ToString();
                    frm.Lb_Cant_Prod.Text = dataGridFatura.Rows[id_pos].Cells[5].Value.ToString();
                    frm.Lb_Estado.Text = dataGridFatura.Rows[id_pos].Cells[2].Value.ToString();
                    frm.Lb_TipoPago.Text = dataGridFatura.Rows[id_pos].Cells[6].Value.ToString();

                    //Factura anulada
                    if (dataGridFatura.Rows[id_pos].Cells[2].Value.ToString() == "Anulada")
                    {
                        frm.Lb_Debe.Visible = false;
                        frm.label20.Visible = false;
                        frm.pictureBox3.Visible = true;
                        frm.Lb_Anulada.Visible = true;
                        frm.Lb_Anulada.ForeColor = Color.Red;
                        frm.guna2GroupBox2.Enabled = false;
                        frm.guna2GroupBox2.Visible = false;
                        frm.btnPrint.Enabled = false;
                        frm.guna2GroupBox3.Visible = true;
                        frm.guna2GroupBox3.Location = new Point(411, 57);
                        frm.guna2GroupBox3.Enabled = false;
                        frm.guna2GroupBox1.Enabled = false;
                        frm.Lb_Devolucion1.Visible = false;
                        frm.Lb_Devolucion2.Visible = false;
                        frm.PictBox_Devolucion.Visible = false;

                        Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
                        frm.txtDescripcion.Text = ctrlFactura.Desc_FacturaAnulada(int.Parse(dataGridFatura.Rows[id_pos].Cells[0].Value.ToString()));
                        frm.ShowDialog();
                    }
                    else
                    {
                        //Factura cancelada
                        if (dataGridFatura.Rows[id_pos].Cells[2].Value.ToString() == "Cancelado")
                        {
                            frm.Lb_Debe.Visible = false;
                            frm.label20.Visible = false;
                        }
                        else
                        {
                            frm.Lb_Debe.Visible = true;
                            frm.label20.Visible = true;
                            frm.Lb_Debe.Text = dataGridFatura.Rows[id_pos].Cells[12].Value.ToString();
                        }

                        Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
                        int id_factura = int.Parse(dataGridFatura.Rows[id_pos].Cells[0].Value.ToString());
                        if (ctrlDevolucion.Verificar_Devolucion(id_factura) == 1)
                        {
                            frm.PictBox_Devolucion.Visible = true;
                            frm.Lb_Devolucion1.Visible = true;
                            frm.Lb_Devolucion2.Visible = true;
                        }
                        else
                        {
                            frm.PictBox_Devolucion.Visible = false;
                            frm.Lb_Devolucion1.Visible = false;
                            frm.Lb_Devolucion2.Visible = false;
                        }
                        frm.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Devolucion_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    if (dataGridFatura.Rows[id_pos].Cells[2].Value.ToString() == "Anulada")
                    {
                        MessageBox_Error.Show("Está factura ya está anulada", "Eror");
                    }
                    else
                    {
                        Controladores.CtrlDevolucion ctrlDevolucion = new Controladores.CtrlDevolucion();
                        int id_factura = int.Parse(dataGridFatura.Rows[id_pos].Cells[0].Value.ToString());
                        if (ctrlDevolucion.Verificar_Devolucion(id_factura) == 1)
                        {
                            MessageBox_Error.Show("Está factura ya se le realizo una devolución", "Eror");
                        }
                        else
                        {
                            Devolucion frm = new Devolucion(dataGridFatura.Rows[id_pos].Cells[0].Value.ToString());
                            frm.lbIdFactura.Text = dataGridFatura.Rows[id_pos].Cells[1].Value.ToString();
                            frm.lbClienteName.Text = dataGridFatura.Rows[id_pos].Cells[4].Value.ToString();
                            frm.Lb_EstadoFactura.Text = dataGridFatura.Rows[id_pos].Cells[2].Value.ToString();

                            string aux1 = dataGridFatura.Rows[id_pos].Cells[9].Value.ToString();
                            string[] words1 = aux1.Split(' ');
                            double aux_total = Double.Parse(words1[1]);

                            string aux2 = dataGridFatura.Rows[id_pos].Cells[8].Value.ToString();
                            string[] words2 = aux2.Split(' ');
                            double aux_desc = Double.Parse(words2[1]);

                            frm.Lb_Subtotal.Text = (aux_total + aux_desc).ToString();
                            frm.Lb_TotalFacturado.Text = aux_total.ToString();
                            frm.Lb_Descuento.Text = "- " + aux_desc.ToString();

                            string aux3 = dataGridFatura.Rows[id_pos].Cells[10].Value.ToString();
                            string[] words3 = aux3.Split(' ');
                            double aux_efectivo = Double.Parse(words3[1]);

                            frm.Lb_Efectivo.Text = aux_efectivo.ToString();

                            string aux4 = dataGridFatura.Rows[id_pos].Cells[12].Value.ToString();
                            string[] words4 = aux4.Split(' ');
                            double aux_pendiente = Double.Parse(words4[1]);

                            frm.Lb_Debe.Text = aux_pendiente.ToString();
                            frm.Lb_Trabajador.Text = dataGridFatura.Rows[id_pos].Cells[13].Value.ToString();
                            frm.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox_Error.Show("Error:" + ex, "Error");
            }
        }

        private void AnularFactura(int id_pos)
        {
            if (dataGridFatura.Rows[id_pos].Cells[2].Value.ToString() == "Anulada")
            {
                MessageBox_Error.Show("Está factura ya está anulada", "Eror");
            }
            else
            {
                DialogResult resultado = guna2MessageDialog1.Show("¿Seguro que desea anular la factura?", "Eliminar");
                if (resultado == DialogResult.Yes)
                {
                    Anular_Factura frm = new Anular_Factura(dataGridFatura.Rows[id_pos].Cells[0].Value.ToString());
                    frm.Txt_Facturar.Text = dataGridFatura.Rows[id_pos].Cells[0].Value.ToString();
                    frm.Lb_Factura.Text = dataGridFatura.Rows[id_pos].Cells[1].Value.ToString();
                    if (dataGridFatura.Rows[id_pos].Cells[2].Value.ToString() == "Pendiente")
                    {
                        frm.Lb_Credito1.Visible = true;
                        frm.Lb_Credito2.Visible = true;
                        frm.Lb_Devolucion3.Visible = false;
                        frm.Lb_Credito2.Text = frm.Lb_Credito2.Text + " " + dataGridFatura.Rows[id_pos].Cells[10].Value.ToString();
                    }
                    else
                    {
                        frm.Lb_Credito1.Visible = false;
                        frm.Lb_Credito2.Visible = false;
                        frm.Lb_Devolucion3.Visible = false;
                    }
                    frm.ShowDialog();
                }
                else
                {

                }
            }
            //MessageBox_Import.Show("Factura anulada con exito");
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Devolución"))
            {
                id_pos = id_pos.Replace("Devolución", "");
                Devolucion_Producto(int.Parse(id_pos));
            }
            if (id_pos.Contains("Ver Factura"))
            {
                id_pos = id_pos.Replace("Ver Factura", "");
                VerFactura(int.Parse(id_pos));
            }
            if (id_pos.Contains("Anular Factura"))
            {
                id_pos = id_pos.Replace("Anular Factura", "");
                AnularFactura(int.Parse(id_pos));
            }
        }

        private void DataGridFatura_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridFatura.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Devolución").Name = "Devolución" + pos;
                    menu.Items.Add("Ver Factura").Name = "Ver Factura" + pos;
                    menu.Items.Add("Anular Factura").Name = "Anular Factura" + pos;
                }
                menu.Show(dataGridFatura, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void DataGridFatura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridFatura.Columns[e.ColumnIndex].Index == 12)
            {
                if (e.Value.GetType() != typeof(System.DBNull))
                {
                    if (e.Value.ToString() == "C$ 0.00")
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
            if (dataGridFatura.Columns[e.ColumnIndex].Index == 2)
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (e.Value.ToString() == "Cancelado")
                        {
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.White;
                        }
                        else if (e.Value.ToString() == "Pendiente")
                        {
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                        else if (e.Value.ToString() == "Anulada")
                        {
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.ForeColor = Color.White;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            Controladores.CtrlReporte ctrl = new Controladores.CtrlReporte();

            SLDocument sL = ctrl.Reporte_Facturas(dataGridFatura);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sL.SaveAs(saveFileDialog1.FileName + ".xlsx");
            }
        }

        private void Guna2Button7_Click(object sender, EventArgs e)
        {
            DialogResult resultado = guna2MessageDialog1.Show("¿Seguro que desea mostrar todas las facturas?, está opcion puede dilatarse en realizar\n\n", "Aviso");
            if (resultado == DialogResult.Yes)
            {
                Todas_Facturas();
            }
            else
            {

            }
        }
    }
}
