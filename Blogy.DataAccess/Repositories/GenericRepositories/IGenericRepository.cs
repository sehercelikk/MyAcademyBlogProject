using Blogy.Entities.Concrete.Common;
using System.Linq.Expressions;

namespace Blogy.DataAccess.Repositories.GenericRepositories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter);
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
}
