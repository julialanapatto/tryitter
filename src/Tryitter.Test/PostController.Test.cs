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

  [Fact]
  public async Task PostShouldReturnContent()
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/Post");

    response.Content.Should().NotBeNull();
  }

  [Fact]
  public async Task PostShouldReturnContentWithText()
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/Post");

    var content = await response.Content.ReadAsStringAsync();

    content.Should().NotBeNullOrEmpty();
  }

  [Theory]
  [InlineData(1)]
  public async Task PostShouldReturnOkWithId(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync($"/Post/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }

  [Theory]
  [InlineData(1)]
  public async Task PostShouldReturnOkCreatePost(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync($"/Post/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("PostId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Titulo");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Conteudo");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Data");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Autor");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Comentarios");
  }

  [Fact]
  public async Task PostReturnOkUpdatePost()
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/Post");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("PostId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Titulo");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Conteudo");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Data");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Autor");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Comentarios");
  }

  [Fact]
  public async Task PostReturnOkDeletePost()
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync("/Post");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("PostId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Titulo");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Conteudo");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Data");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Autor");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Comentarios");
  }
}

