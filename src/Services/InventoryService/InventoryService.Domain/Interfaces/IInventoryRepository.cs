using Ethik.Utility.Data.Repository;
using InventoryService.Domain.Models;

namespace InventoryService.Domain.Interfaces;

/// <summary>
/// Represents a repository interface for managing <see cref="Inventory"/> entities.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IBaseRepository{T}"/> to provide basic CRUD operations
/// for the <see cref="Inventory"/> entity. Additional methods specific to inventory management
/// can be defined here if needed.
/// </remarks>
public interface IInventoryRepository : IBaseRepository<Inventory>
{
}