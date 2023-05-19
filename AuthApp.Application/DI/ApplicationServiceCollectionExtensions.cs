using System.Reflection;
using AuthApp.Application.Interfaces;
using AuthApp.Application.Mapping;
using AuthApp.Application.Options;
using AuthApp.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthApp.Application.DI;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddScoped<IUserService, UserService>();

        services.AddTransient<IAuthenticationService, AuthenticationService>();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(typeof(DtoToModelProfile), typeof(ModelToDtoProfile));
        
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IPasswordHashingService, PasswordHashingService>();

        return services;
    }
}