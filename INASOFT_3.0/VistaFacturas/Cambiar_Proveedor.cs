using DevExpress.XtraEditors;
using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
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
    public partial class Cambiar_Proveedor : Form
    {
        public DataTable dataTable = new DataTable();
        CultureInfo culturaNicaragua = new CultureInfo("es-NI");
        public Cambiar_Proveedor()
        {
            InitializeComponent();
            CargarProveedor();
            CargarProductos();
            CargarDatosIniciales();
            CargarDatosDataGridView();
            Cargar_Total();
        }

        private void CargarDatosIniciales()
        {
            GroupBox_Products.Enabled = false;
            Txt_RUC.Enabled = false;
            txtCodBarra.Enabled = false;
            txtNameP.Enabled = false;
            txtObservacion.Enabled = false;
            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;

            cbProveedor.SelectedIndex = -1;
            Cbx_Productos.Enabled = false;
            Cbx_Productos.SelectedIndex = -1;
        }

        private void CargarDatosDataGridView()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio Compra");
            dataTable.Columns.Add("Total");
            dataTable.Columns.Add("ID");

            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[5].Visible = false;

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            datagridView2.Rows.Add("Subtotal", "", "", "", 0, "");

            datagridView2.Columns[5].Visible = false;

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
        }

        public void Cargar_Total()
        {
            double Total = 0.00;

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Total += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                int numeroRedondeado = (int)Math.Ceiling(Total);
                datagridView2.Rows[0].Cells[0].Value = "Subtotal";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = numeroRedondeado;
                datagridView2.Rows[0].Cells[5].Value = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
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

        private void CargarProductos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProductoRemision();
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            txtCodBarra.Text = "";
            txtNameP.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtObservacion.Text = "";
            Cbx_Productos.SelectedIndex = -1;
            Lb_CantStocks.Text = "...";
            Txt_IDProd.Text = "";
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
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
                    TxtBuscar_Productos.Enabled = true;
                    button1.Enabled = true;

                    Cbx_Productos.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Btn_AddProducto_Click(object sender, EventArgs e)
        {
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
                newRow[2] = Lb_CantStocks.Text.ToString();
                newRow[3] = double.Parse(txtPrecioCompra.Text);
                newRow[4] = double.Parse(txtPrecioCompra.Text) * int.Parse(Lb_CantStocks.Text.ToString());
                newRow[5] = TxtIDProducto.Text;

                dataTable.Rows.Add(newRow);

                dataGridView1.DataSource = dataTable;
                Cargar_Total();

            }

            Clear();
            Cbx_Productos.SelectedIndex = -1;
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

                TxtIDProducto.Text = id.ToString();

                Productos productos = new Productos();
                productos = ctrlProductos.MostrarDatosProductos(id);

                txtCodBarra.Text = productos.Codigo.ToString();
                txtNameP.Text = productos.Nombre;
                Lb_CantStocks.Text = productos.Existencias.ToString();
                txtPrecioVenta.Text = productos.Precio_venta.ToString();
                txtPrecioCompra.Text = productos.Precio_compra.ToString();
                txtObservacion.Text = productos.Observacion.ToString();

                int existencias = productos.Existencias;
                GroupBox_Products.Enabled = true;
                //errorProvider1.SetError(Lb_CantStocks, existencias <= 0 ? "Ya no hay productos en el almacén." : "");
                Lb_CantStocks.ForeColor = existencias <= 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error o registrarla en un archivo de registro.
                // MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Btn_RealizarCompra_Click(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount == 0)
            {
                MessageBoxError.Show("No se ha almacenado ningún producto, al menos guarde uno en la tabla.", "Error");
                return;
            }

            //Insertar datos a las tablas
            Modelos.Compras compras = new Modelos.Compras
            {
                Nombre_venderdor = "--",
                Subtotal = double.Parse(datagridView2.Rows[0].Cells[4].Value.ToString()),
                Descuento = 0.00,
                Iva = 0.00,
                Descripcion = "--",
                Estado = "--",
                Id_TipoPago = 1,
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
                        Id = int.Parse(row.Cells[5].Value.ToString()),
                        Existencias = int.Parse(row.Cells[2].Value.ToString()),
                        Id_proveedor = int.Parse(cbProveedor.SelectedValue.ToString()),
                        Id_Compra = ctrlCompras.ID_Compra()
                    };

                    ctrlCompras.CambiarProveedorProducto(productos);
                }

                MessageBox_Import.Show("Se ha realizado el proveedor del producto", "Importante");
                CtrlInfo ctrlInfo = new CtrlInfo();
                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Cambio el proveedor de los productos mediante la compra : " + compras.Descripcion;
                ctrlInfo.InsertarLog(log);
                this.Close();
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

        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Buscar_NombreProductoRemision(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }
    }
}
