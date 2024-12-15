using Ethik.Utility.Data.Repository;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Repositories;

public class InventoryRepository : BaseRepository<Inventory, ApplicationDbContext>, IInventoryRepository
{
    public InventoryRepository(IDbContextFactory<ApplicationDbContext> contextFactory, ILogger<InventoryRepository> logger) : base(contextFactory, logger)
    {
    }
}
