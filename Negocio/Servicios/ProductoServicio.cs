using Negocio.Entidades;
using Negocio.Interfaces.Servicios;

namespace Negocio.Servicios
{
    public class ProductoServicio : IProductoServicio
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