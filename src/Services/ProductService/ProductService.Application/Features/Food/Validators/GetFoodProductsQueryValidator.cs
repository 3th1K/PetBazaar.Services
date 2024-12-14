using FluentValidation;
using ProductService.Application.Features.Food.Queries;

namespace ProductService.Application.Features.Food.Validators;

public class GetFoodProductsQueryValidator : AbstractValidator<GetFoodProductsQuery>
{
    public GetFoodProductsQueryValidator()
    {
        // Allowed fields for ordering
        var allowedFields = new[] { "Created", "LastModified", "Name", "Price" };

        RuleFor(query => query.OrderBy)
            .Must(orderBy => string.IsNullOrEmpty(orderBy) || allowedFields.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            .WithMessage(query => $"Invalid 'OrderBy' field '{query.OrderBy}'. Allowed fields are: {string.Join(", ", allowedFields)}");
    }
}