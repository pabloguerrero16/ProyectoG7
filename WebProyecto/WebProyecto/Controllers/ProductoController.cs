using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProyecto.Models;

namespace WebProyecto.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModel productoModel = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var datos = productoModel.ConsultarProductos();
            return View(datos);
        }

        public ActionResult ListarProductos()
        {
            var datos = productoModel.ConsultarProductos();
            return View(datos);
        }
        
    }
}
