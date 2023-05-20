using Microsoft.AspNetCore.Mvc;
using Eches.Hr.Infrastructure.Model;
using Eches.Hr.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Eches.Hr.Core;
using Eches.Hr.Core.Setting;
using Microsoft.Extensions.Options;

namespace Eches.Hr.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [MiddlewareFilter(typeof(ExceptionMiddleware))]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenSetting _tokenSetting;
        public AuthenticationController(IOptions<TokenSetting> tokenSetting)
        {
            _tokenSetting = tokenSetting.Value;
        }

        [HttpPost("Token")]
        public IActionResult GenerateToken()
        {
            var result = Token.GenerateJsonWebToken(_tokenSetting.Secret, _tokenSetting.Audience, _tokenSetting.Issuer);
            return Ok(result);
        }
    }
}

