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
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> _userManager;

        public LoginController(IUserAplicationService _userAplicationService,IConfiguration _config, SignInManager<User> signInManager, UserManager<User> _userManager)
        {
            this._userAplicationService = _userAplicationService;
            this._config = _config;
            this.signInManager = signInManager;
            this._userManager = _userManager;

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Userdto login)
        {
            var _user = await _userManager.FindByNameAsync(login.username);
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

        //private string GenerateJSONWebToken(Userdto userInfo)
        //{

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,userInfo.id.ToString()),
        //        new Claim(ClaimTypes.Name,userInfo.username.ToString())
        //    };

        //    //Gereracion de Token

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config.GetSection("AppSettings:Token").Value));

        //    var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.Now.AddDays(1),
        //        SigningCredentials = credenciales
        //    };


        //    var tokenhandler = new JwtSecurityTokenHandler();
        //    var token = tokenhandler.CreateToken(tokenDescriptor);

        //    return tokenhandler.WriteToken(token);
        //}


        private string GenerateJSONWebToken(Userdto userInfo)
        {


            //Gereracion de Token

            //generar una semilla
            string keySecret = this._config.GetSection("AppSettings:Token").Value;
            //Se convierte en bytes
            byte[] keyByte = Encoding.UTF8.GetBytes(keySecret);

            //nuget: System.IdentityModel.Tokens.Jwt
            var key = new SymmetricSecurityKey(keyByte);

            //Crea la credencial con el algoritmo HmacSha256
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userInfo.id.ToString()),
                new Claim(ClaimTypes.Name,userInfo.username.ToString())
            };

            //generador de token.
            //para quien se genera el toke, expiracion, se agregan los claims

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
