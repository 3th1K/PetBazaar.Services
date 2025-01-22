namespace InventoryService.Application.Dtos;

/// <summary>
/// Represents the response returned after successfully adding a new inventory item.
/// </summary>
public class AddInventoryResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly added inventory item.
    /// </summary>
    public string Id { get; set; }
}