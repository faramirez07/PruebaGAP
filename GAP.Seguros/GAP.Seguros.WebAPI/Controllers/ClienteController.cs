using GAP.Seguros.ModeloDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.Seguros.WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            using (var context = new EntidadesGAP())
            {
                var listado = context.Clientes.ToList();
                return listado;
            }

        }

        [HttpGet]
        public Cliente Get(int IdCliente)
        {
            using (var context = new EntidadesGAP())
            {
                var cliente = context.Clientes.FirstOrDefault(x => x.IdCliente == IdCliente);
                return cliente;
            }
        }

        [HttpPost]
        public bool Post(Cliente cliente)
        {
            using (var context = new EntidadesGAP())
            {
                context.Clientes.Add(cliente);
                return context.SaveChanges() > 0;
            }

        }

        [HttpPut]
        public bool Put(Cliente cliente)
        {

            using (var context = new EntidadesGAP())
            {
                DateTime fecha = DateTime.Now;
                var clienteActualizar = context.Clientes.SingleOrDefault(x => x.IdCliente == cliente.IdCliente);
                clienteActualizar.IdCliente = cliente.IdCliente;
                clienteActualizar.Cedula = cliente.Cedula;
                clienteActualizar.Nombre = cliente.Nombre;
                clienteActualizar.Edad = cliente.Edad;
                clienteActualizar.Nacionalidad = cliente.Nacionalidad;
                clienteActualizar.Activo = Convert.ToBoolean(cliente.Activo);
                clienteActualizar.UsuarioCreacion = cliente.UsuarioCreacion;
                clienteActualizar.FechaCreacion = cliente.FechaCreacion;

                return context.SaveChanges() > 0;
            }

        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new EntidadesGAP())
            {
                var clienteEliminar = context.Clientes.FirstOrDefault(x => x.IdCliente == id);
                context.Clientes.Remove(clienteEliminar);
                return context.SaveChanges() > 0;
            }
        }
    }
}

