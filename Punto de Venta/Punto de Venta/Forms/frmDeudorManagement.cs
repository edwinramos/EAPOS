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
    public partial class frmDeudorManagement : Form
    {
        DeudorHelper deudorHelper = new DeudorHelper();
        public frmDeudorManagement()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtEmail.Clear();
            txtNombreCompleto.Clear();
            txtNombreContacto.Clear();
            txtTelefono.Clear();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Deudor deudor = new Deudor()
            {
                NombreContacto = txtNombreContacto.Text,
                NombreDeudor = txtNombreCompleto.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text
            };
            try
            {
                if (txtEmail.Text.Contains("@"))
                {
                    deudorHelper.AddDeudor(deudor);
                    MessageBox.Show("Deudor: " + deudor.NombreDeudor + ". Guardado exitosamente.");
                    Clear();
                }
                else
                    MessageBox.Show(String.Format("Error al guardar deudor {0}. Favor verifique.", deudor.NombreDeudor));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al guardar deudor {0}. Favor verifique.", deudor.NombreDeudor));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCuentasPorPagar frm = new frmCuentasPorPagar();
            frm.ShowDialog();
        }

        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsLetter(pressedKey) || Char.IsSeparator(pressedKey) || pressedKey == '\b')
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter, nor punctuation, nor a space.
                e.Handled = true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (Char.IsNumber(pressedKey) || pressedKey == '-' || pressedKey == '\b')
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
