namespace InventoryService.Application.Dtos;

public class InventoryDetails
{
    public string Id { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public string BatchNumber { get; set; } = "Unknown";
    public DateTime ManufacturingDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; } = "Unknown";
    public bool IsExpired { get; set; }
    public bool IsNearExpiration { get; set; }
}