using Negocio.Entidades;

namespace Negocio.Interfaces.Servicios
{
    public interface IProductoServicio
    {
        Task<Producto?> ActualizarProducto(Producto producto);
        Task<bool> BorrarProducto(int idProducto);
        Task<Producto> CrearProducto(Producto producto);
        Task<List<Producto>> ObtenerProductos(string? search, string? orderBy, int? page, int? take);

    }
}