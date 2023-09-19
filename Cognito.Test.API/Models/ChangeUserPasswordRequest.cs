namespace Cognito.Test.API.Models;

public class ChangeUserPasswordRequest
{
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}