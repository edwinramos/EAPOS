using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;

namespace PuntoDeVenta.Library.Helpers
{
    public class CuentasPorPagarHelper
    {
        public void AddCxP(Entity_Classes.CuentaXPagar cxp)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_CUENTAS_X_PAGAR.Add(ToTableCxP(cxp));
                context.SaveChanges();
            }
        }

        public List<Entity_Classes.CuentaXPagar> GetAllCxP()
        {
            List<Entity_Classes.CuentaXPagar> list = new List<Entity_Classes.CuentaXPagar>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_CUENTAS_X_PAGAR)
                {
                    list.Add(ToModelCxP(item));
                }
            }

            return list;
        }

        public void UpdateCxP(Entity_Classes.CuentaXPagar cxp)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var ss = context.TBL_CUENTAS_X_PAGAR.SingleOrDefault(x => x.CxPID == cxp.CxPID);
                ss.CxPID = cxp.CxPID;
                ss.EstadoDeuda = cxp.EstadoDeuda;
                ss.DeudorID = cxp.DeudorID;
                ss.MontoAPagar = cxp.MontoAPagar;
                ss.ConceptoDeuda = cxp.ConceptoDeuda;
                ss.NombreDeudor = cxp.NombreDeudor;
                context.SaveChanges();
            }
        }

        public TBL_CUENTAS_X_PAGAR ToTableCxP(Entity_Classes.CuentaXPagar cxp)
        {
            TBL_CUENTAS_X_PAGAR cp = new TBL_CUENTAS_X_PAGAR()
            {
                CxPID = cxp.CxPID,
                EstadoDeuda = cxp.EstadoDeuda,
                DeudorID = cxp.DeudorID,
                MontoAPagar = cxp.MontoAPagar,
                ConceptoDeuda = cxp.ConceptoDeuda,
                NombreDeudor = cxp.NombreDeudor,
                FechaDeuda = cxp.FechaDeuda
            };

            return cp;
        }

        public Entity_Classes.CuentaXPagar ToModelCxP(TBL_CUENTAS_X_PAGAR cxp)
        {
            Entity_Classes.CuentaXPagar cp = new Entity_Classes.CuentaXPagar()
            {
                CxPID = cxp.CxPID,
                EstadoDeuda = cxp.EstadoDeuda,
                DeudorID = cxp.DeudorID,
                MontoAPagar = cxp.MontoAPagar,
                ConceptoDeuda = cxp.ConceptoDeuda,
                NombreDeudor = cxp.NombreDeudor,
                FechaDeuda = cxp.FechaDeuda
            };

            return cp;
        }
    }
}
