using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.DataAccess.Repositories.CategoryRepositories;

public interface ICategoryRepository : IGenericRepository<Category>
{

    Task<List<Category>> GetAllCategoriesWithBlogsAsync();
}
