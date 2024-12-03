using MediatR;
using ProductService.Application.Features.Food.Commands;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Extensions.Mappings;

public static class FoodProductMappings
{
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
}