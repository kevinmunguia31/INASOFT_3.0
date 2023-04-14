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
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
            InfoNegocio();
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT idinfogeneral, nombre_negocio, direccion_negocio, num_ruc, nombre_admin, telefono FROM infogeneral";
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
                        txtId.Text = reader.GetString("idinfogeneral");
                        txtNameNgo.Text = reader.GetString("nombre_negocio");
                        txtAddress.Text = reader.GetString("direccion_negocio");
                        txtRUC.Text = reader.GetString("num_ruc");
                        txtNameAdmin.Text = reader.GetString("nombre_admin");
                        txtTelefono.Text = reader.GetString("telefono");

                    }
                }
            }
            catch (MySqlException ex)
            {
               MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            if (txtNameNgo.Text != "" && txtAddress.Text != "" && txtRUC.Text != "" && txtTelefono.Text != "" && txtNameAdmin.Text != "")
            {
                InfoNegocio _info = new InfoNegocio();
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
    }
}
