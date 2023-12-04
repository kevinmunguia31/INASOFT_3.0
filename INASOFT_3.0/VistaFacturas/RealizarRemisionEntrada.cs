using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
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

namespace INASOFT_3._0.VistaFacturas
{
    public partial class RealizarRemisionEntrada : Form
    {
        public DataTable dataTable = new DataTable();
        public RealizarRemisionEntrada()
        {
            InitializeComponent();
            CargarProductos();
            Cargar_Tabla();

            Lb_NombreUsuario.Text = Sesion.nombre;
            GroupBox_Products.Enabled = false;
            Cbx_Productos.Visible = false;
            Lb_Producto.Visible = false;
            btnImportExcel.Visible = false;
            TxtBuscar_Productos.Visible = false;
            button1.Visible = false;
            
            radioButton1.Checked = true; datagridView2.Rows.Add("Total", "", "", "", "", 0, "", "");

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

        private void CargarProductos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProductoRemision();
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Lb_Fecha.Text = "Fecha: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Rbtn_NuevoProducto_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            GroupBox_Products.Enabled = true;
            Cbx_Productos.SelectedIndex = -1;
            Cbx_Productos.Visible = false;
            Lb_Producto.Visible = false;
            Txt_IDProd.Text = "0";
            txtNameP.Enabled = true;
            txtCodBarra.Enabled = true;
            radioButton2.Checked = true;
            GroupBox_CambioProd.Enabled = false;
            btnImportExcel.Visible = true;
            TxtBuscar_Productos.Visible = false;
            button1.Visible = false;
        }

        private void Rbtn_ActualizarProducto_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
            GroupBox_Products.Enabled = true;
            Cbx_Productos.SelectedIndex = -1;
            Cbx_Productos.Visible = true;
            Lb_Producto.Visible = true;
            txtNameP.Enabled = false;
            txtCodBarra.Enabled = false;
            radioButton1.Checked = true;
            GroupBox_CambioProd.Enabled = true;
            btnImportExcel.Visible = false;
            TxtBuscar_Productos.Visible = true;
            button1.Visible = true;
        }

        public void Limpiar()
        {
            txtNameP.Text = "";
            txtCodBarra.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtObservacion.Text = "";
            TxtCantidad.Text = "";
            Lb_CantStocks.Text = "--";
            TxtBuscar_Productos.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VistaProductos vistaProductos = new VistaProductos();
            vistaProductos.ShowDialog();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Productos.SelectedIndex == -1)
            {
                Limpiar();
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

                double existencias = productos.Existencias;
                
                Lb_CantStocks.ForeColor = existencias <= 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error o registrarla en un archivo de registro.
                // MessageBox.Show("Error: " + ex.Message);
            }
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
                Total = (float)Math.Round(Total, 2);
                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = "";
                datagridView2.Rows[0].Cells[5].Value = Total;
                datagridView2.Rows[0].Cells[6].Value = "";
                datagridView2.Rows[0].Cells[7].Value = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Btn_AddProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodBarra.Text) || string.IsNullOrEmpty(txtNameP.Text))
            {
                MessageBoxError.Show("Debe completar todos los campos solicitados", "Error");
                Limpiar();
                return;
            }

            if (TxtCantidad.Text == "")
            {
                MessageBoxError.Show("Debe indicar la cantidad", "Error");                
                return;
            }

            if (string.IsNullOrEmpty(txtPrecioVenta.Text) || string.IsNullOrEmpty(txtPrecioCompra.Text))
            {
                MessageBoxError.Show("No deje campos obligatorios sin marcar", "Error");                
                return;
            }

            if (double.Parse(txtPrecioCompra.Text) > double.Parse(txtPrecioVenta.Text))
            {
                MessageBoxError.Show("El precio de venta no puede ser menor al precio del que se compró el producto", "Error");
                return;
            }


            bool seRepite = dataGridView1.Rows.Cast<DataGridViewRow>().Any(fila => fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == txtCodBarra.Text);

            if (seRepite)
            {
                MessageBox_Import.Show("Ya se ha agregado ese producto. Puede editarlo o borrarlo si lo desea.", "Importante");
            }
            if(Rbtn_NuevoProducto.Checked == true)
            {
                Controladores.CtrlProductos ctrlProductos = new Controladores.CtrlProductos();
                if (ctrlProductos.EvaluacionCodigo(txtCodBarra.Text) == "Existe")
                {
                    MessageBoxError.Show("Éste código de producto ya está en uso", "Error");
                    return;
                }
                else
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow[0] = txtCodBarra.Text;
                    newRow[1] = txtNameP.Text.ToUpper();
                    newRow[2] = TxtCantidad.Text;
                    newRow[3] = double.Parse(txtPrecioCompra.Text);
                    newRow[4] = double.Parse(txtPrecioVenta.Text);
                    newRow[5] = double.Parse(txtPrecioVenta.Text) * double.Parse(TxtCantidad.Text);
                    newRow[6] = Txt_IDProd.Text;
                    newRow[7] = string.IsNullOrEmpty(txtObservacion.Text) ? $"Remisión de entrada del producto {txtNameP.Text}" : txtObservacion.Text;

                    dataTable.Rows.Add(newRow);

                    dataGridView1.DataSource = dataTable;
                    Cargar_Total();
                }
            }
            else
            {
                DataRow newRow = dataTable.NewRow();
                newRow[0] = txtCodBarra.Text;
                newRow[1] = txtNameP.Text;
                newRow[2] = TxtCantidad.Text;
                newRow[3] = double.Parse(txtPrecioCompra.Text);
                newRow[4] = double.Parse(txtPrecioVenta.Text);
                newRow[5] = double.Parse(txtPrecioVenta.Text) * double.Parse(TxtCantidad.Text);
                newRow[6] = Txt_IDProd.Text;
                newRow[7] = string.IsNullOrEmpty(txtObservacion.Text) ? $"Remisión de entrada del producto {txtNameP.Text}" : txtObservacion.Text;

                dataTable.Rows.Add(newRow);

                dataGridView1.DataSource = dataTable;
                Cargar_Total();
            }

            Limpiar();
            Rbtn_ActualizarProducto.Checked = false;
            Rbtn_NuevoProducto.Checked = false;
            Cbx_Productos.Visible = false;
            Lb_Producto.Visible = false;
            TxtBuscar_Productos.Visible = false;
            button1.Visible = false;
            Cbx_Productos.SelectedIndex = -1;
        }

        private void Cbx_Productos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Cbx_Productos.SelectedIndex == -1)
            {
                Limpiar();
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

                double existencias = productos.Existencias;
                Lb_CantStocks.ForeColor = existencias <= 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error o registrarla en un archivo de registro.
                // MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Realizar_remisión_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBoxError.Show("No se ha almacenado ningún producto, al menos guarde uno en la tabla.", "Error");
                return;
            }

            Controladores.CtrlRemision ctrl = new Controladores.CtrlRemision();
            Modelos.Remision remision = new Modelos.Remision();
            remision.Descripcion = string.IsNullOrWhiteSpace(TxtDescripcion.Text) ? "El usuario: " + Lb_NombreUsuario.Text + " ha realizado una remisión de entrada" : (TxtDescripcion.Text);
            remision.Id_Usuario = Sesion.id;
            remision.Tipo_Remision = "Remisión de Entrada";
            bool bandera = ctrl.RealizarRemesa(remision);

            if (bandera)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Modelos.Productos productos = new Modelos.Productos
                    {
                        Id = int.Parse(row.Cells[6].Value.ToString()),
                        Codigo = row.Cells[0].Value.ToString(),
                        Nombre = row.Cells[1].Value.ToString(),
                        Existencias = double.Parse(row.Cells[2].Value.ToString()),
                        Existencias_min = 1,
                        Precio_compra = double.Parse(row.Cells[3].Value.ToString()),
                        Precio_venta = double.Parse(row.Cells[4].Value.ToString()),
                        Observacion = row.Cells[7].Value.ToString(),
                        Id_remision = ctrl.ID_Remision()
                    };

                    ctrl.Remision_ProductosEntrada(productos);
                }

                MessageBox_Import.Show("Se ha realizado la remsión de manera exitosa", "Importante");
                CtrlInfo ctrlInfo = new CtrlInfo();
                string log = Sesion.nombre + " Genero una transacción de remisión de entrada";
                string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:ss:mm");
                ctrlInfo.InsertarLog(fecha, log);
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

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageDialogError.Show("¿Seguro que desea cargar los registros desde EXCEL?\n\n", "Importante");
            if (resultado == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos Excel|*.xls;*.xlsx|Todos los archivos|*.*";
                openFileDialog.Title = "Seleccionar archivo Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        SLDocument sl = new SLDocument(filePath);
                        SLWorksheetStatistics propiedades = sl.GetWorksheetStatistics();

                        int ultimafila = propiedades.EndRowIndex;

                        MySqlConnection conexionBD = Conexion.getConexion();
                        conexionBD.Open();

                        string error = "";
                        Controladores.CtrlRemision ctrl = new Controladores.CtrlRemision();
                        Modelos.Remision remision = new Modelos.Remision();
                        remision.Descripcion = "El usuario: " + Sesion.nombre + " ha realizado una remisión de entrada";
                        remision.Id_Usuario = Sesion.id;
                        remision.Tipo_Remision = "Remisión de Entrada";
                        bool bandera = ctrl.RealizarRemesa(remision);

                        for (int x = 2; x <= ultimafila; x++)
                        {
                            string codigo = sl.GetCellValueAsString("A" + x);

                            if (existeProducto(codigo))
                            {
                                error = "Ya hay productos con el mismo codigo " + codigo + "\n";
                            }
                            else
                            {
                                string sql = "CALL Detalle_RemisionEntrada(@Id, @Codigo, @Nombre, @Existencias, @ExistenciasMin, @PrecioCompra, @PrecioVenta, @Observacion, @IdRemision);";
                                try
                                {
                                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);

                                    // Agregar parámetros
                                    comando.Parameters.AddWithValue("@Id", 0);
                                    comando.Parameters.AddWithValue("@Codigo", sl.GetCellValueAsString("A" + x));
                                    comando.Parameters.AddWithValue("@Nombre", sl.GetCellValueAsString("B" + x));
                                    comando.Parameters.AddWithValue("@Existencias", sl.GetCellValueAsString("C" + x));
                                    comando.Parameters.AddWithValue("@ExistenciasMin", sl.GetCellValueAsString("D" + x));
                                    comando.Parameters.AddWithValue("@PrecioCompra", sl.GetCellValueAsString("E" + x));
                                    comando.Parameters.AddWithValue("@PrecioVenta", sl.GetCellValueAsString("F" + x));
                                    comando.Parameters.AddWithValue("@Observacion", sl.GetCellValueAsString("G" + x));
                                    comando.Parameters.AddWithValue("@IdRemision", ctrl.ID_Remision());
                                    comando.ExecuteNonQuery();
                                }
                                catch (MySqlException ex)
                                {
                                    //MessageBox.Show(sl.GetCellValueAsString("B" + x));
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        MessageBox_Import.Show("Plantilla Cargada Correctamente \n", "Aviso importante");
                        this.Close();
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show("Cierre el Archivo de Plantilla para poder Importar los datos", "Error Al Importar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {

            }
        }

        private bool existeProducto(string codigo)
        {
            MySqlConnection conexionBD = Conexion.getConexion();
            conexionBD.Open();
            string sql = "select id from productos WHERE codigo='" + codigo + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            int num = Convert.ToInt32(comando.ExecuteScalar());

            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TxtBuscar_Productos_TextChanged(object sender, EventArgs e)
        {
            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Buscar_NombreProductoRemision(TxtBuscar_Productos.Text);
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || Char.IsControl(e.KeyChar))
            {
                // Permite dígitos, un punto decimal y teclas de control (retroceso)
                e.Handled = false;
            }
            else
            {
                // Desactiva otras teclas
                e.Handled = true;
            }
        }
    }
}
