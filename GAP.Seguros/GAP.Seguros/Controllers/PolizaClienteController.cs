using GAP.Seguros.ModeloDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace GAP.Seguros.Controllers
{
    public class PolizaClienteController : Controller
    {
        // GET: PolizaCliente
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/PolizaCliente").Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<PolizaCliente>>(resulstring);
                return View(listado);
            }



            return View(new List<PolizaCliente>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PolizaCliente polizacliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.PostAsync("api/PolizCliente", polizacliente, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);
                if (resutado)
                {
                    return RedirectToAction("Index");
                }
                return View(polizacliente);

            }

            return View(polizacliente);
        }


        [HttpGet]
        public ActionResult Actualizar(int IdPolizaCliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/PolizaCliente?IdPolizaCliente=" + IdPolizaCliente).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<PolizaCliente>(resulstring);
                return View(resutado);
            }


            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(PolizaCliente polizacliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");
            var request = clientHttp.PutAsync("api/PolizaCliente", polizacliente, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);


                if (resutado)
                {
                    return RedirectToAction("Index");
                }
                return View(polizacliente);
            }
            return View(polizacliente);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.DeleteAsync("api/PolizaCliente?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);
                if (resutado)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();
        }

        [HttpGet]
        public ActionResult Detalle(int idPolizaCliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/PolizaCliente?idPolizaCliente=" + idPolizaCliente).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<PolizaCliente>(resulstring);
                return View(resutado);
            }

            return View();
        }

    }
}