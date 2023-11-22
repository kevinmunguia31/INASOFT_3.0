using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class RealizarRemisionSalida : Form
    {
        private string lbUser;
        private string lbNombreNegocio;
        private string lbDireccionNegocio;
        private string lbNmRUC;
        private string lbTelefono;

        public DataTable dataTable = new DataTable();
        public RealizarRemisionSalida()
        {
            InitializeComponent();
            Cargar_CbxProductos();
            CargarDataGridView();
        }

        private void CargarDataGridView()
        {
            dataTable.Columns.Add("Código");
            dataTable.Columns.Add("Nombre Producto");
            dataTable.Columns.Add("Cantidad");
            dataTable.Columns.Add("Precio");
            dataTable.Columns.Add("Total");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Descripcion");

            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            datagridView2.Columns[5].Visible = false;

            foreach (DataGridViewBand band in dataGridView1.Columns)
            {
                band.ReadOnly = true;
            }

            datagridView2.Rows.Add("Total", "", "", "", 0, "", "");

            foreach (DataGridViewBand band in datagridView2.Columns)
            {
                band.ReadOnly = true;
            }
        }

        private void Cargar_CbxProductos()
        {
            Cbx_Productos.DataSource = null;
            Cbx_Productos.Items.Clear();

            Controladores.CtrlProductos ctrl = new Controladores.CtrlProductos();
            Cbx_Productos.DataSource = ctrl.Cargar_NombreProductoActivo("");
            Cbx_Productos.ValueMember = "ID";
            Cbx_Productos.DisplayMember = "Nombre";
        }

        private void Cbx_Productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (Cbx_Productos.SelectedIndex == -1)
                {
                    Limpiar();
                    SpinCantidad.Enabled = false;// Si no hay selección, desactiva SpinCantidad
                    id = 0;
                    return; // Salir del método ya que no hay selección válida
                }
                else
                {
                    id = int.Parse(Cbx_Productos.SelectedValue.ToString());
                    Controladores.CtrlProductos ctrlProductos = new CtrlProductos();

                    Productos productos = ctrlProductos.MostrarDatosProductos(id);

                    txtIdProduc.Text = id.ToString();
                    lbCodProdu.Text = productos.Codigo.ToString();
                    lbProductName.Text = LimitarLongitud(productos.Nombre, 30);
                    lbExistencias.Text = productos.Existencias.ToString();
                    Lb_Precio_Compra.Text = productos.Precio_compra.ToString();
                    Lb_Observacion.Text = LimitarLongitud(productos.Observacion.ToString(), 30);

                    lbExistencias.ForeColor = (int.Parse(lbExistencias.Text) <= 0) ? Color.Red : Color.Black;

                    SpinCantidad.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                //MessageBox.Show("Error: " + ex);
            }
        }

        private string LimitarLongitud(string input, int maxLength)
        {
            if (input.Length > maxLength)
            {
                return input.Substring(0, maxLength) + "...";
            }
            return input;
        }

        public void Limpiar()
        {
            Lb_Precio_Compra.Text = "...";
            lbExistencias.Text = "...";
            lbProductName.Text = "...";
            Cbx_Productos.SelectedIndex = -1;
            SpinCantidad.Value = 0;
            lbCodProdu.Text = "...";
            txtIdProduc.Text = "";
            TxtBuscar_Productos.Text = "";
            Lb_Observacion.Text = "...";
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
                datagridView2.Rows[0].Cells[0].Value = "Total";
                datagridView2.Rows[0].Cells[1].Value = "";
                datagridView2.Rows[0].Cells[2].Value = "";
                datagridView2.Rows[0].Cells[3].Value = "";
                datagridView2.Rows[0].Cells[4].Value = numeroRedondeado;

                lbSubtotal.Text = numeroRedondeado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT nombre_negocio, direccion_negocio, num_ruc, telefono FROM infogeneral";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lbNombreNegocio = reader.GetString("nombre_negocio");
                        lbDireccionNegocio = reader.GetString("direccion_negocio");
                        lbNmRUC = reader.GetString("num_ruc");
                        lbTelefono = reader.GetString("telefono");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            if (Cbx_Productos.SelectedIndex == -1)
            {
                MessageBoxError.Show("Tiene que escoger un producto a devolver", "Error");
                Limpiar();
                return; // Salir del método si no se ha seleccionado un producto.
            }

            if (SpinCantidad.Value == 0)
            {
                MessageBoxError.Show("Tiene que indicar la cantidad.", "Error");
                return; // Salir del método si la cantidad es cero.
            }

            if (lbExistencias.Text == "0" || lbCodProdu.Text == "..." || lbProductName.Text == "...")
            {
                MessageBoxError.Show("No ha seleccionado un producto a devolver.", "Error");
                return; // Salir del método si hay problemas con el producto.
            }

            bool seRepite = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Any(fila => fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == lbCodProdu.Text);

            if (seRepite)
            {
                MessageBox_Import.Show("Ya se agregó ese producto, puede borrarlo si desea.", "Importante");
                Limpiar();
                return; // Salir del método si el producto ya está en la lista.
            }

            if (SpinCantidad.Value > int.Parse(lbExistencias.Text))
            {
                MessageBoxError.Show("No hay esa cantidad en el Stock.", "Errir");
                Limpiar();
                return;
            }

            int id = int.Parse(txtIdProduc.Text);
            Controladores.CtrlProductos ctrlProductos = new CtrlProductos();
            Productos productos = ctrlProductos.MostrarDatosProductos(id);

            DataRow newRow = dataTable.NewRow();
            newRow[0] = productos.Codigo.ToString();
            newRow[1] = productos.Nombre.ToString();
            newRow[2] = SpinCantidad.Value.ToString();
            newRow[3] = double.Parse(Lb_Precio_Compra.Text);
            newRow[4] = double.Parse(Lb_Precio_Compra.Text) * int.Parse(SpinCantidad.Value.ToString());
            newRow[5] = int.Parse(Cbx_Productos.SelectedValue.ToString());

            dataTable.Rows.Add(newRow);

            dataGridView1.DataSource = dataTable;
            Limpiar();
            Cargar_Total();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            CtrlInfo ctrlInfo = new CtrlInfo();
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();

            Remision remision = new Remision();
            //remision.Descripcion = Txt_Descripcion.Text;
            remision.Descripcion = string.IsNullOrWhiteSpace(TxtDescripcion.Text) ? "El usuario: " + Sesion.nombre + " ha realizado una remisión de salida" : TxtDescripcion.Text;
            remision.Id_Usuario = Sesion.id;
            remision.Tipo_Remision = "Remisión de Salida";

            CtrlRemision ctrlRemision = new CtrlRemision();
            bool bandera = ctrlRemision.RealizarRemesa(remision);

            if (bandera)
            {
                List<Modelos.Productos> lista = new List<Modelos.Productos>();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        Modelos.Productos productos = new Modelos.Productos
                        {
                            Id = int.Parse(fila.Cells[5].Value.ToString()),
                            Nombre = fila.Cells[1].Value.ToString(),
                            Existencias = int.Parse(fila.Cells[2].Value.ToString()),
                            Id_remision = ctrlRemision.ID_Remision()
                        };
                        lista.Add(productos);
                    }
                }

                foreach (Modelos.Productos productos1 in lista)
                {
                    ctrlRemision.Remision_ProductosSalida(productos1);
                }

                MessageBox_Import.Show("Se ha realizado la remsión de manera exitosa", "Importante");

                string log = "[" + DateTime.Now + "] " + Sesion.nombre + " Genero una transacción de remisión de salida";
                ctrlInfo.InsertarLog(log);
                this.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
