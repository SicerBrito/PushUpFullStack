using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
    public class DbAppContext : DbContext{

        public DbAppContext(DbContextOptions<DbAppContext> options) : base (options){

        }

        public DbSet<Usuario> ? Usuarios { get; set; } = null!;
        public DbSet<Rol> ? Roles { get; set; } = null!;
        public DbSet<UsuarioRoles> ? UsuariosRoles { get; set; } = null!;
        public DbSet<RefreshToken> ? RefreshTokens { get; set; } = null!;
        public DbSet<CarritoCompra> ? CarritoCompras { get; set; } = null!;
        public DbSet<CategoriaProducto> ? CategoriaProductos { get; set; } = null!;
        public DbSet<Cliente> ?  Clientes { get; set; } = null!;
        public DbSet<ClienteCompra> ? ClienteCompras { get; set; } = null!;
        public DbSet<Compra> ? Compras { get; set; } = null!;
        public DbSet<DetalleProducto> ? DetalleProductos { get; set; } = null!;
        public DbSet<Pago> ? Pagos { get; set; } = null!;
        public DbSet<Producto> ? Productos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
