//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuntoDeVenta.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_SUPLIDORES
    {
        public TBL_SUPLIDORES()
        {
            this.TBL_PRODUCTOS = new HashSet<TBL_PRODUCTOS>();
        }
    
        public int SuplidorID { get; set; }
        public string NombreSuplidor { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string NumeroTelefono { get; set; }
        public string NombreDeContacto { get; set; }
        public string TelefonoDeContacto { get; set; }
        public string TituloDeContacto { get; set; }
        public int TipoID { get; set; }
        public string TipoNombre { get; set; }
        public string Email { get; set; }
        public string PaginaWeb { get; set; }
    
        public virtual ICollection<TBL_PRODUCTOS> TBL_PRODUCTOS { get; set; }
        public virtual TBL_TIPOSUPLIDORES TBL_TIPOSUPLIDORES { get; set; }
    }
}