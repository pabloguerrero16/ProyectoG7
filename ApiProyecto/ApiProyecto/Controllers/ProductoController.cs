using ApiProyecto.Entities;
using System;
using System.Collections.Generic;
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

        
    }
}
