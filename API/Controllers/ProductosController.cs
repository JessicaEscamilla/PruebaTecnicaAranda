using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces.Servicios;


namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        public ProductosController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }


        [HttpGet(Name = "ObtenerProductos")]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _productoServicio.ObtenerProductos();
            return Ok(productos);
        }
    }
}
