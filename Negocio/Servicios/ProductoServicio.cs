using Negocio.Entidades;
using Negocio.Interfaces.Repositorios;
using Negocio.Interfaces.Servicios;

namespace Negocio.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        readonly IProductoRepositorio _productoRepositorio;
        public ProductoServicio(IProductoRepositorio productoRepositorio) 
        {
            _productoRepositorio = productoRepositorio;
        }

        public async Task<Producto?> ActualizarProducto(Producto producto)
        {
            var productoBd = await _productoRepositorio.ObtenerProducto(producto.Id);
            if (productoBd == null)
            {
                return null;
            }

            return await _productoRepositorio.ActualizarProducto(producto);
        }

        public async Task<bool> BorrarProducto(int idProducto)
        {

            var productoBorrar = await _productoRepositorio.ObtenerProducto(idProducto);
            if (productoBorrar == null)
                return false;

            return await _productoRepositorio.BorrarProducto(productoBorrar);
        }

        public async Task<Producto> CrearProducto(Producto producto)
        {
            return await _productoRepositorio.CrearProducto(producto);
        }

        public async Task<List<Producto>> ObtenerProductos(string? search, string? orderBy, int? page, int? take)
        {
            var productos = await _productoRepositorio.ObtenerProductos();

            return productos;
        }
    }
}