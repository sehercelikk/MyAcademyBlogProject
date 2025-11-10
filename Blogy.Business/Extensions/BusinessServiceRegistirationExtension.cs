using Blogy.Business.AutoMapper;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentService;
using Blogy.Business.Validators.CategoryValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Blogy.Business.Extensions;

public static class BusinessServiceRegistirationExtension
{
    public static void AddServiceExtension(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CategoryMapping).Assembly);

        services.Scan(opt =>
        {
            opt.FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .AsImplementedInterfaces()
            .WithScopedLifetime();
        });
       

        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly);
    }
}
