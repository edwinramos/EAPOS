using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PuntoDeVenta.Library.Entity_Classes
{
    public class FacturaDetalle
    {
        public int DetalleID { get; set; }
        public int FacturaID { get; set; }
        public String CodigoDeBarra { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioPorCantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioConDescuento { get; set; }
        

    }
}
