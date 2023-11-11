using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbAppContext ? _Context;
        public UnitOfWork(DbAppContext context){
            _Context = context;
        }



        private RolRepository ? _Rol;
        private UsuarioRepository ? _Usuario;
        private UsuariosRolesRepository ? _UsuariosRoles;
        private CarritoCompraRepository ? _CarritoCompra;
        private CategoriaProductoRepository ? _CategoriaProducto;
        private ClienteRepository ? _Cliente;
        private ClienteCompraRepository ? _ClienteCompra;
        private CompraRepository ? _Compra;
        private DetalleProductoRepository ? _DetalleProducto;
        private PagoRepository ? _Pago;
        private ProductoRepository ? _Producto;



        
        public IRol ? Roles => _Rol ??= new RolRepository(_Context!);
        public IUsuario ? Usuarios => _Usuario ??= new UsuarioRepository(_Context!);
        public IUsuarioRoles UsuariosRoles => _UsuariosRoles ??= new UsuariosRolesRepository(_Context!);
        public ICarritoCompra? CarritoCompras => _CarritoCompra ??= new CarritoCompraRepository(_Context!);
        public ICategoriaProducto? CategoriaProductos => _CategoriaProducto ??= new CategoriaProductoRepository(_Context!);
        public ICliente? Clientes => _Cliente ??= new ClienteRepository(_Context!);
        public IClienteCompra? ClienteCompras => _ClienteCompra ??= new ClienteCompraRepository(_Context!);
        public ICompra? Compras => _Compra ??= new CompraRepository(_Context!);
        public IDetalleProducto? DetalleProductos => _DetalleProducto ??= new DetalleProductoRepository(_Context!);
        public IPago? Pagos => _Pago ??= new PagoRepository(_Context!);
        public IProducto? Productos => _Producto ??= new ProductoRepository(_Context!);
    
        
        public void Dispose(){
            _Context!.Dispose();
            GC.SuppressFinalize(this); 
        }

        public Task<int> SaveAsync(){
            return _Context!.SaveChangesAsync();
        }
    }
