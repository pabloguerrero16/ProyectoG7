using ApiProyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    public class LoginController : ApiController
    {
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
    }


}
