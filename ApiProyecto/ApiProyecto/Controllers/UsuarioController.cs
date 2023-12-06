using ApiProyecto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiProyecto.Controllers
{
    public class UsuarioController : ApiController
    {

        [HttpGet]
        [Route("ConsultaUsuarios")]
        public List<USUARIO> ConsultaUsuarios()
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    return (from x in context.USUARIO
                            select x).ToList();
                }

            }catch (Exception)
            {
                return new List<USUARIO>();
            }
        }

        [HttpGet]
        [Route("ConsultaUsuario")]
        public USUARIO ConsultaUsuario(long q)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.USUARIO
                                 where x.ConUsuario == q
                                 select x).FirstOrDefault();

                    return datos;
                }
            }catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarProvincias")]
        public List<System.Web.Mvc.SelectListItem> ConsultarProvincias()
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = ( from x in context.PROVINCIA
                                  select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConProvincia.ToString(), Text = item.Nombre });
                    }

                    return respuesta;
                }
            }catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpPut]
        [Route("ActualizarCuenta")]
        public string ActualizarCuenta(UsuarioEnt ent)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = (from x in context.USUARIO
                                 where x.ConUsuario == ent.ConUsuario
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        datos.Correo = ent.Correo;
                        datos.Nombre = ent.Nombre;
                        datos.Identificacion = ent.Identificacion;
                        datos.ConProvincia = ent.ConProvincia;
                        datos.ConCanton = ent.ConCanton;
                        datos.Imagen = ent.Imagen;
                        context.SaveChanges();
                    }

                    return "OK";
                }
            }catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpPut]
        [Route("ActualizarRol")]
        public string ActualizarRol(UsuarioEnt ent)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = (from x in context.USUARIO
                                 where x.ConUsuario == ent.ConUsuario
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        datos.ConRol = (datos.ConRol == 1 ? 2 : 1);
                        context.SaveChanges();
                    }

                    return "OK";
                }

            }catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        [Route("ConsultarCantones")]
        public List<System.Web.Mvc.SelectListItem> ConsultarCantones(long q)
        {
            try
            {
                using (var context = new ProyectoG7Entities())
                {
                    var datos = (from x in context.CANTON
                                 where x.IdProvincia == q
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConCanton.ToString(), Text = item.Nombre });
                    }

                    return respuesta;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }


        [HttpPut]
        [Route("ActualizarRutaImagenUsuario")]
        public string ActualizarRutaImagenUsuario(UsuarioEnt ent)
        {
            using (var context = new ProyectoG7Entities())
            {
                var datos = context.USUARIO.FirstOrDefault(x => x.Imagen == ent.Imagen);

                if (datos != null)
                {
                    datos.Imagen = ent.Imagen;
                    context.SaveChanges();
                }

                return "OK";
            }
        }


    }
}
