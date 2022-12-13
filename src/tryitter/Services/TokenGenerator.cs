using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tryitter.Constants;
using Tryitter.Models;

namespace Tryitter.Services;

public class TokenGenerator
{
  public string Generate(Student student)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(student),

      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
        SecurityAlgorithms.HmacSha256Signature
      ),
      Expires = DateTime.Now.AddDays(1)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  private ClaimsIdentity AddClaims(Student student)
  {
    ClaimsIdentity identity = new();
    identity.AddClaim(new Claim("StudentId", student.StudentId.ToString()));
    return identity;
  }
}