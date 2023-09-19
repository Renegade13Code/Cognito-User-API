using Cognito.Test.API.Core.Models;

namespace Cognito.Test.API.Core.Operations.Users;

public interface IChangePasswordOperation
{
    Task<Result> ExecuteAsync(Guid userGuid, string currentPassword, string newPassword);
}