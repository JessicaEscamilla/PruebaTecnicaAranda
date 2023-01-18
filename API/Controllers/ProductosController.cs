using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        [HttpGet(Name = "ObtenerProductos")]
        public async Task<IActionResult> ObtenerProductos()
        {
            return Ok("Hola mundo");
        }
    }
}
