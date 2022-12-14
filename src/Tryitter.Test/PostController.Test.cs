using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tryitter.Test;

public class PostControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;

  public PostControllerTest(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
  }

  [Fact]
  public async Task PostShouldReturnOk()
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/Post");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }
}

