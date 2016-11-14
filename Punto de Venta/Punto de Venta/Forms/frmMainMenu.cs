using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Entity;
using PuntoDeVenta.Library;
using System.Data.SqlClient;
using System.Globalization;
using PuntoDeVenta.Library.Helpers;

namespace Punto_de_Venta.Forms
{
    public partial class frmMainMenu : Form
    {
        UsuarioHelper userHelper = new UsuarioHelper();
        ProductoHelper productHelper = new ProductoHelper();
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserManagement newUsr = new frmUserManagement();
            newUsr.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                int userId = (context.TBL_USUARIOS.SingleOrDefault(x => x.ActivoAhora == 1)).UsuarioID;
                context.INACTIVEUSER(userId);
            }
            this.Hide();
            frmLogIn frm = new frmLogIn();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro de que desea salir de la aplicacion?", "Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                using (MuebleriaDBEntities context = new MuebleriaDBEntities())
                {
                    int userId = (context.TBL_USUARIOS.SingleOrDefault(x => x.ActivoAhora == 1)).UsuarioID;
                    context.INACTIVEUSER(userId);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
            PuntoDeVenta.Library.Entity_Classes.Usuario user = new PuntoDeVenta.Library.Entity_Classes.Usuario();

            user = userHelper.GetOnLineUser();
            label1.Text = "Bienvenido "+ user.Nombre+" "+user.Apellido;
            label3.Text = DateTime.Today.ToString("dd/MM/yyyy");
            label2.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("en-US"));
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInventoryManagement frm = new frmInventoryManagement();
            frm.ShowDialog();
        }

        private void btnPuntoDeVenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPointOfSale frm = new frmPointOfSale();
            frm.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmClientManagement frm = new frmClientManagement();
            frm.ShowDialog();
        }

        private void btnDeudores_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }
        public void NotificationsBehavior()
        {
            var a = productHelper.GetFewProducts();
            lblNotifications.Text = a.Count().ToString();
            if (a.Count > 0)
            {
                lblNotifications.BackColor = Color.Red;
                lblNotifications.ForeColor = Color.Black;
                label6.Visible = true;
            }
            else 
            {
                lblNotifications.BackColor = Color.Black;
                lblNotifications.ForeColor = Color.White;
                label6.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Today.ToString("dd/MM/yyyy");
            label2.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("en-US"));

            NotificationsBehavior();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmCuentasPorCobrar frm = new frmCuentasPorCobrar();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCuentasPorPagar frm = new frmCuentasPorPagar();
            frm.ShowDialog();
        }

        private void lblNotifications_DoubleClick(object sender, EventArgs e)
        {
            frmFewProducts frm = new frmFewProducts();
            frm.ShowDialog();
        }
    }
}
