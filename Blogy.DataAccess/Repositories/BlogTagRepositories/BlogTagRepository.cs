using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.DataAccess.Repositories.BlogTagRepositories;

public class BlogTagRepository : GenericRepository<BlogTag>, IBlogTagRepository
{
    public BlogTagRepository(AppDbContext context) : base(context)
    {
    }
}
