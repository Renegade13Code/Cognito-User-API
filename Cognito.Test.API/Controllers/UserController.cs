using Cognito.Test.API.Core.Operations;
using Cognito.Test.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cognito.Test.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IChangePasswordUseCase _changePasswordUseCase;

    public UserController(IChangePasswordUseCase changePasswordUseCase)
    {
        _changePasswordUseCase = changePasswordUseCase;
    }
    
    [HttpPut]
    [Route("password")]
    [Authorize]
    public async Task<IActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordRequest changePasswordRequest)
    {
        var userGuidClaim = HttpContext.User.Claims.FirstOrDefault(cl => string.Equals(cl.Type, "username"))?.Value;
        if (!Guid.TryParse(userGuidClaim, out var userGuid))
        {
            return BadRequest("Token user Guid claim invalid");
        }

        var changePasswordResult = await _changePasswordUseCase.ExecuteAsync(userGuid, changePasswordRequest.CurrentPassword, changePasswordRequest.NewPassword);

        if (!changePasswordResult.Succeeded)
        {
            return BadRequest(changePasswordResult.Errors);
        }
        return NoContent();
    }
}