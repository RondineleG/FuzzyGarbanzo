using FuzzyGarbanzo.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FuzzyGarbanzo.Api.Services;

public class TokenService
{
    public static string CriarToken(Usuario usuario)
    {
        var tokerhandler = new JwtSecurityTokenHandler();
        var chaveCriptografiaEmBytes = Encoding.ASCII.GetBytes(ChaveJwt.ChaveSecreta);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografiaEmBytes), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokerhandler.CreateToken(tokenDescriptor);
        return tokerhandler.WriteToken(token);
    }
}