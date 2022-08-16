using Api.Library;
using Core.Library.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Api.Configurations;

public static class AddFluentValidationConfiguration
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(CategoryCreateValidation));
        services.AddValidatorsFromAssemblyContaining(typeof(CategoryUpdateValidation));
    }
}