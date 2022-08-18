using AutoMapper;
using Infrastructure.Library.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mapping = new MapperConfiguration(mapper =>
        {
            mapper.AddProfile<CategoryMappingProfile>();
        });

        services.AddSingleton(mapping.CreateMapper());
    }
}