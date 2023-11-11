using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {

        builder.ToTable("Compra");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdCompra")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdProductoFk)
            .HasColumnName("IdProductoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Productos)
            .WithMany(p => p.Compras)
            .HasForeignKey(p => p.IdProductoFk);

        builder.Property(p => p.Cantidad)
            .HasColumnName("Cantidad")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.ValorUnitUSD)
            .HasColumnName("ValorUnitUSD")
            .HasColumnType("double")
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                IdProductoFk = 1,
                Cantidad = 3,
                ValorUnitUSD = 20.0
            },
            new {
                Id = 2,
                IdProductoFk = 2,
                Cantidad = 2,
                ValorUnitUSD = 15.5
            },
            new {
                Id = 3,
                IdProductoFk = 3,
                Cantidad = 1,
                ValorUnitUSD = 30.0
            },
            new {
                Id = 4,
                IdProductoFk = 4,
                Cantidad = 4,
                ValorUnitUSD = 10.0
            },
            new {
                Id = 5,
                IdProductoFk = 5,
                Cantidad = 2,
                ValorUnitUSD = 25.5
            },
            new {
                Id = 6,
                IdProductoFk = 1,
                Cantidad = 1,
                ValorUnitUSD = 15.75
            },
            new {
                Id = 7,
                IdProductoFk = 2,
                Cantidad = 3,
                ValorUnitUSD = 30.0
            },
            new {
                Id = 8,
                IdProductoFk = 3,
                Cantidad = 1,
                ValorUnitUSD = 10.0
            },
            new {
                Id = 9,
                IdProductoFk = 4,
                Cantidad = 2,
                ValorUnitUSD = 25.5
            },
            new {
                Id = 10,
                IdProductoFk = 5,
                Cantidad = 1,
                ValorUnitUSD = 15.75
            }
        );


    }
}
