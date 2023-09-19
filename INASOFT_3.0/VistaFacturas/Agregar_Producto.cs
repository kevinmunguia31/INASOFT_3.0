using DevExpress.Charts.Native;
using DevExpress.XtraCharts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml;
using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using INASOFT_3._0.VistaFacturas;
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

namespace INASOFT_3._0
{
    public partial class Agregar_Producto : Form
    {
        public DataTable dataTable = new DataTable();
        CultureInfo culturaNicaragua = new CultureInfo("es-NI");
        protected double aux_DescIVA;

        public Agregar_Producto()
        {
            InitializeComponent();
            CargarProveedor();
            //CargarProductos();
            Cargar_Tabla();

            Lb_NombreUsuario.Text = Sesion.nombre;
            Txt_RUC.Enabled = false;
            Txt_TotalCompra.Enabled = false;

            datagridView2.Rows.Add("Total", "", "", "", "", 0, "", "");

            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            datagridView2.Columns[6].Visible = false;
            datagridView2.Columns[7].Visible = false;

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();
            Clear();
            bloquearCampos(false);

            if (dataGridView1.RowCount == 0)
            {
                groupBox7.Enabled = false;
            }
            Cbx_Productos.Visible = false;
        }

        public void CargarProveedor()
        {
            cbProveedor.DataSource = null;
            cbProveedor.Items.Clear();

            Controladores.CtrlProveedor ctrl = new Controladores.CtrlProveedor();
            cbProveedor.DataSource = ctrl.CargarProveddores();
            cbProveedor.ValueMember = "ID";
            cbProveedor.DisplayMember = "Nombre";
        }

        private void CargarProductos(int id)
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProducto_IDProveedor(id);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        public void Cargar_Total()
        {
            double Total = 0.00;

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }
                int numeroRedondeado = (int)Math.Ceiling(Total);
                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = "";
                datagridView2.Rows[0].Cells[5].Value = numeroRedondeado;
                datagridView2.Rows[0].Cells[6].Value = "";
                datagridView2.Rows[0].Cells[7].Value = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void Subtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                subtotal += float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            //Txt_TotalCompra.Text = subtotal.ToString();
            Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", subtotal);
        }

        public void Cargar_Tabla()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio Compra");
            dataTable.Columns.Add("Precio Venta");
            dataTable.Columns.Add("Total");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Observación");

            dataGridView1.DataSource = dataTable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPrecioCompra.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') && (!txtPrecioVenta.Text.Contains(".")))
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        public void Clear()
        {
            txtCodBarra.Text = "";
            txtNameP.Text = "";
            SpinExist.Value = 0;
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtObservacion.Text = "";
            Cbx_Productos.SelectedIndex = -1;
            Txt_RUC.Text = "";
            Lb_CantStocks.Text = "...";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            Txt_IDProd.Text = "";
        }

        private void Rbtn_TipoDolares_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            bloquearCampos(true);
            Cbx_Productos.Enabled = false;
            Cbx_Productos.Visible = false;
            txtCodBarra.Enabled = true;
            txtNameP.Enabled = true;
            txtPrecioCompra.Enabled = true;
            GroupBox_CambioProd.Enabled = false;

            Txt_IDProd.Text = "0";
        }

        private void Rbtn_TipoCordobas_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            bloquearCampos(true);
            Cbx_Productos.Enabled = true;
            Cbx_Productos.Visible = true;
            txtCodBarra.Enabled = false;
            txtNameP.Enabled = false;
            txtPrecioCompra.Enabled = false;
            GroupBox_CambioProd.Enabled = true;
            Txt_IDProd.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lb_Fecha.Text = "Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    Clear();
                }
                else
                {
                    int id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                    Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                    Txt_IDProd.Text = id.ToString();

                    txtNameP.Text = ctrlProductos.Nombre_Producto(id);

                    txtCodBarra.Text = ctrlProductos.Codigo_Producto(id);                    

                    txtPrecioCompra.Text = ctrlProductos.Precio_Compra(id).ToString();

                    Lb_CantStocks.Text = ctrlProductos.Existencias_Producto(id).ToString();

                    //SpinExist.Maximum = 100;
                    //SpinExist.Minimum = 1;


                    if (int.Parse(Lb_CantStocks.Text) <= 0)
                    {
                        errorProvider1.SetError(Lb_CantStocks, "Ya no hay productos en el almacen.");
                        Lb_CantStocks.ForeColor = Color.Red;
                    }
                    else
                    {
                        errorProvider1.SetError(Lb_CantStocks, "");
                        Lb_CantStocks.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex);
            }
        }

        private void Btn_AddProducto_Click(object sender, EventArgs e)
        {
            bool seRepite = false;

            if (txtCodBarra.Text == "" || txtNameP.Text == "")
            {
                MessageBoxError.Show("Tiene que rellenar todos los campos solicitados", "Error");
                Clear();
            }
            else
            {
                if (SpinExist.Value == 0)
                {
                    MessageBoxError.Show("Tiene que indicar la cantidad", "Error");
                    errorProvider1.SetError(SpinExist, "Debe indicar la cantidad que desea facturar");

                }
                else if (txtPrecioVenta.Text == "")
                {
                    MessageBoxError.Show("No deje campos obligatorios sin marcar", "Error");
                    errorProvider1.SetError(txtPrecioVenta, "Debe indicar el precio del producto");
                }
                else if (double.Parse(txtPrecioCompra.Text) > double.Parse(txtPrecioVenta.Text))
                {
                    MessageBoxError.Show("El precio de venta no puede ser menor al precio del que se compró el producto\n", "Error");
                }
                else
                {
                    errorProvider1.SetError(txtPrecioVenta, "");
                    errorProvider1.SetError(SpinExist, "");
                    timer1.Start();

                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == txtCodBarra.Text)
                        {
                            seRepite = true;
                            break;
                        }
                    }

                    if (seRepite)
                    {
                        MessageBox_Import.Show("Ya se agrego ese producto, puede editarlo o borrarlo si desea", "Importante");
                        Clear();
                    }
                    else
                    {
                        Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                        DataRow newRow = dataTable.NewRow();
                        newRow[0] = txtCodBarra.Text;
                        newRow[1] = txtNameP.Text;
                        newRow[2] = SpinExist.Value.ToString();
                        newRow[3] = double.Parse(txtPrecioCompra.Text);
                        newRow[4] = double.Parse(txtPrecioVenta.Text);
                        newRow[5] = double.Parse(txtPrecioVenta.Text) * int.Parse(SpinExist.Value.ToString());                        
                        newRow[6] = Txt_IDProd.Text;
                        if (txtObservacion.Text == "")
                        {
                            txtObservacion.Text = "Compra del producto " + txtNameP.Text;
                        }
                        else
                        {
                            txtObservacion.Text = txtObservacion.Text;
                        }
                        newRow[7] = txtObservacion.Text;

                        dataTable.Rows.Add(newRow);

                        dataGridView1.DataSource = dataTable;
                        Cargar_Total();
                        Subtotal();

                        if (dataGridView1.RowCount == 0)
                        {
                            groupBox7.Enabled = false;
                        }
                        else
                        {
                            groupBox7.Enabled = true;
                        }
                    }
                }
            }
            Clear();
            bloquearCampos(false);
            Rbtn_ActualizarProducto.Checked = false;
            Rbtn_NuevoProducto.Checked = false;
            Cbx_Productos.Visible = false;
            cbProveedor.SelectedIndex = -1;
        }

        private void bloquearCampos(bool bandera)
        {
            GroupBox_Products.Enabled = bandera;
            Cbx_Productos.Enabled = bandera;
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
                        dataGridView1.Rows.RemoveAt(id_pos);
                        Subtotal();
                        Clear();
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Borrar").Name = "Borrar" + pos;
                }
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void Btn_RealizarCompra_Click(object sender, EventArgs e)
        {
            if(cbProveedor.SelectedIndex == -1 || txt_NombreProveedor.Text == "")
            {
                MessageBoxError.Show("No deje los datos del proveedor sin rellenar", "Error");
            }
            else if(Rbtn_Cordobas.Checked == false && Rbtn_Dolares.Checked == false)
            {
                MessageBoxError.Show("Tiene que indicar el tipo de pago", "Error");
            }
            else if (dataGridView1.RowCount == 0)
            {
                MessageBoxError.Show("No se ha almacenado nigún producto, al menos guarde uno en la tabla.", "Error");
            }
            else
            {
                string tipo_pago = "";
                string descuento = "";
                string iva = "";
                if (Rbtn_Dolares.Checked == true)
                {
                    tipo_pago = "Transferencia";
                }
                if (Rbtn_Cordobas.Checked == true)
                {
                    tipo_pago = "Al contado";
                }
                //Insertar datos a las tablas
                Modelos.Compras compras = new Modelos.Compras();

                compras.Nombre_venderdor = txt_NombreProveedor.Text;
                compras.Subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
                if (Txt_DescuentoCompra.Text == "")
                {
                    descuento = "0";
                }
                else
                {
                    descuento = Txt_DescuentoCompra.Text;
                }

                if (Txt_IVACompra.Text == "")
                {
                    iva = "0";
                }
                else
                {
                    iva = Txt_IVACompra.Text;
                }
                compras.Descuento = double.Parse(descuento);
                compras.Iva = double.Parse(iva);
                compras.Descripcion = Txt_Descripcion.Text;
                compras.Tipo_pago = tipo_pago;
                compras.Id_usuario = Sesion.id;
                compras.Id_proveedor = int.Parse(cbProveedor.SelectedValue.ToString());

                Controladores.CtrlCompras ctrlCompras = new Controladores.CtrlCompras();
                bool bandera = ctrlCompras.Insertar_Compra(compras);

                if (bandera)
                {
                    Modelos.Productos productos = new Modelos.Productos();
                    Modelos.Detalle_Compras detalle_Compras = new Modelos.Detalle_Compras();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        productos.Id = int.Parse(row.Cells[6].Value.ToString());
                        productos.Codigo = row.Cells[0].Value.ToString();
                        productos.Nombre = row.Cells[1].Value.ToString();
                        productos.Existencias = int.Parse(row.Cells[2].Value.ToString());
                        productos.Precio_compra = double.Parse(row.Cells[3].Value.ToString());
                        productos.Precio_total = double.Parse(row.Cells[5].Value.ToString());
                        productos.Precio_venta = double.Parse(row.Cells[4].Value.ToString());
                        productos.Observacion = row.Cells[7].Value.ToString();

                        ctrlCompras.Productos_Comprados(productos);
                    } 
                    MessageBox_Import.Show("Se ha realizado la compra de manera éxitosa", "Importante");
                    this.Close();
                }
            }
        }

        private void cbProveedor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cbProveedor.SelectedIndex == -1)
                {
                    Clear();
                    Cbx_Productos.Enabled = false;
                }
                else
                {
                    int id = int.Parse(cbProveedor.SelectedValue.ToString());
                    Controladores.CtrlProveedor ctrlProveedor = new CtrlProveedor();
                    Txt_RUC.Text = ctrlProveedor.RUC(id);
                    Cbx_Productos.Enabled = true;
                    CargarProductos(id);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Txt_DescuentoCompra_TextChanged(object sender, EventArgs e)
        {
            double subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
            double total = 0.00;
            double desc;

            try
            {
                if (Txt_DescuentoCompra.Text == "")
                {
                    desc = 0.00;
                    Txt_DescuentoCompra.Text = "";
                    Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", subtotal);
                    //Lb_AuxDescIVA.Text = subtotal.ToString();
                    aux_DescIVA = subtotal;
                }
                else
                {
                    desc = (double.Parse(Txt_DescuentoCompra.Text) / 100);
                    total = subtotal - (subtotal * desc);

                    // Formatea el total con descuento como moneda
                    Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", total);
                    //Lb_AuxDescIVA.Text = total.ToString();
                    aux_DescIVA = total;
                }
            }
            catch (Exception ex)
            {
                Txt_DescuentoCompra.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ver_EditarProducto ver_EditarProducto = new Ver_EditarProducto();
            ver_EditarProducto.GroupBox_EditarProd.Visible = false;
            ver_EditarProducto.GroupBox_VerProd.Visible = true;
            ver_EditarProducto.ShowDialog();
        }

        private void Txt_IVACompra_TextChanged(object sender, EventArgs e)
        {
            double subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
            double total = 0.00;
            double iva;

            try
            {
                if (Txt_IVACompra.Text == "")
                {
                    iva = 0.00;
                    Txt_DescuentoCompra.Text = "";
                    Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", subtotal);
                    //Lb_AuxDescIVA.Text = subtotal.ToString();
                    aux_DescIVA = subtotal;
                }
                else
                {
                    iva = (double.Parse(Txt_IVACompra.Text) / 100);
                    total = subtotal + (subtotal * iva);

                    // Formatea el total con descuento como moneda
                    Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", total);
                    //Lb_AuxDescIVA.Text = total.ToString();
                    aux_DescIVA = total;
                }
            }
            catch (Exception ex)
            {
                Txt_IVACompra.Text = "";
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = true;
        }
    }
}
