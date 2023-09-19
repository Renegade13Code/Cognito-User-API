using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cognito.Test.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    [Authorize]
    [Authorize(Roles = "Admin")]
    public IActionResult TestEndpoint()
    {
        return Ok("You have been successfully authed against aws Cognito to call this endpoint :)");
    }
}