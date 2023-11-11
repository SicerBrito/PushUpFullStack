using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly DbAppContext _Context;
    public ClienteRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _Context.Set<Cliente>()
            .Include(p => p.ClienteCompras)
            .Include(p => p.CarritoCompras)
            .ToListAsync();
    }
}
