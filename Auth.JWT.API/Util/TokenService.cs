using Auth.JWT.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.JWT.API.Util
{
    public static class TokenService
    {
        private static readonly WebApplicationBuilder builder = WebApplication.CreateBuilder();        

        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username),                    
                    new Claim(ClaimTypes.Role, "employee"/*usuario.Role.ToString()*/)
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                Issuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                Audience = builder.Configuration.GetSection("Jwt:Audience").Value,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); ;
        }
    }
}
