
using GAP.Seguros.ModeloDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
//using System.Net.Http.Formatting;

namespace GAP.Seguros.Controllers
{
    public class PolizaController : Controller
    {
        // GET: Poliza
        public ActionResult Index()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/Poliza").Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Poliza>>(resulstring);
                return View(listado);
            }
            
            return View(new List<Poliza>());

        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var requestTipoPoliza = clientHttp.GetAsync("api/TipoPoliza").Result;

            var requestTipoRiesgo = clientHttp.GetAsync("/api/TipoRiesgo").Result;

            if (requestTipoRiesgo.IsSuccessStatusCode)
            {
                var resulstring = requestTipoRiesgo.Content.ReadAsStringAsync().Result;
                var listadoRiesgo = JsonConvert.DeserializeObject<List<TipoRiesgo>>(resulstring);
                ViewBag.TipoRiesgo = listadoRiesgo;
            }

            if (requestTipoPoliza.IsSuccessStatusCode)
            {
                var resulstring = requestTipoPoliza.Content.ReadAsStringAsync().Result;
                var listadoPoliza = JsonConvert.DeserializeObject<List<TipoPoliza>>(resulstring);
                ViewBag.TipoPoliza = listadoPoliza;
            }
                       

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Poliza poliza)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.PostAsync("api/Poliza", poliza, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);
                if (resutado)
                {
                    return RedirectToAction("Index");
                }
                return View(poliza);
           
            }
         
            return View(poliza);
        }


        [HttpGet]
        public ActionResult Actualizar(int IdPoliza, string idTipoPolizSelec, string idTipoRiesSelec)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/Poliza?IdPoliza=" + IdPoliza).Result;

            var requestTipoRiesgo = clientHttp.GetAsync("/api/TipoRiesgo").Result;

            if (requestTipoRiesgo.IsSuccessStatusCode)
            {
                var resulstring = requestTipoRiesgo.Content.ReadAsStringAsync().Result;
                var listadoRiesgo = JsonConvert.DeserializeObject<List<TipoRiesgo>>(resulstring);
                SelectList ListTipoRiesgo = new SelectList(listadoRiesgo, "IdRiesgo", "Nombre", Convert.ToInt32(idTipoRiesSelec));
                ViewBag.TipoRiesgo = ListTipoRiesgo;
            }

            var requestTipoPoliza = clientHttp.GetAsync("api/TipoPoliza").Result;


            if (requestTipoPoliza.IsSuccessStatusCode)
            {
                var resulstring = requestTipoPoliza.Content.ReadAsStringAsync().Result;
                var listadoPoliza = JsonConvert.DeserializeObject<List<TipoPoliza>>(resulstring);
                 SelectList ListCategories = new SelectList(listadoPoliza, "IdTipo", "Nombre", Convert.ToInt32(idTipoPolizSelec));
                ViewBag.TipoPoliza = ListCategories;
                //ViewBag.IdTipoPolizS = idTipoPolizSelec;
            }
          
            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<Poliza>(resulstring);
                return View(resutado);
            }
            

            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Poliza poliza)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");
              //var request = clientHttp.GetAsync("api/Poliza?IdPoliza=" + IdPoliza).Result;
            var request = clientHttp.PutAsync("api/Poliza", poliza, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<bool>(resulstring);


                if (resutado)
                {
                    return RedirectToAction("Index");
                }
                return View(poliza);
            }
            return View(poliza);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.DeleteAsync("api/Poliza?id=" + id).Result;

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
        public ActionResult Detalle(int idPoliza)
        {
            HttpClient clientHttp = new HttpClient();
            clientHttp.BaseAddress = new Uri("https://localhost:44350/");

            var request = clientHttp.GetAsync("api/Poliza?idPoliza=" + idPoliza).Result;

            if (request.IsSuccessStatusCode)
            {
                var resulstring = request.Content.ReadAsStringAsync().Result;
                var resutado = JsonConvert.DeserializeObject<Poliza>(resulstring);
                return View(resutado);
            }

            return View();
        }

      






    }
}