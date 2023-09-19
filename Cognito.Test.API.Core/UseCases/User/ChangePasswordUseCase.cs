using Cognito.Test.API.Core.Models;
using Cognito.Test.API.Core.Operations;
using Cognito.Test.API.Core.Operations.Users;

namespace Cognito.Test.API.Core.UseCases.User;

internal class ChangePasswordUseCase : IChangePasswordUseCase
{
    private readonly IChangePasswordOperation _changePasswordOperation;

    public ChangePasswordUseCase(IChangePasswordOperation changePasswordOperation)
    {
        _changePasswordOperation = changePasswordOperation;
    }
    public async Task<Result> ExecuteAsync(Guid userGuid, string currentPassword, string newPassword)
    {
        return await _changePasswordOperation.ExecuteAsync(userGuid, currentPassword, newPassword)
            .ConfigureAwait(false);
    }
}