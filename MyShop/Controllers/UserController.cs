using Contracts;
using Entities.DTO.User;
using Entities.Model;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager repositoryManager;
        public IOptions<AppSettings> options { get; }
        public UserController(IRepositoryManager repositoryManager, IOptions<AppSettings> options)
        {
            this.repositoryManager = repositoryManager;
            this.options = options;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Loginasync(UserCredentials userCredentials, CancellationToken token)
        {
            if (userCredentials is null)
                return BadRequest("No data");

            var user = await repositoryManager.User.Login(userCredentials.Login, userCredentials.Password, false, token);
            if (user is null)
                throw new Exception("user is null");

            var key = System.Text.Encoding.UTF8.GetBytes(options.Value.SecretKey);
            var tokendescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity
                (
                    new List<Claim>
                    {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.GivenName, user.FirstName),
                            new Claim(ClaimTypes.Name, user.LastName),
                            new Claim(ClaimTypes.Role, user.Role.ToString()),
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha384),
            };

            var securitytoken = new JwtSecurityTokenHandler().CreateToken(tokendescriptor);

            var authinfo = new UserAuthInfo
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securitytoken),
                UserCredentials = user.Adapt<UserDTO>(),
            };
            if (string.IsNullOrEmpty(authinfo.Token))
                return Unauthorized("Error login or password");

            return Ok(authinfo);
        }
    }
}

