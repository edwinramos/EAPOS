using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;

namespace PuntoDeVenta.Library.Helpers
{
    public class FacturaHelper
    {
        #region Metodos de Facturas
        public void AddFactura(PuntoDeVenta.Library.Entity_Classes.Factura f)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_FACTURAS.Add(ToTableFatura(f));//ver relacion factura-cliente al guardar factura con cliente vacio
                foreach (var item in f.FacturaDetalles)
                {
                    context.PRODUCT_SOLD(item.CodigoDeBarra, item.Cantidad);
                }
                context.SaveChanges();
            }
        }

        public decimal GetGananciasProductos(string barCode, int facturaId)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {

                var dd = context.TBL_FACTURA_DETALLE.FirstOrDefault(x => x.CodigoDeBarra == barCode && x.FacturaID == facturaId);
                decimal preLista = context.TBL_PRODUCTOS.FirstOrDefault(x => x.CodigoDeBarra == barCode).PrecioDeLista;
                //decimal preUnitario = context.TBL_PRODUCTOS.FirstOrDefault(x => x.CodigoDeBarra == barCode).PrecioPorUnidad;
                decimal preDescuento = context.TBL_FACTURA_DETALLE.FirstOrDefault(x => x.FacturaID == facturaId && x.CodigoDeBarra == barCode).PrecioConDescuento;
                //decimal pLista = Convert.ToDecimal((from p in context.TBL_PRODUCTOS
                //                           where p.CodigoDeBarra == barCode
                //                           select p.PrecioDeLista).ToString());

                //decimal pUnitario = Convert.ToDecimal(from p in context.TBL_PRODUCTOS
                //                                   where p.CodigoDeBarra == barCode
                //                                   select p.PrecioPorUnidad);

                return Math.Abs((preLista - preDescuento) * dd.Cantidad);
                //decimal precioDescuento = (from p in context.TBL_PRODUCTOS
                //           join fd in context.TBL_FACTURA_DETALLE on p.CodigoDeBarra equals fd.CodigoDeBarra
                //           where p.CodigoDeBarra == barCode
                //           select fd.PrecioConDescuento).Sum();

                //var precioDeLista = (from p in context.TBL_PRODUCTOS
                //           where p.CodigoDeBarra == barCode
                //           select p.PrecioDeLista).Sum();

                //return (Convert.ToDecimal(precioDeLista) - precioDescuento);
            }
        }

        public Object GetBillsBetweenDates(DateTime date1, DateTime date2)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var res = (from f in context.TBL_FACTURAS
                           join fd in context.TBL_FACTURA_DETALLE on f.FacturaID equals fd.FacturaID
                           join p in context.TBL_PRODUCTOS on fd.CodigoDeBarra equals p.CodigoDeBarra
                           where f.FechaFactura <= date2.Date && f.FechaFactura >= date1.Date
                           select new
                           {
                               FacturaID = fd.FacturaID,
                               CodigoDeBarra = fd.CodigoDeBarra,
                               NombreProducto = p.ProductoNombre,
                               Cantidad = fd.Cantidad,
                               FechaFactura = f.FechaFactura,
                               PrecioConDescuento = fd.PrecioConDescuento
                           }).ToList();
                return res;
            }
        }
        public Object GetBillsADay(DateTime date)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var res = (from f in context.TBL_FACTURAS
                           join fd in context.TBL_FACTURA_DETALLE on f.FacturaID equals fd.FacturaID
                           join p in context.TBL_PRODUCTOS on fd.CodigoDeBarra equals p.CodigoDeBarra
                           where f.FechaFactura == date.Date
                           select new
                           {
                               FacturaID = fd.FacturaID,
                               CodigoDeBarra = fd.CodigoDeBarra,
                               NombreProducto = p.ProductoNombre,
                               Cantidad = fd.Cantidad,
                               FechaFactura = f.FechaFactura,
                               PrecioConDescuento = fd.PrecioConDescuento
                           }).ToList();
                return res;
            }
        }

        public void AddFacturaDetalle(PuntoDeVenta.Library.Entity_Classes.FacturaDetalle fd)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_FACTURA_DETALLE.Add(ToTableFaturaDetalle(fd));
                context.SaveChanges();
            }
        }

        public TBL_FACTURAS ToTableFatura(PuntoDeVenta.Library.Entity_Classes.Factura f)
        {
            TBL_FACTURAS DBfactura = new TBL_FACTURAS();
            DBfactura.FechaFactura = f.FechaFactura;
            DBfactura.UsuarioID = f.UsuarioID;
            DBfactura.CedulaCliente = f.CedulaCliente;
            DBfactura.NombreCliente = f.NombreCliente;
            DBfactura.TotalEnFactura = f.TotalEnFactura;
            DBfactura.UsuarioID = f.UsuarioID;
            DBfactura.NombreUsuario = f.NombreUsuario;
            foreach (var x in f.FacturaDetalles)
            {
                DBfactura.TBL_FACTURA_DETALLE.Add(ToTableFaturaDetalle(x));
            }
            return DBfactura;
        }

        public TBL_FACTURA_DETALLE ToTableFaturaDetalle(PuntoDeVenta.Library.Entity_Classes.FacturaDetalle fd)
        {
            TBL_FACTURA_DETALLE factura = new TBL_FACTURA_DETALLE();
            factura.Cantidad = fd.Cantidad;
            factura.CodigoDeBarra = fd.CodigoDeBarra;
            factura.NombreProducto = fd.NombreProducto;
            factura.PrecioPorCantidad = fd.PrecioPorCantidad;
            factura.Descuento = fd.Descuento;
            factura.PrecioConDescuento = fd.PrecioConDescuento;

            return factura;
        }

        public PuntoDeVenta.Library.Entity_Classes.Factura ToModelFactura(TBL_FACTURAS DBFactura)
        {
            PuntoDeVenta.Library.Entity_Classes.Factura fa = new Entity_Classes.Factura();
            fa.FacturaID = DBFactura.FacturaID;
            fa.FechaFactura = DBFactura.FechaFactura;
            fa.NombreCliente = DBFactura.NombreCliente;
            fa.NombreUsuario = DBFactura.NombreUsuario;
            fa.TotalEnFactura = DBFactura.TotalEnFactura;
            fa.UsuarioID = DBFactura.UsuarioID;
            fa.CedulaCliente = DBFactura.CedulaCliente;
            foreach (var x in DBFactura.TBL_FACTURA_DETALLE)
            {
                fa.FacturaDetalles.Add(ToModelFacturaDetalle(x));
            }

            return fa;
        }

        public PuntoDeVenta.Library.Entity_Classes.FacturaDetalle ToModelFacturaDetalle(TBL_FACTURA_DETALLE factura)
        {
            PuntoDeVenta.Library.Entity_Classes.FacturaDetalle fd = new PuntoDeVenta.Library.Entity_Classes.FacturaDetalle();
            fd.DetalleID = factura.FacturaID;
            fd.NombreProducto = factura.NombreProducto;
            fd.Cantidad = factura.Cantidad;
            fd.CodigoDeBarra = factura.CodigoDeBarra;
            fd.Descuento = factura.Descuento;
            fd.PrecioPorCantidad = factura.PrecioPorCantidad;
            fd.PrecioConDescuento = factura.PrecioConDescuento;

            return fd;
        }

        public List<TBL_FACTURAS> GetFacturasByCliente(string cliente)
        {
            List<TBL_FACTURAS> list = new List<TBL_FACTURAS>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var ff = context.TBL_FACTURAS.Where(x => x.NombreCliente == cliente);
                foreach (var item in ff)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public List<TBL_FACTURAS> GetFacturasByDate(DateTime date)
        {
            List<TBL_FACTURAS> list = new List<TBL_FACTURAS>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var ff = from item in context.TBL_FACTURAS
                         where item.FechaFactura == date
                         select item;

                foreach (var item in ff)
                {
                    list.Add(item);
                }
                //}
            }

            return list;
        }

        public List<PuntoDeVenta.Library.Entity_Classes.Factura> GetFacturas()
        {
            List<PuntoDeVenta.Library.Entity_Classes.Factura> list = new List<Entity_Classes.Factura>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_FACTURAS)
                {
                    PuntoDeVenta.Library.Entity_Classes.Factura factura = new Entity_Classes.Factura();
                    factura.FacturaID = item.FacturaID;
                    factura.FechaFactura = item.FechaFactura;
                    factura.UsuarioID = item.UsuarioID;
                    factura.CedulaCliente = item.CedulaCliente;
                    factura.NombreUsuario = item.NombreUsuario;
                    factura.NombreCliente = item.NombreCliente;
                    factura.TotalEnFactura = item.TotalEnFactura;
                    var query = context.TBL_FACTURA_DETALLE.Where(x => x.FacturaID == factura.FacturaID);
                    foreach (var x in query)
                    {
                        factura.FacturaDetalles = new List<Entity_Classes.FacturaDetalle>();
                        factura.FacturaDetalles.Add(ToModelFacturaDetalle(x));
                    }
                    list.Add(factura);
                }
            }
            return list;
        }
        #endregion
    }
}
