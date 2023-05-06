﻿using INASOFT_3._0.Modelos;
using INASOFT_3._0.VistaFacturas;
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
    public partial class UC_Factura : UserControl
    {
        public DataGridViewButtonColumn GB = new DataGridViewButtonColumn();
        public UC_Factura()
        {
            InitializeComponent();
            CargarFacturas();
            dataGridFatura.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void CargarFacturas()
        {
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            dataGridFatura.DataSource = ctrlFactura.CargarFactura();
        }

        private void txtNewInvoice_Click(object sender, EventArgs e)
        {
            Facturar1 facturar = new Facturar1();
            facturar.ShowDialog();
        }

        private void eliminarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_factura = int.Parse(dataGridFatura.CurrentRow.Cells[0].Value.ToString());
            string sql = "CALL Eliminar_Factura('" + id_factura + "')";
            try
            {
                try
                {
                    MySqlConnection conexioBD = Conexion.getConexion();
                    conexioBD.Open();
                    MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                    comando.ExecuteNonQuery();
                    MessageDialogInfo.Show("Se elimino la Factura Seleccionada", "Eliminar Factura");
                    CargarFacturas();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }catch(System.FormatException ex)
            {
                MessageBox.Show("Error:" + ex); 
            }
            

        }

        private void btnFacturaCliente_Click(object sender, EventArgs e)
        {
            SearchInvoiceClient frm = new SearchInvoiceClient();
            frm.ShowDialog();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            SearchInvoiceDate frm = new SearchInvoiceDate();
            frm.ShowDialog();
        }

        private void btnSearchMonth_Click(object sender, EventArgs e)
        {
            SearchInvoiceMonth frm = new SearchInvoiceMonth();
            frm.ShowDialog();
        }

        private void btnRango_Click(object sender, EventArgs e)
        {
            SearchInvoiceRange frm = new SearchInvoiceRange();
            frm.ShowDialog();
        }

        private void UC_Factura_Load(object sender, EventArgs e)
        {
            //Boton en Datagrid
            GB.Name = "GB";
            GB.Text = "Detalles →";
            GB.HeaderText = "Ver Detalles";
            GB.UseColumnTextForButtonValue = true;
            dataGridFatura.Columns.Add(GB);
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
