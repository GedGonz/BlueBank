using BlueBan.Aplication.Entitydto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlueBlanUnitTest
{
    public static class FakeJwtManager
    {


        public static string Issuer { get; set; } 
        public static string Audience { get; set; } 
        public static SecurityKey SecurityKey { get; set; }

        private static readonly RandomNumberGenerator generator = RandomNumberGenerator.Create();
        private static readonly byte[] key = new byte[32];
        static FakeJwtManager()
        {
            Issuer = "GEDGONZ";
            Audience = "GEDGONZ";
        }


        public static string GenerateJwtToken()
        {
            var user = new Userdto()
            {
                id = "",
                username="Admin"
            };
            return GenerateJSONWebToken(user);
        }

        private static string GenerateJSONWebToken(Userdto userInfo)
        {

            string keySecret = "GedGonz12345678*";

            byte[] keyByte = Encoding.UTF8.GetBytes(keySecret);

            SecurityKey = new SymmetricSecurityKey(keyByte);


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userInfo.id.ToString()),
                new Claim(ClaimTypes.Name,userInfo.username.ToString())
            };

            var cred = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                audience: Audience,
                issuer: Issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: cred
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
