using DAL_CRUD.Data;
using DAL_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _appcontext;
        public AuthController(ApplicationDbContext appcontext)
        {
            _appcontext = appcontext;
        }
        //[HttpGet, Route("login")]
        //public IActionResult Login()
        //{
        //    return null;
        //}
        [HttpPost,Route("login")]
        public IActionResult Login([FromBody] LoginModelVM user)
        {
            if (user == null)
                return BadRequest("Invalid Client Request");

            if (_appcontext.Users.Any(a=>a.UserName== user.UserName) && _appcontext.Users.Where(a => a.UserName == user.UserName).Any(a=>a.Password==user.Password))
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
                var signingcredintials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims:new List<Claim>(),
                expires:DateTime.Now.AddMinutes(5),
               
                signingCredentials: signingcredintials
                );
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token= tokenstring });
            }
            return Unauthorized();
        }
    }
}
