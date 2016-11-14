using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Library.Entity_Classes
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public String CodigoBarra { get; set; }
        public int SuplidorID { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public decimal PrecioPorUnidad { get; set; }
        public string Descripcion { get; set; }
        public int UnidadesEnAlmacen { get; set; }
        public int Descontinuado { get; set; }
        public string SuplidorNombre { get; set; }
        public decimal PrecioDeLista { get; set; }
        public DateTime? FechaDeCompra { get; set; }
        public DateTime FechaDeIngreso { get; set; }
    }
}


