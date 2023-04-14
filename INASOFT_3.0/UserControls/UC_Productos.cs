using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
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
            CargarTablaProduct(null);
            TotalProductos();
            CapitalInvertido();
        }

        public void CargarTablaProduct(string dato)
        {
            List<Productos> lista = new List<Productos>();
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.consulta(dato);
        }
        public void CapitalInvertido()
        {

            MySqlDataReader reader = null;
            string sql = "SELECT SUM(precio_total) FROM productos";

            try
            {
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
                            double d = Convert.ToDouble(reader.GetString(0), CultureInfo.InvariantCulture);
                            lbCapital.Text = d.ToString("0,0.00", CultureInfo.InvariantCulture);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            catch(SqlNullValueException)
            {

            }
           
        }
        public void TotalProductos()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT count(*) FROM productos";
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
                        lbCantiTota.Text = reader.GetString(0);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }




        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Index == 3)
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
                catch(NullReferenceException ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lbCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lbNameP.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lbExistencias.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            //CASTEO DE DOBLE A MONEDA LOCAL
            double p = Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value, CultureInfo.InvariantCulture);
            lbPrecioCompra.Text = p.ToString("0.00", CultureInfo.InvariantCulture);

            double d = Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value, CultureInfo.InvariantCulture);
            lbPrecioVenta.Text = d.ToString("0.00", CultureInfo.InvariantCulture);

            double x = Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value, CultureInfo.InvariantCulture);
            lbPrecioDolar.Text = x.ToString("0.00", CultureInfo.InvariantCulture);

            double z = Convert.ToDouble(dataGridView1.CurrentRow.Cells[7].Value, CultureInfo.InvariantCulture);
            lbPrecioTotal.Text = z.ToString("0.00", CultureInfo.InvariantCulture);

            lbObservaciones.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            lbProveedor.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            CargarTablaProduct(dato);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            CargarTablaProduct(null);
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void lbCapital_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ADDEDIT frm = new ADDEDIT();
            frm.ShowDialog();
        }

        private void UC_Productos_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void editar_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string codigo = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string existencia = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string precio_compra = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string precio_venta = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string precio_dolar = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            string observaciones = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            string proveedor = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            ADDEDIT update = new ADDEDIT();
            update.labelTitle.Text = "EDITAR PRODUCTO";
            update.txtId.Text = id;
            update.txtCodBarra.Text = codigo;
            update.txtNameP.Text = nombre;
            update.SpinExist.Value = int.Parse(existencia);
            update.txtPrecioCompra.Text = precio_compra;
            update.txtPrecioVenta.Text = precio_venta;
            update.txtPrecioDolar.Text = precio_dolar;
            update.txtObservacion.Text = observaciones;
            update.ShowDialog();
        }

        public void ReiniciarDatos()
        {
            lbCodigo.Text = "...";
            lbNameP.Text = "...";
            lbExistencias.Text = "...";
            lbPrecioCompra.Text = "...";
            lbPrecioVenta.Text = "...";
            lbPrecioDolar.Text = "...";
            lbPrecioTotal.Text = "...";
            lbObservaciones.Text = "...";
            lbProveedor.Text = "...";


        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageDialog.Show("Seguro que desea eliminar el registro?", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlProductos _ctrl = new CtrlProductos();
                bandera = _ctrl.eliminar(id);
                if (bandera)
                {
                    MessageDialogInfo.Show("Registro Eliminado con exito", "Aviso");
                    CargarTablaProduct(null);
                    ReiniciarDatos();
                    CapitalInvertido();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarTablaProduct(null);
            TotalProductos();
            CapitalInvertido();
        }
    }
}
