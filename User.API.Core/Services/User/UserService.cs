using User.API.Core.Interfaces.Users;
using User.API.Core.Models;

namespace User.API.Core.Services.User;

public class UserService: IUserService
{
    private readonly IAwsCognitoUserService _awsCognitoUserService;

    public UserService(IAwsCognitoUserService awsCognitoUserService)
    {
        _awsCognitoUserService = awsCognitoUserService;
    }
    
    public async Task<Result> UpdateUserPasswordAsync(Guid userGuid, string currentPassword, string newPassword)
    {
        return await _awsCognitoUserService.UpdatePasswordAsync(userGuid, currentPassword, newPassword)
            .ConfigureAwait(false);
    }
}