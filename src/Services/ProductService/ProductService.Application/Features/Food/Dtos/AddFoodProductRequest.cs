using ProductService.Application.Features.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.Features.Food.Dtos;

public sealed class AddFoodProductRequest : AddProductRequest
{
    [Required]
    public string Ingredients { get; init; } = null!;
}