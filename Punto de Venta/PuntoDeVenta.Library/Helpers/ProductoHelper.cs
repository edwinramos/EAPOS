using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PuntoDeVenta.Entity;
using System.Data.Entity.Validation;

namespace PuntoDeVenta.Library.Helpers
{
    public class ProductoHelper
    {
        public List<Entity_Classes.Producto> GetFewProducts()
        {
            List<Entity_Classes.Producto> list = new List<Entity_Classes.Producto>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var s = context.TBL_PRODUCTOS.Where(x => x.UnidadesEnAlmacen <= 2);
                foreach (var item in s)
                {
                    list.Add(ToModelProduct(item));
                }
            }
            return list;
        }

        public void AddProducto(Entity_Classes.Producto product)
        {
            try
            {
                using (MuebleriaDBEntities context = new MuebleriaDBEntities())
                {
                    context.TBL_PRODUCTOS.Add(ToTableProduct(product));
                    context.SaveChanges();

                }
            }
            catch (DbEntityValidationException q)
            {
                string msh = q.InnerException.ToString();
            }
        }

        public bool CheckProductAvailability(string barCode, int amount)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var res = (from n in context.TBL_PRODUCTOS
                           where n.UnidadesEnAlmacen >= 0
                           && n.CodigoDeBarra == barCode
                           select n.UnidadesEnAlmacen).ToList();

                if (amount - (Convert.ToInt32(res[0])) <= 0)
                {
                    return true;
                }

            }
            return false;
        }

        public bool BarCodeChecker(String bcode)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                return context.TBL_PRODUCTOS.Any(x => x.CodigoDeBarra == bcode);
            }
        }

        public void UpdateProductInStock(string barCode, int cantidad)
        {

            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                TBL_PRODUCTOS prod = context.TBL_PRODUCTOS.SingleOrDefault(x => x.CodigoDeBarra == barCode);
                prod.UnidadesEnAlmacen = cantidad;
                context.SaveChanges();
            }
        }

        public void UpdateProducto(Entity_Classes.Producto product)
        {
            SuplidorHelper supHelper = new SuplidorHelper();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var pro = context.TBL_PRODUCTOS.SingleOrDefault(x => x.ProductoID == product.ProductoID);
                pro.CodigoDeBarra = product.CodigoBarra;
                pro.PrecioDeLista = product.PrecioDeLista;
                pro.Descontinuado = product.Descontinuado;
                pro.Descripcion = product.Descripcion;
                pro.Marca = product.Marca;
                pro.ProductoNombre = product.NombreProducto;
                pro.PrecioPorUnidad = product.PrecioPorUnidad;
                pro.SuplidorNombre = product.SuplidorNombre;
                pro.UnidadesEnAlmacen = product.UnidadesEnAlmacen;
                pro.SuplidorID = supHelper.GetSuplidorID(pro.SuplidorNombre);
                pro.FechaDeCompra = product.FechaDeCompra;
                context.SaveChanges();
            }
        }

        public List<PuntoDeVenta.Library.Entity_Classes.Producto> GetProductsByIngresoDate(DateTime date)
        {
            List<PuntoDeVenta.Library.Entity_Classes.Producto> list = new List<Entity_Classes.Producto>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var dd = from item in context.TBL_PRODUCTOS
                         where item.FechaDeIngreso == date
                         select item;
                foreach (var item in dd)
                {
                    list.Add(ToModelProduct(item));
                }
            }
            return list;
        }

        public List<PuntoDeVenta.Library.Entity_Classes.Producto> GetProductsByCompraDate(DateTime date)
        {
            List<PuntoDeVenta.Library.Entity_Classes.Producto> list = new List<Entity_Classes.Producto>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                var dd = from item in context.TBL_PRODUCTOS
                         where item.FechaDeCompra == date
                         select item;
                foreach (var item in dd)
                {
                    list.Add(ToModelProduct(item));
                }
            }
            return list;
        }
        public int GetProductPrice(String barcode)
        {
            Entity_Classes.Producto product = new Entity_Classes.Producto();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                product = ToModelProduct(context.TBL_PRODUCTOS.SingleOrDefault(x => x.CodigoDeBarra == barcode));
            }
            return Convert.ToInt32(product.PrecioPorUnidad);
        }

        public Entity_Classes.Producto GetProductByCode(int code)
        {
            Entity_Classes.Producto product = new Entity_Classes.Producto();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                product = ToModelProduct(context.TBL_PRODUCTOS.SingleOrDefault(x => x.ProductoID == code));
            }

            return product;
        }

        public TBL_PRODUCTOS ToTableProduct(Entity_Classes.Producto product)
        {
            TBL_PRODUCTOS DBProduct = new TBL_PRODUCTOS();
            DBProduct.CodigoDeBarra = product.CodigoBarra;
            DBProduct.ProductoNombre = product.NombreProducto;
            DBProduct.PrecioPorUnidad = product.PrecioPorUnidad;
            DBProduct.Marca = product.Marca;
            DBProduct.UnidadesEnAlmacen = product.UnidadesEnAlmacen;
            DBProduct.Descripcion = product.Descripcion;
            DBProduct.Descontinuado = product.Descontinuado;
            DBProduct.FechaDeIngreso = product.FechaDeIngreso;
            DBProduct.FechaDeCompra = product.FechaDeCompra;
            DBProduct.SuplidorNombre = product.SuplidorNombre;
            DBProduct.SuplidorID = product.SuplidorID;
            DBProduct.PrecioDeLista = product.PrecioDeLista;
            return DBProduct;
        }

        public Entity_Classes.Producto ToModelProduct(TBL_PRODUCTOS product)
        {
            Entity_Classes.Producto pro = new Entity_Classes.Producto();
            pro.CodigoBarra = product.CodigoDeBarra;
            pro.NombreProducto = product.ProductoNombre;
            pro.PrecioPorUnidad = product.PrecioPorUnidad;
            pro.Marca = product.Marca;
            pro.UnidadesEnAlmacen = product.UnidadesEnAlmacen;
            pro.Descripcion = product.Descripcion;
            pro.Descontinuado = product.Descontinuado;
            pro.FechaDeIngreso = product.FechaDeIngreso;
            pro.FechaDeCompra = product.FechaDeCompra;
            pro.SuplidorNombre = product.SuplidorNombre;
            pro.SuplidorID = product.SuplidorID;
            pro.PrecioDeLista = product.PrecioDeLista;
            return pro;
        }

        /*public List<Entity_Classes.ProductoFantasma> GetProductosFantasma()
        {
            List<Entity_Classes.ProductoFantasma> productList = new List<Entity_Classes.ProductoFantasma>();
            using(MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach(var item in context.TBL_PRODUCTOS)
                {
                    Entity_Classes.Producto prod = new Entity_Classes.Producto();
                    Entity_Classes.ProductoFantasma jiggle = new Entity_Classes.ProductoFantasma();
                    jiggle.CodigoBarra = item.CodigoDeBarra;
                    jiggle.NombreProducto = item.ProductoNombre;
                    jiggle.PrecioPorUnidad = item.PrecioPorUnidad.ToString("#,##0");
                    jiggle.Marca = item.Marca;
                    jiggle.UnidadesEnAlmacen = item.UnidadesEnAlmacen;
                    jiggle.Descripcion = item.Descripcion;
                    jiggle.Descontinuado = item.Descontinuado;
                    productList.Add(jiggle);
                }
            }
            return productList;
        }*/

        public List<Entity_Classes.Producto> GetProductos()
        {
            List<Entity_Classes.Producto> productList = new List<Entity_Classes.Producto>();
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                foreach (var item in context.TBL_PRODUCTOS)
                {
                    Entity_Classes.Producto jiggle = new Entity_Classes.Producto();
                    jiggle.ProductoID = item.ProductoID;
                    jiggle.CodigoBarra = item.CodigoDeBarra;
                    jiggle.NombreProducto = item.ProductoNombre;
                    jiggle.PrecioPorUnidad = Math.Round(item.PrecioPorUnidad, 2);
                    jiggle.Marca = item.Marca;
                    jiggle.UnidadesEnAlmacen = item.UnidadesEnAlmacen;
                    jiggle.Descripcion = item.Descripcion;
                    jiggle.Descontinuado = item.Descontinuado;
                    jiggle.FechaDeIngreso = item.FechaDeIngreso;
                    jiggle.FechaDeCompra = item.FechaDeCompra;
                    jiggle.SuplidorID = item.SuplidorID;
                    jiggle.SuplidorNombre = item.SuplidorNombre;
                    jiggle.PrecioDeLista = item.PrecioDeLista;
                    productList.Add(jiggle);
                }
            }
            return productList;
        }

        public void DeleteProduct(int productID)
        {
            using (MuebleriaDBEntities context = new MuebleriaDBEntities())
            {
                context.TBL_PRODUCTOS.Remove(context.TBL_PRODUCTOS.SingleOrDefault(x => x.ProductoID == productID));
                context.SaveChanges();
            }

        }
    }
}
