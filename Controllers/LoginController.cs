using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Softtek.Constans;
using Softtek.Models;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Softtek.Controllers
{
    [Route("Seguridad/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

/*
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola"); 
        }
*/

        [HttpPost]
        public IActionResult Login (LoginUser loginUser)
        {
            var user = Authenticate(loginUser);
            if (user != null)
            {
                var token = GenerateToken(user);

              //return Ok("Usuario logueado");
                return Ok(token);
            }
            return NotFound("Usuario no pudo validarse");
        }

        private UserModel Authenticate(LoginUser loginUser)
        {
            var CurrentUser = UserConstans.Users.FirstOrDefault(u => u.Username.ToLower() == loginUser.Username.ToLower() && u.Password == loginUser.Password ); 

            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            
            return null;
        }

        private string GenerateToken (UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
{
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);  
        }
    }
}
