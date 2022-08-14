using Microsoft.Extensions.Configuration;

namespace Core.Configurations;

public static class ConfigurationsExtension
{
    public static Settings GetSettings(this IConfiguration configuration)
    {
        return configuration.Get<Settings>();
    }
}