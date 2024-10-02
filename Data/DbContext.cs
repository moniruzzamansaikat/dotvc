using Microsoft.EntityFrameworkCore;
using YourProjectName.Models;

namespace YourProjectName.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Item>().HasData(
      new Item { Id = 12, Name = "Item 1", Price = 100, Description = "Description 1", SerialNumberId = 1, CategoryId = 1 }
    );

    modelBuilder.Entity<SerialNumber>().HasData(
        new SerialNumber { Id = 1, Number = "123456", ItemId = 12 }
    );

    modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "Category 1", Description = "Description 1" }
    );

    modelBuilder.Entity<Item>().HasOne(i => i.Category).WithMany().HasForeignKey(i => i.CategoryId);
    modelBuilder.Entity<Item>().HasOne(i => i.SerialNumber).WithOne().HasForeignKey<Item>(i => i.SerialNumberId);

    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Item> Items { get; set; }

  public DbSet<SerialNumber> SerialNumbers { get; set; }

  public DbSet<Category> Categories { get; set; }
}

