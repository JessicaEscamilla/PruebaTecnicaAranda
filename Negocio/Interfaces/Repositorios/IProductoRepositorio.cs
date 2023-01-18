using Negocio.Entidades;

namespace Negocio.Interfaces.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<List<Producto>> ObtenerProductos();
    }
}