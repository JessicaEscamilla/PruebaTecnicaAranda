using Negocio.Entidades;

namespace Negocio.Interfaces.Servicios
{
    public interface IProductoServicio
    {
        Task<List<Producto>> ObtenerProductos();

    }
}