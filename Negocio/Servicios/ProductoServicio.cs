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

        public async Task<List<Producto>> ObtenerProductos()
        {
            return await _productoRepositorio.ObtenerProductos();
        }
    }
}