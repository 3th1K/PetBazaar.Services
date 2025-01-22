using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure;

/// <summary>
/// Represents the database context for the InventoryService, used to manage and query inventory data.
/// </summary>
/// <remarks>
/// This context uses an in-memory database for demonstration purposes. It defines a <see cref="DbSet{TEntity}"/>
/// for the <see cref="Inventory"/> entity, which represents the inventory table in the database.
/// </remarks>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Configures the database context to use an in-memory database named "Inventory".
    /// </summary>
    /// <param name="optionsBuilder">The builder used to configure the database context options.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Inventory");
    }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="Inventory"/> entity.
    /// </summary>
    public DbSet<Inventory> Inventories { get; set; }
}