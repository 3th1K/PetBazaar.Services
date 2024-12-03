using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Models;

namespace ProductService.Infrastructure;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Product");
    }

    public DbSet<FoodProduct> FoodProducts { get; set; }
}