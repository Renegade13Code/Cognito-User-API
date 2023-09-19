using System.Security.Claims;
using User.API.Core.Models;

namespace User.API.Core.Interfaces.Users;

public interface IAwsCognitoUserService
{
    Task<Result> UpdatePasswordAsync(Guid userGuid, string currentPassword, string newPassword);
    Task GetUserAsync(ClaimsPrincipal principal);
}