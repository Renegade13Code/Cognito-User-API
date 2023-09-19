using Cognito.Test.API.Core.Operations;
using Cognito.Test.API.Core.UseCases.User;
using Microsoft.Extensions.DependencyInjection;

namespace Cognito.Test.API.Core;

public static class Bootstrapper
{
    public static IServiceCollection AddApiCore(this IServiceCollection services)
    {
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        return services;
    }
}