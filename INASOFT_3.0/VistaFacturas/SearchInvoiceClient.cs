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
    public partial class SearchInvoiceClient : Form
    {
        public SearchInvoiceClient()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string dato = txtSearch.Text;
            string sql = "SELECT a.ID, b.Nombre, a.Fecha, a.Descuento, a.Cantidad_Descont, a.Subtotal, a.Total_Final, a.Efectivo, a.Devolucion FROM Facturas a INNER JOIN Clientes b ON a.ID_Cliente = b.ID WHERE b.Nombre = '" + dato + "'";
            
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridFatura.DataSource = dt;
                txtSearch.Text = "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
