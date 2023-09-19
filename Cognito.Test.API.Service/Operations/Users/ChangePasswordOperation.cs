using Amazon.CognitoIdentity.Model;
using Amazon.Extensions.CognitoAuthentication;
using Cognito.Test.API.Core.Models;
using Cognito.Test.API.Core.Operations.Users;
using Microsoft.AspNetCore.Identity;

namespace Cognito.Test.API.Service.Operations.Users;

internal class ChangePasswordOperation : IChangePasswordOperation
{
    private readonly UserManager<CognitoUser> _userManager;

    public ChangePasswordOperation(UserManager<CognitoUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Result> ExecuteAsync(Guid userGuid, string currentPassword, string newPassword)
    {
        ArgumentNullException.ThrowIfNull(userGuid);
        ArgumentNullException.ThrowIfNull(currentPassword);
        ArgumentNullException.ThrowIfNull(newPassword);

        try
        {
            var user = await _userManager.FindByIdAsync(userGuid.ToString()).ConfigureAwait(false);
            var identityResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword)
                .ConfigureAwait(false);
            
            if (!identityResult.Succeeded)
            {
                return Result.Fail(identityResult.Errors.Select(x => x.Description));
            }

            return Result.Success();
        }
        catch (Exception ex)
        {
            //Log Error
            throw new ExternalServiceException("Exception occured updating Cognito user password", ex);
        }
    }
}