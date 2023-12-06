using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProyecto.Entities;
using WebProyecto.Models;

namespace WebProyecto.Controllers
{
    public class LoginController : BaseController
    {

        UsuarioModel usuarioModel = new UsuarioModel();

        [HttpGet]
        public ActionResult Index()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            return View();
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
          Session.Clear();
          return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuarioEnt ent)
        {
            var resp = usuarioModel.IniciarSesion(ent);

            if (resp != null)
            {
                Session["ConUsuario"] = resp.ConUsuario;
                Session["Nombre"] = resp.Nombre;
                Session["Rol"] = resp.DescripcionRol;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MensajeUsuario = "Correo o Contraseña Incorrectos";
                return View();
            }
        }

        [HttpGet]
        public ActionResult RegistrarCuenta() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCuenta(UsuarioEnt ent)
        {
            var resp = usuarioModel.RegistrarCuenta(ent);
            if (resp == "OK")
            {
                return RedirectToAction("IniciarSesion", "Login");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }
    }
    
}