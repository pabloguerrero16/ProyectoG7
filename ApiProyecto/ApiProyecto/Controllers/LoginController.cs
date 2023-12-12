using ApiProyecto.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    public class LoginController : ApiController
    {

        Utilitario util = new Utilitario();

        [HttpPost]
        [Route("RegistrarCuenta")]
        public string RegistrarCuenta(UsuarioEnt ent)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    context.RegistrarCuenta(ent.Identificacion, ent.Nombre, ent.Correo, ent.Contrasenna);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IniciarSesion_Result IniciarSesion(UsuarioEnt ent)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    return context.IniciarSesion(ent.Correo, ent.Contrasenna).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("RecuperarCuenta")]
        public string RecuperarCuenta(UsuarioEnt ent)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = (from x in context.USUARIO
                                 where x.Identificacion == ent.Identificacion
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        string urlHtml = AppDomain.CurrentDomain.BaseDirectory + "Templates\\mail.html";
                        string html = File.ReadAllText(urlHtml);

                        html = html.Replace("@@Nombre", datos.Nombre);
                        html = html.Replace("@@Contrasenna", datos.Contrasenna);

                        util.EnvioCorreos(datos.Correo, "Recuperar Contraseña", html);
                        return "OK";
                    }

                    return "ERROR AL ENVIAR EL CORREO";
                }
            }catch (Exception)
            {
                return string.Empty;
            }
        }
    }


}
