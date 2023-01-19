using Negocio.Entidades;
using Negocio.ModelosVista;

namespace Negocio.Interfaces.Servicios
{
    public interface IProductoServicio
    {
        Task<Producto?> ActualizarProducto(Producto producto);
        Task<bool> BorrarProducto(int idProducto);
        Task<Producto> CrearProducto(Producto producto);
        Task<ProductosPage> ObtenerProductos(string? busqueda, string? ordenarPor, int? pagina, int? tamanioPagina);

    }
}