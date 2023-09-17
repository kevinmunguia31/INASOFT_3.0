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

namespace INASOFT_3._0
{
    public partial class ImportBD : Form
    {
        public ImportBD()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string ruta = "";

            OpenFileDialog selecciona = new OpenFileDialog();
            selecciona.Filter = "Archivos SQL (*.sql)|*.sql";
            selecciona.Title = "Seleccionar Respaldo";
            selecciona.InitialDirectory = @"C:\";

            if (selecciona.ShowDialog() == DialogResult.OK)
            {
                ruta = selecciona.FileName;
                txtRuta.Text = ruta;

                MySqlConnection conexionBD = Conexion.getConexion();
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup respaldo = new MySqlBackup(comando);

                comando.Connection = conexionBD;
                conexionBD.Open();
                respaldo.ImportFromFile(ruta);
                conexionBD.Close();
                MessageDialoginfo.Show("Respaldo se Restauro con Exito! ✅", "Aviso");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }
    }
}
