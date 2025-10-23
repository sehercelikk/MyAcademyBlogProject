using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.BlogRepositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Blog>> GetBlogWithCategoryAsync()
    {
       var query= await _table.Include(b => b.Category).ToListAsync();
        return query;



    }

    public async Task<List<Blog>> GetLast3BlogsAsync()
    {
        var blogs= await _table.OrderByDescending(b => b.Id).Take(3).ToListAsync();
        return blogs;
    }
}
