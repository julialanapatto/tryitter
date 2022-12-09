using Microsoft.EntityFrameworkCore;
using Tryitter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tryitter.Context
{
  //  Aula 155:
  public class AppDbContext : IdentityDbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Student>? Students { get; set; }
    public DbSet<Post>? Post { get; set; }
  }
}
