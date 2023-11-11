using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class DetalleProductoRepository : GenericRepository<DetalleProducto>, IDetalleProducto
{
    private readonly DbAppContext _Context;
    public DetalleProductoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<DetalleProducto>> GetAllAsync()
    {
        return await _Context.Set<DetalleProducto>()
            .Include(p => p.Productos)
            .ToListAsync();
    }
}
