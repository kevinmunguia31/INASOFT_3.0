using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class DetalleFactura : Form
    {
        public DataTable dataTable = new DataTable();
        private Timer timer;

        public DetalleFactura()
        {
            InitializeComponent();

            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            lbIdFactura.Text = lbIdFactura.Text + " " + ctrlFactura.Codigo_Factura().ToString();
            Lb_AuxCodFac.Text = ctrlFactura.Codigo_Factura().ToString();

            Cargar_Productos();
            cargar_tabla();
            Limpiar();

            datagridView1.Columns[0].ReadOnly = true;
            datagridView1.Columns[1].ReadOnly = true;
            datagridView1.Columns[4].ReadOnly = true;

            datagridView2.Rows.Add("Total", "", "", "", 0);

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();

            timer = new Timer();
            timer.Interval = 5000; // 5000 milisegundos = 5 segundos
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Al transcurrir el tiempo, limpiar el mensaje de error y detener el temporizador
            errorProvider1.SetError(txtPrecio, "");
            errorProvider1.SetError(SpinCantidad, "");
            timer.Stop();
        }

        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "1")
            {
                MessageBox_Import.Show("En está opción no se permitirá facturar al crédito", "AVISO");
            }
            if (txtIdCliente.Text == "1")
            {
                lbClienteName.Text = "Cliente génerico";
            }
            else
            {
                int limite = 25;
                if (lbClienteName.Text.Length > limite)
                {
                    lbClienteName.Text = lbClienteName.Text.Substring(0, limite) + "...";
                }
                else
                {
                    lbClienteName.Text = lbClienteName.Text;
                }
            }
        }

        private void Cargar_Productos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProducto();
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        public void Cargar_Total()
        {
            double Total = 0.00;
            
            try
            {
                for (int i = 0; i < datagridView1.Rows.Count; i++)
                {
                    Total += float.Parse(datagridView1.Rows[i].Cells[4].Value.ToString());                   
                }
                int numeroRedondeado = (int)Math.Ceiling(Total);
                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = numeroRedondeado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Hide();
            this.Close();
        }

        public void cargar_tabla()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");

            datagridView1.DataSource = dataTable;
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            bool seRepite = false;

            if (Cbx_Productos.SelectedIndex == -1)
            {
                MessageBox_Error.Show("Tiene que escoger un producto a facturar", "Error");
                Limpiar();
            }
            else
            {
                if (SpinCantidad.Value == 0)
                {
                    MessageBox_Error.Show("Tiene que indicar la cantidad", "Error");
                    errorProvider1.SetError(SpinCantidad, "Debe indicar la cantidad que desea facturar");

                }
                else if (lbExistencias.Text == "0")
                {
                    MessageBox_Error.Show("Se acabo esté producto en el inventario", "Error");
                }
                else if (txtPrecio.Text == "")
                {
                    MessageBox_Error.Show("No deje campos obligatorios sin marcar", "Error");
                    errorProvider1.SetError(txtPrecio, "Debe indicar el precio del producto");
                }
                else if(lbCodProdu.Text == "..." || lbProductName.Text == "...")
                {
                    MessageBox_Error.Show("No ha seleccionado un producto a facturar.", "Error");
                }
                else if (double.Parse(Lb_PrecioCompra.Text) > double.Parse(txtPrecio.Text))
                {
                    MessageBoxError.Show("El precio no puede ser menor al precio del que se compró el producto\n", "Error");
                }
                else
                {
                    errorProvider1.SetError(txtPrecio, "");
                    errorProvider1.SetError(SpinCantidad, "");
                    timer.Start();

                    foreach (DataGridViewRow fila in datagridView1.Rows)
                    {
                        if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == lbCodProdu.Text)
                        {
                            seRepite = true;
                            break;
                        }
                    }

                    if (seRepite)
                    {
                        MessageBox_Import.Show("Ya se agrego ese producto, puede editarlo o borrarlo si desea", "Importante");
                        Limpiar();
                    }
                    else
                    {

                        Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                        DataRow newRow = dataTable.NewRow();
                        newRow[0] = ctrlProductos.Codigo_Producto(int.Parse(txtIdProduc.Text));
                        newRow[1] = ctrlProductos.Nombre_Producto(int.Parse(txtIdProduc.Text));
                        newRow[2] = SpinCantidad.Value.ToString();
                        newRow[3] = double.Parse(txtPrecio.Text);
                        newRow[4] = double.Parse(txtPrecio.Text) * int.Parse(SpinCantidad.Value.ToString());

                        dataTable.Rows.Add(newRow);

                        datagridView1.DataSource = dataTable;
                        Subtotal();
                        Limpiar();
                        Cargar_Total();
                    }
                }
            }
            Limpiar();
        }

        public void Limpiar()
        {
            txtPrecio.Text = "";
            lbExistencias.Text = "...";
            lbProductName.Text = "...";
            Cbx_Productos.SelectedIndex = -1;
            SpinCantidad.Value = 0;
            lbCodProdu.Text = "...";
            txtIdProduc.Text = "";
            TxtBuscar_Productos.Text = "";
            Lb_PrecioCompra.Text = "...";
        }

        public void Subtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < datagridView1.Rows.Count; i++)
            {
                subtotal += float.Parse(datagridView1.Rows[i].Cells[4].Value.ToString());
            }
            lbSubtotal.Text = subtotal.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (datagridView1.RowCount == 0)
            {
                MessageBox_Error.Show("No se ha almacenado ningún productos para la facturación, al menos facturé un producto", "Error");
            }
            else
            {
                List<Detalle_Factura> listaProductos = new List<Detalle_Factura>();

                foreach (DataGridViewRow fila in datagridView1.Rows)
                {
                    if (!fila.IsNewRow) // Evita la fila en blanco al final del DataGridView
                    {
                        Detalle_Factura productos = new Detalle_Factura
                        {
                            Codigo_producto = fila.Cells[0].Value.ToString(),
                            Nombre_producto = fila.Cells[1].Value.ToString(),
                            Cantidad = Convert.ToInt32(fila.Cells[2].Value),
                            Precio = Convert.ToDouble(fila.Cells[3].Value),
                            Total = Convert.ToDouble(fila.Cells[4].Value)
                        };

                        listaProductos.Add(productos);
                    }
                }
                MessageBox_Ok.Show("Productos agregados a la factura", "Aviso");
                FacturaFinal frm = new FacturaFinal();
                frm.lbNombreCliente.Text = lbClienteName.Text;
                frm.lbSubtotal.Text = lbSubtotal.Text;
                frm.txtIdCliente.Text = txtIdCliente.Text;
                frm.lbTotal.Text = lbSubtotal.Text;
                frm.Lb_User.Text = Lb_User.Text;
                //frm.lbIdFactura.Text = Lb_AuxCodFac.Text;

                frm.Show();
                this.Hide();
                this.Close();
            }
        }

        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Buscar_NombreProducto(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    Limpiar();
                }
                else
                {
                    txtIdProduc.Text = Cbx_Productos.SelectedValue.ToString();
                    int id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                    Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
                    string aux_NombProd = ctrlProductos.Nombre_Producto(id);
                    int limite = 15;

                    if (aux_NombProd.Length > limite)
                    {
                        lbProductName.Text = aux_NombProd.Substring(0, limite) + "...";
                    }
                    else
                    {
                        lbProductName.Text = aux_NombProd;
                    }
                    string aux_CodProd = ctrlProductos.Codigo_Producto(id);

                    if (aux_CodProd.Length > limite)
                    {
                        lbCodProdu.Text = aux_CodProd.Substring(0, limite) + "...";
                    }
                    else
                    {
                        lbCodProdu.Text = aux_CodProd;
                    }
                    lbExistencias.Text = ctrlProductos.Existencias_Producto(id).ToString();
                    txtPrecio.Text = ctrlProductos.Precio_Producto(id).ToString();
                    SpinCantidad.Maximum = Convert.ToDecimal(lbExistencias.Text);
                    Lb_PrecioCompra.Text = ctrlProductos.Precio_Compra(id).ToString();

                    if (int.Parse(lbExistencias.Text) <= 0)
                    {
                        errorProvider1.SetError(lbExistencias, "Ya no hay productos en el almacen.");
                        lbExistencias.ForeColor = Color.Red;
                    }
                    else
                    {
                        errorProvider1.SetError(lbExistencias, "");
                        lbExistencias.ForeColor = Color.Black;
                    }
                }
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    txtPrecio.Enabled = false;
                    SpinCantidad.Enabled = false;
                }
                else
                {
                    txtPrecio.Enabled = true;
                    SpinCantidad.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Cargar_Productos();
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
        private void Eliminar_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    bool bandera = false;
                    DialogResult resultado = MessageDialogError.Show("Seguro que desea eliminar el registro?", "Eliminar");
                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show(id_pos.ToString());
                        datagridView1.Rows.RemoveAt(id_pos);
                        Subtotal();
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

        private void DatagridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = datagridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Borrar").Name = "Borrar" + pos;
                }
                menu.Show(datagridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void DatagridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == datagridView1.Columns["Cantidad"].Index && e.RowIndex >= 0)
                {
                    DataGridViewCell CantidadCell = datagridView1.Rows[e.RowIndex].Cells["Cantidad"];
                    DataGridViewCell PrecioCell = datagridView1.Rows[e.RowIndex].Cells["Precio"];
                    DataGridViewCell TotalCell = datagridView1.Rows[e.RowIndex].Cells["Total"];

                    decimal cantidad = Convert.ToDecimal(CantidadCell.Value);
                    decimal precio = Convert.ToDecimal(PrecioCell.Value);
                    decimal total = precio * cantidad;
                    TotalCell.Value = total;
                }
                if (e.ColumnIndex == datagridView1.Columns["Precio"].Index && e.RowIndex >= 0)
                {
                    DataGridViewCell CantidadCell = datagridView1.Rows[e.RowIndex].Cells["Cantidad"];
                    DataGridViewCell PrecioCell = datagridView1.Rows[e.RowIndex].Cells["Precio"];
                    DataGridViewCell TotalCell = datagridView1.Rows[e.RowIndex].Cells["Total"];

                    decimal cantidad = Convert.ToDecimal(CantidadCell.Value);
                    decimal precio = Convert.ToDecimal(PrecioCell.Value);
                    decimal total = precio * cantidad;
                    TotalCell.Value = total;
                }
            }
            catch (Exception ex)
            {
                MessageBoxError.Show("Error: " + ex.Message);
            }
            Cargar_Total();
            Subtotal();
        }

        private void DatagridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                bool isINT = int.TryParse(e.FormattedValue.ToString(), out int resultado);
                if (isINT == false)
                {
                    e.Cancel = true;
                    MessageBox_Error.Show("El dato debe ser numérico", "Error");
                }
            }
            if(e.ColumnIndex == 3)
            {
                bool isDouble = double.TryParse(e.FormattedValue.ToString(), out double resultado);
                if (isDouble == false)
                {
                    e.Cancel = true;
                    MessageBox_Error.Show("El dato debe ser numérico", "Error");
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Lb_FechaHoy.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void TxtPrecio_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPrecio.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
    }
}

 