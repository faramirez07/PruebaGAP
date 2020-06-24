using GAP.Seguros.ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.Seguros.WebAPI.Controllers
{
    public class TipoPolizaController : ApiController
    {
        [HttpGet]
        public IEnumerable<TipoPoliza> Get()
        {
            using (var context = new EntidadesGAP())
            {
                var listado = context.TipoPolizas.ToList();
                return listado;
            }

        }
    }
}
