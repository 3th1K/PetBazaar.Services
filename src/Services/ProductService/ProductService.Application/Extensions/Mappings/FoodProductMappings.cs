using ProductService.Application.Features.Food.Commands;
using ProductService.Application.Features.Food.Dtos;
using ProductService.Domain.Models;

namespace ProductService.Application.Extensions.Mappings;

/// <summary>
/// Provides extension methods for mapping between domain models and DTOs related to food products.
/// </summary>
public static class FoodProductMappings
{
    /// <summary>
    /// Maps an <see cref="AddFoodProductCommand"/> to a <see cref="FoodProduct"/> domain model.
    /// </summary>
    /// <param name="command">The <see cref="AddFoodProductCommand"/> to map.</param>
    /// <returns>A <see cref="FoodProduct"/> domain model containing the mapped data.</returns>
    public static FoodProduct ToFoodProduct(this AddFoodProductCommand command)
    {
        return new FoodProduct
        {
            CategoryId = command.CategoryId,
            Name = command.Name,
            Price = command.Price,
            DescriptionShort = command.DescriptionShort,
            DescriptionMedium = command.DescriptionMedium,
            DescriptionLarge = command.DescriptionLarge,
            Ingredients = command.Ingredients
        };
    }

    /// <summary>
    /// Maps a <see cref="FoodProduct"/> domain model to a <see cref="FoodProductDetails"/> DTO.
    /// </summary>
    /// <param name="result">The <see cref="FoodProduct"/> domain model to map.</param>
    /// <returns>A <see cref="FoodProductDetails"/> DTO containing the mapped data.</returns>
    public static FoodProductDetails ToFoodProductDetails(this FoodProduct result)
    {
        return new FoodProductDetails
        {
            Id = result.Id,
            Created = result.Created,
            LastModified = result.LastModified,
            CategoryId = result.CategoryId,
            Name = result.Name,
            Price = result.Price,
            DescriptionShort = result.DescriptionShort,
            DescriptionMedium = result.DescriptionMedium,
            DescriptionLarge = result.DescriptionLarge,
            Ingredients = result.Ingredients
        };
    }

    /// <summary>
    /// Maps a collection of <see cref="FoodProduct"/> domain models to a collection of <see cref="FoodProductDetails"/> DTOs.
    /// </summary>
    /// <param name="result">The collection of <see cref="FoodProduct"/> domain models to map.</param>
    /// <returns>A collection of <see cref="FoodProductDetails"/> DTOs containing the mapped data.</returns>
    public static IEnumerable<FoodProductDetails> ToFoodProductDetails(this IEnumerable<FoodProduct> result)
    {
        return result.Select(foodProduct => foodProduct.ToFoodProductDetails());
    }
}