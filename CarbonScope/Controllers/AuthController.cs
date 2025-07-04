using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using CarbonScope.Services.Abstract;
using CarbonScope.Dtos;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        try
        {
            var token = await _authService.Register(dto);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var token = await _authService.Login(dto);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
