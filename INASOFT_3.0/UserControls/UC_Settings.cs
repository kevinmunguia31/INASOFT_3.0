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
                    bandera = ctrlInfo.Actualizar(_info);
                    MessageDialoginfo.Show("Registro Actualizado Con Exito", "Actualizar Información");
                   
                    string log = Sesion.nombre + " ha cambia la información del negocio";
                    string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    ctrlInfo.InsertarLog(fecha, log);
                    InfoNegocio();

                }
                else
                {
                    bandera = ctrlInfo.Insertar(_info);
                    MessageDialoginfo.Show("Información Guardada con Exito", "Guardar Información");
                    string log = Sesion.nombre + " Ha Registrado la Información del Negocio";
                    string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    ctrlInfo.InsertarLog(fecha, log);
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
                txtPath.Text = ofdSeleccionar.FileName;
                pbImagen.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void CargarLogs()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT fecha, descripcion FROM logs";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            CtrlInfo ctrlInfo = new CtrlInfo();
            SaveFileDialog selecciona = new SaveFileDialog();
            selecciona.Filter = "Archivo SQL (*.sql)| *.sql";
            selecciona.InitialDirectory = @"C:\";
            selecciona.Title = "Seleccionar Archivo de respaldo";
            selecciona.FileName = "Respaldo_" + DateTime.Now.ToString("ddMMyyyy") + ".sql";

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
                string log = Sesion.nombre + " Genero un Respaldo de la Base de Datos";
                string fecha = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                ctrlInfo.InsertarLog(fecha, log);

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rutaImagen = txtPath.Text;
            Properties.Settings.Default.RutaImagen = rutaImagen;
            Properties.Settings.Default.Save();
            MessageBox.Show("Imagen Guardada correctamente.");
        }

        private void UC_Settings_Load(object sender, EventArgs e)
        {
            //Cargar Imagen
            string rutaImagen = Properties.Settings.Default.RutaImagen;

            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                // Carga la imagen desde la ruta especificada
                Image imagen = Image.FromFile(rutaImagen);
                pbImagen.Image = imagen;
            }
            else
            {
                MessageBox.Show("La imagen no se encontró en la ruta especificada. Cargue el logo desde las configuraciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //MessageBox.Show(fecha);
            CtrlInfo _ctrlInfo = new CtrlInfo();
            dataGridView1.DataSource = _ctrlInfo.BuscarLogs(fecha);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarLogs();
        }
    }
}
