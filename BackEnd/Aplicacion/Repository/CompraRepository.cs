using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class CompraRepository : GenericRepository<Compra>, ICompra
{
    private readonly DbAppContext _Context;
    public CompraRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Compra>> GetAllAsync()
    {
        return await _Context.Set<Compra>()
            .Include(p => p.Productos)
            .Include(p => p.ClienteCompras)
            .ToListAsync();
    }
}
