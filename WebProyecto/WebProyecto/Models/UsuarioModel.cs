using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using WebProyecto.Entities;
using static System.Net.WebRequestMethods;

namespace WebProyecto.Models
{
    public class UsuarioModel
    {
        readonly string urlApi = "https://localhost:44327/";
        public UsuarioEnt IniciarSesion (UsuarioEnt ent)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "IniciarSesion";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            }
        }

        public string RegistrarCuenta(UsuarioEnt ent)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarCuenta";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ConsultarProvincias()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarProvincias";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;

            }
        }

        public List<SelectListItem> ConsultarCantones(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarCantones?q="+q;
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;

            }
        }

        public List<UsuarioEnt> ConsultaUsuarios()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultaUsuarios";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            }
        }

        public UsuarioEnt ConsultaUsuario(long q)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultaUsuario?q="+q;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            }
        }
        
        public string ActualizarCuenta(UsuarioEnt ent)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarCuenta";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string ActualizarRol(UsuarioEnt ent)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarRol";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}