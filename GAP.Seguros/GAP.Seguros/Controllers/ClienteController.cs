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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/Cliente").Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Cliente>>(resulstring);
                return View(listado);
            }

            return View(new List<Cliente>());
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Cliente cliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.PostAsync("api/Cliente", cliente, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);
                if (resutado)
                {
                    return RedirectToAction("Index");
                }
                return View(cliente);

            }

            return View(cliente);
        }


        [HttpGet]
        public ActionResult Actualizar(int IdCliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/Cliente?IdCliente=" + IdCliente).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<Cliente>(resulstring);
                return View(resutado);
            }


            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Cliente cliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");
            var request = clientHttp.PutAsync("api/Cliente", cliente, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);


                if (resutado)
                {
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.DeleteAsync("api/Cliente?id=" + id).Result;

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
        public ActionResult Detalle(int idCliente)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/CLiente?idCliente=" + idCliente).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<Cliente>(resulstring);
                return View(resutado);
            }

            return View();
        }

    }
}