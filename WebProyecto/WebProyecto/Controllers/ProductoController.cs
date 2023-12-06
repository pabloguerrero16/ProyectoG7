using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProyecto.Models;

namespace WebProyecto.Controllers
{
    public class ProductoController : BaseController
    {
        ProductoModel productoModel = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var datos = productoModel.ConsultarProductos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ListarProductos()
        {
            var datos = productoModel.ConsultarProductos();
            return View(datos);
        }

        [HttpGet]
        public ActionResult DetalleProducto(long q) 
        { 
            var datos = productoModel.DetalleProducto(q);
            return View(datos);
        }

        public ActionResult FiltrarModelos(long q)
        {
            var datos = productoModel.FiltrarModelos(q);
            return View(datos);
        }

        public ActionResult FiltrarCategorias(long q)
        {
            var datos = productoModel.FiltrarCategorias(q);
            return View(datos);
        }

        public ActionResult FiltrarMarca(long q)
        {
            var datos = productoModel.FiltrarMarca(q);
            return View(datos);
        }



    }
}
