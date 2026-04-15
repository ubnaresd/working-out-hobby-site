using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
    {
        var tokens = await authService.LoginAsync(request);

        if (tokens is null)
        {
            return BadRequest("Invalid username or password");
        }

        return Ok(tokens);
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
    {
        var result = await authService.RefreshTokensAsync(request);

        if (result is null || result.Jwt is null || result.RefreshToken is null)
        {
            return Unauthorized("Invalid refresh token");
        }

        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    public ActionResult<string> AuthenticateOnlyEndpoint()
    {
        return Ok("You are authenticated");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-route")]
    public ActionResult<string> AdminOnlyEndpoint()
    {
        return Ok("You are an admin");
    }
}
