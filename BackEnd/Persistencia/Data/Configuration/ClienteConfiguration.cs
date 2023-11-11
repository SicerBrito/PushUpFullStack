using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {

        builder.ToTable("Cliente");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdCliente")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Direccion)
            .HasColumnName("Direccion")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.NroContacto)
            .HasColumnName("NroContacto")
            .HasColumnType("double")
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                Nombres = "Juan",
                Apellidos = "Pérez",
                Direccion = "Calle A, Ciudad",
                NroContacto = 123456789.0
            },
            new {
                Id = 2,
                Nombres = "María",
                Apellidos = "Gómez",
                Direccion = "Calle B, Ciudad",
                NroContacto = 987654321.0
            },
            new {
                Id = 3,
                Nombres = "Carlos",
                Apellidos = "Rodríguez",
                Direccion = "Calle C, Ciudad",
                NroContacto = 555555555.0
            },
            new {
                Id = 4,
                Nombres = "Ana",
                Apellidos = "Martínez",
                Direccion = "Calle D, Ciudad",
                NroContacto = 111111111.0
            },
            new {
                Id = 5,
                Nombres = "Pedro",
                Apellidos = "López",
                Direccion = "Calle E, Ciudad",
                NroContacto = 999999999.0
            },
            new {
                Id = 6,
                Nombres = "Laura",
                Apellidos = "Sánchez",
                Direccion = "Calle F, Ciudad",
                NroContacto = 888888888.0
            },
            new {
                Id = 7,
                Nombres = "Diego",
                Apellidos = "Hernández",
                Direccion = "Calle G, Ciudad",
                NroContacto = 777777777.0
            },
            new {
                Id = 8,
                Nombres = "Elena",
                Apellidos = "Gutiérrez",
                Direccion = "Calle H, Ciudad",
                NroContacto = 666666666.0
            },
            new {
                Id = 9,
                Nombres = "Hugo",
                Apellidos = "Flores",
                Direccion = "Calle I, Ciudad",
                NroContacto = 444444444.0
            },
            new {
                Id = 10,
                Nombres = "Sofía",
                Apellidos = "Díaz",
                Direccion = "Calle J, Ciudad",
                NroContacto = 333333333.0
            }
        );


    }
}
