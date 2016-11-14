using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Library.Helpers;
using PuntoDeVenta.Library.Entity_Classes;

namespace Punto_de_Venta.Forms
{
    public partial class frmCuentasPorPagar : Form
    {
        DeudorHelper deudorHelper = new DeudorHelper();
        CuentasPorPagarHelper cxpHelper = new CuentasPorPagarHelper();
        public frmCuentasPorPagar()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeudores_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDeudorManagement frm = new frmDeudorManagement();
            frm.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CuentaXPagar cxp = new CuentaXPagar()
                {
                    ConceptoDeuda = txtConcepto.Text,
                    FechaDeuda = DateTime.Today,
                    MontoAPagar = Convert.ToDecimal(txtMonto.Text),
                    NombreDeudor = cmbDeudores.SelectedItem.ToString(),
                    DeudorID = (deudorHelper.GetDeudorByName(cmbDeudores.SelectedItem.ToString())).DeudorID,
                    EstadoDeuda = cmbEstado.SelectedItem.ToString()
                };
                cxpHelper.AddCxP(cxp);
                MessageBox.Show("¡Registro guardado exitosamente!");
                LoadAll();
            }
            catch
            {
                MessageBox.Show("Error al guardar. Favor verifique.");
            }
        }

        public void LoadAll()
        {
            List<Deudor> list = deudorHelper.GetAllDeudores();
            cmbDeudores.Items.Clear();
            foreach (var item in list)
            {
                cmbDeudores.Items.Add(item.NombreDeudor);
            }
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Saldada");
            cmbEstado.SelectedIndex = 0;

            cuentaXPagarBindingSource.DataSource = cxpHelper.GetAllCxP();
        }

        private void CuentasPorPagar_Load(object sender, EventArgs e)
        {
            LoadAll();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.ShowDialog();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsNumber(pressedKey) || pressedKey == '\b' || pressedKey == '.')
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter, nor punctuation, nor a space.
                e.Handled = true;
        }
    }
}
