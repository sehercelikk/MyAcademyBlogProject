using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.BlogTagRepositories;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Blogy.DataAccess.Repositories.CommentRepositories;
using Blogy.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Blogy.DataAccess.Extensions;

public static class ServiceRegistiration
{
    public static void AddRepositoriesExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options.UseLazyLoadingProxies();
        }
         );

        services.AddIdentity<AppUser, AppRole>(config =>
        {
            config.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.Scan(opt =>
        {
            opt.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });

    }
}
