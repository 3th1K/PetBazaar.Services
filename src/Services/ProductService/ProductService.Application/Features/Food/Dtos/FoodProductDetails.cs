using ProductService.Application.Features.Common.Dtos;

namespace ProductService.Application.Features.Food.Dtos;

/// <summary>
/// Represents detailed information about a food product.
/// </summary>
/// <remarks>
/// This class extends <see cref="ProductDetails"/> to include additional properties specific to food products.
/// </remarks>
public class FoodProductDetails : ProductDetails
{
    /// <summary>
    /// Gets or sets the ingredients of the food product.
    /// </summary>
    public string Ingredients { get; set; } = null!;
}