using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Tryitter.Models;
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

  // [Theory]
  // [InlineData(1)]
  // public async Task ShouldReturnOkWithId(int id)
  // {
  //   var client = _factory.CreateClient();

  //   var response = await client.GetAsync($"/Student/{id}");

  //   response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  // }


  [Fact]
  public async Task ShoulReturnOkCreateStudent()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      Nome = "Teste",
      Email = "email@email.com",
      Modulo = "Final",
      Status = "Ativo",
      Senha = "secreta"
    };

    var response = await client.PostAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
  }

  // [Fact]
  // public async Task ShoulReturnOkUpdateStudent()
  // {
  //   var client = _factory.CreateClient();

  //   var student = new Student
  //   {
  //     StudentId = 18,
  //     Nome = "Teste",
  //     Email = "email@email.com",
  //     Modulo = "Final",
  //     Status = "Ativo",
  //     Senha = "secreta"
  //   };

  //   var response = await client.PutAsJsonAsync("/Student", student);

  //   response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  // }

  // [Fact]
  // public async Task ShoulReturnBadRequestUpdateStudent()
  // {
  //   var client = _factory.CreateClient();

  //   var student = new Student
  //   {
  //     StudentId = 18,
  //     Nome = "Teste",
  //     Email = "email@email.com",
  //     Modulo = "Final",
  //     Status = "Ativo",
  //     Senha = "secreta"
  //   };

  //   var response = await client.PutAsJsonAsync("/Student", student);

  //   response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
  // }

  // [Theory]
  // [InlineData(1)]
  // public async Task ShouldReturnOkDeleteStudent(int id)
  // {
  //   var client = _factory.CreateClient();

  //   var response = await client.DeleteAsync($"/Student/{id}");

  //   response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  // }

  [Theory]
  [InlineData(0)]
  public async Task ShouldReturnNotFoundDeleteStudent(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.DeleteAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
  }

  // [Theory]
  // [InlineData(1)]
  // public async Task ShouldReturnOkDeleteStudentWithId(int id)
  // {
  //   var client = _factory.CreateClient();

  //   var response = await client.DeleteAsync($"/Student/{id}");

  //   response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  // }

  [Theory]
  [InlineData(0)]
  public async Task ShouldReturnNotFoundDeleteStudentWithId(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.DeleteAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
  }

  [Fact]
  public async Task ShoulReturnOkCreateStudentWithId()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      Nome = "Teste",
      Email = "email@email.com",
      Modulo = "Final",
      Status = "Ativo",
      Senha = "secreta"
    };

    var response = await client.PostAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
  }


  // [Fact]
  // public async Task ShoulReturnOkUpdateStudentWithId()
  // {
  //   var client = _factory.CreateClient();

  //   var student = new Student
  //   {
  //     Nome = "Teste",
  //     Email = "email@email.com",
  //     Modulo = "Final",
  //     Status = "Ativo",
  //     Senha = "secreta"
  //   };

  //   var response = await client.PutAsJsonAsync("/Student", student);

  //   response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  //   response.Content.ReadAsStringAsync().Result.Should().Contain("Nome");
  //   response.Content.ReadAsStringAsync().Result.Should().Contain("Email");
  //   response.Content.ReadAsStringAsync().Result.Should().Contain("Modulo");
  //   response.Content.ReadAsStringAsync().Result.Should().Contain("Status");
  //   response.Content.ReadAsStringAsync().Result.Should().Contain("Senha");
  // }

  //   [Fact]
  //   public async Task ShoulReturnBadRequestUpdateStudentWithId()
  //   {
  //     var client = _factory.CreateClient();

  //     var student = new Student
  //     {
  //       Nome = "Teste",
  //       Email = "email@email.com",
  //       Modulo = "Final",
  //       Status = "Ativo",
  //       Senha = "secreta"
  //     };

  //     var response = await client.PutAsJsonAsync("/Student", student);

  //     response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
  //   }
  //
}

