using INASOFT_3._0.Controladores;
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
    public partial class Devolucion : Form
    {
        public DataTable dataTable = new DataTable();
        public Devolucion(string id_factura)
        {
            InitializeComponent();
            Txt_Factura.Text = id_factura;
            CargarDetalleFacturas();
            cargar_tabla();
            Cargar_Total();

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
        }
        public void CargarDetalleFacturas()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            datagridView1.DataSource = ctrlFactura.DetalleFactura(Txt_Factura.Text);
        }

        private void DatagridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int pos = datagridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1 && pos != null)
                {
                    if (lbCodProdu.Text == datagridView1.Rows[pos].Cells[0].Value.ToString())
                    {
                        MessageBox_Error.Show("Ya estás trabajando con esté producto");
                    }
                    else
                    {

                        lbProductName.Text = datagridView1.Rows[pos].Cells[1].Value.ToString();
                        int limite = 15;
                        if (lbProductName.Text.Length > limite)
                        {
                            lbProductName.Text = lbProductName.Text.Substring(0, limite) + "...";
                        }
                        else
                        {
                            lbProductName.Text = lbProductName.Text;
                        }
                        lbCodProdu.Text = datagridView1.Rows[pos].Cells[0].Value.ToString();
                        LbPrecio.Text = datagridView1.Rows[pos].Cells[2].Value.ToString();
                        lbExistencias.Text = datagridView1.Rows[pos].Cells[3].Value.ToString();
                        SpinCantidad.Text = datagridView1.Rows[pos].Cells[3].Value.ToString();
                    }
                }
            }
        }
        private void Eliminar_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    bool bandera = false;
                    DialogResult resultado = guna2MessageDialog1.Show("Seguro que desea eliminar el registro?", "Eliminar");
                    if (resultado == DialogResult.Yes)
                    {
                        //MessageBox.Show(id_pos.ToString());
                        datagridView2.Rows.RemoveAt(id_pos);
                        Limpiar();
                        Cargar_Total();
                    }
                    else
                    {

                    }
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

            if (id_pos.Contains("Borrar"))
            {
                id_pos = id_pos.Replace("Borrar", "");
                Eliminar_Producto(int.Parse(id_pos));
            }
        }

        public void cargar_tabla()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");

            datagridView2.DataSource = dataTable;
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Hide();
            this.Close();
        }

        public void Cargar_Total()
        {
            double Total = 0.00;
            try
            {
                for (int i = 0; i < datagridView2.Rows.Count; i++)
                {
                    Total += float.Parse(datagridView2.Rows[i].Cells[4].Value.ToString());
                }
                lbTotalDevolucion.Text = Total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void Limpiar()
        {
            lbCodProdu.Text = "...";
            lbExistencias.Text = "...";
            lbProductName.Text = "...";
            LbPrecio.Text = "...";
            SpinCantidad.Value = 0;
            lbCodProdu.Text = "...";
        }

        private void BttnConfirmar_Click(object sender, EventArgs e)
        {
            if (datagridView2.RowCount == 0)
            { 
                MessageBox_Import.Show("No se ha almacenado ningún productos para devolver, necesita almenos ingresar uno", "Importante");
            }
            else
            {
                string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
                string hora = DateTime.Now.ToString("hh:mm:ss");
                string Fecha_final = fecha + " " + hora;
                string descripcion;

                int cantidad = 0;

                for (int i = 0; i < datagridView2.Rows.Count; i++)
                {
                    cantidad += int.Parse(datagridView2.Rows[i].Cells[2].Value.ToString());
                }

                if (txtDescripcion.Text == "")
                {
                    descripcion = "El cliente "+ lbClienteName.Text + " ha hecho una devolución de "+ cantidad + " productos";
                }
                else
                {
                    descripcion = txtDescripcion.Text;
                }

                Controladores.CtrlDevolucion ctrlDevolucion = new CtrlDevolucion();
                bool bandera1 = ctrlDevolucion.Agregar_Devolucion(Fecha_final, descripcion, int.Parse(Txt_Factura.Text));

                int devolucion = ctrlDevolucion.ID_Devolucion();
                int factura = int.Parse(Txt_Factura.Text);

                for (int i = 0; i < datagridView2.Rows.Count; i++)
                {
                    DataGridViewRow row = datagridView2.Rows[i];
                    ctrlDevolucion.Devolucion_productos(int.Parse(row.Cells[2].Value.ToString()), double.Parse(row.Cells[3].Value.ToString()), row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), devolucion, factura);
                }
                double Devolucion = double.Parse(lbTotalDevolucion.Text);
                int id_factura = int.Parse(Txt_Factura.Text);

                ctrlDevolucion.Actualizar_Factura(Devolucion, id_factura);
                UserControls.UC_Factura uC_Factura = new UserControls.UC_Factura();
                uC_Factura.CargarFacturas();
                MessageBox_Import.Show("La devolución se ha hecho correctamente, le tiene que devolver al cliente un monto de: C$ " + lbTotalDevolucion.Text + "\n\n" , "Importante");

                this.Hide();
                this.Close();
            }
        }

        private void BtnAñadirProducto_Click_1(object sender, EventArgs e)
        {
            bool seRepite = false;
            if(lbCodProdu.Text == "...")
            {
                MessageBox_Error.Show("Marqué algún producto para devolver", "Error");
            }
            else
            {
                if (SpinCantidad.Value > int.Parse(lbExistencias.Text))
                {
                    MessageBox_Error.Show("El cliente no compro esa cantidad");
                }
                else
                {
                    foreach (DataGridViewRow fila in datagridView2.Rows)
                    {
                        if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == lbCodProdu.Text)
                        {
                            seRepite = true;
                            break;
                        }
                    }

                    if (seRepite)
                    {
                        MessageBox_Error.Show("El dato ya existe en la tabla de devolución","Error");
                    }
                    else
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow[0] = lbCodProdu.Text;
                        newRow[1] = lbProductName.Text;
                        newRow[2] = SpinCantidad.Value;
                        newRow[3] = LbPrecio.Text;
                        newRow[4] = (double.Parse(LbPrecio.Text) * double.Parse(SpinCantidad.Value.ToString())).ToString();

                        dataTable.Rows.Add(newRow);

                        datagridView2.DataSource = dataTable;
                        Limpiar();
                        Cargar_Total();
                    }
                }
            }
        }

        private void Devolucion_Load(object sender, EventArgs e)
        {
            if (lbClienteName.Text == "--")
            {
                lbClienteName.Text = "Cliente génerico";
            }
            else
            {
                int limite = 15;
                if (lbClienteName.Text.Length > limite)
                {
                    lbClienteName.Text = lbClienteName.Text.Substring(0, limite) + "...";
                }
                else
                {
                    lbClienteName.Text = lbClienteName.Text;
                }
            }
            if (Lb_EstadoFactura.Text == "Cancelado")
            {
                Lb_EstadoFactura.ForeColor = Color.Green;
            }
            else
            {
                Lb_EstadoFactura.ForeColor = Color.Orange;
            }

            if(double.Parse(Lb_Debe.Text) > 0.00)
            {
                Lb_Debe.ForeColor = Color.Red;
                label22.ForeColor = Color.Red;
            }
            else
            {
                Lb_Debe.ForeColor = Color.Green;
                label22.ForeColor = Color.Green;
            }
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = guna2MessageDialog1.Show("Al devolver todos los productos la factura quedará anulada, ¿está seguro que desea devolver todos los productos?\n\n", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
                string hora = DateTime.Now.ToString("hh:mm:ss");
                string Fecha_final = fecha + " " + hora;
                string descripcion = "Se hizo una devolución de todos los productos";
                double Devolucion = 0;
                int ID_factura = int.Parse(Txt_Factura.Text);

                Controladores.CtrlDevolucion ctrlDevolucion = new CtrlDevolucion();
                bool bandera1 = ctrlDevolucion.Agregar_Devolucion(Fecha_final, descripcion, ID_factura);

                int ID_devolucion = ctrlDevolucion.ID_Devolucion();

                for (int i = 0; i < datagridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = datagridView1.Rows[i];
                    ctrlDevolucion.Devolucion_productos(int.Parse(row.Cells[3].Value.ToString()), double.Parse(row.Cells[2].Value.ToString()), row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), ID_devolucion, ID_factura);
                }

                for (int i = 0; i < datagridView1.Rows.Count; i++)
                {
                    Devolucion += double.Parse(datagridView1.Rows[i].Cells[4].Value.ToString());
                }
                ctrlDevolucion.Actualizar_Factura(Devolucion, ID_factura);

                this.Hide();

                Anular_Factura frm = new Anular_Factura(Txt_Factura.Text);
                frm.Txt_Facturar.Text = Txt_Factura.Text;
                frm.Lb_Factura.Text = lbIdFactura.Text;
                if (Lb_EstadoFactura.Text == "Pendiente")
                {
                    frm.Lb_Credito1.Visible = true;
                    frm.Lb_Credito2.Visible = true;
                    frm.Lb_Devolucion3.Visible = true;
                    frm.Lb_Credito2.Text = frm.Lb_Credito2.Text + " " + Devolucion;
                    frm.Lb_Devolucion3.Text = frm.Lb_Devolucion3.Text + " " + Devolucion;
                }
                else
                {
                    frm.Lb_Credito1.Visible = false;
                    frm.Lb_Credito2.Visible = false;
                    frm.Lb_Devolucion3.Visible = true;
                    frm.Lb_Devolucion3.Location = new Point(6, 133);
                    frm.Lb_Devolucion3.Text = frm.Lb_Devolucion3.Text + " " + Devolucion;
                }
                frm.ShowDialog();

                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void DatagridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = datagridView2.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Borrar").Name = "Borrar" + pos;
                }
                menu.Show(datagridView2, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }
    }
}
