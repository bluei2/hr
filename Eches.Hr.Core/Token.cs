using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Eches.Hr.Core
{
    public static class Token
    {
        public static string GenerateJsonWebToken(string secret, string audience, string issuer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: audience,
                issuer: issuer,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(3));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

