using Microsoft.AspNetCore.Mvc;
using WorkingOutHobby.Models;
using WorkingOutHobby.Services;

namespace WorkingOutHobby.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        var user = await authService.RegisterAsync(request);
        if (user is null)
        {
            return BadRequest("User already exists");
        }

        return Ok(user);
    }
}
