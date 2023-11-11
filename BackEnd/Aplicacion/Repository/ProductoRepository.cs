using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly DbAppContext _Context;
    public ProductoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _Context.Set<Producto>()
            .Include(p => p.CategoriaProductos)
            .Include(p => p.CarritoCompras)
            .Include(p => p.Compras)
            .Include(p => p.DetalleProductos)
            .ToListAsync();
    }
}
