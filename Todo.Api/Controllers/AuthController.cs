using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Todo.Api.Models;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (login != null)
            {
                if (login.UserName?.ToLower() == "mojtaba" && login.Password?.ToLower() == "123")
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mojtaba"));
                    var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var tokenOption = new JwtSecurityToken(
                        issuer: "https://localhost:7100",
                        claims: new List<Claim>
                        {
                new Claim(ClaimTypes.Name , "mojtaba"),
                new Claim(ClaimTypes.Role , "Admin")
                        },
                        signingCredentials: signin,
                        expires: DateTime.Now.AddMinutes(30)
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                    return Ok(new { token = token });
                }
                else
                    return Unauthorized();
            }
            else
                return BadRequest(ModelState);
        }
    }
}
