using Ethik.Utility.Api.Validation;
using ProductService.Application.Features.Food.Queries;

namespace ProductService.Application.Features.Food.Validators;

/// <summary>
/// Validates the <see cref="GetFoodProductsQuery"/> to ensure it meets the required criteria.
/// </summary>
public class GetFoodProductsQueryValidator : Validator<GetFoodProductsQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetFoodProductsQueryValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the <see cref="GetFoodProductsQuery.OrderBy"/> field, if provided, is one of the allowed fields.
    /// </remarks>
    public GetFoodProductsQueryValidator()
    {
        // Allowed fields for ordering
        var allowedFields = new[] { "Created", "LastModified", "Name", "Price" };

        // Rule for validating the 'OrderBy' field
        AddRules(rule =>
        {
            rule.RuleFor(query => query.OrderBy)
            .Must(orderBy => string.IsNullOrEmpty(orderBy) || allowedFields.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            .WithMessage(query => $"Invalid 'OrderBy' field '{query.OrderBy}'. Allowed fields are: {string.Join(", ", allowedFields)}");
        });
       
    }
}