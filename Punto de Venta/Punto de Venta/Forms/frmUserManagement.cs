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
//using PuntoDeVenta.Entity;

namespace Punto_de_Venta.Forms
{
    public partial class frmUserManagement : Form
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void GuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                PuntoDeVenta.Library.Entity_Classes.Usuario Usuario = new PuntoDeVenta.Library.Entity_Classes.Usuario();
                if (txtNombre.Text != "")
                {
                    Usuario.Nombre = txtNombre.Text;
                }
                else
                {
                    MessageBox.Show("El Nombre es requerido.");
                }
                Usuario.Apellido = txtApellido.Text;


                if (txtUserName.Text != "")
                    Usuario.NombreUsuario = txtUserName.Text;

                if (txtPassword.Text != "" && txtPassConfirm.Text != "")
                {
                    if (txtPassword.Text == txtPassConfirm.Text)
                    {
                        Usuario.Contraseña = txtPassword.Text;
                    }
                    else
                    {
                        MessageBox.Show("Las constraseñas no coinciden.");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseña es un campo obligatorio.");
                }

                UsuarioHelper userHelper = new UsuarioHelper();
                if (Usuario.Nombre != "" || Usuario.NombreUsuario != "" || Usuario.Contraseña != "")
                {
                    userHelper.AddUsuario(Usuario);
                    MessageBox.Show(String.Format("¡El usuario {0} ha sido creado correctamente!", Usuario.Nombre));
                }
                else 
                {
                    MessageBox.Show("Campos Imcompletos.");
                }
            }
            catch (Exception error)
            {  }
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
