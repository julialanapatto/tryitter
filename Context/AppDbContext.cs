using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.Context
{
  public class AppDbContext : DbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Student>? Students { get; set; }
    public DbSet<Post>? Post { get; set; }
  }
}
