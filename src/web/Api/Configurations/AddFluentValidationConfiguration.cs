using Core.Library.Models;
using FluentValidation;

namespace Api.Configurations;

public static class AddFluentValidationConfiguration
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(CategoryCreateRequest));
        services.AddValidatorsFromAssemblyContaining(typeof(CategoryUpdateRequest));
    }
}