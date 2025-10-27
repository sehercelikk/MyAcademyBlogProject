using Blogy.Business.AutoMapper;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Validators.CategoryValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blogy.Business.Extensions;

public static class BusinessServiceRegistirationExtension
{
    public static void AddServiceExtension(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CategoryMapping).Assembly);


        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBlogService, BlogService>();

        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly);
    }
}
