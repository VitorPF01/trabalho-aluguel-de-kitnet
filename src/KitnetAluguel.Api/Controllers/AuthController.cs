using KitnetAluguel.Api.DTOs;
using KitnetAluguel.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace KitnetAluguel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var user = await _auth.RegisterAsync(request);
        return CreatedAtAction(nameof(Register), new { id = user.Id }, new { user.Id, user.Name, user.Email });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var resp = await _auth.LoginAsync(request);
        if (resp is null)
            return Unauthorized(new { message = "Credenciais invalidas" });
        return Ok(resp);
    }
}
