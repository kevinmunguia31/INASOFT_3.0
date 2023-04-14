using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
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
    public partial class SearchInvoiceDate : Form
    {
        public SearchInvoiceDate()
        {
            InitializeComponent();
        }

        public void Subtotal()
        {
            double valor = 0; //declaramos una variable double
            foreach (System.Windows.Forms.DataGridViewRow row in dataGridFatura.Rows)
            {
                valor += Convert.ToDouble(row.Cells[6].Value.ToString());
            }
            lbSubtotal.Text = valor.ToString("###,##0.00"); //le damos formato a la variable y se la asigno al textbox
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            string fecha = DatePicker.Value.ToString("yyyy/MM/dd");
            //MessageBox.Show(fecha);
            string sql = "SELECT a.ID, b.Nombre, a.Fecha, a.Descuento, a.Cantidad_Descont, a.Subtotal, a.Total_Final, a.Efectivo, a.Devolucion FROM Facturas a INNER JOIN Clientes b ON a.ID_Cliente = b.ID WHERE DATE_FORMAT(a.fecha, '%Y/%m/%d') = '" + fecha + "'";

            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridFatura.DataSource = dt;
                Subtotal();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SearchInvoiceDate_Load(object sender, EventArgs e)
        {

        }
    }
}
