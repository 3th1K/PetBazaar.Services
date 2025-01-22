using FluentValidation;
using InventoryService.Application.Queries;

namespace InventoryService.Application.Validators;

/// <summary>
/// Validates the <see cref="GetInventoriesQuery"/> to ensure it meets the required criteria.
/// </summary>
public class GetInventoriesQueryValidator : AbstractValidator<GetInventoriesQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetInventoriesQueryValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator ensures that the <see cref="GetInventoriesQuery.OrderBy"/> field, if provided, is one of the allowed fields.
    /// </remarks>
    public GetInventoriesQueryValidator()
    {
        // Allowed fields for ordering
        var allowedFields = new[] { "Created", "LastModified", "ProductId", "BatchNumber", "ManufacturingDate", "ExpirationDate", "Quantity", "Location" };

        // Rule for validating the 'OrderBy' field
        RuleFor(query => query.OrderBy)
            .Must(orderBy => string.IsNullOrEmpty(orderBy) || allowedFields.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            .WithMessage(query => $"Invalid 'OrderBy' field '{query.OrderBy}'. Allowed fields are: {string.Join(", ", allowedFields)}");
    }
}