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
using Microsoft.Office.Interop.Excel;

namespace Punto_de_Venta.Forms
{
    public partial class frmCuentasPorCobrar : Form
    {
        FacturaHelper facturaHelper = new FacturaHelper();
        ClienteHelper clientHelper = new ClienteHelper();

        List<PuntoDeVenta.Library.Entity_Classes.Factura> factlist = new List<PuntoDeVenta.Library.Entity_Classes.Factura>();
        List<PuntoDeVenta.Library.Entity_Classes.Cliente> clientList = new List<PuntoDeVenta.Library.Entity_Classes.Cliente>();
        public frmCuentasPorCobrar()
        {
            InitializeComponent();
        }

        public void LoadAll()
        {
            factlist = facturaHelper.GetFacturas();
            facturaBindingSource.DataSource = factlist;
            cmbClientes.Items.Clear();
            clientList = clientHelper.GetClientes();
            foreach (var cl in clientList)
            {
                cmbClientes.Items.Add(cl.NombreCompleto);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            facturaBindingSource.DataSource = facturaHelper.GetFacturasByDate(dateTimePicker1.Value.Date);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                facturaBindingSource.DataSource = facturaHelper.GetFacturasByCliente(clientHelper.GetClienteByName(cmbClientes.SelectedItem.ToString()).NombreCompleto);
            }
            catch
            {
                MessageBox.Show("No se han encontrado cuentas con este cliente, por favor verifíque.");
            }
        }

        private void CuentasPorCobrar_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void btnClientes(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.ShowDialog();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            //this.Hide();
            frmConsultas fw = new frmConsultas();
            fw.ShowDialog();
        }

        private void tmsiGuardarExcel_Click(object sender, EventArgs e)
        {
            ComunMethods cm = new ComunMethods();
            cm.ExportToExcel(FacturaGridView);
        }
    }
}
