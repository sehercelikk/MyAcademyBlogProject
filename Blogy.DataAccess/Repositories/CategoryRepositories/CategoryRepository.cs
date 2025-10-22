using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.CategoryRepositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetAllCategoriesWithBlogsAsync()
    {
        return await _context.Categories.Include(a => a.Blogs).AsNoTracking().ToListAsync();

    }
}
