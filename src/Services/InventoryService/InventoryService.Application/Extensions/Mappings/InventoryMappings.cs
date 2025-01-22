using InventoryService.Application.Dtos;
using InventoryService.Domain.Models;

namespace InventoryService.Application.Extensions.Mappings;

/// <summary>
/// Provides extension methods for mapping between domain models and DTOs related to inventory.
/// </summary>
public static class InventoryMappings
{
    /// <summary>
    /// Maps an <see cref="Inventory"/> domain model to an <see cref="InventoryDetails"/> DTO.
    /// </summary>
    /// <param name="result">The <see cref="Inventory"/> domain model to map.</param>
    /// <returns>An <see cref="InventoryDetails"/> DTO containing the mapped data.</returns>
    public static InventoryDetails ToInventoryDetails(this Inventory result)
    {
        return new InventoryDetails
        {
            Id = result.Id,
            Created = result.Created,
            LastModified = result.LastModified,
            ProductId = result.ProductId,
            BatchNumber = result.BatchNumber,
            ManufacturingDate = result.ManufacturingDate,
            ExpirationDate = result.ExpirationDate,
            Quantity = result.Quantity,
            Location = result.Location,
            IsExpired = result.IsExpired,
            IsNearExpiration = result.IsNearExpiration,
        };
    }

    /// <summary>
    /// Maps a collection of <see cref="Inventory"/> domain models to a collection of <see cref="InventoryDetails"/> DTOs.
    /// </summary>
    /// <param name="result">The collection of <see cref="Inventory"/> domain models to map.</param>
    /// <returns>A collection of <see cref="InventoryDetails"/> DTOs containing the mapped data.</returns>
    public static IEnumerable<InventoryDetails> ToInventoryDetails(this IEnumerable<Inventory> result)
    {
        return result.Select(i => i.ToInventoryDetails());
    }

    /// <summary>
    /// Maps a collection of <see cref="Inventory"/> domain models to a <see cref="ProductInventoryDetails"/> DTO.
    /// </summary>
    /// <param name="result">The collection of <see cref="Inventory"/> domain models to map.</param>
    /// <returns>A <see cref="ProductInventoryDetails"/> DTO containing aggregated and mapped data.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input collection is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the input collection is empty or contains items with mismatched product IDs.</exception>
    public static ProductInventoryDetails ToProductInventoryDetails(this IEnumerable<Inventory> result)
    {
        // Ensure the input collection is not null
        if (result == null)
        {
            throw new ArgumentNullException(nameof(result), "The input collection cannot be null.");
        }

        // Convert the collection to a list for further processing
        var list = result.ToList();

        // Ensure the collection is not empty
        if (list.Count == 0)
        {
            throw new InvalidOperationException("The input collection cannot be empty.");
        }

        // Ensure all items in the collection belong to the same product
        var firstProductId = list[0].ProductId;
        if (list.Any(inventory => inventory.ProductId != firstProductId))
        {
            throw new InvalidOperationException("All items in the collection must belong to the same product.");
        }

        // Map the collection to ProductInventoryDetails
        return new ProductInventoryDetails(firstProductId, list.ToInventoryDetails().ToList());
    }
}