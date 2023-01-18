using Negocio.Entidades;
using Negocio.Interfaces.Repositorios;

namespace Repositorio.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        public async Task<List<Producto>> ObtenerProductos()
        {
            var productos = new List<Producto>
            {
                new Producto
                {
                    Categoria = "test",
                    Descripcion = "test"
                },
                new Producto
                {
                    Categoria = "test3",
                    Descripcion = "test3"
                }
            };

            return productos;
        }
    }
}