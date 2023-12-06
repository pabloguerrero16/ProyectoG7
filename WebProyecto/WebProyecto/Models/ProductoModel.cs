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

        public ProductoEnt DetalleProducto(long q)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "DetalleProducto?q=" + q;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<ProductoEnt>().Result;
            }
        }

        public List<SelectListItem> ConsultarModelos()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarModelos";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<SelectListItem> ConsultarCategorias()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarCategorias";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<SelectListItem> ConsultarMarcas()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarMarcas";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }

        public List<ProductoEnt> FiltrarModelos(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "FiltrarModelos?q="+q;
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }

        public List<ProductoEnt> FiltrarCategorias(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "FiltrarCategorias?q=" + q;
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }

        public List<ProductoEnt> FiltrarMarca(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "FiltrarMarca?q=" + q;
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }



    }
}