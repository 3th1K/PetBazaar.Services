using Ethik.Utility.Data.Repository;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryService.Infrastructure.Repositories;

public class InventoryRepository : BaseRepository<Inventory, ApplicationDbContext>, IInventoryRepository
{
    public InventoryRepository(IDbContextFactory<ApplicationDbContext> contextFactory, ILogger<InventoryRepository> logger) : base(contextFactory, logger)
    {
    }
}