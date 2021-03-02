using pruebaSellnowapi.Models;
using pruebaSellnowapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace pruebaSellnowapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class cartListController : ControllerBase
    {
        private readonly cartListService _cartListService;

        public cartListController(cartListService cartListService)
        {
            _cartListService = cartListService;
        }

        [HttpGet]
        public ActionResult<List<cartList>> Get() =>
            _cartListService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCartlist")]
        public ActionResult<cartList> Get(string Id)
        {
            var carrito = _cartListService.Get(Id);

            if (carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }

        [HttpPost]
        public ActionResult<cartList> Create(cartList carrito)
        {
            _cartListService.Create(carrito);

            return CreatedAtRoute("GetPedido", new { id = carrito.Id.ToString() }, carrito);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, cartList carritoIn)
        {
            var carrito = _cartListService.Get(id);

            if (carrito == null)
            {
                return NotFound();
            }

            _cartListService.Update(id, carritoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var carrito = _cartListService.Get(id);

            if (carrito == null)
            {
                return NotFound();
            }

            _cartListService.Remove(carrito.Id);

            return NoContent();
        }
    }
}