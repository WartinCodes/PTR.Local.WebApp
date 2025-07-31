using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services.Implementations;

namespace WebApplication4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        // Generacion de token sin validacion de usuario y contraseña ya que no está creado.
        var token = _tokenService.GenerateToken("demo-user");

        return Ok(token);
    }
}


