namespace InventoryService.Application.Dtos;

/// <summary>
/// Represents a request to add a new inventory item.
/// </summary>
public sealed class AddInventoryRequest
{
    /// <summary>
    /// Gets or initializes the unique identifier of the product associated with the inventory.
    /// </summary>
    public string ProductId { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the batch number of the inventory item.
    /// </summary>
    public string BatchNumber { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the manufacturing date of the inventory item.
    /// </summary>
    public DateTime ManufacturingDate { get; init; }

    /// <summary>
    /// Gets or initializes the expiration date of the inventory item, if applicable.
    /// </summary>
    public DateTime? ExpirationDate { get; init; }

    /// <summary>
    /// Gets or initializes the quantity of the inventory item.
    /// </summary>
    public int Quantity { get; init; }

    /// <summary>
    /// Gets or initializes the location where the inventory item is stored.
    /// </summary>
    public string Location { get; init; } = null!;
}