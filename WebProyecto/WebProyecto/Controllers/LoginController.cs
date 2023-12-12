using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebProyecto.Entities;
using WebProyecto.Models;
using WebProyecto.Models.Paypal_Order;
using WebProyecto.Models.Paypal_Transaction;

namespace WebProyecto.Controllers
{
    public class LoginController : BaseController
    {

        UsuarioModel usuarioModel = new UsuarioModel();
        CarritoModel carritoModel = new CarritoModel();

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
        public async Task<ActionResult> pagoConfirmado()
        {
            string token = Request.QueryString["token"];

            bool status = false;

            using (var client = new HttpClient())
            {
                var userName = "AQ7gpDQbGtSmJCl-7hhsn8c2eeSsu5yoMAX-7D6XYB251xJayzoxqZIgTrjGM7HcVYbEM4qM8UUc4uZM";
                var passwd = "EAUqSU6BYoZxSu1lDa_e7VW4Ja-YIF25AJLXOU0MRRN2t6dVVXV3Dxd3ucEwibx6e9Xatxm-u3vqeyix";

                client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com");

                var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));


                var data = new StringContent("{}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"/v2/checkout/orders/{token}/capture", data);

                status = response.IsSuccessStatusCode;

                if (status)
                {
                    var jsonRespuesta = response.Content.ReadAsStringAsync().Result;
                    PaypalTransaction objeto = JsonConvert.DeserializeObject<PaypalTransaction>(jsonRespuesta);
                    ViewData["IdTransaccion"] = objeto.purchase_units[0].payments.captures[0].id;
                    string valorCaptura = objeto.purchase_units[0].payments.captures[0].amount.value;
                    ViewData["Total"] = valorCaptura;

                }
            }

            return View();
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
                @Session["Correo"] = resp.Correo;
                Session["Rol"] = resp.DescripcionRol;
                Session["Imagen"] = resp.Imagen;

                var datos = carritoModel.ConsultarCarrito(resp.ConUsuario);
                Session["Cant"] = datos.Sum(x => x.Cantidad);
                Session["Subt"] = datos.Sum(x => x.SubTotal);

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

        [HttpPost]
        public async Task<JsonResult> Paypal(string precio, string producto)
        {
            bool status = false;
            string respuesta = string.Empty;

            using (var client = new HttpClient())
            {
                var userName = "AQ7gpDQbGtSmJCl-7hhsn8c2eeSsu5yoMAX-7D6XYB251xJayzoxqZIgTrjGM7HcVYbEM4qM8UUc4uZM";
                var passwd = "EAUqSU6BYoZxSu1lDa_e7VW4Ja-YIF25AJLXOU0MRRN2t6dVVXV3Dxd3ucEwibx6e9Xatxm-u3vqeyix";

                client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com");

                var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var orden = new PaypalOrder()
                {
                    intent = "CAPTURE",
                    purchase_units = new List<Models.Paypal_Order.PurchaseUnit>()
                    {
                        new Models.Paypal_Order.PurchaseUnit()
                        {
                            amount = new Models.Paypal_Order.Amount() {
                                currency_code = "USD",
                                value = precio
                            }
                        }
                    },
                    application_context = new ApplicationContext()
                    {
                        brand_name = "Grupo Volkswagen",
                        landing_page = "NO_PREFERENCE",
                        user_action = "PAY_NOW", //paypal muestra el monto del pago
                        return_url = "https://localhost:44383/Login/pagoConfirmado", //cuando pasa el pago
                        cancel_url = "https://localhost:44383/Carrito/ConsultarCarrito" //cuando se cancela el pago
                    }
                };

                var json = JsonConvert.SerializeObject(orden);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/v2/checkout/orders", data);

                status = response.IsSuccessStatusCode;

                if (status)
                {
                    respuesta = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    var errorMessage = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Error de PayPal: {errorMessage}");
                }
            }

            return Json(new { status = status, respuesta = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RecuperarCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarCuenta(UsuarioEnt ent)
        {
            var resp = usuarioModel.RecuperarCuenta(ent);

            if (resp == "OK")
            {
                return RedirectToAction("IniciarSesion", "Login");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido enviar el correo con su información";
                return View();
            }
        }
    }

}