using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Entidades;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class ProductoMapa : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.HasKey(x => x.Id);
    }
}