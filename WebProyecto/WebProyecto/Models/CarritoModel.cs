using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using WebProyecto.Entities;

namespace WebProyecto.Models
{
    public class CarritoModel
    {

        readonly string urlApi = "https://localhost:44327/";

        public string RegistrarCarrito(CarritoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarCarrito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }

        }
        public List<CarritoEnt> ConsultarCarrito(long q)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarCarrito?q=" + q;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<CarritoEnt>>().Result;
            }
        }

        public string PagarCarrito(CarritoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "PagarCarrito";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }

        }

        public void EliminarProductoCarrito(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "EliminarProductoCarrito?q="+q;
                var resp = client.DeleteAsync(url).Result;
            }
        }

        public void EliminarCarrito(long q)
        {

        }


        public List<FacturasEnt> ConsultarFacturas (long q)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarFacturas?q=" + q;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<FacturasEnt>>().Result;   
            }
        }

        public List<FacturasEnt> ConsultarDetalleFactura(long q)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarDetalleFactura?q=" + q;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<FacturasEnt>>().Result;
            }
        }
    }
}