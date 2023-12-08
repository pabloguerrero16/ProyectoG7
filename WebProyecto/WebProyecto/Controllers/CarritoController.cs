
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
        Session["Subt"] = datos.Sum(x => x.Precio);

        return Json("OK", JsonRequestBehavior.AllowGet);
    }
}

