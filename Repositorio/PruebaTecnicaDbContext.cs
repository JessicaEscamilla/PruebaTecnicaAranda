using Microsoft.EntityFrameworkCore;
using Negocio.Entidades;
using System.Reflection;

namespace Repositorio
{
    public class PruebaTecnicaDbContext : DbContext
    {
        public PruebaTecnicaDbContext (DbContextOptions options) : base(options) 
        { 
        
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}