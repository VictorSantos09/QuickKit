using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms;
using QuickKit.AspNetCore.Attributes;
using QuickKit.Security.Jwt;
using System.Security.Claims;
using System.Text;

namespace Classroom.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ClassroomProtectedController : ControllerBase
    {
        private readonly IJwtTokenGenerator _tokenGenerator;

        public ClassroomProtectedController(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpGetTestEndPointKit]
        [Authorize]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpGet("createToken")]
        [AllowAnonymous]
        public IActionResult CreateToken()
        {
            JwtTokenRequest request = new(Enumerable.Empty<Claim>(),
                DateTime.Now.AddMinutes(1),
                TokenInfo.KeyString,
                TokenInfo.Issuer,
                TokenInfo.Audience
                );

            return Ok(_tokenGenerator.Generate(request));
        }
    }

    public static class TokenInfo
    {
        public const string Issuer = "localhost";
        public const string Audience = "localhost";
        public static byte[] Key = CreateKey();
        public const string KeyString = "mysuperfantasticsecretkeythatissecure";

        public static byte[] CreateKey()
        {
            return Encoding.UTF8.GetBytes(KeyString);
        }
    }
}
