using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Inventory");
    }

    public DbSet<Inventory> Inventories { get; set; }
} 