using pruebaSellnowapi.Models;
using pruebaSellnowapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace pruebaSellnowapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdministradorController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult<List<Admin>> Get() =>
            _adminService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAdmin")]
        public ActionResult<Admin> Get(string id)
        {
            var admin = _adminService.Get(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }
         [HttpGet("{correo}/{password}")]
        public ActionResult<List<Admin>> GetIniciarSesion(string correo, string password)
        {
            var admin = _adminService.GetIniciarSesion(correo,password);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [HttpPost]
        public ActionResult<Admin> Create(Admin admin)
        {
            _adminService.Create(admin);

            return CreatedAtRoute("GetPedido", new { id = admin.Id.ToString() }, admin);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Admin adminIn)
        {
            var admin = _adminService.Get(id);

            if (admin == null)
            {
                return NotFound();
            }

            _adminService.Update(id, adminIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var admin = _adminService.Get(id);

            if (admin == null)
            {
                return NotFound();
            }

            _adminService.Remove(admin.Id);

            return NoContent();
        }

    }
}