using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Library.Entity_Classes;
using PuntoDeVenta.Library.Helpers;

namespace Punto_de_Venta.Forms
{
    public partial class frmClientManagement : Form
    {
        public frmClientManagement()
        {
            InitializeComponent();
        }

        ClienteHelper clientHelper = new ClienteHelper();
        private void ClientManagement_Load(object sender, EventArgs e)
        {
            ttCedula.SetToolTip(txtCedula,"Introducir datos sin guiones(-)");
            ttCedula.SetToolTip(txtRNC, "Introducir datos sin guiones(-)");
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            try
            {
                if(txtEmail.Text.Contains("@"))
                    cliente.Email = txtEmail.Text;
                else
                    cliente.Email = null;

                string pattern = @"\b\d{3}-\d{3}-\d{4}";
                cliente.CedulaCliente = txtCedula.Text;


                cliente.NombreCompleto = txtNombre.Text;
                cliente.Direccion = txtDireccion.Text;               
                cliente.RNC = txtRNC.Text;
                clientHelper.AddCliente(cliente);
                MessageBox.Show("¡Cliente guardado exitosamente!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Error al guardar cliente {0}. Favor verifique.", cliente.NombreCompleto));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.ShowDialog();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char pressedKey = e.KeyChar;
            if (!Char.IsNumber(pressedKey))
            {
                // Allow input.
                e.Handled = false;
            }
            else
                // Stop the character from being entered into the control since not a letter, nor punctuation, nor a space.
                e.Handled = true;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
