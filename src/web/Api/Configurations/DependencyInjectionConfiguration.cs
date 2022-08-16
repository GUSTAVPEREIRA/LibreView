using Application.Library;
using Core.Library;
using Infrastructure.Library;

namespace Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
    }
}