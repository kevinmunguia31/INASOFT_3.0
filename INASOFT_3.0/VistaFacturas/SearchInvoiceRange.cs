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
    public partial class SearchInvoiceRange : Form
    {
        public SearchInvoiceRange()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string fechaini = DateTimePickerInicio.Value.ToString("yyyy/MM/dd");
            string fechaFin = DateTimePickerFin.Value.ToString("yyyy/MM/dd");


        }
    }
}
