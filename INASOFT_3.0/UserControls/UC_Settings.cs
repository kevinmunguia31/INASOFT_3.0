using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
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
            /*MySqlDataReader reader = null;
            string sql = "SELECT idinfogeneral, nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono, logoNegocio FROM infogeneral";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    byte[]Foto = (byte[])reader["logoNegocio"];
                    MemoryStream ms = new MemoryStream(Foto);
                    pbImagen.Image = Image.FromStream(ms);
                    txtId.Text = reader.GetString("idinfogeneral");
                    txtNameNgo.Text = reader.GetString("nombre_negocio");
                    txtAddress.Text = reader.GetString("direccion_negocio");
                    txtRUC.Text = reader.GetString("num_ruc");
                    txtNameAdmin.Text = reader.GetString("nombre_admin");
                    txtTelefono.Text = reader.GetString("telefono");
                }
            }
            catch (MySqlException ex)
            {
               MessageBox.Show(ex.Message.ToString());
            }*/
            string sql = "SELECT idinfogeneral, nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono, logoNegocio FROM infogeneral";

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    MemoryStream ms = new MemoryStream((byte[])reader["logoNegocio"]);
                    Bitmap bmp = new Bitmap(ms);
                    pbImagen.Image = bmp;
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
            /*bool bandera = false;
            InfoNegocio _info = new InfoNegocio();

            MemoryStream ms = new MemoryStream();
            pbImagen.Image.Save(ms, ImageFormat.Jpeg);

            if (txtNameNgo.Text != "" && txtAddress.Text != "" && txtRUC.Text != "" && txtTelefono.Text != "" && txtNameAdmin.Text != "")
            {
                _info.Nombre = txtNameNgo.Text;
                _info.Direccion = txtAddress.Text;
                _info.NumRUC = txtRUC.Text;
                _info.NombreAdmin = txtNameAdmin.Text;
                _info.Telefono = txtTelefono.Text;
                _info.Imagen = ms.ToArray();

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
            }*/
            MemoryStream ms = new MemoryStream();
            pbImagen.Image.Save(ms, ImageFormat.Jpeg);
            byte[] aBayte = ms.ToArray();

            MySqlConnection conexionDB = Conexion.getConexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand("INSERT INTO infogeneral (nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono, logoNegocio) VALUES ('" + txtNameNgo.Text + "','" + txtAddress.Text + "','" + txtRUC.Text + "','" + txtNameAdmin.Text + "','" + txtTelefono.Text + "', @logoNegocio)", conexionDB);
                comando.Parameters.AddWithValue("logoNegocio", aBayte);
                comando.ExecuteNonQuery();
                MessageBox.Show("Datos Guardados con Exito");
                pbImagen.Image = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar los datos" + ex.Message);
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
    }
}
