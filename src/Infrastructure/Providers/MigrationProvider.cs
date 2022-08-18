using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Providers;

public static class MigrationProvider
{
    public static void RunMigration(this IServiceScope scope)
    {
        try
        {
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<DatabaseContext>>();
            logger.LogError(ex, "Ocorreu um erro na migração ou alimentação de dados");
        }
    }
}