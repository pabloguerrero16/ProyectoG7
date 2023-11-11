using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using WebProyecto.Entities;
using static System.Net.WebRequestMethods;

namespace WebProyecto.Models
{
    public class UsuarioModel
    {
        public UsuarioEnt IniciarSesion (UsuarioEnt ent)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44327/" + "IniciarSesion";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            }
        }

        public string RegistrarCuenta(UsuarioEnt ent)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44327/" + "RegistrarCuenta";
                JsonContent contenido = JsonContent.Create(ent);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}