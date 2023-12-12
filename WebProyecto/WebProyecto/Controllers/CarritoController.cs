
using System.Web.Mvc;
using System;
using WebProyecto.Entities;
using WebProyecto.Models;
using System.Linq;
using WebProyecto.Controllers;

public class CarritoController : BaseController
{
    CarritoModel carritoModel = new CarritoModel();

    [HttpPost]
    public ActionResult RegistrarCarrito(long conProducto, int cantidad)
    {
        CarritoEnt entidad = new CarritoEnt();
        entidad.ConUsuario = long.Parse(Session["ConUsuario"].ToString());
        entidad.ConProducto = conProducto;
        entidad.Cantidad = cantidad;
        entidad.FechaCarrito = DateTime.Now;

        carritoModel.RegistrarCarrito(entidad);

        var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
        Session["Cant"] = datos.Sum(x => x.Cantidad);
        Session["Subt"] = datos.Sum(x => x.SubTotal);

        return Json("OK", JsonRequestBehavior.AllowGet);
    }


    [HttpGet]
    public ActionResult ConsultarCarrito()
    {
        var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
        Session["Total"] = datos.Sum(x => x.Total);
        return View(datos);
    }


    [HttpPost]
    public ActionResult PagarCarrito()
    {
        CarritoEnt entidad = new CarritoEnt();
        entidad.ConUsuario = long.Parse(Session["ConUsuario"].ToString());
        var resultado = carritoModel.PagarCarrito(entidad);

        var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
        Session["Cant"] = datos.Sum(x => x.Cantidad);
        Session["Subt"] = datos.Sum(x => x.SubTotal);

        if (resultado != "")
        {
            Session["Cant"] = datos.Sum(x => x.Cantidad);
            Session["Subt"] = datos.Sum(x => x.SubTotal);
            return RedirectToAction("Index", "Login");
        }
        else
        {
            ViewBag.MensajeUsuario = "No se pudo realizar su compra, verifique las unidades disponibles";
            return View("ConsultarCarrito",datos);
        }
    }

    [HttpGet]
    public ActionResult EliminarProductoCarrito(long q)
    {
        carritoModel.EliminarProductoCarrito(q);
        var datos = carritoModel.ConsultarCarrito(long.Parse(Session["ConUsuario"].ToString()));
        Session["Cant"] = datos.Sum(x => x.Cantidad);
        Session["Subt"] = datos.Sum(x => x.SubTotal);
        return RedirectToAction("ConsultarCarrito", "Carrito");
    }

    [HttpGet]
    public ActionResult ConsultarFacturas()
    {
        var datos = carritoModel.ConsultarFacturas(long.Parse(Session["ConUsuario"].ToString()));
        return View(datos);
    }

    [HttpGet]
    public ActionResult ConsultarDetalleFactura(long q)
    {
        var datos = carritoModel.ConsultarDetalleFactura(q);
        return View(datos);
    }


}

