using Negocio.Componentes;
using Negocio.Entidades;
using Negocio.Interfaces.Repositorios;
using Negocio.Interfaces.Servicios;
using Negocio.ModelosVista;

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

        public async Task<ProductosPage> ObtenerProductos(string? busqueda, string? ordenarPor, int? pagina, int? tamanioPagina)
        {
            var productos = await _productoRepositorio.ObtenerProductos();
            var paginaCalcular = pagina ?? 1;
            var tamanioPaginaCalcular = tamanioPagina ?? 20;

            if (!string.IsNullOrEmpty(busqueda))
            {
                productos = productos
                    .Where(x =>
                        string.Equals(x.Nombre, busqueda, StringComparison.CurrentCultureIgnoreCase) ||
                        string.Equals(x.Descripcion, busqueda, StringComparison.CurrentCultureIgnoreCase) ||
                        string.Equals(x.Categoria, busqueda, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            switch (ordenarPor)
            {
                case "nombre":
                    productos = productos.OrderBy(x => x.Nombre).ToList();
                    break;
                case "nombre_desc":
                    productos = productos.OrderByDescending(x => x.Nombre).ToList();
                    break;
                case "categoria":
                    productos = productos.OrderBy(x => x.Categoria).ToList();
                    break;
                case "categoria_desc":
                    productos = productos.OrderByDescending(x => x.Categoria).ToList();
                    break;
                default:
                    productos = productos.OrderBy(x=>x.Id).ToList();
                    break;
            }

            return new ProductosPage
            {
                Pagina = paginaCalcular,
                Paginas = (int)Math.Ceiling(productos.Count / (double)tamanioPaginaCalcular),
                Total = productos.Count,
                Items = productos.Skip((paginaCalcular - 1) * tamanioPaginaCalcular).Take(tamanioPaginaCalcular).ToList()
            };
        }
    }
}