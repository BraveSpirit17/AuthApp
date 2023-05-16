using AuthApp.Application.DI;
using AuthApp.Infrastructure.DI;

namespace AuthApp.Api.Extensions;

public static class RegistrationService
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureInfrastructure(configuration);
        services.ConfigureApplication(configuration);

        return services;
    }
}