using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {

        builder.ToTable("Producto");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Precio)
            .HasColumnName("Precio")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(p => p.IdCategoriaFk)
            .HasColumnName("IdCategoriaFk")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasOne(p => p.CategoriaProductos)
            .WithMany(p => p.Productos)
            .HasForeignKey(p => p.IdCategoriaFk);

        builder.Property(p => p.Marca)
            .HasColumnName("Marca")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.UrlImagen)
            .HasColumnName("UrlImagen")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.StockDisponible)
            .HasColumnName("StockDisponible")
            .HasColumnType("int")
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                Nombre = "Laptop Adidas",
                Precio = 800.0,
                IdCategoriaFk = 1,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/nV5x34p.jpg",
                StockDisponible = 50
            },
            new {
                Id = 2,
                Nombre = "Smartphone Adidas",
                Precio = 500.0,
                IdCategoriaFk = 1,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/w99d8o5.jpg",
                StockDisponible = 100
            },
            new {
                Id = 3,
                Nombre = "Television Adidas",
                Precio = 1200.0,
                IdCategoriaFk = 2,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/5rE070t.jpg",
                StockDisponible = 30
            },
            new {
                Id = 4,
                Nombre = "Zapatillas Deportivas Adidas",
                Precio = 80.0,
                IdCategoriaFk = 3,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/oQ8i8q.jpg",
                StockDisponible = 200
            },
            new {
                Id = 5,
                Nombre = "Libro de Ciencia Ficción Adidas",
                Precio = 15.0,
                IdCategoriaFk = 7,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/3c3Q8sJ.jpg",
                StockDisponible = 50
            },
            new {
                Id = 6,
                Nombre = "Mesa de Comedor Adidas",
                Precio = 250.0,
                IdCategoriaFk = 6,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/787878s.jpg",
                StockDisponible = 60
                },

            new {
                Id = 7,
                Nombre = "Reloj Inteligente Adidas",
                Precio = 100.0,
                IdCategoriaFk = 5,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/f94g11j.jpg",
                StockDisponible = 75
            },
            new {
                Id = 8,
                Nombre = "Cámara DSLR Adidas",
                Precio = 600.0,
                IdCategoriaFk = 4,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/339559s.jpg",
                StockDisponible = 15
            },
            new {
                Id = 9,
                Nombre = "Silla de Oficina Adidas",
                Precio = 120.0,
                IdCategoriaFk = 10,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/696969s.jpg",
                StockDisponible = 40
            },
            new {
                Id = 10,
                Nombre = "Botellas de Vino (Pack de 6) Adidas",
                Precio = 50.0,
                IdCategoriaFk = 6,
                Marca = "Adidas",
                UrlImagen = "https://i.imgur.com/787878s.jpg",
                StockDisponible = 60
            }
        );


    }
}
