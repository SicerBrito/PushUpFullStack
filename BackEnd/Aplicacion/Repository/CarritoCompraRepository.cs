using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class CarritoCompraRepository : GenericRepository<CarritoCompra>, ICarritoCompra
{
    private readonly DbAppContext _Context;
    public CarritoCompraRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<CarritoCompra>> GetAllAsync()
    {
        return await _Context.Set<CarritoCompra>()
            .Include(p => p.Clientes)
            .Include(p => p.Productos)
            .ToListAsync();
    }
}
