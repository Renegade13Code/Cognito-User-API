using User.API.Core.Models;

namespace User.API.Core.Interfaces.Users;

public interface IExternalUserService
{
    Task<Result> UpdatePasswordAsync(Guid userGuid, string currentPassword, string newPassword);
    Task<Models.User> GetUserAsync(Guid userGuid);

}