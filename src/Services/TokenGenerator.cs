using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Tryitter.Constants;

namespace Tryitter.Services;

public class TokenGenerator
{
  public string Generate()
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
        SecurityAlgorithms.HmacSha256Signature
      ),
      Expires = DateTime.Now.AddDays(1)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}