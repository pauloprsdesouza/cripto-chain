using Cripto.Chain.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cripto.Chain.Api.Infrastructure.Dependencies
{
    public static class ApiDbContextConfiguration
    {
        public static void DbContextConfigure(this IServiceCollection service, IConfiguration configuration)
        {
                service.AddDbContext<ApiDbContext>(options =>
            {
                options.UseNpgsql("server=localhost;Port=5440;database=postgres;user id=postgres;password=mysecretpassword", pgsql =>
                {
                    pgsql.MigrationsHistoryTable(tableName: "__migration_history", schema: ApiDbContext.Schema);
                });
            });
        }
    }
}
