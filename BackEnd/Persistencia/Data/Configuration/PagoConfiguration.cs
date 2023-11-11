using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PagoConfiguration : IEntityTypeConfiguration<Pago>
{
    public void Configure(EntityTypeBuilder<Pago> builder)
    {

        builder.ToTable("Pago");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdPago")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                Nombre = "Tarjeta de Crédito"
            },
            new {
                Id = 2,
                Nombre = "Transferencia Bancaria"
            },
            new {
                Id = 3,
                Nombre = "PayPal"
            },
            new {
                Id = 4,
                Nombre = "Efectivo"
            },
            new {
                Id = 5,
                Nombre = "Cheque"
            },
            new {
                Id = 6,
                Nombre = "Tarjeta de Débito"
            },
            new {
                Id = 7,
                Nombre = "Bitcoin"
            },
            new {
                Id = 8,
                Nombre = "Apple Pay"
            },
            new {
                Id = 9,
                Nombre = "Google Pay"
            },
            new {
                Id = 10,
                Nombre = "Venmo"
            }
        );


    }
}
