using Cognito.Test.API.Core.Models;

namespace Cognito.Test.API.Core.Operations;

public interface IChangePasswordUseCase
{
    Task<Result> ExecuteAsync(Guid userGuid, string currentPassword, string newPassword);
}