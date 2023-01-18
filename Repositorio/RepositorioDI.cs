using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negocio.Interfaces.Repositorios;
using Repositorio.Repositorios;

namespace Repositorio
{
    public static class RepositorioDI
    {
        public static IServiceCollection AgregarRepositorioDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PruebaTecnicaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductoRepositorio, ProductoRepositorio>();
            return services;
        }
    }
}