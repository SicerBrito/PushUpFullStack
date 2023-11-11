namespace Dominio.Interfaces;
    public interface IUnitOfWork{
        
        IUsuario ? Usuarios { get; }
        IRol ? Roles { get; }
        IUsuarioRoles UsuariosRoles { get; }
        ICarritoCompra ? CarritoCompras { get; }
        ICategoriaProducto ? CategoriaProductos { get; }
        ICliente ? Clientes { get; }
        IClienteCompra ? ClienteCompras { get; }
        ICompra ? Compras { get; }
        IDetalleProducto ? DetalleProductos { get; }
        IPago ? Pagos { get; }
        IProducto ? Productos { get; }
        Task<int> SaveAsync();
        
    }
