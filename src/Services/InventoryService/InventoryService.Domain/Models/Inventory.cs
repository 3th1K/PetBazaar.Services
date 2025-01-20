using Ethik.Utility.Data.Repository;

namespace InventoryService.Domain.Models;

public class Inventory : IBaseEntity
{
    public string Id { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public bool IsDeleted { get; set; }

    public string ProductId { get; set; } = null!;
    public string BatchNumber { get; set; } = "Unknown";
    public DateTime ManufacturingDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public string Location { get; set; } = "Unknown";

    public bool IsExpired
    {
        get
        {
            return ExpirationDate.HasValue && ExpirationDate.Value.Date <= DateTime.Now.Date;
        }
    }

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