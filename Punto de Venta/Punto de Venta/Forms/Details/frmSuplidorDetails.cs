using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Punto_de_Venta.Forms
{
    public partial class frmSuplidorDetails : Form
    {
        DataGridViewRow row;
        public frmSuplidorDetails(DataGridViewRow row)
        {
            try
            {
                InitializeComponent();
                label2.Text = Convert.ToString(row.Cells[1].Value);
                label4.Text = Convert.ToString(row.Cells[2].Value);
                label6.Text = Convert.ToString(row.Cells[3].Value);
                label8.Text = Convert.ToString(row.Cells[4].Value);
                label10.Text = Convert.ToString(row.Cells[5].Value);
                label14.Text = Convert.ToString(row.Cells[6].Value);
                label15.Text = Convert.ToString(row.Cells[7].Value);
                label16.Text = Convert.ToString(row.Cells[8].Value);
                label18.Text = Convert.ToString(row.Cells[9].Value);
                label21.Text = Convert.ToString(row.Cells[10].Value);
                label22.Text = Convert.ToString(row.Cells[11].Value);
            }
            catch{}
        }
        public frmSuplidorDetails()
        {
            InitializeComponent();
        }
    }
}
