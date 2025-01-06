namespace InventoryService.Application.Dtos;

public class ProductInventoryDetails
{
    public string ProductId { get; set; } = null!;
    public int TotalQuantityInStock { get; set; }
    public int NonExpiredQuantity { get; set; }
    public int NearExpirationQuantity { get; set; }
    public List<InventoryDetails> InventoryDetails { get; set; } = [];
    public List<InventoryDetails> NonExpiredInventoryDetails { get; set; } = [];
    public List<InventoryDetails> NearExpirationInventoryDetails { get; set; } = [];

    /// <summary>
    /// Creates product inventory object
    /// </summary>
    /// <param name="productId">The product id of the product</param>
    /// <param name="productInventoryList">The inventory list for the given product</param>
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
