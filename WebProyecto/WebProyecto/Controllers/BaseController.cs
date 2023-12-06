using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProyecto.Models;

namespace WebProyecto.Controllers
{
    public class BaseController : Controller
    {

        ProductoModel productoModel = new ProductoModel();
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            ViewBag.Marcas = productoModel.ConsultarMarcas();
            ViewBag.Modelos = productoModel.ConsultarModelos();
            ViewBag.Categorias = productoModel.ConsultarCategorias();

            base.OnActionExecuting(filterContext);
        }
    }
}