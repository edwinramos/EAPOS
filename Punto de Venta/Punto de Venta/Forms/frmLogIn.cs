using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using PuntoDeVenta.Library.Helpers;
using PuntoDeVenta.Entity;
using System.Data.SqlClient;

namespace Punto_de_Venta.Forms
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioHelper getusrs = new UsuarioHelper();
                List<PuntoDeVenta.Library.Entity_Classes.Usuario> usrlist = new List<PuntoDeVenta.Library.Entity_Classes.Usuario>();
                usrlist = getusrs.GetUsuarios();
                string enc = getusrs.Encrypt(txtPassword.Text);
                PuntoDeVenta.Library.Entity_Classes.Usuario usr = usrlist.Single(x => x.Contraseña == enc && x.NombreUsuario == txtUserName.Text);
                string dec = getusrs.Decrypt(usr.Contraseña);
                if (txtUserName.Text == usr.NombreUsuario && txtPassword.Text == dec)
                {
                    using (MuebleriaDBEntities context = new MuebleriaDBEntities())
                    {
                        context.ACTIVEUSER(usr.UsuarioID);
                    }
                    frmMainMenu frm = new frmMainMenu();
                    this.Hide();
                    frm.ShowDialog();                 
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Usuario o Contraseña incorrectos.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}