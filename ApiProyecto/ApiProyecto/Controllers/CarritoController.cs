﻿using ApiProyecto.Entities;
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
        [Route("RegistrarCarrito")]
        public string RegistrarCarrito(CARRITO carrito)
        {
            using (var context = new ProyectoG7Entities())
            {

                var datos = (from x in context.CARRITO
                             where x.ConUsuario == carrito.ConUsuario
                             && x.ConProducto == carrito.ConProducto
                             select x).FirstOrDefault();

                if (datos == null)
                {
                    context.CARRITO.Add(carrito);
                    context.SaveChanges();
                    
                }
                else
                {
                    datos.Cantidad = carrito.Cantidad;
                    context.SaveChanges();
                }

                return "OK";
            }
        }

        [HttpGet]
        [Route("ConsultarCarrito")]
        public object ConsultarCarrito(long q)
        {
            using (var context = new ProyectoG7Entities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return  (from x in context.CARRITO
                        join y in context.PRODUCTO on x.ConProducto equals  y.ConProducto
                        where x.ConUsuario == q
                        select new
                        {
                            x.ConProducto,
                            x.ConCarrito,
                            x.ConUsuario,
                            x.Cantidad,
                            x.FechaCarrito,
                            y.Precio
                        } ).ToList();
            }
        }
    }
}
