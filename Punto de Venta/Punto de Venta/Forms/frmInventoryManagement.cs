using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PuntoDeVenta.Library.Entity_Classes;
using PuntoDeVenta.Library.Helpers;

namespace Punto_de_Venta.Forms
{
    public partial class frmInventoryManagement : Form
    {
        List<Suplidor> listSup = new List<Suplidor>();
        ProductoHelper productHelper = new ProductoHelper();
        SuplidorHelper supHelper = new SuplidorHelper();
        public frmInventoryManagement()
        {
            InitializeComponent();
        }

        private void InventoryManagement_Load(object sender, EventArgs e)
        {
            comboDescontinuado.SelectedIndex = 1;
            LoadGrid();
            //splitContainer1.Panel1Collapsed = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.ShowDialog();
        }

        public void Clear()
        {
            txtCodigoBarra.Clear();
            txtDescripcion.Clear();
            txtNombreProducto.Clear();
            txtMarca.Clear();
            txtPrecioUnidad.Clear();
            txtUnitAlcmacen.Clear();
            txtPrecioDeLista.Clear();
            comboDescontinuado.SelectedIndex = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PuntoDeVenta.Library.Entity_Classes.Producto producto = new PuntoDeVenta.Library.Entity_Classes.Producto();
                
                producto.CodigoBarra = txtCodigoBarra.Text;
                producto.NombreProducto = txtNombreProducto.Text;
                producto.Marca = txtMarca.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.PrecioPorUnidad = Convert.ToDecimal(txtPrecioUnidad.Text);
                producto.UnidadesEnAlmacen = Convert.ToInt32(txtUnitAlcmacen.Text);
                producto.FechaDeCompra = dtpFechaDeCompra.Value.Date;
                if (comboDescontinuado.SelectedIndex == 0)
                {
                    producto.Descontinuado = 1;
                }
                else
                {
                    producto.Descontinuado = 0;
                }
                producto.SuplidorID = supHelper.GetSuplidorID(cmbSuplidores.SelectedItem.ToString());
                producto.FechaDeIngreso = DateTime.Today;
                producto.FechaDeCompra = dtpFechaDeCompra.Value.Date;
                producto.SuplidorNombre = cmbSuplidores.SelectedItem.ToString();
                producto.PrecioDeLista = Convert.ToDecimal(txtPrecioDeLista.Text);
                if (!checkBox1.Checked)
                {
                    productHelper.AddProducto(producto);
                    LoadGrid();
                    Clear();
                    MessageBox.Show("¡Producto agregado exitosamente!");
                }
                else
                {
                    producto.ProductoID = Convert.ToInt32(ProductGridView.SelectedCells[0].Value);
                    productHelper.UpdateProducto(producto);
                    LoadGrid();
                    Clear();
                    checkBox1.Checked = false;
                    txtCodigoBarra.Enabled = true;
                    MessageBox.Show("¡Producto modificado exitosamente!");
                }
            }
            catch (Exception q)
            {
                MessageBox.Show("Error al guardar: Existen campos incompletos o incorrectos. Por favor verifique."+q.InnerException);
            }
            txtCodigoBarra.Focus();
        }

        public void LoadGrid()
        {
            List<PuntoDeVenta.Library.Entity_Classes.Producto> list = new List<PuntoDeVenta.Library.Entity_Classes.Producto>();
            list = productHelper.GetProductos();
            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(PuntoDeVenta.Library.Entity_Classes.Producto);
            foreach (PuntoDeVenta.Library.Entity_Classes.Producto pro in list)
            {
                bs.Add(pro);
            }
            ProductGridView.DataSource = bs;

            listSup = supHelper.GetSuplidores();

            cmbSuplidores.Items.Clear();
            foreach(var item in listSup)
            {
                cmbSuplidores.Items.Add(item.NombreSuplidor);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Seguro que desea eliminar el producto?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var row = ProductGridView.Rows[ProductGridView.SelectedRows[0].Index];
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    productHelper.DeleteProduct(id);
                    LoadGrid();
                }
            }
            catch
            { MessageBox.Show("No se ha seleccionado un elemento para eliminar, por favor verífique."); }
        }

        private void btnAdministracionSuplidores_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSupplierManagement frm = new frmSupplierManagement();
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var list = productHelper.GetProductsByIngresoDate(dateTimePicker1.Value.Date);
            ProductGridView.DataSource = list;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = ProductGridView.Rows[ProductGridView.SelectedRows[0].Index];
                int code = Convert.ToInt32(row.Cells[0].Value);
                Producto product = productHelper.GetProductByCode(code);

                txtCodigoBarra.Text = product.CodigoBarra.ToString();
                txtDescripcion.Text = product.Descripcion;
                txtMarca.Text = product.Marca;
                txtNombreProducto.Text = product.NombreProducto;
                txtPrecioUnidad.Text = product.PrecioPorUnidad.ToString("0.00");
                txtUnitAlcmacen.Text = product.UnidadesEnAlmacen.ToString();
                txtPrecioDeLista.Text = product.PrecioDeLista.ToString("0.00");
                cmbSuplidores.SelectedItem = supHelper.VerifySuplidorName(product.SuplidorNombre);
                if (product.Descontinuado == 1)
                {
                    comboDescontinuado.SelectedIndex = 0;
                }
                else
                {
                    comboDescontinuado.SelectedIndex = 1;
                }
                checkBox1.Checked = true;
                //txtCodigoBarra.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Debe seleccionar antes de editar, por favor verífique.");
            }
        }
        private void txtUnitAlcmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsNumber(pressedKey) || pressedKey == '\b' || pressedKey == '.' || pressedKey == ',')
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter, nor punctuation, nor a space.
                e.Handled = true;
        }

        private void btnBuscarFecCompra_Click(object sender, EventArgs e)
        {
            var list = productHelper.GetProductsByCompraDate(dateTimePicker2.Value.Date);
            ProductGridView.DataSource = list;
        }

        private void chkOB_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkOB.Checked)
            {
                LoadGrid();
                splitContainer1.Visible = false;
            }
            else { 
                splitContainer1.Visible = true; 
            }
        }

        private void ProductGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ProductGridView.Rows[ProductGridView.SelectedRows[0].Index];
            Details.frmProductoDetails detalles = new Details.frmProductoDetails(row);
            detalles.Show();
        }

        private void tsmiGuardarExcel_Click(object sender, EventArgs e)
        {
            ComunMethods cm = new ComunMethods();
            cm.ExportToExcel(ProductGridView);
        }
    }
}
