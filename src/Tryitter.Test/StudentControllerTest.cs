using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tryitter.Test;


public class StudentControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public StudentControllerTest(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async Task ShouldReturnOk()
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/Student");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }
}

