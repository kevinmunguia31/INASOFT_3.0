using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.VistaFacturas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Productos : UserControl
    {
        public UC_Productos()
        {
            InitializeComponent();
            CargarTablaProduct();
            Cargar_Compras();
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            lbCapital.Text = ctrlProductos.CapitalInvertido();
            lbCantiTota.Text = ctrlProductos.TotalProductos();
            dataGridView1.Columns[10].Visible = false;

            dataGridView2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }
            foreach (DataGridViewBand band in dataGridView2.Columns)
            {
                band.ReadOnly = true;
            }
        }

        public void Cargar_Compras()
        {
            Controladores.CtrlCompras ctrlCompras = new Controladores.CtrlCompras();
            dataGridView2.DataSource = ctrlCompras.CargarCompras();
        }

        //Cargar el dataGridView
        public void CargarTablaProduct()
        {
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.CargarProductos();
        }

        //Buscador de productos
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.BuscarProducto(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Agregar_Producto frm = new Agregar_Producto();
            frm.ShowDialog();
        }

        public void Limpiar()
        {
            lbCodigo.Text = "...";
            lbNameP.Text = "...";
            lbExistencias.Text = "...";
            lbPrecioCompra.Text = "...";
            lbPrecioVenta.Text = "...";
            lbPrecioTotal.Text = "...";
            lbObservaciones.Text = "...";
            lbProveedor.Text = "...";
        }

        private void menuClick_Opciones(object sender, ToolStripItemClickedEventArgs e)
        {
            string id_pos = e.ClickedItem.Name.ToString();

            if (id_pos.Contains("Borrar"))
            {
                id_pos = id_pos.Replace("Borrar", "");
                Eliminar_Producto(int.Parse(id_pos));
                Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
                lbCapital.Text = ctrlProductos.CapitalInvertido();
                lbCantiTota.Text = ctrlProductos.TotalProductos();
            }

            if (id_pos.Contains("Editar"))
            {
                id_pos = id_pos.Replace("Editar", "");
                Editar_Producto(int.Parse(id_pos));
                Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
                lbCapital.Text = ctrlProductos.CapitalInvertido();
                lbCantiTota.Text = ctrlProductos.TotalProductos();
            }
        }

        private void Editar_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    string id = dataGridView1.Rows[id_pos].Cells[0].Value.ToString();
                    string codigo = dataGridView1.Rows[id_pos].Cells[1].Value.ToString();
                    string nombre = dataGridView1.Rows[id_pos].Cells[2].Value.ToString();
                    string estado = dataGridView1.Rows[id_pos].Cells[3].Value.ToString();
                    string existencia = dataGridView1.Rows[id_pos].Cells[4].Value.ToString();

                    string aux1 = dataGridView1.Rows[id_pos].Cells[5].Value.ToString();
                    string[] words1 = aux1.Split(' ');
                    string aux_PrecioCompra = words1[1];
                    string precio_compra = aux_PrecioCompra;

                    string aux2 = dataGridView1.Rows[id_pos].Cells[6].Value.ToString();
                    string[] words2 = aux2.Split(' ');
                    string aux_PrecioVenta = words2[1];

                    string precio_venta = aux_PrecioVenta;
                    string observaciones = dataGridView1.Rows[id_pos].Cells[8].Value.ToString();
                    
                    Ver_EditarProducto update = new Ver_EditarProducto();
                    //update.labelTitle.Text = "Editar producto";
                    update.txtCodBarra.Text = codigo;
                    update.txtNameP.Text = nombre;
                    update.SpinExist.Value = int.Parse(existencia);
                    update.txtPrecioCompra.Text = precio_compra;
                    update.txtPrecioVenta.Text = precio_venta;
                    update.txtObservacion.Text = observaciones;
                    update.Cbx_Estados.SelectedItem = estado;
                    update.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void Eliminar_Producto(int id_pos)
        {
            try
            {
                if (id_pos > -1 && id_pos != null)
                {
                    bool bandera = false;
                    DialogResult resultado = MessageDialog.Show("Seguro que desea eliminar el registro?", "Eliminar");
                    if (resultado == DialogResult.Yes)
                    {
                        int id = int.Parse(dataGridView1.Rows[id_pos].Cells[0].Value.ToString());
                        CtrlProductos _ctrl = new CtrlProductos();
                        bandera = _ctrl.Eliminar(id);
                        if (bandera)
                        {
                            MessageDialogInfo.Show("Registro Eliminado con exito", "Aviso");
                            CargarTablaProduct();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }

        private void Bttn_Info_Click(object sender, EventArgs e)
        {
            MessageBox_Import.Show(
             "1. Tiene la opción de ver todos los productos que hay en el almacén.\n" +
             "2. Tiene la función de buscar un producto determinado ya sea por su nombre o por su código.\n" +
             "3. Puede agregar, editar y eliminar un producto si desea hacerlo." +
             "\n", "¿Cómo funciona este apartado?");
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            CargarTablaProduct();
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            lbCapital.Text = ctrlProductos.CapitalInvertido();
            lbCantiTota.Text = ctrlProductos.TotalProductos();
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Index == 4)
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (Convert.ToInt32(e.Value) > 0)
                        {
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.White;
                        }
                        else
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            CultureInfo culturaLocal = new CultureInfo("es-NI");
            if (e.Button == MouseButtons.Left)
            {
                int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1 && pos != null)
                {
                    txtID.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
                    lbCodigo.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
                    lbNameP.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
                    //lbNameP.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
                    if (int.Parse(dataGridView1.Rows[pos].Cells[4].Value.ToString()) > 0)
                    {
                        lbExistencias.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
                        lbExistencias.ForeColor = Color.Black;
                    }
                    else
                    {
                        lbExistencias.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
                        lbExistencias.ForeColor = Color.Red;
                    }
                    lbObservaciones.Text = dataGridView1.Rows[pos].Cells[8].Value.ToString();
                    lbProveedor.Text = dataGridView1.Rows[pos].Cells[9].Value.ToString();
                    groupBox_Detalle.Text = "Producto " + dataGridView1.Rows[pos].Cells[2].Value.ToString();

                    lbPrecioCompra.Text = dataGridView1.Rows[pos].Cells[5].Value.ToString();                    

                    lbPrecioVenta.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();

                    lbPrecioTotal.Text = dataGridView1.Rows[pos].Cells[7].Value.ToString();
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                int pos = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (pos > -1)
                {
                    menu.Items.Add("Borrar").Name = "Borrar" + pos;
                    menu.Items.Add("Editar").Name = "Editar" + pos;
                }
                menu.Show(dataGridView1, e.X, e.Y);
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menuClick_Opciones);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
