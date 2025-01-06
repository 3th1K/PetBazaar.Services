using InventoryService.Application.Dtos;
using InventoryService.Domain.Models;

namespace InventoryService.Application.Extensions.Mappings;

public static class InventoryMappings
{
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

    public static IEnumerable<InventoryDetails> ToInventoryDetails(this IEnumerable<Inventory> result)
    {
        return result.Select(i => i.ToInventoryDetails());
    }

    public static ProductInventoryDetails ToProductInventoryDetails(this IEnumerable<Inventory> result)
    {
        var list = result.ToList();
        return new ProductInventoryDetails(list[0].ProductId, result.ToInventoryDetails().ToList());
    }
}
