using Microsoft.AspNetCore.Mvc;

using Wrongcat.Api.Model.AuthDto;
using Wrongcat.Api.Services;

namespace Wrongcat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
    {
        try
        {
            var result = await authService.RegisterAsync(registerDto);
            if (result == false)
            {
                return StatusCode(409, "The email address already exists");
            }

            return StatusCode(201);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}