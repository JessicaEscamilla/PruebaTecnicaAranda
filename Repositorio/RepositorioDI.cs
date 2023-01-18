using Microsoft.Extensions.DependencyInjection;
using Negocio.Interfaces.Repositorios;
using Repositorio.Repositorios;

namespace Repositorio
{
    public static class RepositorioDI
    {
        public static IServiceCollection AgregarRepositorioDI(this IServiceCollection services)
        {
            services.AddTransient<IProductoRepositorio, ProductoRepositorio>();
            return services;
        }
    }
}