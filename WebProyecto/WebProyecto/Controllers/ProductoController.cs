using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using WebProyecto.Entities;
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

        [HttpGet]
        public ActionResult FiltrarModelos(long q)
        {
            var datos = productoModel.FiltrarModelos(q);
            return View(datos);
        }

        [HttpGet]
        public ActionResult FiltrarCategorias(long q)
        {
            var datos = productoModel.FiltrarCategorias(q);
            return View(datos);
        }

        [HttpGet]
        public ActionResult FiltrarMarca(long q)
        {
            var datos = productoModel.FiltrarMarca(q);
            return View(datos);
        }

        [HttpGet]
        public ActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto(HttpPostedFileBase ImgProducto, ProductoEnt entidad)
        {
            entidad.Imagen = string.Empty;

            long conProducto = productoModel.AgregarProducto(entidad);

            if (conProducto > 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(ImgProducto.FileName));
                string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images/Productos\\" + conProducto + extension;
                ImgProducto.SaveAs(ruta);

                entidad.Imagen= "~/Images/Productos/" + conProducto+extension;
                entidad.ConProducto= conProducto;

                productoModel.ActualizarRutaImagen(entidad);

                return RedirectToAction("ConsultarProductos", "Producto");
            } else
            {
                ViewBag.MensajeUsuario = "No se ha registrado el producto";
                return View();
            }
        }



    }
}
