using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class PagoRepository : GenericRepository<Pago>, IPago
{
    private readonly DbAppContext _Context;
    public PagoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Pago>> GetAllAsync()
    {
        return await _Context.Set<Pago>()
            .Include(p => p.ClienteCompras)
            .ToListAsync();
    }
}
