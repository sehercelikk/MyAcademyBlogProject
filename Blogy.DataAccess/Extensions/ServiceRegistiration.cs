using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.BlogTagRepositories;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Blogy.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogy.DataAccess.Extensions;

public static class ServiceRegistiration
{
    public static void AddRepositoriesExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<AppUser,AppRole>(config=>
        {
            config.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBlogTagRepository, BlogTagRepository>();
    }
}
