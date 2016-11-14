using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using PuntoDeVenta.Library.Helpers;

namespace Punto_de_Venta.Forms
{
    public partial class frmSupplierManagement : Form
    {
        List<PuntoDeVenta.Library.Entity_Classes.TipoSuplidor> SuplidorTipos = new List<PuntoDeVenta.Library.Entity_Classes.TipoSuplidor>();
        SuplidorHelper supHelper = new SuplidorHelper();
        public frmSupplierManagement()
        {
            InitializeComponent();
        }

        private void SupplierManagement_Load(object sender, EventArgs e)
        {
            LoadGrid();

            SuplidorTipos = supHelper.GetTiposSuplidores();
            foreach (var item in SuplidorTipos)
            {
                cmbTipo.Items.Add(item.NombreTipo);
            }
        }

        public void LoadGrid()
        {
            List<PuntoDeVenta.Library.Entity_Classes.Suplidor> list = supHelper.GetSuplidores();
            suplidorBindingSource.DataSource = list;
            System.Data.DataTable dt = new System.Data.DataTable();
        }

        public void CleanAll()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is System.Windows.Forms.TextBox)
                        (control as System.Windows.Forms.TextBox).Clear();
                    else
                        func(control.Controls);
                foreach (Control control in controls)
                    if (control is System.Windows.Forms.MaskedTextBox)
                        (control as System.Windows.Forms.MaskedTextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        public bool CheckProperties(PuntoDeVenta.Library.Entity_Classes.Suplidor obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (string.IsNullOrEmpty(property.GetValue(obj, null).ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                PuntoDeVenta.Library.Entity_Classes.Suplidor suplidor = new PuntoDeVenta.Library.Entity_Classes.Suplidor();
                suplidor.NombreSuplidor = txtNombre.Text;
                suplidor.Descripcion = txtDescripcion.Text;
                suplidor.Direccion = txtDireccion.Text;
                suplidor.NombreContacto = txtNombreContacto.Text;
                suplidor.NumeroTelefono = txtNumeroTelefono.Text;
                suplidor.TelefonoDeContacto = txtTelefonoContacto.Text;
                suplidor.TituloContacto = txtTituloContacto.Text;
                suplidor.Ciudad = txtCiudad.Text;
                suplidor.TipoID = supHelper.GetTipoSuplidor(cmbTipo.SelectedItem.ToString());
                suplidor.TipoNombre = cmbTipo.SelectedItem.ToString();
                suplidor.Email = txtEmail.Text;
                suplidor.PaginaWeb = txtPaginaWeb.Text;

                if (!CheckProperties(suplidor))
                {
                    throw new Exception();
                }
                if (checkBox1.Checked)
                {
                    suplidor.SuplidorID = Convert.ToInt32(SupplierGridView.SelectedCells[0].Value);
                    supHelper.UpdateSuplidor(suplidor);
                    LoadGrid();
                    CleanAll();
                }
                else
                {
                    supHelper.AddSuplidor(suplidor);
                    LoadGrid();
                    CleanAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe llenar todos los campos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInventoryManagement frm = new frmInventoryManagement();
            frm.ShowDialog();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = SupplierGridView.Rows[SupplierGridView.SelectedRows[0].Index];
                int code = Convert.ToInt32(row.Cells[0].Value);
                PuntoDeVenta.Library.Entity_Classes.Suplidor suplidor = supHelper.GetSuplidorByCode(code);
                txtTituloContacto.Text = suplidor.TituloContacto;
                txtNombre.Text = suplidor.NombreSuplidor;
                txtDescripcion.Text = suplidor.Descripcion;
                txtDireccion.Text = suplidor.Direccion;
                txtCiudad.Text = suplidor.Ciudad;
                txtNombreContacto.Text = suplidor.NombreContacto;
                txtNumeroTelefono.Text = suplidor.NumeroTelefono;
                txtTelefonoContacto.Text = suplidor.TelefonoDeContacto;
                txtEmail.Text = suplidor.Email;
                txtPaginaWeb.Text = suplidor.PaginaWeb;

                if (suplidor.TipoID == 1)
                {
                    cmbTipo.SelectedIndex = 0;
                }
                else
                {
                    cmbTipo.SelectedIndex = 1;
                }
                checkBox1.Checked = true;
                //txtCodigoBarra.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Debe seleccionar antes de editar, por favor verífique.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("¿Seguro que desea eliminar el suplidor?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    var row = SupplierGridView.Rows[SupplierGridView.SelectedRows[0].Index];
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    supHelper.DeleteSuplidor(id);
                    LoadGrid();
                }
            }
            catch
            { MessageBox.Show("No se ha seleccionado un elemento para eliminar, por favor verífique."); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = SupplierGridView.Rows[SupplierGridView.SelectedRows[0].Index];
            frmSuplidorDetails detalles = new frmSuplidorDetails(row);
            detalles.Show();
        }

        private void tsmiGuardarComo_Click(object sender, EventArgs e)
        {
            ComunMethods cm = new ComunMethods();
            cm.ExportToExcel(SupplierGridView);
        }
    }
}
