using Ethik.Utility.Data.Repository;
using ProductService.Domain.Models;

namespace ProductService.Domain.Interfaces;

/// <summary>
/// Represents a repository interface for managing <see cref="FoodProduct"/> entities.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IBaseRepository{T}"/> to provide basic CRUD operations
/// for the <see cref="FoodProduct"/> entity. Additional methods specific to food product management
/// can be defined here if needed.
/// </remarks>
public interface IFoodProductRepository : IBaseRepository<FoodProduct>
{
}