using Tryitter.Entities;
using Tryitter.Services;

namespace TryitterTest
{
  public class TokenTest
  {
    [Theory]
    [InlineData("julia@trybe.com", "senhajulia")]
    public void TestTokenGeneratorSuccess(string email, string password)
    {
      Student student = new() { Email = email, Password = password };
      TokenGenerator token = new();
      string response = token.Generate(student);
      response.Should().NotBeNull();
    }

    [Theory]
    [InlineData("klecianny@trybe.com", "senhaklecianny")]
    public void TestTokenGeneratorKeySuccess(string email, string password)
    {
      Student student = new() { Email = email, Password = password };
      var token = new TokenGenerator().Generate(student);
      var validTokenFormat = token.Split('.');
      Assert.Equal(3, validTokenFormat.Length);
    }
  }
}