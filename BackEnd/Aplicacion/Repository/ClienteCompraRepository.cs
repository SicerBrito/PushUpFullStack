using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class ClienteCompraRepository : GenericRepository<ClienteCompra>, IClienteCompra
{
    private readonly DbAppContext _Context;
    public ClienteCompraRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<ClienteCompra>> GetAllAsync()
    {
        return await _Context.Set<ClienteCompra>()
            .Include(p => p.Clientes)
            .Include(p => p.Compras)
            .Include(p => p.Pagos)
            .ToListAsync();
    }
}
