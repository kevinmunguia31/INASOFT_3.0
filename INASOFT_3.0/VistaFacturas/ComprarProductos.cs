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
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace INASOFT_3._0
{
    public partial class ComprarProductos : Form
    {
        public DataTable dataTable = new DataTable();
        CultureInfo culturaNicaragua = new CultureInfo("es-NI");
        protected double aux_DescIVA;

        public ComprarProductos()
        {
            Controladores.CtrlCompras ctrlCompras = new Controladores.CtrlCompras();
            InitializeComponent();
            CargarProveedor();
            CargarTiposPagos();
            Cargar_Tabla();
            Clear();

            Lb_NombreUsuario.Text = Sesion.nombre;
            GroupBox_Products.Enabled = false;            
            Txt_RUC.Enabled = false;
            Txt_TotalCompra.Enabled = false;
            Txt_RUC.Enabled = false;
            cbProveedor.SelectedIndex = -1;
            Lb_ID_compra.Text = ctrlCompras.NumeroCompra().ToString();

            Cbx_Productos.Visible = false;
            Lb_Producto.Visible = false;


            datagridView2.Rows.Add("Total", "", "", "", "", 0, "", "");

            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            datagridView2.Columns[6].Visible = false;
            datagridView2.Columns[7].Visible = false;

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
            Cargar_Total();
            if (dataGridView1.RowCount == 0)
            {
                groupBox7.Enabled = false;
            }
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

        public void CargarTiposPagos()
        {
            CbxTipoPagos.DataSource = null;
            CbxTipoPagos.Items.Clear();

            Controladores.CtrlTipo_Pago ctrl = new Controladores.CtrlTipo_Pago();
            CbxTipoPagos.DataSource = ctrl.Cargar_Tipos_Pago();
            CbxTipoPagos.ValueMember = "ID";
            CbxTipoPagos.DisplayMember = "Tipos";
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
            Lb_CantStocks.Text = "...";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            Txt_IDProd.Text = "";
        }

        private void Rbtn_TipoDolares_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            GroupBox_Products.Enabled = true;
            Cbx_Productos.SelectedIndex = -1;
            Cbx_Productos.Enabled = false;
            Cbx_Productos.Visible = false;
            Lb_Producto.Visible = false;
            txtNameP.Enabled = true;
            txtCodBarra.Enabled = true;
            GroupBox_CambioProd.Enabled = false;
            radioButton2.Checked = true;
            Txt_IDProd.Text = "0";
        }

        private void Rbtn_TipoCordobas_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            GroupBox_Products.Enabled = true;
            Cbx_Productos.SelectedIndex = -1;
            Cbx_Productos.Enabled = true;
            Cbx_Productos.Visible = true;
            Lb_Producto.Visible = true;
            txtCodBarra.Enabled = false;
            txtNameP.Enabled = false;
            GroupBox_CambioProd.Enabled = true;
            radioButton1.Checked = true;
            cbProveedor.Enabled = true;
            Txt_IDProd.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lb_Fecha.Text = "Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Productos.SelectedIndex == -1)
            {
                Clear();
                return;
            }

            try
            {
                int id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                Txt_IDProd.Text = id.ToString();

                Productos productos = new Productos();
                productos = ctrlProductos.MostrarDatosProductos(id);

                txtCodBarra.Text = productos.Codigo.ToString();
                txtNameP.Text = productos.Nombre;
                Lb_CantStocks.Text = productos.Existencias.ToString();
                txtPrecioVenta.Text = productos.Precio_venta.ToString();
                txtPrecioCompra.Text = productos.Precio_compra.ToString();
                txtObservacion.Text = productos.Observacion.ToString();

                int existencias = productos.Existencias;
                //errorProvider1.SetError(Lb_CantStocks, existencias <= 0 ? "Ya no hay productos en el almacén." : "");
                Lb_CantStocks.ForeColor = existencias <= 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error o registrarla en un archivo de registro.
                // MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Btn_AddProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodBarra.Text) || string.IsNullOrEmpty(txtNameP.Text))
            {
                MessageBoxError.Show("Debe completar todos los campos solicitados", "Error");
                Clear();
                return;
            }

            if (SpinExist.Value == 0)
            {
                MessageBoxError.Show("Debe indicar la cantidad", "Error");
                errorProvider1.SetError(SpinExist, "Debe indicar la cantidad que desea facturar");
                return;
            }

            if (string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                MessageBoxError.Show("No deje campos obligatorios sin marcar", "Error");
                errorProvider1.SetError(txtPrecioVenta, "Debe indicar el precio del producto");
                return;
            }

            if (double.Parse(txtPrecioCompra.Text) > double.Parse(txtPrecioVenta.Text))
            {
                MessageBoxError.Show("El precio de venta no puede ser menor al precio del que se compró el producto", "Error");
                return;
            }

            errorProvider1.SetError(txtPrecioVenta, "");
            errorProvider1.SetError(SpinExist, "");

            bool seRepite = dataGridView1.Rows.Cast<DataGridViewRow>().Any(fila => fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == txtCodBarra.Text);

            if (seRepite)
            {
                MessageBox_Import.Show("Ya se ha agregado ese producto. Puede editarlo o borrarlo si lo desea.", "Importante");
            }
            else
            {
                DataRow newRow = dataTable.NewRow();
                newRow[0] = txtCodBarra.Text;
                newRow[1] = txtNameP.Text.ToUpper();
                newRow[2] = SpinExist.Value.ToString();
                newRow[3] = double.Parse(txtPrecioCompra.Text);
                newRow[4] = double.Parse(txtPrecioVenta.Text);
                newRow[5] = double.Parse(txtPrecioVenta.Text) * int.Parse(SpinExist.Value.ToString());
                newRow[6] = Txt_IDProd.Text;
                newRow[7] = string.IsNullOrEmpty(txtObservacion.Text) ? $"Compra del producto {txtNameP.Text}" : txtObservacion.Text;

                dataTable.Rows.Add(newRow);

                dataGridView1.DataSource = dataTable;
                Cargar_Total();
                Subtotal();

                groupBox7.Enabled = dataGridView1.RowCount > 0;
            }

            Clear();
            Rbtn_ActualizarProducto.Checked = false;
            Rbtn_NuevoProducto.Checked = false;
            GroupBox_Products.Enabled = false;
            Cbx_Productos.Visible = false;
            Lb_Producto.Visible = false;
            Cbx_Productos.SelectedIndex = -1;
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
                        //MessageBox.Show(id_pos.ToString());
                        dataGridView1.Rows.RemoveAt(id_pos);
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
            if (cbProveedor.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt_NombreProveedor.Text))
            {
                MessageBoxError.Show("No deje los datos del proveedor sin rellenar", "Error");
                return;
            }

            if (CbxTipoPagos.SelectedIndex == -1)
            {
                MessageBoxError.Show("Tiene que indicar el tipo de pago", "Error");
                return;
            }

            if (!Rbtn_Pendiente.Checked && !Rbtn_Cancelado.Checked)
            {
                MessageBoxError.Show("Tiene que indicar el estado de la compra", "Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(Txt_Descripcion.Text))
            {
                MessageBoxError.Show("Tienes que indicar la referencia", "Error");
                return;
            }

            if (dataGridView1.RowCount == 0)
            {
                MessageBoxError.Show("No se ha almacenado ningún producto, al menos guarde uno en la tabla.", "Error");
                return;
            }

            string estado = Rbtn_Cancelado.Checked ? "Cancelado" : "Pendiente";
            double descuento = string.IsNullOrWhiteSpace(Txt_DescuentoCompra.Text) ? 0 : double.Parse(Txt_DescuentoCompra.Text);
            double iva = string.IsNullOrWhiteSpace(Txt_IVACompra.Text) ? 0 : double.Parse(Txt_IVACompra.Text);

            //Insertar datos a las tablas
            Modelos.Compras compras = new Modelos.Compras
            {
                Nombre_venderdor = txt_NombreProveedor.Text,
                Subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString()),
                Descuento = descuento,
                Iva = iva,
                Descripcion = Txt_Descripcion.Text,
                Estado = estado,
                Id_TipoPago = int.Parse(CbxTipoPagos.SelectedValue.ToString()),
                Id_usuario = Sesion.id,
                Id_proveedor = int.Parse(cbProveedor.SelectedValue.ToString())
            };

            Controladores.CtrlCompras ctrlCompras = new Controladores.CtrlCompras();
            bool bandera = ctrlCompras.Insertar_Compra(compras);

            if (bandera)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Modelos.Productos productos = new Modelos.Productos
                    {
                        Id = int.Parse(row.Cells[6].Value.ToString()),
                        Codigo = row.Cells[0].Value.ToString(),
                        Nombre = row.Cells[1].Value.ToString(),
                        Existencias = int.Parse(row.Cells[2].Value.ToString()),
                        Existencias_min = 1,
                        Precio_compra = double.Parse(row.Cells[3].Value.ToString()),
                        Precio_venta = double.Parse(row.Cells[4].Value.ToString()),
                        Observacion = row.Cells[7].Value.ToString(),
                        Id_Compra = ctrlCompras.ID_Compra()                    
                    };
                    
                    ctrlCompras.Productos_Comprados(productos);
                }

                MessageBox_Import.Show("Se ha realizado la compra de manera exitosa", "Importante");
                CtrlInfo ctrlInfo = new CtrlInfo();
                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero una orden de compra con referencia: " + compras.Descripcion;
                ctrlInfo.InsertarLog(log);
                this.Close();
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
                    Cbx_Productos.SelectedIndex = -1;
                }
                else
                {
                    int id = int.Parse(cbProveedor.SelectedValue.ToString());
                    Controladores.CtrlProveedor ctrlProveedor = new CtrlProveedor();
                    Txt_RUC.Text = ctrlProveedor.RUC(id);
                    Cbx_Productos.Enabled = true;                    
                    CargarProductos(id);
                    Cbx_Productos.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CalcularTotal()
        {
            double subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
            double total = 0.00;

            double desc, iva;

            if (string.IsNullOrWhiteSpace(Txt_DescuentoCompra.Text))
            {
                desc = 0.00;
            }
            else
            {
                desc = (double.Parse(Txt_DescuentoCompra.Text) / 100);
            }

            if (string.IsNullOrWhiteSpace(Txt_IVACompra.Text))
            {
                iva = 0.00;
            }
            else
            {
                iva = (double.Parse(Txt_IVACompra.Text) / 100);
            }

            // Calcular el total aplicando el descuento primero y luego el IVA
            total = (subtotal - (subtotal * desc)) * (1 + iva);

            // Formatea el total con descuento e IVA como moneda
            Txt_TotalCompra.Text = string.Format(culturaNicaragua, "{0:C}", total);
            aux_DescIVA = total;
        }

        private void Txt_DescuentoCompra_TextChanged(object sender, EventArgs e)
        {
            /*
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
            */
            CalcularTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VistaProductos vistaProductos = new VistaProductos();
            vistaProductos.ShowDialog();
        }

        private void Txt_IVACompra_TextChanged(object sender, EventArgs e)
        {
            /*   double subtotal = double.Parse(datagridView2.Rows[0].Cells[5].Value.ToString());
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
               }*/
            CalcularTotal();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioCompra.Enabled = true;
            txtPrecioVenta.Enabled = true;
        }
    }
}
