using Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Providers;

public static class EntityFrameworkProvider
{
    public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSettings();

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.CreatePosgresqlProvider(settings.ConnectionString);
        });
    }
}