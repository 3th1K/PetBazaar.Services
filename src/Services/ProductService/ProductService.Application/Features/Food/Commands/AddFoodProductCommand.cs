using Ethik.Utility.Data.Results;
using MediatR;
using ProductService.Application.Features.Common.Commands;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Commands;

public class AddFoodProductCommand : AddProductCommand, IRequest<OperationResult<string>>
{
    public string Ingredients { get; set; } = null!;

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