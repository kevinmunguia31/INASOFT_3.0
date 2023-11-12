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
    public partial class ArqueoCaja : Form
    {
        public ArqueoCaja()
        {
            InitializeComponent();
            string fecha = DateTime.Now.ToString("D");
            lbDate.Text = fecha;
            txtCapital.Text = Properties.Settings.Default.CapitalCaja;
        }

        private void CalcularTotal()
        {

            int cant10 = int.Parse(txtDiez.Text);
            int cant20 = int.Parse(txtVeinte.Text);
            int cant50 = int.Parse(txtCincuenta.Text);
            int cant100 = int.Parse(txtCien.Text);
            int cant200 = int.Parse(txtDocientos.Text);
            int cant500 = int.Parse(txtQuinientos.Text);
            int cant1000 = int.Parse(txtMil.Text);
            int cant1 = int.Parse(txtPeso.Text);
            int cant5 = int.Parse(txtCinco.Text);

            //Calcular el total
            int total = (cant10 * 10) + (cant20 * 20) + (cant50 * 50) + (cant100 * 100) + (cant200 * 200) + (cant500 * 500) + (cant1000 * 1000) + (cant1 * 1) + (cant5 * 5);
            txtTotal.Text = total.ToString();
        }

        private void CalcularDescuadre()
        {

            int Total = int.Parse(txtTotal.Text);
            int Capital = int.Parse(txtCapital.Text);

            //Calcular el Descuadre
            int descuadre = Total - Capital;
            
            if(descuadre < 0) 
            {
                txtDescuadre.Text = descuadre.ToString();
                txtDescuadre.ForeColor = Color.Red;
            }
            else
            {
                txtDescuadre.Text = descuadre.ToString();
                txtDescuadre.ForeColor = Color.Green;
            }
        }

        private void txtMil_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch(System.FormatException) { }
        }

        private void txtQuinientos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtDocientos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtCien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtCincuenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtVeinte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtDiez_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtCinco_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularTotal();
                CalcularDescuadre();
            }
            catch (System.FormatException) { }
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularDescuadre();
                CalcularTotal();
            }
            catch (System.FormatException) { };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CapitalCaja = txtCapital.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Información Guardada correctamente.");
        }
    }
}
