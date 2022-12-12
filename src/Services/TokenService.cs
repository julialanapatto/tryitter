using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Tryitter.Models;

namespace Tryitter.Services
{
  public class TokenService: IToken
  {
        public string GerarToken(string key, string issuer, string audience, UserModel user)
        // retorna uma strink que é o token desserializado, passa a chave secreta, emissor, audiencia e usuario, implementa geração do token
        {
          var claims = new []
          {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            //claims compoem o payload do token
          };

          var SecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key));

          var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

          var token = new JwtSecurityToken(issuer: issuer, audience: audience, claims: claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

          var tokenHandler = new JwtSecurityTokenHandler();

          var stringToken = tokenHandler.WriteToken(token);

          return stringToken;
        }

  }
}