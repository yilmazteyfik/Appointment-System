using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using Appointment_System_Server.Application.Service;
using Appointment_System_Server.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Appointment_System_Server.Infrastructure.Services;

internal class JwtProvider : IJwtProvider
{
    public string CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim("UserName", user.UserName ?? string.Empty)
        };

        DateTime expires = DateTime.Now.AddDays(1);
        string key = "MySuperSecretKey12345MySuperSecretKey12345MySuperSecretKey123333345"; // En az 64 bayt
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);
            
        JwtSecurityToken jwtSecurityToken = new(
            issuer: "Teyfik Yilmaz",//kim uygulamanin sahibi
            audience: "appointment.com",
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials);
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        string token = handler.WriteToken(jwtSecurityToken);

        return token;
    }
}