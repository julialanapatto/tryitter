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

  [Theory]
  [InlineData(1)]
  public async Task ShouldReturnOkWithId(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }

  [Theory]
  [InlineData(0)]
  public async Task ShouldReturnNotFoundWithId(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
  }

  [Theory]
  [InlineData(1)]
  public async Task ShouldReturnOkWithIdAndNameAndAge(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.GetAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("StudentId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Name");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Age");
  }

  [Fact]
  public async task ShoulReturnOkCreateStudent()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      Name = "Teste",
      Age = 20
    };

    var response = await client.PostAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    response.Headers.Location.ToString().Should().Be("http://localhost/Student/3");
  }

  [Fact]
  public async task ShoulReturnBadRequestCreateStudent()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      Name = "Teste",
      Age = 20
    };

    var response = await client.PostAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
  }

  [Fact]
  public async task ShoulReturnOkUpdateStudent()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      StudentId = 1,
      Name = "Teste",
      Age = 20
    };

    var response = await client.PutAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }

  [Fact]
  public async task ShoulReturnBadRequestUpdateStudent()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      StudentId = 1,
      Name = "Teste",
      Age = 20
    };

    var response = await client.PutAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
  }

  [Theory]
  [InlineData(1)]
  public async Task ShouldReturnOkDeleteStudent(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.DeleteAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
  }

  [Theory]
  [InlineData(0)]
  public async Task ShouldReturnNotFoundDeleteStudent(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.DeleteAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
  }

  [Theory]
  [InlineData(1)]
  public async Task ShouldReturnOkDeleteStudentWithId(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.DeleteAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("StudentId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Name");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Age");
  }

  [Theory]
  [InlineData(0)]
  public async Task ShouldReturnNotFoundDeleteStudentWithId(int id)
  {
    var client = _factory.CreateClient();

    var response = await client.DeleteAsync($"/Student/{id}");

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
  }

  [Fact]
  public async task ShoulReturnOkCreateStudentWithId()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      Name = "Teste",
      Age = 20
    };

    var response = await client.PostAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    response.Headers.Location.ToString().Should().Be("http://localhost/Student/3");
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("StudentId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Name");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Age");
  }

  [Fact]
  public async task ShoulReturnBadRequestCreateStudentWithId()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      Name = "Teste",
      Age = 20
    };

    var response = await client.PostAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
  }

  [Fact]
  public async task ShoulReturnOkUpdateStudentWithId()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      StudentId = 1,
      Name = "Teste",
      Age = 20
    };

    var response = await client.PutAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    response.Content.ReadAsStringAsync().Result.Should().Contain("StudentId");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Name");
    response.Content.ReadAsStringAsync().Result.Should().Contain("Age");
  }

  [Fact]
  public async task ShoulReturnBadRequestUpdateStudentWithId()
  {
    var client = _factory.CreateClient();

    var student = new Student
    {
      StudentId = 1,
      Name = "Teste",
      Age = 20
    };

    var response = await client.PutAsJsonAsync("/Student", student);

    response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
  }
}

