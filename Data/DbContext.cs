using Microsoft.EntityFrameworkCore;
using YourProjectName.Models;

namespace YourProjectName.Data;

public class ApplicationDbContext : DbContext {
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    
  }

  public DbSet<Item> Items { get; set; }
}

