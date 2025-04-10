using Microsoft.AspNetCore.Mvc;
using WebApplication.DTOs;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _service;

        public PrestamoController(IPrestamoService service)
        {
            _service = service;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] PrestamoRequestDTO request)
        {
            try
            {
                var resultado = await _service.RegistrarPrestamoAsync(request);
                return Ok(new { mensaje = "Préstamo registrado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Ok("Bienvenido a la API de préstamos. Use /api/libros/registrar para registrar un préstamo.");
        }
    }
}
