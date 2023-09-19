using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.API.Core.Services.User;
using User.API.DtoModels;

namespace User.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // [HttpGet]
    // [Authorize]
    // public async ActionResult GetUser()
    // {
    //     
    // }
    
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

        var changePasswordResult = await _userService.UpdateUserPasswordAsync(userGuid, changePasswordRequest.CurrentPassword, changePasswordRequest.NewPassword);

        if (!changePasswordResult.Succeeded)
        {
            return BadRequest(changePasswordResult.Errors);
        }
        return NoContent();
    }
}