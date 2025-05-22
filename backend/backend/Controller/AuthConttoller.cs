using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
[DisableCors]
public class AuthController : ControllerBase
{
    IUserService userService;
    public AuthController(IUserService _userService) {
       userService = _userService;
    }
    [DisableCors]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] RequestLogin login)
    {
        if (!await userService.Login(login.email,login.password))
              return StatusCode((int) System.Net.HttpStatusCode.NoContent); 
        var token = GenerateJwtToken();
        return Ok(new { token });
    }
    [DisableCors]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User login)
    {
        if (!await userService.Register(login))
              return StatusCode((int) System.Net.HttpStatusCode.NoContent);  
        return Ok("OK");
    }
    [DisableCors]
    [HttpGet("Validate")]
    public async Task<IActionResult> Validate( )
    {
        if (!Request.Headers.ContainsKey("token"))  
              return StatusCode((int) System.Net.HttpStatusCode.NoContent);  
        return Ok("OK");
    }
    private string GenerateJwtToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}