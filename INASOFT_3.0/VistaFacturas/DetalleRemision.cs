using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
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
    public partial class DetalleRemision : Form
    {
        public DetalleRemision(int idRemision)
        {
            InitializeComponent();
            int id = idRemision;
            CargarRemision(id);
        }

        public void CargarRemision(int idRemision)
        {// Obtén el valor en Form2
            CtrlRemision remision = new CtrlRemision();
            dataGridView1.DataSource = remision.CargarDetalleRemisiones(idRemision);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
