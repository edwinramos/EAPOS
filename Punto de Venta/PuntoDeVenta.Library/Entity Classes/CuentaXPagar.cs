using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Library.Entity_Classes
{
    public class CuentaXPagar
    {
        public int CxPID { get; set; }
        public int DeudorID { get; set; }
        public string ConceptoDeuda { get; set; }
        public decimal MontoAPagar { get; set; }
        public string NombreDeudor { get; set; }
        public string EstadoDeuda { get; set; }
        public DateTime FechaDeuda { get; set; }
    }
}
