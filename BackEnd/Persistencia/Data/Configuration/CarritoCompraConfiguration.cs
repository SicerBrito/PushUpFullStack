using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CarritoCompraConfiguration : IEntityTypeConfiguration<CarritoCompra>
{
    public void Configure(EntityTypeBuilder<CarritoCompra> builder)
    {

        builder.ToTable("CarritoCompra");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdCarritoCompra")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.IdClienteFk)
            .HasColumnName("IdClienteFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Clientes)
            .WithMany(p => p.CarritoCompras)
            .HasForeignKey(p => p.IdClienteFk);

        builder.Property(p => p.IdProductoFk)
            .HasColumnName("IdProductoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Productos)
            .WithMany(p => p.CarritoCompras)
            .HasForeignKey(p => p.IdProductoFk);

        builder.Property(p => p.ProductoEnCarrito)
            .HasColumnName("ProductoEnCarrito")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.CantidadCadaProductoEnCarrito)
            .HasColumnName("CantidadCadaProductoEnCarrito")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.PrecioTotalCarrito)
            .HasColumnName("PrecioTotalCarrito")
            .HasColumnType("double")
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                IdClienteFk = 1,
                IdProductoFk = 1,
                ProductoEnCarrito = "Producto 1",
                CantidadCadaProductoEnCarrito = 2,
                PrecioTotalCarrito = 20.5
            },
            new {
                Id = 2,
                IdClienteFk = 1,
                IdProductoFk = 3,
                ProductoEnCarrito = "Producto 2",
                CantidadCadaProductoEnCarrito = 1,
                PrecioTotalCarrito = 15.75
            },
            new {
                Id = 3,
                IdClienteFk = 2,
                IdProductoFk = 2,
                ProductoEnCarrito = "Producto 3",
                CantidadCadaProductoEnCarrito = 3,
                PrecioTotalCarrito = 30.0
            },
            new {
                Id = 4,
                IdClienteFk = 3,
                IdProductoFk = 1,
                ProductoEnCarrito = "Producto 4",
                CantidadCadaProductoEnCarrito = 1,
                PrecioTotalCarrito = 10.0
            },
            new {
                Id = 5,
                IdClienteFk = 2,
                IdProductoFk = 3,
                ProductoEnCarrito = "Producto 5",
                CantidadCadaProductoEnCarrito = 2,
                PrecioTotalCarrito = 25.5
            },
            new {
                Id = 6,
                IdClienteFk = 4,
                IdProductoFk = 2,
                ProductoEnCarrito = "Producto 6",
                CantidadCadaProductoEnCarrito = 1,
                PrecioTotalCarrito = 15.75
            },
            new {
                Id = 7,
                IdClienteFk = 3,
                IdProductoFk = 1,
                ProductoEnCarrito = "Producto 7",
                CantidadCadaProductoEnCarrito = 3,
                PrecioTotalCarrito = 30.0
            },
            new {
                Id = 8,
                IdClienteFk = 4,
                IdProductoFk = 3,
                ProductoEnCarrito = "Producto 8",
                CantidadCadaProductoEnCarrito = 1,
                PrecioTotalCarrito = 10.0
            },
            new {
                Id = 9,
                IdClienteFk = 5,
                IdProductoFk = 2,
                ProductoEnCarrito = "Producto 9",
                CantidadCadaProductoEnCarrito = 2,
                PrecioTotalCarrito = 25.5
            },
            new {
                Id = 10,
                IdClienteFk = 5,
                IdProductoFk = 1,
                ProductoEnCarrito = "Producto 10",
                CantidadCadaProductoEnCarrito = 1,
                PrecioTotalCarrito = 15.75
            }
        );


    }
}
