using ProductService.Application.Features.Common.Dtos;

namespace ProductService.Application.Features.Food.Dtos;

public class FoodProductDetails : ProductDetails
{
    public string Ingredients { get; set; } = null!;
}