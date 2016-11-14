using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Library.Entity_Classes
{
    public class Suplidor
    {
        public int SuplidorID { get; set; }
        public string NombreSuplidor { get; set; }
        public string Descripcion { get; set; }
        public string NumeroTelefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string TipoNombre { get; set; }
        public string NombreContacto { get; set; }
        public string TituloContacto { get; set; }
        public string TelefonoDeContacto { get; set; }
        public int TipoID { get; set; }
        public string Email { get; set; }
        public string PaginaWeb { get; set; }
    }
}
