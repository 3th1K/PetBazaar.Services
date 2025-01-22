using Ethik.Utility.Data.Repository;

namespace InventoryService.Domain.Models;

/// <summary>
/// Represents an inventory item, which tracks the stock and details of a product.
/// </summary>
public class Inventory : IBaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the inventory item.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time when the inventory item was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the inventory item was last modified.
    /// </summary>
    public DateTime LastModified { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the inventory item is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product associated with the inventory item.
    /// </summary>
    public string ProductId { get; set; } = null!;

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
    /// Gets a value indicating whether the inventory item has expired.
    /// </summary>
    /// <remarks>
    /// An inventory item is considered expired if its <see cref="ExpirationDate"/> is on or before the current date.
    /// </remarks>
    public bool IsExpired
    {
        get
        {
            return ExpirationDate.HasValue && ExpirationDate.Value.Date <= DateTime.Now.Date;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the inventory item is near its expiration date.
    /// </summary>
    /// <remarks>
    /// An inventory item is considered near expiration if its <see cref="ExpirationDate"/> is within the next 30 days.
    /// </remarks>
    public bool IsNearExpiration
    {
        get
        {
            return ExpirationDate.HasValue &&
                   ExpirationDate.Value.Date > DateTime.Now.Date &&
                   ExpirationDate.Value.Date <= DateTime.Now.AddDays(30).Date;
        }
    }
}