using pruebaSellnowapi.Models;
using pruebaSellnowapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace pruebaSellnowapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly VendedorService _vendedorService;

        public VendedorController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet]
        public ActionResult<List<Vendedor>> Get() =>
            _vendedorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetVendedor")]
        public ActionResult<Vendedor> Get(string id)
        {
            var vendedor = _vendedorService.Get(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

         [HttpGet("{email}/{password}")]
        public ActionResult<List<Vendedor>> GetIniciarSesion(string email, string password)
        {
            var vendedor = _vendedorService.GetIniciarSesion(email,password);

            if (vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        [HttpPost]
        public ActionResult<Vendedor> Create(Vendedor vendedor)
        {
            _vendedorService.Create(vendedor);

            return CreatedAtRoute("GetVendedor", new { id = vendedor.Id.ToString() }, vendedor);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Vendedor vendedorIn)
        {
            var vendedor = _vendedorService.Get(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            _vendedorService.Update(id, vendedorIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var vendedor = _vendedorService.Get(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            _vendedorService.Remove(vendedor.Id);

            return NoContent();
        }
    }
}