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
    public partial class SearchInvoiceMonth : Form
    {
        public SearchInvoiceMonth()
        {
            InitializeComponent();
        }
        public void Subtotal()
        {
            double valor = 0; //declaramos una variable double
            foreach (System.Windows.Forms.DataGridViewRow row in dataGridFatura.Rows)
            { 
                valor += Convert.ToDouble(row.Cells[4].Value.ToString());    
            }
           lbSubtotal.Text = valor.ToString("###,##0.00"); //le damos formato a la variable y se la asigno al textbox
        }


        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string fecha = DateTimePicker1.Value.ToString("MM");
            //MessageBox.Show(fecha);
            string sql = "SELECT c.ID, c.Fecha, d.Nombre, SUM(a.cantidad) AS Total_de_Productos, c.Total_Final, c.Efectivo, c.Devolucion, e.Nombre AS Le_Atendio FROM Detalle_Factura a RIGHT JOIN Productos b ON a.ID_Producto = b.ID RIGHT JOIN Facturas c ON a.ID_Factura = c.ID RIGHT JOIN Clientes d ON c.ID_Cliente = d.ID RIGHT JOIN Usuarios e ON c.ID_Usuario = e.ID WHERE month(fecha) = '" + fecha + "' GROUP BY c.ID;";

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
    }
}
