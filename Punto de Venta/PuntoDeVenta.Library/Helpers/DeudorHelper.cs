using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;

namespace PuntoDeVenta.Library.Helpers
{
    public class DeudorHelper
    {
        public void AddDeudor(Entity_Classes.Deudor deudor)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                TBL_DEUDORES deu = new TBL_DEUDORES()
                {
                    Email = deudor.Email,
                    NombreCompleto = deudor.NombreDeudor,
                    NombreContacto = deudor.NombreContacto,
                    Telefono = deudor.Telefono
                };
                context.TBL_DEUDORES.Add(deu);
                context.SaveChanges();
            }
        }

        public List<Entity_Classes.Deudor> GetAllDeudores()
        {
            List<Entity_Classes.Deudor> list = new List<Entity_Classes.Deudor>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_DEUDORES)
                {
                    list.Add(ToModelDeudor(item));
                }
            }
            return list;
        }

        public Entity_Classes.Deudor ToModelDeudor(TBL_DEUDORES deudor)
        {
            Entity_Classes.Deudor deu = new Entity_Classes.Deudor()
            {
                DeudorID = deudor.DeudorID,
                NombreDeudor = deudor.NombreCompleto,
                NombreContacto = deudor.NombreContacto,
                Telefono = deudor.Telefono,
                Email = deudor.Email
            };
            return deu;
        }

        public Entity_Classes.Deudor GetDeudorByName(string name)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var ss = context.TBL_DEUDORES.SingleOrDefault(x => x.NombreCompleto == name);
                Entity_Classes.Deudor deudor = new Entity_Classes.Deudor()
                {
                    DeudorID = ss.DeudorID,
                    Email = ss.Email,
                    NombreDeudor = ss.NombreCompleto,
                    NombreContacto = ss.NombreContacto,
                    Telefono = ss.Telefono
                };
                return deudor;
            }
        }
    }
}
