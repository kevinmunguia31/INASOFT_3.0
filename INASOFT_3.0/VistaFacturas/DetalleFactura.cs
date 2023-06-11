using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
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
        public DetalleFactura()
        {
            InitializeComponent();
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            lbIdFactura.Text = (int.Parse(ctrlFactura.ID_Factura().ToString()) + 1).ToString();
            txtIdFactura.Text = (int.Parse(ctrlFactura.ID_Factura().ToString()) + 1).ToString();

            Cargar_Productos();
            Cbx_Productos.SelectedIndex = -1;
            cargar_tabla();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            ctrlFactura.Cancelar_Factura(ctrlFactura.ID_Factura());
            this.Dispose();
        }
        /*
        public void obtenerIDFactura()
        {
            string dato = txtIdCliente.Text;
            MySqlDataReader reader = null;
            string consulta = "SELECT ID FROM facturas WHERE id_cliente='" + dato + "'";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lbIdFactura.Text = reader.GetString("id");
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error Al Buscar: " + ex.Message);
            }
            finally { conexionBD.Close(); }
        }
        */
        public void cargar_tabla()
        {
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");

            dataGridView1.DataSource = dataTable;
        }
        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            //List<Modelos.Detalle_Factura> personas = new List<Modelos.Detalle_Factura>();

            // Crea una nueva fila y asigna los valores de las columnas
            DataRow newRow = dataTable.NewRow();
            newRow[0] = txtIdProduc.Text;
            newRow[1] = lbProductName.Text;
            newRow[2] = SpinCantidad.Value.ToString();
            newRow[3] = txtPrecio.Text;
            newRow[4] = double.Parse(txtPrecio.Text) * int.Parse(SpinCantidad.Value.ToString());
            // Asigna valores a las demás columnas de la fila según sea necesario

            // Agrega la fila al DataTable
            dataTable.Rows.Add(newRow);

            // Asigna el DataTable como origen de datos del DataGridView
            dataGridView1.DataSource = dataTable;
            limpiar();
            /*string sql = "CALL Facturar_Productos('" + SpinCantidad.Value + "','" + txtPrecio.Text + "','" + txtIdProduc.Text + "','" + txtIdFactura.Text + "')";
            try
            {

                if (lbProductName.Text != "" && txtPrecio.Text != "" && txtIdProduc.Text != "" && SpinCantidad.Value !=  0)
                {
                    if (lbExistencias.Text != "0")
                    {
                        MySqlConnection conexioBD = Conexion.getConexion();
                        conexioBD.Open();
                        MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                        comando.ExecuteNonQuery();
                        MessageDialogInfo.Show("Produsctos Agregados a la Factura", "AVISO");

                        //Agregar a la tabla
                        ListaProductos[fila, 0] = lbProductName.Text;
                        ListaProductos[fila, 1] = txtPrecio.Text;
                        ListaProductos[fila, 2] = SpinCantidad.Value.ToString();
                        ListaProductos[fila, 3] = (float.Parse(SpinCantidad.Value.ToString()) * float.Parse(txtPrecio.Text)).ToString();
                        ListaProductos[fila, 4] = txtIdProduc.Text;
                        dataGridView1.Rows.Add(ListaProductos[fila, 0], ListaProductos[fila, 1], ListaProductos[fila, 2], ListaProductos[fila, 3], ListaProductos[fila, 4]);
                        //AUMENTA LA FILA EN LA TABLA
                        fila++;
                        lbProductName.Text = txtPrecio.Text = lbExistencias.Text = txtIdProduc.Text = "";
                        Cbx_Productos.SelectedIndex = -1;
                        SpinCantidad.Value = 0;
                    }
                    else
                    {
                        MessageDialogError.Show("No hay existencias de este producto", "AVISO");
                    }

                }
                else
                {
                    MessageDialogWar.Show("Verifique la Cantidad del Producto", "AVISO");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            */
            Subtotal();
        }

        public void limpiar()
        {
            txtPrecio.Text = "";
            lbExistencias.Text = "";
            lbProductName.Text = "";
            Cbx_Productos.SelectedIndex = -1;
        }
        public void Subtotal()
        {
            float subtotal = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                subtotal += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            lbSubtotal.Text = subtotal.ToString();
        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            int id_producto = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            int cantidad = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            string sql = "CALL Eliminar_Producto_Facturado('" + txtIdDetalleFactura.Text + "','" + id_producto + "','" + cantidad + "')";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                MessageDialogInfo.Show("Se elimino el Producto Seleccionado", "AVISO");
                if (dataGridView1.CurrentRow == null)
                    return;
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                txtIdDetalleFactura.Text = "";
                Subtotal();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            int id = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            MySqlDataReader reader = null;
            string consulta = "SELECT id FROM detalle_factura WHERE id_producto='" + id + "'";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIdDetalleFactura.Text = reader.GetString("id");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron Productos Con ese Codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error Al Buscar: " + ex.Message);
            }
            finally { conexionBD.Close(); }
        */
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            int id = int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            MySqlDataReader reader = null;
            string consulta = "SELECT ID FROM Detalle_Factura WHERE ID_Producto='" + id + "'";
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtIdDetalleFactura.Text = reader.GetString("id");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron Productos Con ese Codigo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error Al Buscar: " + ex.Message);
            }
            finally { conexionBD.Close(); }
            */
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Today.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString();
            string hora = DateTime.Now.ToString("hh:mm:ss");
            string Fecha_final = fecha + " " + hora;
            string user = Sesion.id.ToString();




            string sql = "CALL Insertar_Factura('" + Fecha_final + "', '" + user + "', '" + txtIdCliente.Text + "');";

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            int id_factura = ctrlFactura.ID_Factura();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                //MessageBox.Show(int.Parse(row.Cells[2].Value.ToString())+ ", " + double.Parse(row.Cells[3].Value.ToString()) + ", " + int.Parse(row.Cells[0].Value.ToString()) + ", "+ id_factura);
                string sql_1 = "CALL Facturar_Productos(" + int.Parse(row.Cells[2].Value.ToString()) + ", " + double.Parse(row.Cells[3].Value.ToString()) + ", " + int.Parse(row.Cells[0].Value.ToString()) + ", " + id_factura + ")";

                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql_1, conexioBD);
                comando.ExecuteNonQuery();
            }

            MessageDialogInfo.Show("Produsctos Agregados a la Factura", "AVISO");
            FacturaFinal frm = new FacturaFinal();
            frm.lbIdFactura.Text = lbIdFactura.Text;
            frm.lbNombreCliente.Text = lbClienteName.Text;
            frm.lbSubtotal.Text = lbSubtotal.Text;
            frm.txtIdCliente.Text = txtIdCliente.Text;
            frm.lbTotal.Text = lbSubtotal.Text;
            frm.ShowDialog();
            this.Dispose();
        }

        string[,] ListaProductos = new string[200, 10];
        int fila = 0;

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
                    txtIdProduc.Text = "";
                }
                else
                {
                    txtIdProduc.Text = Cbx_Productos.SelectedValue.ToString();
                    int id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                    //MessageBox.Show(txtIdProduc.Text);
                    Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
                    lbProductName.Text = ctrlProductos.Nombre_Producto(id);
                    lbExistencias.Text = ctrlProductos.Existencias_Producto(id).ToString();
                    txtPrecio.Text = ctrlProductos.Precio_Producto(id).ToString();

                    SpinCantidad.Value = Convert.ToDecimal(lbExistencias.Text);

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Cargar_Productos();
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
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
                    DialogResult resultado = MessageBox.Show("Seguro que desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        MessageBox.Show(id_pos.ToString());
                        if (id_pos >= 0 && id_pos < dataGridView1.Rows.Count)
                        {
                            // Eliminar la fila del DataGridView
                            //dataGridView1.Rows.RemoveAt(id_pos);
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex, "Error");
            }
        }
    }
}

 