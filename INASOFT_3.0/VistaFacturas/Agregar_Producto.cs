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

        public Agregar_Producto()
        {
            InitializeComponent();
            CargarProveedor();
            CargarProductos();
            Cargar_Tabla();

            Lb_NombreUsuario.Text = Sesion.nombre;
            Txt_RUC.Enabled = false;
            Txt_TotalCompra.Enabled = false;

            datagridView2.Rows.Add("Total", "", "", "", "", 0, "", "", "", "");

            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            datagridView2.Columns[6].Visible = false;
            datagridView2.Columns[7].Visible = false;
            datagridView2.Columns[8].Visible = false;
            datagridView2.Columns[9].Visible = false;

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();
            Clear();
            bloquearCampos(false);
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

        private void CargarProductos()
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
                datagridView2.Rows[0].Cells[8].Value = "";
                datagridView2.Rows[0].Cells[9].Value = "";
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
            dataTable.Columns.Add("IVA");
            dataTable.Columns.Add("Descuento");
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
            TxtBuscar_Productos.Text = "";
            cbProveedor.SelectedIndex = -1;
            Cbx_Productos.SelectedIndex = -1;
            Txt_RUC.Text = "";
            Lb_CantStocks.Text = "...";
            Txt_IVA.Text = "";
            Txt_DescuentoProd.Text = "";

            Txt_IDProd.Text = "";
        }

        private void Rbtn_TipoDolares_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            bloquearCampos(true);
            Cbx_Productos.Enabled = false;
            TxtBuscar_Productos.Enabled = false;
            button1.Enabled = false;
            Cbx_Productos.Visible = false;
            TxtBuscar_Productos.Visible = false;
            button1.Visible = false;
            txtCodBarra.Enabled = true;
            txtNameP.Enabled = true;
            txtPrecioCompra.Enabled = true;
            Rbtn_ActualizarProducto.Checked = false;
            Rbtn_NuevoProducto.Checked = true;

            Txt_IDProd.Text = "0";
        }

        private void Rbtn_TipoCordobas_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            bloquearCampos(true);
            Cbx_Productos.Enabled = true;
            TxtBuscar_Productos.Enabled = true;
            button1.Enabled = true;
            Cbx_Productos.Visible = true;
            TxtBuscar_Productos.Visible = true;
            button1.Visible = true;
            txtCodBarra.Enabled = false;
            txtNameP.Enabled = false;
            txtPrecioCompra.Enabled = false;
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
            double descuento = 0.00;
            double iva = 0.00;

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

                        string aux1 = Lb_PrecioDescIVA.Text;
                        string[] words1 = aux1.Split('$');
                        string aux_PrecioCompra = words1[1];

                        newRow[3] = double.Parse(aux_PrecioCompra);
                        newRow[4] = double.Parse(txtPrecioVenta.Text);
                        newRow[5] = double.Parse(txtPrecioVenta.Text) * int.Parse(SpinExist.Value.ToString());                        
                        newRow[6] = Txt_IDProd.Text;
                        if (Txt_IVA.Text == "")
                        {
                            iva = 0.00;
                        }
                        else
                        {
                            iva = double.Parse(Txt_IVA.Text);
                        }
                        newRow[7] = iva;

                        if (Txt_DescuentoProd.Text == "")
                        {
                            descuento = 0.00;
                        }
                        else
                        {
                            descuento = double.Parse(Txt_DescuentoProd.Text);
                        }
                        newRow[8] = descuento;

                        if (txtObservacion.Text == "")
                        {
                            txtObservacion.Text = "Compra del producto " + txtNameP.Text;
                        }
                        else
                        {
                            txtObservacion.Text = txtObservacion.Text;
                        }
                        newRow[9] = txtObservacion.Text;

                        dataTable.Rows.Add(newRow);

                        dataGridView1.DataSource = dataTable;
                        Cargar_Total();
                        Subtotal();
                    }
                }
            }
            Clear();
            bloquearCampos(false);            
        }

        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Buscar_NombreProducto(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CultureInfo culturaNicaragua = new CultureInfo("es-NI");
                if (txtPrecioCompra.Text == "")
                {
                    Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", 0.00);
                }
                else
                {
                    Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", decimal.Parse(txtPrecioCompra.Text));
                }
            }
            catch (Exception ex)
            {
                txtPrecioCompra.Text = "";
                Lb_PrecioDescIVA.Text = "...";
            }
        }

        private void bloquearCampos(bool bandera)
        {
            GroupBox_Products.Enabled = bandera;
            Cbx_Productos.Enabled = bandera;
            TxtBuscar_Productos.Enabled = bandera;
            button1.Enabled = bandera;
        }

        private void Txt_IVA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_IVA.Text == "")
                {
                    Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", decimal.Parse(txtPrecioCompra.Text));
                }
                else if (decimal.TryParse(Txt_IVA.Text, out decimal tasaIVA))
                {
                    tasaIVA = tasaIVA / 100;

                    if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra))
                    {
                        decimal iva = precioCompra + (precioCompra * tasaIVA);

                        Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", iva);
                    }
                    else
                    {
                        MessageBox.Show("Precio de compra no válido");
                    }
                }
                else
                {
                    MessageBox.Show("Porcentaje de IVA no válido");
                }
            }
            catch (Exception ex)
            {
                //Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", decimal.Parse(txtPrecioCompra.Text));
            }
        }

        private void Txt_DescuentoProd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt_DescuentoProd.Text == "")
                {
                    Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", decimal.Parse(txtPrecioCompra.Text));
                }
                else if (decimal.TryParse(Txt_DescuentoProd.Text, out decimal decuento))
                {
                    decuento = decuento / 100;

                    if (decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra))
                    {
                        decimal desc = precioCompra - (precioCompra * decuento);

                        Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", desc);
                    }
                    else
                    {
                        MessageBox.Show("Precio de compra no válido");
                    }
                }
                else
                {
                    MessageBox.Show("Porcentaje de IVA no válido");
                }
            }
            catch (Exception ex)
            {
                //Lb_PrecioDescIVA.Text = string.Format(culturaNicaragua, "{0:C}", decimal.Parse(txtPrecioCompra.Text));
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
                if (Rbtn_Dolares.Checked == true)
                {
                    tipo_pago = "Dólares";
                }
                if (Rbtn_Cordobas.Checked == true)
                {
                    tipo_pago = "Córdobas";
                }
                //Insertar datos a las tablas
                Modelos.Compras compras = new Modelos.Compras();

                compras.Nombre_venderdor = txt_NombreProveedor.Text;
                compras.Subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
                if (Txt_DescuentoCompra.Text == "")
                {
                    descuento = "0.00";
                }
                else
                {
                    descuento = Txt_DescuentoCompra.Text;
                }
                compras.Descuento = double.Parse(descuento);
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
                        detalle_Compras.Iva = double.Parse(row.Cells[7].Value.ToString());
                        detalle_Compras.Descuento = double.Parse(row.Cells[8].Value.ToString());
                        detalle_Compras.Total = double.Parse(row.Cells[5].Value.ToString());
                        productos.Precio_venta = double.Parse(row.Cells[4].Value.ToString());
                        productos.Observacion = row.Cells[9].Value.ToString();

                        ctrlCompras.Productos_Comprados(detalle_Compras, productos);
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
                }
                else
                {
                    int id = int.Parse(cbProveedor.SelectedValue.ToString());
                    Controladores.CtrlProveedor ctrlProveedor = new CtrlProveedor();
                    Txt_RUC.Text = ctrlProveedor.RUC(id);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Txt_DescuentoCompra_TextChanged(object sender, EventArgs e)
        {
            double subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
            double total = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
            double desc;
            try
            {
                if (Txt_DescuentoCompra.Text == "")
                {
                    desc = 0.00;
                    Txt_DescuentoCompra.Text = "";
                    //Txt_TotalCompra.Text = subtotal.ToString();
                    Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", subtotal);
                }
                else
                {
                    desc = (double.Parse(Txt_DescuentoCompra.Text) / 100);

                    total = subtotal - (subtotal -(subtotal * desc));
                    //Txt_TotalCompra.Text = total.ToString();
                    Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", total);
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
    }
}
