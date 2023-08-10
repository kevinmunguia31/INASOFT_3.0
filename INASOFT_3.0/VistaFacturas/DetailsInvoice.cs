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
        public DetailsInvoice(string id)
        {
            InitializeComponent();
            InfoNegocio();
            txtIDFactura.Text = id;
            InfoProducts();
            
            //dataGridView1.DataSource = InfoProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void InfoProducts()
        {
            string idFactura = txtIDFactura.Text;
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridView1.DataSource = ctrlFactura.DetalleFactura(idFactura);
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            //string sql = "SELECT direccion_negocio, telefono, logoNegocio FROM infogeneral";
            string sql = "SELECT direccion_negocio, telefono FROM infogeneral";
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
                        //MemoryStream ms = new MemoryStream((byte[])reader["logoNegocio"]);
                        //Bitmap bmp = new Bitmap(ms);
                        //pictureBox1.Image = bmp;
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

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
