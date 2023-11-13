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
    public class ProductoModel
    {
        readonly string urlApi = "https://localhost:44327/";
        
        public List<ProductoEnt> ConsultarProductos()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarProductos";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }

        public List<ProductoEnt> ListarProductos()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarProductos";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }
    }
}