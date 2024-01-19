using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManager.Application.Contract;
using UserManager.Application.Models;
using UserManager.Application.Service;
using UserManager.Domain.Ports;
using UserManager.Domain.Services;

namespace UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationsController : ControllerBase
    {
        private readonly string secretKey;

        private readonly IUserAppService _userAppService;

        public AutenticationsController(IConfiguration config, UserAppService userAppService)
        {
            _userAppService = userAppService;
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }
        [HttpPost]
        [Route("Validate")]
        public IActionResult Validate([FromBody] UserInfoDTO userInfoDTO) {
            var user = _userAppService.GeTaskByEmail(userInfoDTO.Email, userInfoDTO.Password);

            if (user.Result != null)
            {
                var KeyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userInfoDTO.Email));
                claims.AddClaim(new Claim("Rol", (user.Result) != null ?  user?.Result?.CodeRole : string.Empty));

                var tokeDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenCofig = tokenHandler.CreateToken(tokeDescriptor);

                string createToken = tokenHandler.WriteToken(tokenCofig);

                return StatusCode(StatusCodes.Status200OK, new { token = createToken });
            }
            else
            { return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" }); }
        }       
    }
}
