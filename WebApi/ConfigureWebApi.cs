using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistence;
using Quartz;
using Quartz.AspNetCore;
using WebApi.BackgroundJobs;
using WebApi.Endpoints;

namespace WebApi;

public static class ConfigureWebApi
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        var assembly = typeof(ConfigureWebApi).Assembly;

        // Configure Endpoints
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        ServiceDescriptor[] serviceDescriptors = assembly.DefinedTypes
            .Where(
                type =>
                    type is { IsAbstract: false, IsInterface: false }
                    && type.IsAssignableTo(typeof(IEndpoint))
            )
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        // Configure Outbox Messages Processing
        services.AddSingleton<OutboxDbContextInterceptor>();
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(OutboxStartupJob));

            configure
                .AddJob<OutboxStartupJob>(jobKey)
                .AddTrigger(
                    trigger =>
                        trigger
                            .ForJob(jobKey)
                            .WithSimpleSchedule(
                                schedule => schedule.WithIntervalInSeconds(5).WithRepeatCount(0)
                            )
                );
        });
        services.AddQuartzServer(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        // Configure Database
        services.AddDbContext<OutboxDbContext>(
            (sp, opt) =>
            {
                var outboxInterceptor = sp.GetRequiredService<OutboxDbContextInterceptor>();
                opt.UseNpgsql("name=ConnectionStrings:PostgresDatabase")
                    .AddInterceptors(outboxInterceptor);
            }
        );

        return services;
    }

    public static IApplicationBuilder UseWebApi(
        this WebApplication app,
        RouteGroupBuilder? routeGroupBuilder = null
    )
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHttpsRedirection();
        }

        return app;
    }
}
