using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using User.API.AWS.Cognito.Service.AutoMapper;
using User.API.AWS.Cognito.Service.Service;
using User.API.Core.Interfaces.Users;

namespace User.API.AWS.Cognito.Service;

public static class Bootstrapper
{
    public static IServiceCollection AddAwsCognitoService(this IServiceCollection services)
    {
        //Add AWS Cognito Services
        services.AddCognitoIdentity();

        //Register operations in DI container
        return services
            .AddSingleton<Profile, AwsCognitoServiceProfile>()
            .AddScoped<IExternalUserService, AwsCognitoUserService>();
    }
}