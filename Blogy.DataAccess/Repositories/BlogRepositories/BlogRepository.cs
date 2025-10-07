﻿using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entities.Concrete;

namespace Blogy.DataAccess.Repositories.BlogRepositories;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }
}
