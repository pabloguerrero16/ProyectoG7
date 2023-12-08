using ApiProyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    public class CarritoController : ApiController
    {
        [HttpPost]
        [Route("AgregarCarrito")]
        public string AgregarProducto(CARRITO carrito)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.CARRITO.Add(carrito);
                context.SaveChanges();
                return"OK";
            }
        }

        [HttpGet]
        [Route("ConsultarCarrito")]
        public object ConsultarCarrito(long q)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                return (from x in context.CARRITO
                        join y in context.PRODUCTO on x.ConProducto equals y.ConProducto
                        where x.ConProducto == q
                        select new
                        {
                            x.ConProducto,
                            x.ConCarrito,
                            x.ConUsuario,
                            x.Cantidad,
                            x.FechaCarrito,
                            y.Precio
                        }).ToList();
            }
        }
    }
}
