namespace ProductService.Domain.Models;

/// <summary>
/// Represents a food product, which is a specific type of product with additional properties.
/// </summary>
/// <remarks>
/// This class extends the <see cref="Product"/> class to include properties specific to food products.
/// </remarks>
public class FoodProduct : Product
{
    /// <summary>
    /// Gets or sets the ingredients of the food product.
    /// </summary>
    public string Ingredients { get; set; } = null!;
}