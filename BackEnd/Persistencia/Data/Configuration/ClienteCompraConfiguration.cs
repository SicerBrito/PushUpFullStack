using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ClienteCompraConfiguration : IEntityTypeConfiguration<ClienteCompra>
{
    public void Configure(EntityTypeBuilder<ClienteCompra> builder)
    {

        builder.ToTable("ClienteCompra");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdClienteCompra")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdClienteFk)
            .HasColumnName("IdClienteFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Clientes)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdClienteFk);

        builder.Property(p => p.IdCompraFk)
            .HasColumnName("IdCompraFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Compras)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdCompraFk);

        builder.Property(p => p.FechaTransaccion)
            .HasColumnName("FechaTransaccion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.ValorTotalTransaccion)
            .HasColumnName("ValorTotalTransaccion")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(p => p.IdMetodoPagoFk)
            .HasColumnName("IdMetodoPagoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Pagos)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdMetodoPagoFk);

        builder.Property(p => p.DireccionCliente)
            .HasColumnName("DireccionCliente")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
        
        
        
        
        
        
        
        
        
        
        builder.HasData(
            new {
                Id = 1,
                IdClienteFk = 1,
                IdCompraFk = 1,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 50.0,
                IdMetodoPagoFk = 1,
                DireccionCliente = "Calle A, Ciudad"
            },
            new {
                Id = 2,
                IdClienteFk = 2,
                IdCompraFk = 2,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 75.0,
                IdMetodoPagoFk = 2,
                DireccionCliente = "Calle B, Ciudad"
            },
            new {
                Id = 3,
                IdClienteFk = 3,
                IdCompraFk = 3,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 100.0,
                IdMetodoPagoFk = 1,
                DireccionCliente = "Calle C, Ciudad"
            },
            new {
                Id = 4,
                IdClienteFk = 4,
                IdCompraFk = 4,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 30.0,
                IdMetodoPagoFk = 3,
                DireccionCliente = "Calle D, Ciudad"
            },
            new {
                Id = 5,
                IdClienteFk = 5,
                IdCompraFk = 5,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 60.0,
                IdMetodoPagoFk = 2,
                DireccionCliente = "Calle E, Ciudad"
            },
            new {
                Id = 6,
                IdClienteFk = 1,
                IdCompraFk = 6,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 45.0,
                IdMetodoPagoFk = 1,
                DireccionCliente = "Calle F, Ciudad"
            },
            new {
                Id = 7,
                IdClienteFk = 2,
                IdCompraFk = 7,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 80.0,
                IdMetodoPagoFk = 2,
                DireccionCliente = "Calle G, Ciudad"
            },
            new {
                Id = 8,
                IdClienteFk = 3,
                IdCompraFk = 8,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 95.0,
                IdMetodoPagoFk = 3,
                DireccionCliente = "Calle H, Ciudad"
            },
            new {
                Id = 9,
                IdClienteFk = 4,
                IdCompraFk = 9,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 70.0,
                IdMetodoPagoFk = 1,
                DireccionCliente = "Calle I, Ciudad"
            },
            new {
                Id = 10,
                IdClienteFk = 5,
                IdCompraFk = 10,
                FechaTransaccion = DateTime.Now,
                ValorTotalTransaccion = 55.0,
                IdMetodoPagoFk = 2,
                DireccionCliente = "Calle J, Ciudad"
            }
        );


    }
}
