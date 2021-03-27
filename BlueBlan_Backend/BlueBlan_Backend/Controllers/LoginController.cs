using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using BlueBlan.Dominio.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlueBlan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private IUserAplicationService _userAplicationService;


        public LoginController(IUserAplicationService _userAplicationService,IConfiguration _config)
        {
            this._userAplicationService = _userAplicationService;
            this._config = _config;

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Userdto login)
        {
            var isAuthenticate =await _userAplicationService.Authenticate(login.username, login.password);

            if (isAuthenticate) 
            {
                var user = await _userAplicationService.findUser(login.username);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    return Ok(new { token = tokenString });
                }
            }
         

            return Unauthorized();
        }

        private string GenerateJSONWebToken(Userdto userInfo)
        {

            string keySecret = this._config.GetSection("AppSettings:Token").Value;

            byte[] keyByte = Encoding.UTF8.GetBytes(keySecret);

            var key = new SymmetricSecurityKey(keyByte);

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userInfo.id.ToString()),
                new Claim(ClaimTypes.Name,userInfo.username.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                audience: this._config.GetSection("AppSettings:Issuer").Value,
                issuer: this._config.GetSection("AppSettings:Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: cred
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
