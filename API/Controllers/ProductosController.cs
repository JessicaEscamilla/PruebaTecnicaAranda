using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
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


        [HttpGet]
        public async Task<IActionResult> Obtener(string? search, string? orderBy, int? page, int? take)
        {
            var productos = await _productoServicio.ObtenerProductos(search, orderBy, page, take);
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearActualizar(Producto producto)
        {
            Producto? productoCreadoActualizado = producto.Id == 0 
                ? await _productoServicio.CrearProducto(producto) 
                : await _productoServicio.ActualizarProducto(producto);

            return productoCreadoActualizado == null ? NotFound() : Ok(productoCreadoActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            return await _productoServicio.BorrarProducto(id) ? NoContent() : BadRequest();
        }
    }
}
