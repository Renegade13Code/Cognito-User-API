using System.Security.Claims;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Identity;
using User.API.AWS.Cognito.Service.Models;
using User.API.Core.Interfaces.Users;
using User.API.Core.Models;

namespace User.API.AWS.Cognito.Service.Service;

public class AwsCognitoUserService : IAwsCognitoUserService
{
    private readonly UserManager<CognitoUser> _userManager;

    public AwsCognitoUserService(UserManager<CognitoUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Result> UpdatePasswordAsync(Guid userGuid, string currentPassword, string newPassword)
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
    
    public async Task GetUserAsync(ClaimsPrincipal principal)
    {
        var User = await _userManager.GetUserAsync(principal).ConfigureAwait(false);
    }
}