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
            txtPort.Text = Properties.Settings.Default.DbPort;
            txtUser.Text = Properties.Settings.Default.DbUser;
            txtPassword.Text = Properties.Settings.Default.DbPassword;
            VerificarBD();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string ruta = "";
            ruta = txtRuta.Text;

            try
            {
                MySqlConnection conexionBD = Conexion.getConexion();
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup respaldo = new MySqlBackup(comando);

                comando.Connection = conexionBD;
                conexionBD.Open();
                respaldo.ImportFromFile(ruta);
                conexionBD.Close();
                MessageDialoginfo.Show("Script Importado con Exito! ✅", "Aviso");
                this.Close();
            }catch(Exception ex) 
            {
                MessageBox.Show($"Error al importar la base de datos: {ex.Message}");
            }
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            string puerto = Properties.Settings.Default.DbPort;
            string usuario = Properties.Settings.Default.DbUser;
            string password = Properties.Settings.Default.DbPassword;

            // Utiliza los valores recuperados para establecer la conexión a la base de datos MySQL.
            string connectionString = "Server=localhost;Port=" + puerto + ";User Id=" + usuario + ";Password=" + password + ";";
            string databaseName = lbNameDB.Text;

            try
            {
                // Conectar a MySQL
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Comando SQL para crear la base de datos
                    string createDatabaseQuery = $"CREATE DATABASE {databaseName}";

                    using (MySqlCommand cmd = new MySqlCommand(createDatabaseQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"La base de datos '{databaseName}' se ha creado con éxito.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la base de datos: {ex.Message}");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Configurar el diálogo de apertura de archivos
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos SQL|*.sql";
            openFileDialog.Title = "Seleccionar archivo SQL";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Mostrar la ruta del archivo seleccionado en el TextBox
                txtRuta.Text = openFileDialog.FileName;
            }
        }

        private void VerificarBD()
        {
            string puerto = Properties.Settings.Default.DbPort;
            string usuario = Properties.Settings.Default.DbUser;
            string password = Properties.Settings.Default.DbPassword;

            // Utiliza los valores recuperados para establecer la conexión a la base de datos MySQL.
            string connectionString = "Server=localhost;Port=" + puerto + ";User Id=" + usuario + ";Password=" + password + ";";

            string databaseNameToCheck = "Prueba2"; // El nombre de la base de datos que deseas verificar

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para verificar la existencia de la base de datos
                    string query = $"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{databaseNameToCheck}'";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            MessageBox.Show($"La base de datos '{databaseNameToCheck}' existe.");
                            btnCrearBD.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show($"La base de datos '{databaseNameToCheck}' no existe.");
                            btnCrearBD.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la existencia de la base de datos: {ex.Message}");
            }
        }

        private void Bttn_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
             "Para Cargar un respaldo de la base de datos.\n" +
             "Solo cargar el archivo .SQL, no es necesario crear la base de datos para esto", "¿Cómo funciona este apartado?");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DbPort = txtPort.Text;
            Properties.Settings.Default.DbUser = txtUser.Text;
            Properties.Settings.Default.DbPassword = txtPassword.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Configuracion Guardada correctamente.");
        }

        private void ImportBD_Load(object sender, EventArgs e)
        {

        }
    }
}
