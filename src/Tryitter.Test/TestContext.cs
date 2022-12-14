using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tryitter.Context;

public class TestContext<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(
              d => d.ServiceType ==
                  typeof(DbContextOptions<AppDbContext>));
      if (descriptor != null)
        services.Remove(descriptor);
      services.AddDbContext<AppDbContext>(options =>
          {
            options.UseInMemoryDatabase("InMemoryQuizTest");
          });
      var sp = services.BuildServiceProvider();
      using (var scope = sp.CreateScope())
      using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
      {
        try
        {
          appContext.Database.EnsureCreated();
        }
        catch (Exception e)
        {
          throw e;
        }
      }
    });
  }
}