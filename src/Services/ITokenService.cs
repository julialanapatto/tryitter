using Tryitter.Models;

namespace Tryitter.Services
{
  public interface IToken
  {
    string GerarToken(string key, string issuer, string audience, UserModel user);
  }
}