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
        public async Task<IActionResult> Obtener(string? busqueda, string? ordenarPor, int? pagina, int? tamanioPagina)
        {
            var productos = await _productoServicio.ObtenerProductos(busqueda?.Trim(), ordenarPor, pagina, tamanioPagina);
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Producto producto)
        {
            var productoCreado = await _productoServicio.CrearProducto(producto);
            return Created("", productoCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Producto producto)
        {
            if (producto.Id != id) 
                return BadRequest();

            var productoActualizado = await _productoServicio.ActualizarProducto(producto);
            return productoActualizado == null ? NotFound() : Ok(productoActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            return await _productoServicio.BorrarProducto(id) ? NoContent() : BadRequest();
        }
    }
}
