using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Models;

namespace ProductService.Infrastructure;

/// <summary>
/// Represents the database context for the ProductService, used to manage and query product data.
/// </summary>
/// <remarks>
/// This context uses an in-memory database for demonstration purposes. It defines a <see cref="DbSet{TEntity}"/>
/// for the <see cref="FoodProduct"/> entity, which represents the food products table in the database.
/// </remarks>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Configures the database context to use an in-memory database named "Product".
    /// </summary>
    /// <param name="optionsBuilder">The builder used to configure the database context options.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Product");
    }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="FoodProduct"/> entity.
    /// </summary>
    public DbSet<FoodProduct> FoodProducts { get; set; }
}