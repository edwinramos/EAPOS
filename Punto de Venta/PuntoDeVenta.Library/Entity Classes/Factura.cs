using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Library.Entity_Classes
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal TotalEnFactura { get; set; }
        public int UsuarioID { get; set; }
        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NombreUsuario { get; set; }
        public virtual List<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
