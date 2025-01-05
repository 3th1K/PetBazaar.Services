namespace InventoryService.Application.Dtos;

public sealed class AddInventoryRequest
{
    public string ProductId { get; init; } = null!;
    public string BatchNumber { get; init; } = null!;
    public DateTime ManufacturingDate { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public int Quantity { get; init; }
    public string Location { get; init; } = null!;
}
