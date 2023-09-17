using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using INASOFT_3._0.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
            InfoNegocio();
            CargarLogs();
        }

        private void InfoNegocio()
        {
            Controladores.CtrlInfo ctrlInfo = new Controladores.CtrlInfo();
            ctrlInfo.consulta(null);

           /* txtId.Text = ctrlInfo.;
            txtNameNgo.Text = reader["nombre_negocio"].ToString();
            txtAddress.Text = reader["direccion_negocio"].ToString();
            txtRUC.Text = reader["num_ruc"].ToString();
            txtNameAdmin.Text = reader["nombre_admin"].ToString();
            txtTelefono.Text = reader["telefono"].ToString();
            /*
            string sql = "SELECT idinfogeneral, nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono FROM infogeneral";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    txtId.Text = reader["idinfogeneral"].ToString();
                    txtNameNgo.Text = reader["nombre_negocio"].ToString();
                    txtAddress.Text = reader["direccion_negocio"].ToString();
                    txtRUC.Text = reader["num_ruc"].ToString();
                    txtNameAdmin.Text = reader["nombre_admin"].ToString();
                    txtTelefono.Text = reader["telefono"].ToString();
                }
                else
                {
                    MessageBox.Show("No se hayo registro");
                }


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return null;*/
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            InfoNegocio _info = new InfoNegocio();

            
            if (txtNameNgo.Text != "" && txtAddress.Text != "" && txtRUC.Text != "" && txtTelefono.Text != "" && txtNameAdmin.Text != "")
            {
                _info.Nombre = txtNameNgo.Text;
                _info.Direccion = txtAddress.Text;
                _info.NumRUC = txtRUC.Text;
                _info.NombreAdmin = txtNameAdmin.Text;
                _info.Telefono = txtTelefono.Text;

                CtrlInfo ctrlInfo = new CtrlInfo();
                if (txtId.Text != "")
                {
                    _info.Id = int.Parse(txtId.Text);
                    bandera = ctrlInfo.actualizar(_info);
                    MessageDialoginfo.Show("Registro Actualizado Con Exito", "Actualizar Información");
                    InfoNegocio();

                }
                else
                {
                    bandera = ctrlInfo.insertar(_info);
                    MessageDialoginfo.Show("Información Guardada con Exito", "Guardar Información");
                    InfoNegocio();
                }
            }
            else
            {
                MessageDialogWar.Show("Rellene Todos los campos", "Aviso");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                lbRuta.Text = ofdSeleccionar.FileName;
                pbImagen.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void CargarLogs()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT descripcion FROM logs";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);

                listViewLogs.Clear();
                listViewLogs.View = View.Details;

                listViewLogs.FullRowSelect = true;
                listViewLogs.Columns.Add(dt.Columns[0].ToString(), 800);

                foreach (DataRow row in dt.Rows)
                {
                    string[] arr = new string[1];
                    ListViewItem item = new ListViewItem();
                    
                    for (int i = 0; i < arr.Length; i++) 
                    {
                        arr[i] = row[i].ToString();
                        item = new ListViewItem(arr);
                    }
                    listViewLogs.Items.Add(item);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog selecciona = new SaveFileDialog();
            selecciona.Filter = "Archivo SQL (*.sql)| *.sql";
            selecciona.InitialDirectory = @"C:\";
            selecciona.Title = "Seleccionar Archivo de respaldo";

            if (selecciona.ShowDialog() == DialogResult.OK)
            {
                string ruta = selecciona.FileName;

                MySqlConnection conexionBD = Conexion.getConexion();
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup bk = new MySqlBackup(comando);

                comando.Connection = conexionBD;
                conexionBD.Open();
                bk.ExportToFile(ruta);
                conexionBD.Close();
                MessageDialoginfo.Show("Respaldo Generado con Exito!", "Aviso");
            }
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
    }
}
