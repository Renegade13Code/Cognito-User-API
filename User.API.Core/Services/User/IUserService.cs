using User.API.Core.Models;

namespace User.API.Core.Services.User;

public interface IUserService
{
    Task<Result> UpdateUserPasswordAsync(Guid userGuid, string currentPassword, string newPassword);
}