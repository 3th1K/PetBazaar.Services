using Ethik.Utility.Data.Results;
using MediatR;
using ProductService.Application.Features.Food.Commands;
using ProductService.Application.Features.Food.Dtos;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    public static IEnumerable<FoodProductDetails> ToFoodProductDetails(this IEnumerable<FoodProduct> result)
    {
        return result.Select(foodProduct => foodProduct.ToFoodProductDetails());
    }
}