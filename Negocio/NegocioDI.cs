using Microsoft.Extensions.DependencyInjection;
using Negocio.Interfaces.Servicios;
using Negocio.Servicios;

namespace Negocio
{
    public static class NegocioDI 
    {
        public static IServiceCollection AgregarNegocioDI (this IServiceCollection services)
        {
            services.AddTransient<IProductoServicio, ProductoServicio>();
            return services;
        }
    }
}