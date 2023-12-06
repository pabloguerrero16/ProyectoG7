using ApiProyecto.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarProductos")]
        public List<ProductoEnt> ConsultarProductos()
        {
            using (var context = new ProyectoG7Entities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var productos = context.Database.SqlQuery<ProductoEnt>("ConsultarProductos").ToList();  
                return productos;
            }
        }

        [HttpGet]
        [Route("DetalleProducto")]
        public ProductoEnt DetalleProducto(long q)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.PRODUCTO
                                 where x.ConProducto == q
                                 select new ProductoEnt
                                 {
                                     ConProducto = x.ConProducto,
                                     Nombre = x.Nombre,
                                     ConModelo = (long)x.ConModelo,
                                     DescripcionModelo = x.MODELO.Descripcion,
                                     ConMarca = (long)x.ConMarca,
                                     DescripcionMarca = x.MARCA.Descripcion,
                                     ConCategoria = (long)x.ConCategoria,
                                     DescripcionCategoria = x.CATEGORIA.Descripcion,
                                     Precio = x.Precio,
                                     Stock = x.Stock,
                                     Imagen = x.Imagen
                                 }).FirstOrDefault();
                    return datos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarModelos")]
        public List<System.Web.Mvc.SelectListItem> ConsultarModelos()
        {
            try
            {
                using (var context = new ProyectoG7Entities()){
                    var datos = (from x in context.MODELO
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConModelo.ToString(), Text = item.Descripcion});
                    }
                    return respuesta;
                }
            }catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("ConsultarCategorias")]
        public List<System.Web.Mvc.SelectListItem> ConsultarCategorias()
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = (from x in context.CATEGORIA
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConCategoria.ToString(), Text = item.Descripcion });
                    }
                    return respuesta;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("ConsultarMarcas")]
        public List<System.Web.Mvc.SelectListItem> ConsultarMarcas()
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = (from x in context.MARCA
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConMarca.ToString(), Text = item.Descripcion });
                    }
                    return respuesta;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpGet]
        [Route("FiltrarModelos")]
        public List<ProductoEnt> FiltrarModelos(long q)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var productos = context.PRODUCTO
                    .Include(p => p.MODELO)
                    .Include(p => p.MARCA)
                    .Include(p => p.CATEGORIA)
                    .Where(p => p.ConModelo == q)
                    .Select(p => new ProductoEnt
                    {
                        ConProducto = p.ConProducto,
                        Nombre = p.Nombre,
                        ConModelo = (long)p.ConModelo,
                        DescripcionModelo = p.MODELO.Descripcion,
                        ConMarca = (long)p.ConMarca,
                        DescripcionMarca = p.MARCA.Descripcion,
                        ConCategoria = (long)p.ConCategoria,
                        DescripcionCategoria = p.CATEGORIA.Descripcion, 
                        Precio = p.Precio,
                        Stock = p.Stock,
                        Imagen = p.Imagen
                    })
                    .ToList();

                return productos;
            }
        }

        [HttpGet]
        [Route("FiltrarCategorias")]
        public List<ProductoEnt> FiltrarCategorias(long q)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var productos = context.PRODUCTO
                    .Include(p => p.MODELO)
                    .Include(p => p.MARCA)
                    .Include(p => p.CATEGORIA)
                    .Where(p => p.ConCategoria == q)
                    .Select(p => new ProductoEnt
                    {
                        ConProducto = p.ConProducto,
                        Nombre = p.Nombre,
                        ConModelo = (long)p.ConModelo,
                        DescripcionModelo = p.MODELO.Descripcion,
                        ConMarca = (long)p.ConMarca,
                        DescripcionMarca = p.MARCA.Descripcion,
                        ConCategoria = (long)p.ConCategoria,
                        DescripcionCategoria = p.CATEGORIA.Descripcion,
                        Precio = p.Precio,
                        Stock = p.Stock,
                        Imagen = p.Imagen
                    })
                    .ToList();

                return productos;
            }
        }

        [HttpGet]
        [Route("FiltrarMarca")]
        public List<ProductoEnt> FiltrarMarca(long q)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var productos = context.PRODUCTO
                    .Include(p => p.MODELO)
                    .Include(p => p.MARCA)
                    .Include(p => p.CATEGORIA)
                    .Where(p => p.ConMarca == q)
                    .Select(p => new ProductoEnt
                    {
                        ConProducto = p.ConProducto,
                        Nombre = p.Nombre,
                        ConModelo = p.ConModelo ?? 0,
                        DescripcionModelo = p.MODELO.Descripcion,
                        ConMarca = p.ConMarca ?? 0,
                        DescripcionMarca = p.MARCA.Descripcion,
                        ConCategoria = p.ConCategoria ?? 0,
                        DescripcionCategoria = p.CATEGORIA.Descripcion,
                        Precio = p.Precio,
                        Stock = p.Stock,
                        Imagen = p.Imagen
                    })
                    .ToList();

                return productos;
            }
        }

        [HttpPost]
        [Route("AgregarProducto")]
        public long AgregarProducto(PRODUCTO producto)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.PRODUCTO.Add(producto);
                context.SaveChanges();
                return producto.ConProducto;
            }
        }

        [HttpPut]
        [Route("ActualizarRutaImagen")]
        public string ActualizarRutaImagen(PRODUCTO tProducto)
        {
            using (var context = new ProyectoG7Entities())
            {
                var datos = context.PRODUCTO.FirstOrDefault(x => x.ConProducto == tProducto.ConProducto);

                if (datos != null)
                {
                    datos.Imagen = tProducto.Imagen;
                    context.SaveChanges();
                }

                return "OK";
            }
        }


    }
}
