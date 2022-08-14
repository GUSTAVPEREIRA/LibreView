using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Providers;

public static class PostgresqlProvider
{
    public static DbContextOptionsBuilder CreatePosgresqlProvider(this DbContextOptionsBuilder dbContextOptions,
        string connectionString)
    {
        return dbContextOptions.UseNpgsql(connectionString,
            builder => builder.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
    }
}