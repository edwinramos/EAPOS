using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PuntoDeVenta.Entity;
using PuntoDeVenta.Library.Helpers;

namespace Punto_de_Venta.Forms
{
    public partial class frmPointOfSale : Form
    {
        ProductoHelper productHelper = new ProductoHelper();
        UsuarioHelper userHelper = new UsuarioHelper();
        FacturaHelper facturaHelper = new FacturaHelper();
        ClienteHelper clientHelper = new ClienteHelper();

        List<PuntoDeVenta.Library.Entity_Classes.FacturaDetalle> list = new List<PuntoDeVenta.Library.Entity_Classes.FacturaDetalle>();
        List<PuntoDeVenta.Library.Entity_Classes.Cliente> clientList = new List<PuntoDeVenta.Library.Entity_Classes.Cliente>();
        List<PuntoDeVenta.Library.Entity_Classes.Factura> factlist = new List<PuntoDeVenta.Library.Entity_Classes.Factura>();
        String usrPass;
        public frmPointOfSale()
        {
            InitializeComponent();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.ShowDialog();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodigoBarra.Text))
                {
                    ScanningClear();
                }
                else
                {
                    String barcode;
                    PuntoDeVenta.Library.Entity_Classes.Producto producto = new PuntoDeVenta.Library.Entity_Classes.Producto();

                    using (MuebleriaDBEntities context = new MuebleriaDBEntities())
                    {
                        barcode = txtCodigoBarra.Text;
                        try
                        {
                            producto = productHelper.ToModelProduct(context.TBL_PRODUCTOS.SingleOrDefault(x => x.CodigoDeBarra == barcode));
                        }
                        catch { ScanningClear(); }
                    }

                    txtProductoNombre.Text = producto.NombreProducto;
                    txtMarca.Text = producto.Marca;

                    decimal price = Convert.ToDecimal(productHelper.GetProductPrice(txtCodigoBarra.Text)) * Convert.ToDecimal(txtCantidad.Text);
                    decimal PrecioDescuento = price - (price / 100) * (NUDDescuento.Value);
                    if (NUDDescuento.Value == 0)
                    {
                        txtPrecioDescuento.Text = price.ToString("0.00");
                    }

                    if (NUDDescuento.Value > 0)
                    {
                        txtPrecioDescuento.Text = PrecioDescuento.ToString("0.00");
                    }
                }
            }
            catch 
            {
                //ScanningClear();
            }
        }
        public void LoadAll()
        {
            cmbClientes.Items.Clear();
            clientList = clientHelper.GetClientes();
            foreach(var cl in clientList)
            {
                cmbClientes.Items.Add(cl.NombreCompleto);
            }
        }

        private void PointOfSale_Load(object sender, EventArgs e)
        {
            LoadingTimer.Start();
            LoadAll();
            //using(MuebleriaDBEntities context = new MuebleriaDBEntities())
            //{
            //     var ls = context.TBL_PRODUCTOS.Select(x => x.CodigoDeBarra);
            //     txtCodigoBarra.AutoCompleteCustomSource = ls.ToList(;
            //}
            

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                PuntoDeVenta.Library.Entity_Classes.FacturaDetalle facturaDetalle = new PuntoDeVenta.Library.Entity_Classes.FacturaDetalle();

                PuntoDeVenta.Library.Entity_Classes.Producto prod = new PuntoDeVenta.Library.Entity_Classes.Producto();
                using (MuebleriaDBEntities context = new MuebleriaDBEntities())
                {
                    String codigo = txtCodigoBarra.Text;
                    prod = productHelper.ToModelProduct(context.TBL_PRODUCTOS.SingleOrDefault(x => x.CodigoDeBarra == codigo));
                }
                facturaDetalle.CodigoDeBarra = txtCodigoBarra.Text;
                if (productHelper.CheckProductAvailability(txtCodigoBarra.Text, Convert.ToInt32(txtCantidad.Text)))
                {
                    facturaDetalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                }
                else 
                {
                    MessageBox.Show("No existen productos disponibles en el almacen para este producto.");
                    throw new Exception();
                }
                facturaDetalle.NombreProducto = txtProductoNombre.Text;
                facturaDetalle.PrecioPorCantidad = prod.PrecioPorUnidad * facturaDetalle.Cantidad;
                if (NUDDescuento.Value != 0)
                {
                    facturaDetalle.Descuento = NUDDescuento.Value;
                    facturaDetalle.PrecioConDescuento = facturaDetalle.PrecioPorCantidad - ((facturaDetalle.PrecioPorCantidad / 100) * facturaDetalle.Descuento);
                }
                else
                {
                    facturaDetalle.Descuento = 0;
                    facturaDetalle.PrecioConDescuento = facturaDetalle.PrecioPorCantidad;
                }
                decimal total = 0;
                list.Add(facturaDetalle);
                foreach (var item in list)
                {
                    total += item.PrecioConDescuento;
                }
                txtTotal.Text = total.ToString("0.00");
                this.TBL_FACTURABindingSource.DataSource = list;
                this.reportViewer1.RefreshReport();
                Clear();
            }
            catch(Exception r)
            {
                MessageBox.Show("Existen campos imcompletos. Por favor, verifique.");
            }
            txtCodigoBarra.Focus();
        }

        private void Clear()
        {
            txtCantidad.Clear();
            txtCodigoBarra.Clear();
            txtPrecioDescuento.Clear();
            txtMarca.Clear();
            txtProductoNombre.Clear();
            
            NUDDescuento.Value = 0;
        }

        private void ScanningClear()
        {
            txtCantidad.Clear();
            txtPrecioDescuento.Clear();
            txtMarca.Clear();
            txtProductoNombre.Clear();

            NUDDescuento.Value = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea Guardar la factura actual?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    PuntoDeVenta.Library.Entity_Classes.Factura factura = new PuntoDeVenta.Library.Entity_Classes.Factura();
                    factura.FechaFactura = DateTime.Today;
                    factura.TotalEnFactura = Convert.ToDecimal(txtTotal.Text);
                    factura.UsuarioID = (userHelper.GetOnLineUser()).UsuarioID;
                    if (cmbClientes.SelectedItem == null)
                    {
                        factura.NombreCliente = "";
                        throw new Exception();
                    }
                    else
                    {
                        factura.NombreCliente = cmbClientes.SelectedItem.ToString();
                    }

                    factura.NombreUsuario = (userHelper.GetOnLineUser()).NombreUsuario;
                    if ((clientHelper.GetClienteByName(factura.NombreCliente)).CedulaCliente == null)
                    {
                        factura.CedulaCliente = "";
                    }
                    else 
                    {
                        factura.CedulaCliente = (clientHelper.GetClienteByName(factura.NombreCliente)).CedulaCliente;
                    }
                    
                    factura.FacturaDetalles = new List<PuntoDeVenta.Library.Entity_Classes.FacturaDetalle>();

                    factura.FacturaDetalles = list;

                    facturaHelper.AddFactura(factura);
                    MessageBox.Show("¡Factura guardada exitosamente!");
                    Clear();
                    TBL_FACTURABindingSource.Clear();
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show("Error al guardar, favor verifique.");
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar la factura actual?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                list.Clear();
                this.reportViewer1.RefreshReport();
            }
            Clear();
            txtCodigoBarra.Focus();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (!Char.IsLetter(pressedKey))
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter, nor punctuation, nor a space.
                e.Handled = true;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea Guardar la factura actual?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    PuntoDeVenta.Library.Entity_Classes.Factura factura = new PuntoDeVenta.Library.Entity_Classes.Factura();
                    factura.FechaFactura = DateTime.Today;
                    factura.TotalEnFactura = Convert.ToDecimal(txtTotal.Text);
                    factura.UsuarioID = (userHelper.GetOnLineUser()).UsuarioID;
                    if (cmbClientes.SelectedItem == null)
                    {
                        factura.NombreCliente = "";
                        throw new Exception();
                    }
                    else
                    {
                        factura.NombreCliente = cmbClientes.SelectedItem.ToString();
                    }

                    factura.NombreUsuario = (userHelper.GetOnLineUser()).NombreUsuario;
                    if ((clientHelper.GetClienteByName(factura.NombreCliente)).CedulaCliente == null)
                    {
                        factura.CedulaCliente = "";
                    }
                    else
                    {
                        factura.CedulaCliente = (clientHelper.GetClienteByName(factura.NombreCliente)).CedulaCliente;
                    }

                    factura.FacturaDetalles = new List<PuntoDeVenta.Library.Entity_Classes.FacturaDetalle>();

                    factura.FacturaDetalles = list;

                    facturaHelper.AddFactura(factura);
                    MessageBox.Show("¡Factura guardada exitosamente!");
                    Clear();
                    TBL_FACTURABindingSource.Clear();
                    this.reportViewer1.PrintDialog();
                    this.reportViewer1.RefreshReport();
                    
                }
            }
            catch (Exception h)
            {
                MessageBox.Show("Error al guardar, favor verifique.");
                e.Cancel = true;
            }
            e.Cancel = true;
        }

        

        

    }
}
