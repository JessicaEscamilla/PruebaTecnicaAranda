using Negocio.Entidades;

namespace Negocio.Interfaces.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<Producto> ActualizarProducto(Producto producto);
        Task<bool> BorrarProducto(Producto producto);
        Task<Producto> CrearProducto(Producto producto);
        Task<Producto?> ObtenerProducto(int idProducto);
        Task<List<Producto>> ObtenerProductos();
    }
}