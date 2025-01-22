using Ethik.Utility.Data.Repository;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryService.Infrastructure.Repositories;

/// <summary>
/// Represents a repository for managing <see cref="Inventory"/> entities in the database.
/// </summary>
/// <remarks>
/// This repository extends <see cref="BaseRepository{T, TContext}"/> to provide basic CRUD operations
/// for the <see cref="Inventory"/> entity using the <see cref="ApplicationDbContext"/>.
/// </remarks>
public class InventoryRepository : BaseRepository<Inventory, ApplicationDbContext>, IInventoryRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryRepository"/> class.
    /// </summary>
    /// <param name="contextFactory">The factory used to create instances of <see cref="ApplicationDbContext"/>.</param>
    /// <param name="logger">The logger used for logging operations.</param>
    public InventoryRepository(IDbContextFactory<ApplicationDbContext> contextFactory, ILogger<InventoryRepository> logger)
        : base(contextFactory, logger)
    {
    }
}