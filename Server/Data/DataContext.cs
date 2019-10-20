using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options) {}

    public DbSet<Home> Homes { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
