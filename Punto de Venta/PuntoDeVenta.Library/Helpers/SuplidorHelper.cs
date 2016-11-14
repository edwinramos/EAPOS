using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;

namespace PuntoDeVenta.Library.Helpers
{
    public class SuplidorHelper
    {
        public List<PuntoDeVenta.Library.Entity_Classes.Suplidor> GetSuplidores()
        {
            List<PuntoDeVenta.Library.Entity_Classes.Suplidor> list = new List<Entity_Classes.Suplidor>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_SUPLIDORES)
                {
                    PuntoDeVenta.Library.Entity_Classes.Suplidor sup = new Entity_Classes.Suplidor();
                    sup.SuplidorID = item.SuplidorID;
                    sup.Ciudad = item.Ciudad;
                    sup.Descripcion = item.Descripcion;
                    sup.Direccion = item.Direccion;
                    sup.NombreSuplidor = item.NombreSuplidor;
                    sup.NombreContacto = item.NombreDeContacto;
                    sup.NumeroTelefono = item.NumeroTelefono;
                    sup.TelefonoDeContacto = item.TelefonoDeContacto;
                    sup.TituloContacto = item.TituloDeContacto;
                    sup.TipoNombre = item.TipoNombre;
                    sup.TipoID = item.TipoID;
                    sup.Email = item.Email;
                    sup.PaginaWeb = item.PaginaWeb;
                    list.Add(sup);
                }
            }
            return list;
        }

        public string VerifySuplidorName(string name)
        {
            PuntoDeVenta.Library.Entity_Classes.Suplidor sup = new Entity_Classes.Suplidor();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                sup = ToModelSuplidor(context.TBL_SUPLIDORES.SingleOrDefault(x => x.NombreSuplidor == name));
            }
            return sup.NombreSuplidor;
        }

        public int GetSuplidorIdByName(string name)
        {
            PuntoDeVenta.Library.Entity_Classes.Suplidor sup = new Entity_Classes.Suplidor();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                sup = ToModelSuplidor(context.TBL_SUPLIDORES.SingleOrDefault(x => x.NombreSuplidor == name));
            }
            return sup.SuplidorID;
        }

        public Entity_Classes.Suplidor GetSuplidorByCode(int code)
        {
            Entity_Classes.Suplidor sup = new Entity_Classes.Suplidor();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                sup = ToModelSuplidor(context.TBL_SUPLIDORES.SingleOrDefault(x => x.SuplidorID == code));
            }

            return sup;
        }

        public List<PuntoDeVenta.Library.Entity_Classes.TipoSuplidor> GetTiposSuplidores()
        {
            List<PuntoDeVenta.Library.Entity_Classes.TipoSuplidor> list = new List<PuntoDeVenta.Library.Entity_Classes.TipoSuplidor>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_TIPOSUPLIDORES)
                {
                    PuntoDeVenta.Library.Entity_Classes.TipoSuplidor tipo = new Entity_Classes.TipoSuplidor();
                    tipo.TipoID = item.TipoID;
                    tipo.NombreTipo = item.NombreTipo;
                    list.Add(tipo);
                }
            }
            return list;
        }

        public int GetTipoSuplidor(string nombre)
        {
            int TipoId;
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                TipoId = (context.TBL_TIPOSUPLIDORES.SingleOrDefault(x => x.NombreTipo == nombre)).TipoID;
            }
            return TipoId;
        }

        public int GetSuplidorID(string nombre)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var sup = context.TBL_SUPLIDORES.SingleOrDefault(x => x.NombreSuplidor == nombre);
                return sup.SuplidorID;
            }
        }

        public void AddSuplidor(PuntoDeVenta.Library.Entity_Classes.Suplidor supplier)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_SUPLIDORES.Add(ToTableSuplidor(supplier));
                context.SaveChanges();
            }
        }

        public void UpdateSuplidor(Entity_Classes.Suplidor supplier)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var sup = context.TBL_SUPLIDORES.SingleOrDefault(x => x.SuplidorID == supplier.SuplidorID);
                sup.Descripcion = supplier.Descripcion;
                sup.Direccion = supplier.Direccion;
                sup.Ciudad = supplier.Ciudad;
                sup.NombreDeContacto = supplier.NombreContacto;
                sup.NombreSuplidor = supplier.NombreSuplidor;
                sup.NumeroTelefono = supplier.NumeroTelefono;
                sup.TituloDeContacto = supplier.TituloContacto;
                sup.TelefonoDeContacto = supplier.TelefonoDeContacto;
                sup.TipoID = supplier.TipoID;
                sup.TipoNombre = supplier.TipoNombre;
                sup.Email = supplier.Email;
                sup.PaginaWeb = supplier.PaginaWeb;
                context.SaveChanges();
            }
        }

        public void DeleteSuplidor(int id)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_SUPLIDORES.Remove(context.TBL_SUPLIDORES.SingleOrDefault(x => x.SuplidorID == id));
                context.SaveChanges();
            }
        }

        public PuntoDeVenta.Library.Entity_Classes.Suplidor ToModelSuplidor(TBL_SUPLIDORES supplier)
        {
            PuntoDeVenta.Library.Entity_Classes.Suplidor sup = new PuntoDeVenta.Library.Entity_Classes.Suplidor();
            sup.Descripcion = supplier.Descripcion;
            sup.Direccion = supplier.Direccion;
            sup.Ciudad = supplier.Ciudad;
            sup.NombreContacto = supplier.NombreDeContacto;
            sup.NombreSuplidor = supplier.NombreSuplidor;
            sup.NumeroTelefono = supplier.NumeroTelefono;
            sup.TituloContacto = supplier.TituloDeContacto;
            sup.TelefonoDeContacto = supplier.TelefonoDeContacto;
            sup.TipoID = supplier.TipoID;
            sup.TipoNombre = supplier.TipoNombre;
            sup.Email = supplier.Email;
            sup.PaginaWeb = supplier.PaginaWeb;
            return sup;
        }

        public TBL_SUPLIDORES ToTableSuplidor(PuntoDeVenta.Library.Entity_Classes.Suplidor supplier)
        {
            TBL_SUPLIDORES sup = new TBL_SUPLIDORES();
            sup.Descripcion = supplier.Descripcion;
            sup.Direccion = supplier.Direccion;
            sup.Ciudad = supplier.Ciudad;
            sup.NombreDeContacto = supplier.NombreContacto;
            sup.NombreSuplidor = supplier.NombreSuplidor;
            sup.NumeroTelefono = supplier.NumeroTelefono;
            sup.TituloDeContacto = supplier.TituloContacto;
            sup.TelefonoDeContacto = supplier.TelefonoDeContacto;
            sup.TipoID = supplier.TipoID;
            sup.TipoNombre = supplier.TipoNombre;
            sup.Email = supplier.Email;
            sup.PaginaWeb = supplier.PaginaWeb;
            return sup;
        }
    }
}
