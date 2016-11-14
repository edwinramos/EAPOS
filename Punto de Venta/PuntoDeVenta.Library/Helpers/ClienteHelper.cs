using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;

namespace PuntoDeVenta.Library.Helpers
{
    public class ClienteHelper : ComunMethods
    {
        
        public void AddCliente(PuntoDeVenta.Library.Entity_Classes.Cliente client)
        {         
            context.TBL_CLIENTES.Add(ToTableCliente(client));
            context.SaveChanges();
        }

        public TBL_CLIENTES ToTableCliente(PuntoDeVenta.Library.Entity_Classes.Cliente client)
        {
            TBL_CLIENTES cl = new TBL_CLIENTES();
            cl.CedulaCliente = client.CedulaCliente;
            cl.Email = client.Email;
            cl.Direccion = client.Direccion;
            cl.NombreCompleto = client.NombreCompleto;
            cl.RNC = client.RNC;
            return cl;
        }

        public PuntoDeVenta.Library.Entity_Classes.Cliente ToModelCleinte(TBL_CLIENTES client)
        {
            PuntoDeVenta.Library.Entity_Classes.Cliente cl = new Entity_Classes.Cliente();
            cl.CedulaCliente = client.CedulaCliente;
            cl.Email = client.Email;
            cl.Direccion = client.Direccion;

            cl.NombreCompleto = client.NombreCompleto;
            cl.RNC = client.RNC;
            return cl;
        }

        public PuntoDeVenta.Library.Entity_Classes.Cliente GetClienteByName(string name)
        {
            PuntoDeVenta.Library.Entity_Classes.Cliente cl = new Entity_Classes.Cliente();
            if (name != "")
            {
                cl = ToModelCleinte(context.TBL_CLIENTES.SingleOrDefault(x => x.NombreCompleto == name));
            }
            return cl;
        }

        public List<PuntoDeVenta.Library.Entity_Classes.Cliente> GetClientes()
        {
            List<PuntoDeVenta.Library.Entity_Classes.Cliente> list = new List<Entity_Classes.Cliente>();

            foreach (var item in context.TBL_CLIENTES)
            {
                list.Add(ToModelCleinte(item));
            }

            return list;
        }
    }
}
