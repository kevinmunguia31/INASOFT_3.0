using INASOFT_3._0.Controladores;
using INASOFT_3._0.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INASOFT_3._0.VistaFacturas
{
    public partial class FacturaFinal : Form
    {
        public FacturaFinal()
        {
            InitializeComponent();
            InstalledPrintersCombo();
            InfoNegocio();
            Controladores.CtrlFactura ctrlFactura = new CtrlFactura();
            txtIdFactura.Text = ctrlFactura.ID_Factura().ToString();
            lbUser.Text = Sesion.nombre;
            Txt_descuento.Text = "0";
        }

        private void InfoNegocio()
        {
            MySqlDataReader reader = null;
            string sql = "SELECT nombre_negocio, direccion_negocio, num_ruc, telefono FROM infogeneral";
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
                        lbNombreNegocio.Text = reader.GetString("nombre_negocio");
                        lbDireccionNegocio.Text = reader.GetString("direccion_negocio");
                        lbNmRUC.Text = reader.GetString("num_ruc");
                        lbTelefono.Text = reader.GetString("telefono");

                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public DataTable InfoProducts()
        {
            string dato = txtIdCliente.Text;
            string idFact = txtIdFactura.Text;
            //MySqlDataReader reader = null;
            //string sql = " SELECT a.Cantidad, b.Nombre, a.Precio, a.Total FROM Detalle_Factura a INNER JOIN Productos b ON a.ID_Producto = b.ID INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID WHERE d.ID = '"+ dato +"' && a.ID_Factura = '" + idFact +"'";
            string sql = "SELECT b.Nombre, a.Precio, a.Cantidad, a.Total FROM Detalle_Factura a INNER JOIN Productos b ON a.ID_Producto = b.ID INNER JOIN Facturas c ON a.ID_Factura = c.ID INNER JOIN Clientes d ON c.ID_Cliente = d.ID WHERE d.ID = '" + dato + "' && a.ID_Factura = '" + idFact + "'";

            MySqlConnection conexioBD = Conexion.getConexion();
            conexioBD.Open();
            //MySqlCommand comando = new MySqlCommand(sql, conexioBD);
            // reader = comando.ExecuteReader();
            MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexioBD);
            DataTable consulta = new DataTable();
            adp.Fill(consulta);

            return consulta;
        }

        private void InstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cbImpresoras.Items.Add(pkInstalledPrinters);

            }
            cbImpresoras.Text = "POS-80";
        }

        private void FacturaFinal_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = InfoProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Controladores.CtrlFactura ctrlFactura = new Controladores.CtrlFactura();
            ctrlFactura.Cancelar_Factura(ctrlFactura.ID_Factura());
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void SpinDescuento_ValueChanged(object sender, EventArgs e)
        {
            //int iva = int.Parse(SpinDescuento.Value.ToString());
            //float subtotal = float.Parse(lbSubtotal.Text);
            //float total;
            //float descuento;

            //float desc = descuento = (float.Parse(iva.ToString()) / 100);

            //descuento = (float.Parse(iva.ToString()) / 100) * subtotal;
            //total = subtotal - descuento;

            //lbTotal.Text = total.ToString();
            //lbPrecDesc.Text = descuento.ToString();
            //lbDescCant.Text = iva.ToString();
            //lbDesc.Text = desc.ToString();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbDevolucion.Text = (float.Parse(Txt_Efectivo.Text) - float.Parse(lbTotal.Text)).ToString();
            }
            catch
            {
                lbDevolucion.Text = "0.00";
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            string tipoPago = "";
            if (radioButton1.Checked == true)
            {
                tipoPago = "Dolares";
            }

            if(radioButton2.Checked == true)
            {
                tipoPago = "Cordobas";
            }
            //string sql = "CALL Facturacion_Final('" + Txt_descuento.Text + "','" + lbSubtotal.Text + "','" + guna2TextBox1.Text + "', '" + lbIdFactura.Text + ", '" + tipoPago + "')";
            string sql = "CALL Facturacion_Final(" + Txt_descuento.Text + ", " + lbSubtotal.Text + ", " + Txt_Efectivo.Text + ", "+ txtIdFactura.Text +", '"+ tipoPago +"');";
            try
            {
                MySqlConnection conexioBD = Conexion.getConexion();
                conexioBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexioBD);
                comando.ExecuteNonQuery();
                MessageDialogInfo.Show("Se actualizo la Factura");
                //////////////// IMPRESION DE LA FACTURA /////////////////////////////////////////////////
                clsFactura.CreaTicket Ticket1 = new clsFactura.CreaTicket();
                
                Ticket1.TextoCentro(lbNombreNegocio.Text); //imprime una linea de descripcion
                Ticket1.TextoCentro("**********************************");

                Ticket1.TextoIzquierda(lbDireccionNegocio.Text);
                Ticket1.TextoIzquierda(lbTelefono.Text);
                Ticket1.TextoIzquierda(lbNmRUC.Text);
                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                Ticket1.TextoIzquierda("No Fac:" + lbIdFactura.Text);
                Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda("Le Atendio: " + Sesion.nombre);
                Ticket1.TextoIzquierda("Cliente: " + lbNombreCliente.Text);
                Ticket1.TextoIzquierda("");
                clsFactura.CreaTicket.LineasGuion();

                clsFactura.CreaTicket.EncabezadoVenta();
                clsFactura.CreaTicket.LineasGuion();
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    // PROD                     //PrECIO                                    CANT                         TOTAL
                    Ticket1.AgregaArticulo(r.Cells[0].Value.ToString(), float.Parse(r.Cells[1].Value.ToString()), float.Parse(r.Cells[2].Value.ToString()), float.Parse(r.Cells[3].Value.ToString())); //imprime una linea de descripcion
                }


                clsFactura.CreaTicket.LineasGuion();
                Ticket1.AgregaTotales("Sub-Total", float.Parse(lbSubtotal.Text)); // imprime linea con Subtotal
                Ticket1.AgregaTotales("Menos Descuento", float.Parse(lbPrecDesc.Text)); // imprime linea con decuento total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Total", float.Parse(lbTotal.Text)); // imprime linea con total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Efectivo Entregado:", float.Parse(Txt_Efectivo.Text));
                Ticket1.AgregaTotales("Efectivo Devuelto:", float.Parse(lbDevolucion.Text));


                // Ticket1.LineasTotales(); // imprime linea 

                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoIzquierda(" ");
                Ticket1.ImprimirTiket(cbImpresoras.Text);

                MessageDialogInfo.Show("Gracias por preferirnos", "Facturar");
                this.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Txt_descuento_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                lbTotal.Text = (double.Parse(lbTotal.Text) - double.Parse(Txt_descuento.Text)).ToString();
            }
            catch
            {
                lbTotal.Text = lbTotal.Text;
            }*/
        }
    }
}
