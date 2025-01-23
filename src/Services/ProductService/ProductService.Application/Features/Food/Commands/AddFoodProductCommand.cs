using Ethik.Utility.Data.Results;
using MediatR;
using ProductService.Application.Features.Common.Commands;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Commands;

/// <summary>
/// Represents a command to add a new food product.
/// </summary>
/// <remarks>
/// This command extends <see cref="AddProductCommand"/> to include additional properties specific to food products.
/// </remarks>
public class AddFoodProductCommand : AddProductCommand, IRequest<OperationResult<string>>
{
    /// <summary>
    /// Gets or sets the ingredients of the food product.
    /// </summary>
    public string Ingredients { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddFoodProductCommand"/> class.
    /// </summary>
    /// <param name="request">The request containing the details of the food product to add.</param>
    public AddFoodProductCommand(AddFoodProductRequest request)
    {
        Name = request.Name;
        CategoryId = request.CategoryId;
        Price = request.Price;
        DescriptionShort = request.DescriptionShort;
        DescriptionMedium = request.DescriptionMedium;
        DescriptionLarge = request.DescriptionLarge;
        Ingredients = request.Ingredients;
    }
}