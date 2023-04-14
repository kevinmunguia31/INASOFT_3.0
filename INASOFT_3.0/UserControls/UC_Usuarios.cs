using INASOFT_3._0.Controladores;
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

namespace INASOFT_3._0.UserControls
{
    public partial class UC_Usuarios : UserControl
    {
        public UC_Usuarios()
        {
            InitializeComponent();
            
        }
        public void CargarTablaUser()
        {
            string sql = "select usuarios.id, usuarios.nombre, usuarios.usuario, usuarios.password, tipo_usuarios.nombre as Rol from usuarios inner join tipo_usuarios on usuarios.id_tipo = tipo_usuarios.id";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void CargarCategoria()
        {
            cbRoles.DataSource = null;
            cbRoles.Items.Clear();
            string sql = "SELECT id, nombre FROM tipo_usuarios ORDER BY nombre ASC";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                MySqlDataAdapter data = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                data.Fill(dt);

                cbRoles.ValueMember = "id";
                cbRoles.DisplayMember = "nombre";
                cbRoles.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show("Error al Cargar" + ex.Message);
            }
            finally { conexioBD.Close(); }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtNombreYapellido.Text != "" && txtUserName.Text != "" && txtpassword.Text != "" && txtConfirmP.Text != "")
            {
                Usuarios _usuarios = new Usuarios();
                _usuarios.Nombre = txtNombreYapellido.Text;
                _usuarios.Usuario = txtUserName.Text;
                _usuarios.Password = txtpassword.Text;
                _usuarios.ConPassword = txtConfirmP.Text;
                _usuarios.Id_tipo = Convert.ToInt32(cbRoles.SelectedValue.ToString());
                // MessageBox.Show(_usuarios.Id_tipo.ToString());

                try
                {
                    ctrlUsuarios control = new ctrlUsuarios();
                    string respuesta = control.ctrlRegistro(_usuarios);

                    if (respuesta.Length > 0)
                    {
                        MessageDialogInfo.Show(respuesta, "Aviso");
                    }
                    else
                    {
                        MessageDialogInfo.Show("Usuario Registrado", "Aviso");
                        CargarTablaUser();
                        txtNombreYapellido.Text = "";
                        txtUserName.Text = "";
                        txtpassword.Text = "";
                        txtConfirmP.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageDialogWar.Show("Rellene Todos Los Campos", "AVISO");
            }
            
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            DialogResult resultado = MessageDialog.Show("Seguro que desea eliminar este Usuario?", "Eliminar");
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ModeloUsers _ctrl = new ModeloUsers();
                bandera = _ctrl.eliminar(id);
                if (bandera)
                {
                    MessageDialogInfo.Show("Usuario Eliminado con exito", "AVISO");
                    CargarTablaUser();
                }
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void UC_Usuarios_Load(object sender, EventArgs e)
        {
            CargarCategoria();
            CargarTablaUser();
        }
    }
}
