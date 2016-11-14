using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Punto_de_Venta.Forms.Details
{
    public partial class frmProductoDetails : Form
    {
        public frmProductoDetails(DataGridViewRow row)
        {
            InitializeComponent();
            label2.Text = row.Cells[1].Value.ToString();
            label4.Text = row.Cells[2].Value.ToString();
            label6.Text = row.Cells[3].Value.ToString();
            label8.Text = row.Cells[4].Value.ToString();
            label10.Text = row.Cells[5].Value.ToString();
            label12.Text = row.Cells[6].Value.ToString();
            label14.Text = Math.Round(Convert.ToDecimal(row.Cells[7].Value), 2).ToString();
            label16.Text = row.Cells[8].Value.ToString();
            label18.Text = row.Cells[9].Value.ToString();
        }

        public frmProductoDetails()
        {
            InitializeComponent();
        }
    }
}
