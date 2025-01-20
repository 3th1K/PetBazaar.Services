using Ethik.Utility.Data.Repository;
using InventoryService.Domain.Models;

namespace InventoryService.Domain.Interfaces;

public interface IInventoryRepository : IBaseRepository<Inventory>
{
}