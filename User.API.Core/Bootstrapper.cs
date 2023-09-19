using Microsoft.Extensions.DependencyInjection;
using User.API.Core.Services.User;

namespace User.API.Core;

public static class Bootstrapper
{
    public static IServiceCollection AddApiCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}