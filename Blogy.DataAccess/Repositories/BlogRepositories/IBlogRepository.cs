using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.DataAccess.Repositories.BlogRepositories;

public interface IBlogRepository : IGenericRepository<Blog>
{
    Task<List<Blog>> GetBlogWithCategoryAsync();
    Task<List<Blog>> GetLast3BlogsAsync();
}
