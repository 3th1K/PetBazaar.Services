using ProductService.Application.Features.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.Features.Food.Dtos;

/// <summary>
/// Represents a request to add a new food product.
/// </summary>
/// <remarks>
/// This class extends <see cref="AddProductRequest"/> to include additional properties specific to food products.
/// </remarks>
public sealed class AddFoodProductRequest : AddProductRequest
{
    /// <summary>
    /// Gets or initializes the ingredients of the food product.
    /// </summary>
    /// <remarks>
    /// This property is required and must not be null or empty.
    /// </remarks>
    [Required]
    public string Ingredients { get; init; } = null!;
}