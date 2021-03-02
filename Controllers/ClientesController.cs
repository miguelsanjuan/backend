using pruebaSellnowapi.Models;
using pruebaSellnowapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace pruebaSellnowapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public ActionResult<List<Clientes>> Get() =>
            _clientesService.Get();

        [HttpGet("{email}/{password}")]
        public ActionResult<List<Clientes>> GetIniciarSesion(string email, string password)
        {
            var cliente = _clientesService.GetIniciarSesion(email,password);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("{id:length(24)}", Name = "GetClientes")]
        public ActionResult<Clientes> Get(string id)
        {
            var cliente = _clientesService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public ActionResult<Clientes> Create(Clientes cliente)
        {
            _clientesService.Create(cliente);

            return CreatedAtRoute("GetPedido", new { id = cliente.Id.ToString() }, cliente);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Clientes clienteIn)
        {
            var cliente = _clientesService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clientesService.Update(id, clienteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var cliente = _clientesService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clientesService.Remove(cliente.Id);

            return NoContent();
        }

    }
}