using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repository;
public class CategoriaProductoRepository : GenericRepository<CategoriaProducto>, ICategoriaProducto
{
    private readonly DbAppContext _Context;
    public CategoriaProductoRepository(DbAppContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<CategoriaProducto>> GetAllAsync()
    {
        return await _Context.Set<CategoriaProducto>()
            .Include(p => p.Productos)
            .ToListAsync();
    }
}
