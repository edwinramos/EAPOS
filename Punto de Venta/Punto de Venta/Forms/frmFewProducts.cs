using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PuntoDeVenta.Library.Helpers;

namespace Punto_de_Venta.Forms
{
    public partial class frmFewProducts : Form
    {
        public frmFewProducts()
        {
            InitializeComponent();
        }
        ProductoHelper productHelper = new ProductoHelper();
        private void dgvfewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvfewProducts.Rows[dgvfewProducts.SelectedRows[0].Index];
            Details.frmProductoDetails detalles = new Details.frmProductoDetails(row);
            detalles.ShowDialog();
        }
        private void frmFewProducts_Load(object sender, EventArgs e)
        {
            productoBindingSource.DataSource = productHelper.GetFewProducts();
            label6.Text = String.Format("Existen {0} producto/s escaso/s en Inventario.", productoBindingSource.Count);
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvfewProducts.Rows)
            {             
                productHelper.UpdateProductInStock((row.Cells[1].Value).ToString(), Convert.ToInt32(row.Cells[6].Value));
            }

            productoBindingSource.DataSource = productHelper.GetFewProducts();
            if (dgvfewProducts.RowCount == 0)
            {
                MessageBox.Show(String.Format("Todos los productos pendientes han sido actualizados."));
                this.Close();
            }
            MessageBox.Show(String.Format("¡Productos actualizados exitosamente!"));
        }
    }
}
