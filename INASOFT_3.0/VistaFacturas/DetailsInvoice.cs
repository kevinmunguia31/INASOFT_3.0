using INASOFT_3._0.Modelos;
using INASOFT_3._0.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class DetailsInvoice : Form
    {
        public int codigoFact;
        public DetailsInvoice()
        {
            InitializeComponent();
            InfoNegocio();
            dataGridView1.DataSource = InfoProducts();
            UC_Factura factura = new UC_Factura();
            MessageBox.Show(factura.dataGridFatura.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT direccion_negocio, telefono, logoNegocio FROM infogeneral";
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
                        MemoryStream ms = new MemoryStream((byte[])reader["logoNegocio"]);
                        Bitmap bmp = new Bitmap(ms);
                        pictureBox1.Image = bmp;
                        lbDireccion.Text = reader.GetString("direccion_negocio");
                        lbTelefono.Text = reader.GetString("telefono");

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public DataTable InfoProducts()
        {
          
            //MySqlDataReader reader = null;
            //string sql = " SELECT a.Cantidad, b.Nombre, a.Precio, a.Total FROM Detalle_Factura a INNER JOIN Productos b ON a.ID_Producto = b.ID INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID WHERE d.ID = '"+ dato +"' && a.ID_Factura = '" + idFact +"'";
            string sql = "SELECT b.Nombre, a.Precio, a.Cantidad, a.Total FROM Detalle_Factura a INNER JOIN Productos b ON a.ID_Producto = b.ID INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID WHERE c.ID = " + codigoFact + "";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            //MySqlCommand comando = new MySqlCommand(sql, conexioBD);
            // reader = comando.ExecuteReader();
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexioBD);
            DataTable consulta = new DataTable();
            adp.Fill(consulta);

            return consulta;
        }
    }
}
