using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class ConfigurePersistence
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        // services.AddDbContext<OutboxDbContext>(
        //     (opt) => opt.UseNpgsql("name=ConnectionStrings:PostgresDatabase").AddInterceptors<OutboxDbContextInterceptor>()
        // );

        return services;
    }
}
