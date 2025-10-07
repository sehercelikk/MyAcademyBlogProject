using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.DataAccess.Repositories.CategoryRepositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepo
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
