using Microsoft.EntityFrameworkCore;
using Negocio.Entidades;
using Negocio.Interfaces.Repositorios;

namespace Repositorio.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly PruebaTecnicaDbContext _pruebaTecnicaDbContext;

        public ProductoRepositorio(PruebaTecnicaDbContext pruebaTecnicaDbContext)
        {
            _pruebaTecnicaDbContext = pruebaTecnicaDbContext;
        }

        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            _pruebaTecnicaDbContext.Update(producto);
            await _pruebaTecnicaDbContext.SaveChangesAsync();   

            return producto;
        }

        public async Task<bool> BorrarProducto(Producto producto)
        {
            _pruebaTecnicaDbContext.Remove(producto);

            return await _pruebaTecnicaDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Producto> CrearProducto(Producto producto)
        {
            await _pruebaTecnicaDbContext.AddAsync(producto);
            await _pruebaTecnicaDbContext.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto?> ObtenerProducto(int idProducto)
        {
            return await _pruebaTecnicaDbContext.Productos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == idProducto);
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            return await _pruebaTecnicaDbContext.Productos.AsNoTracking().ToListAsync();
        }
    }
}