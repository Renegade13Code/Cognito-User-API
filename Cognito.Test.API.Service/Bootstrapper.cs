using Amazon.AspNetCore.Identity.Cognito;
using Amazon.Extensions.CognitoAuthentication;
using Cognito.Test.API.Core.Operations.Users;
using Cognito.Test.API.Service.Operations.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Cognito.Test.API.Service;

public static class Bootstrapper
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        //Add AWS Cognito Services
        services.AddCognitoIdentity();
        
        //Register operations in DI container
        services.AddScoped<IChangePasswordOperation, ChangePasswordOperation>();
        return services;
    }
}