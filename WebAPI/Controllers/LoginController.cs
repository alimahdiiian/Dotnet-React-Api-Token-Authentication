using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;


//Authenticate the user & generate Token 
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);

            }

            return NotFound("user not found");
        }

        private string Generate(UserModel user)
        {
            var securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim (ClaimTypes.Surname, user.SureName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            // Create JWT token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15), // Token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstant.Users.FirstOrDefault(u => u.UserName
            .ToLower() == userLogin.UserName.ToLower()
            && u.PassWord == userLogin.PassWord);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }




    }
}
