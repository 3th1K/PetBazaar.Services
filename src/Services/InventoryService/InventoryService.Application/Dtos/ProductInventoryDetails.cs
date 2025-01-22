namespace InventoryService.Application.Dtos;

/// <summary>
/// Represents detailed information about the inventory of a specific product.
/// </summary>
public class ProductInventoryDetails
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public string ProductId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the total quantity of the product currently in stock across all inventory items.
    /// </summary>
    public int TotalQuantityInStock { get; set; }

    /// <summary>
    /// Gets or sets the total quantity of the product that is not expired.
    /// </summary>
    public int NonExpiredQuantity { get; set; }

    /// <summary>
    /// Gets or sets the total quantity of the product that is near its expiration date.
    /// </summary>
    public int NearExpirationQuantity { get; set; }

    /// <summary>
    /// Gets or sets the list of all inventory details for the product.
    /// </summary>
    public List<InventoryDetails> InventoryDetails { get; set; } = [];

    /// <summary>
    /// Gets or sets the list of inventory details for the product that are not expired.
    /// </summary>
    public List<InventoryDetails> NonExpiredInventoryDetails { get; set; } = [];

    /// <summary>
    /// Gets or sets the list of inventory details for the product that are near their expiration date.
    /// </summary>
    public List<InventoryDetails> NearExpirationInventoryDetails { get; set; } = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductInventoryDetails"/> class.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="productInventoryList">The list of inventory details associated with the product.</param>
    /// <remarks>
    /// This constructor calculates and populates aggregated quantities and filtered lists based on the provided inventory details.
    /// </remarks>
    public ProductInventoryDetails(string productId, List<InventoryDetails> productInventoryList)
    {
        ProductId = productId;
        InventoryDetails = productInventoryList;

        // Filtering inventory lists
        NonExpiredInventoryDetails = productInventoryList.Where(inv => !inv.IsExpired).ToList();
        NearExpirationInventoryDetails = productInventoryList.Where(inv => inv.IsNearExpiration).ToList();

        // Aggregating quantity information
        TotalQuantityInStock = productInventoryList.Sum(inv => inv.Quantity);
        NonExpiredQuantity = NonExpiredInventoryDetails.Sum(inv => inv.Quantity);
        NearExpirationQuantity = NearExpirationInventoryDetails.Sum(inv => inv.Quantity);
    }
}