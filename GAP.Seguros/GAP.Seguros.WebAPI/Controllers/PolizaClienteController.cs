using GAP.Seguros.ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.Seguros.WebAPI.Controllers
{
    public class PolizaClienteController : ApiController
    {
        [HttpGet]
        public IEnumerable<PolizaCliente> Get()
        {
            using (var context = new EntidadesGAP())
            {
                var listado = context.PolizaClientes.ToList();
                return listado;
            }

        }

        [HttpGet]
        public PolizaCliente Get(int IdPolizaCliente)
        {
            using (var context = new EntidadesGAP())
            {
                var polizacliente = context.PolizaClientes.FirstOrDefault(x => x.IdPolizaCliente == IdPolizaCliente);
                return polizacliente;
            }
        }

        [HttpPost]
        public bool Post(PolizaCliente polizacliente)
        {
            using (var context = new EntidadesGAP())
            {
                context.PolizaClientes.Add(polizacliente);
                return context.SaveChanges() > 0;
            }

        }

        [HttpPut]
        public bool Put(PolizaCliente polizacliente)
        {

            using (var context = new EntidadesGAP())
            {
                DateTime fecha = DateTime.Now;
                var PolizaclienteActualizar = context.PolizaClientes.SingleOrDefault(x => x.IdPolizaCliente == polizacliente.IdPolizaCliente);
                PolizaclienteActualizar.IdPolizaCliente = polizacliente.IdPolizaCliente;
                PolizaclienteActualizar.IdCliente = polizacliente.IdCliente;
                PolizaclienteActualizar.IdPoliza = polizacliente.IdPoliza;
                PolizaclienteActualizar.PorcentajeCobertura = polizacliente.PorcentajeCobertura;
                PolizaclienteActualizar.Activo = Convert.ToBoolean(polizacliente.Activo);
                PolizaclienteActualizar.UsuarioCreacion = polizacliente.UsuarioCreacion;
                PolizaclienteActualizar.FechaCreacion = polizacliente.FechaCreacion;

                return context.SaveChanges() > 0;
            }

        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new EntidadesGAP())
            {
                var polizaclienteEliminar = context.PolizaClientes.FirstOrDefault(x => x.IdPolizaCliente == id);
                context.PolizaClientes.Remove(polizaclienteEliminar);
                return context.SaveChanges() > 0;
            }
        }
    }

}
