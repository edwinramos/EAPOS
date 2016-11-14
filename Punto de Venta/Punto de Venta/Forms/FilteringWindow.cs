using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PuntoDeVenta.Library.Helpers;
using Microsoft.Office.Interop.Excel;

namespace Punto_de_Venta.Forms
{
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
        }
        FacturaHelper facturaHelper = new FacturaHelper();
        
        public void DtpsSwitch(bool pow)
        {
            dtpDia.Enabled = pow;
            dtpFechaIni.Enabled = !pow;
            dtpFechaFin.Enabled = !pow;
            label1.Enabled = !pow;
            label2.Enabled = !pow;
        }

        private void rbtnDia_Click(object sender, EventArgs e)
        {
            DtpsSwitch(true);
        }

        private void rbtnFecha_Click(object sender, EventArgs e)
        {
            DtpsSwitch(false);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            LoadGrid();
        }

        public void LoadGrid()
        {
            Object data = new Object();
            decimal sum = 0;
            decimal csum = 0;
            if (rbtnDia.Checked)
            {
                data = facturaHelper.GetBillsADay(dtpDia.Value.Date);                
                bindingSource1.DataSource = data;
            }
            else
            {
                data = facturaHelper.GetBillsBetweenDates(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date);
                bindingSource1.DataSource = data;
            }
            FillGrid();
            var o = (dataGridView1.Rows.Cast<DataGridViewRow>().Select(s => s.Cells[1].Value)).ToList();
            var fId = (dataGridView1.Rows.Cast<DataGridViewRow>().Select(s => s.Cells[0].Value)).ToList();
            var c = (dataGridView1.Rows.Cast<DataGridViewRow>().Select(s => s.Cells[5].Value)).ToList();
            for (int i = 0; i < dataGridView1.RowCount; i++ )
            {
                sum += facturaHelper.GetGananciasProductos(o[i].ToString(), Convert.ToInt32(fId[i]));
            }
            foreach (var row in c)
            {
                csum += Convert.ToDecimal(row);
            }

            label5.Text = String.Format("Ganancia Total: RD${0}", sum.ToString("0.00"));
            label4.Text = String.Format("Total Vendido: RD${0}", csum.ToString("0.00"));
        }

        private void FillGrid()
        {
            dataGridView1.Columns["FacturaID"].DataPropertyName = "FacturaID";
            dataGridView1.Columns["CodigoDeBarra"].DataPropertyName = "CodigoDeBarra";
            dataGridView1.Columns["NombreProducto"].DataPropertyName = "NombreProducto";
            dataGridView1.Columns["Cantidad"].DataPropertyName = "Cantidad";
            dataGridView1.Columns["FechaFactura"].DataPropertyName = "FechaFactura";
            dataGridView1.Columns["PrecioConDescuento"].DataPropertyName = "PrecioConDescuento";
            //dataGridView1.Columns["Ganancias"].DataPropertyName = "Ganancias";
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);

            DtpsSwitch(true);
        }

        public void ExportToExcel()
        {
            // Create a DataSet and add the DataTable of DataGridView 
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

            // Export Excel file 
            Microsoft.Office.Interop.Excel.Application excelFile = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook;
            Worksheet sheet;
            var misValue = System.Reflection.Missing.Value;
            excelFile.Visible = true;
            workbook = excelFile.Workbooks.Add(misValue);
            sheet = (Worksheet)workbook.Worksheets.get_Item(1);
            sheet.Cells[1, 1].EntireRow.Font.Bold = true;
            Range cr = (Range)sheet.Cells[1, 1];
            cr.Select();
            sheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void tsmiGuardarExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
    }
}
