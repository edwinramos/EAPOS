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
    
    public partial class TBL_CUENTAS_X_PAGAR
    {
        public int CxPID { get; set; }
        public string ConceptoDeuda { get; set; }
        public decimal MontoAPagar { get; set; }
        public int DeudorID { get; set; }
        public string NombreDeudor { get; set; }
        public string EstadoDeuda { get; set; }
        public System.DateTime FechaDeuda { get; set; }
    
        public virtual TBL_DEUDORES TBL_DEUDORES { get; set; }
    }
}
