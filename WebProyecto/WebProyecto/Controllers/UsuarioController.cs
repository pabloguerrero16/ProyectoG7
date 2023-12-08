using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProyecto.Entities;
using WebProyecto.Models;

namespace WebProyecto.Controllers
{
    public class UsuarioController : BaseController
    {
        UsuarioModel  usuarioModel = new UsuarioModel();
        [HttpGet]
        public ActionResult ConsultaUsuarios()
        {
            long ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            var datos = usuarioModel.ConsultaUsuarios().Where(x => x.ConUsuario != ConUsuario).ToList();
            return View(datos);
            
        }

        [HttpGet]
        public ActionResult PerfilUsuario()
        {
            long ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            ViewBag.Provincias = usuarioModel.ConsultarProvincias();
            var datos = usuarioModel.ConsultaUsuario(ConUsuario);
            return View(datos);
        }

        [HttpPost]
        public ActionResult PerfilUsuario(HttpPostedFileBase ImgUsuario, UsuarioEnt ent)
        {
            
            
            
            var resp = usuarioModel.ActualizarCuenta(ent);
            if(resp == "OK")
            {
                if (ImgUsuario != null)
                {
                    string extension = Path.GetExtension(Path.GetFileName(ImgUsuario.FileName));
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "Images/Users\\" + ent.Identificacion + extension;
                    ImgUsuario.SaveAs(ruta);

                    ent.Imagen = "/Images/Users/" + ent.Identificacion + extension;
                    ent.ConUsuario = ent.ConUsuario;

                    usuarioModel.ActualizarRutaImagenUsuario(ent);
                } 
                Session["Nombre"] = ent.Nombre;
                Session["Imagen"] = ent.Imagen;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Provincias = usuarioModel.ConsultarProvincias();
                ViewBag.MensajeUsuario = "No ha sido posible actualizar su información";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarRol(long q)
        {
            var ent = new UsuarioEnt();
            ent.ConUsuario = q;

            var resp = usuarioModel.ActualizarRol(ent);

            if (resp == "OK")
            {
                return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MensajeUsuario = "Error al modificar el estado del usuario";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarCuenta(long q)
        {
            ViewBag.Provincias = usuarioModel.ConsultarProvincias();
            var datos = usuarioModel.ConsultaUsuario(q);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActualizarCuenta(HttpPostedFileBase ImgUsuario ,UsuarioEnt ent)
        {
            var resp = usuarioModel.ActualizarCuenta(ent);

            if (resp == "OK")
            {
                if (ImgUsuario != null)
                {
                    string extension = Path.GetExtension(Path.GetFileName(ImgUsuario.FileName));
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "~/Images/Users\\" + ent.Identificacion + extension;
                    ImgUsuario.SaveAs(ruta);

                    ent.Imagen = "~/Images/Users/" + ent.Identificacion + extension;
                    ent.ConUsuario = ent.ConUsuario;

                    usuarioModel.ActualizarRutaImagenUsuario(ent);
                }

                return RedirectToAction("ConsultaUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MensajeUsuario = "No ha sido posible actualizar su información";
                return View();
            }
        }

        public JsonResult ConsultarCantones(long q)
        {
            var cantones = usuarioModel.ConsultarCantones(q);
            var result = cantones.Select(c => new { Value = c.Value, Text = c.Text });
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        
    }
}
