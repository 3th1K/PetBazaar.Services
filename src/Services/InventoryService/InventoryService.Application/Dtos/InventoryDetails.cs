namespace InventoryService.Application.Dtos;

/// <summary>
/// Represents detailed information about an inventory item.
/// </summary>
public class InventoryDetails
{
    /// <summary>
    /// Gets or sets the unique identifier of the inventory item.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the product associated with the inventory item.
    /// </summary>
    public string ProductId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time when the inventory item was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the inventory item was last modified.
    /// </summary>
    public DateTime LastModified { get; set; }

    /// <summary>
    /// Gets or sets the batch number of the inventory item. Defaults to "Unknown" if not specified.
    /// </summary>
    public string BatchNumber { get; set; } = "Unknown";

    /// <summary>
    /// Gets or sets the manufacturing date of the inventory item.
    /// </summary>
    public DateTime ManufacturingDate { get; set; }

    /// <summary>
    /// Gets or sets the expiration date of the inventory item, if applicable.
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the inventory item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the location where the inventory item is stored. Defaults to "Unknown" if not specified.
    /// </summary>
    public string Location { get; set; } = "Unknown";

    /// <summary>
    /// Gets or sets a value indicating whether the inventory item has expired.
    /// </summary>
    public bool IsExpired { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the inventory item is near its expiration date.
    /// </summary>
    public bool IsNearExpiration { get; set; }
}