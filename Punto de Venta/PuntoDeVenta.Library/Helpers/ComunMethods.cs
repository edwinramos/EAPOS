using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PuntoDeVenta.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Data.Entity.Validation;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace PuntoDeVenta.Library.Helpers
{
    public class ComunMethods
    {
        //string connString = "data source=EDWIN-PC;initial catalog=MuebleriaDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";

        #region Metodos de Ordenes
        /*public void AddOrden(Entity_Classes.Orden_Detalle OrDet)
        {
            using(MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_ORDENES_DETALLES.Add(ToTableOrDet(OrDet));
                context.SaveChanges();
            }
        }

        public TBL_ORDENES_DETALLES ToTableOrDet(Entity_Classes.Orden_Detalle OrDet)
        {
            TBL_ORDENES_DETALLES orden = new TBL_ORDENES_DETALLES();
            orden.CodigoDeBarra = OrDet.CodigoDeBarra;
            orden.Cantidad = OrDet.Cantidad;
            orden.OrdenID = OrDet.OrdenID;
            //orden.NombreProducto = OrDet.NombreProducto;
            orden.Descuento = OrDet.Descuento;
            orden.PrecioConDescuento = OrDet.PrecioConDescuento;
            orden.PrecioCantidad = OrDet.PrecioPorCantidad;

            
            return orden;
        }
        */

        #endregion

        public MuebleriaDBEntities context = new MuebleriaDBEntities();

        public void ExportToExcel(DataGridView dataGrid)
        {
            // Create a DataSet and add the DataTable of DataGridView 
            dataGrid.RowHeadersVisible = true;
            dataGrid.SelectAll();
            DataObject dataObj = dataGrid.GetClipboardContent();
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
    }
}
