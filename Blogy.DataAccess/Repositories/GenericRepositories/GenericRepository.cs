using Blogy.DataAccess.Context;
using Blogy.Entities.Concrete.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blogy.DataAccess.Repositories.GenericRepositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _table;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _table = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AnyAsync(predicate);
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _table.FindAsync(id);
        _context.Remove(result);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
    {
       return await _table.Where(filter).AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
