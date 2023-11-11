using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleProductoConfiguration : IEntityTypeConfiguration<DetalleProducto>
{
    public void Configure(EntityTypeBuilder<DetalleProducto> builder)
    {

        builder.ToTable("DetalleProducto");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdDetalleProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdProductoFk)
            .HasColumnName("IdProductoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Productos)
            .WithMany(p => p.DetalleProductos)
            .HasForeignKey(p => p.IdProductoFk);

        builder.Property(p => p.DetallesAdicionalesProducto)
            .HasColumnName("DetallesAdicionalesProducto")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                IdProductoFk = 1,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 1"
            },
            new {
                Id = 2,
                IdProductoFk = 2,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 2"
            },
            new {
                Id = 3,
                IdProductoFk = 3,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 3"
            },
            new {
                Id = 4,
                IdProductoFk = 4,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 4"
            },
            new {
                Id = 5,
                IdProductoFk = 5,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 5"
            },
            new {
                Id = 6,
                IdProductoFk = 1,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 1"
            },
            new {
                Id = 7,
                IdProductoFk = 2,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 2"
            },
            new {
                Id = 8,
                IdProductoFk = 3,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 3"
            },
            new {
                Id = 9,
                IdProductoFk = 4,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 4"
            },
            new {
                Id = 10,
                IdProductoFk = 5,
                DetallesAdicionalesProducto = "Detalles adicionales para Producto 5"
            }
        );


    }
}
