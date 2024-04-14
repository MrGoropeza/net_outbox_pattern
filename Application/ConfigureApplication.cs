using Application.Diseases.List;
using Application.Users.SignUp;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConfigureApplication).Assembly);

        services.AddScoped<ISignUpHandler, SignUpHandler>();
        services.AddScoped<IListDiseasesService, ListDiseasesService>();

        return services;
    }
}
