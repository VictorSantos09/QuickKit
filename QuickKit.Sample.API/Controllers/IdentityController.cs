using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickKit.Security.Jwt;
using System.Security.Claims;

namespace QuickKit.Sample.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public IdentityController(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GenerateToken()
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, "Teste"),
            new Claim(ClaimTypes.Role, "Admin")
        };

        JwtTokenRequest request = new(claims,
                                      DateTime.Now.AddHours(1),
                                      "mysuperfantasticsecretkeythatissecure",
                                      "localhost",
                                      "localhost");

        var token = _jwtTokenGenerator.Generate(request);
        return Ok(token);
    }
}
