using pruebaSellnowapi.Models;
using pruebaSellnowapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace pruebaSellnowapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductoController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Productos>> Get() =>
            _productService.Get();

        [HttpGet("{product_id}", Name = "GetProducto")]
        public ActionResult<Productos> Get(int product_id)
        {
            var producto = _productService.Get(product_id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public ActionResult<Productos> Create(Productos producto)
        {
            _productService.Create(producto);

            return CreatedAtRoute("GetProducto", new { id = producto.Id.ToString() }, producto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(int product_id, Productos productoIn)
        {
            var producto = _productService.Get(product_id);

            if (producto == null)
            {
                return NotFound();
            }

            _productService.Update(product_id, productoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(int Id)
        {
            var producto = _productService.Get(Id);

            if (producto == null)
            {
                return NotFound();
            }

            _productService.Remove(producto.Id);

            return NoContent();
        }
    }
}