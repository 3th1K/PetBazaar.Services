using Ethik.Utility.Common.Extentions;
using Ethik.Utility.CQRS;
using Ethik.Utility.Data.Results;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared.Events;
using ProductService.Application.Extensions.Mappings;
using ProductService.Application.Features.Food.Commands;
using ProductService.Domain.Interfaces;
using PetBazaar.Shared.Constants;
namespace ProductService.Application.Features.Food.Handlers;

/// <summary>
/// Handles the <see cref="AddFoodProductCommand"/> to add a new food product.
/// </summary>
public sealed class AddFoodProductHandler : IRequestHandler<AddFoodProductCommand, OperationResult<string>>
{
    private readonly ILogger<AddFoodProductHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;
    private readonly IEventPublisher _eventPublisher;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddFoodProductHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging operations.</param>
    /// <param name="foodProductRepository">The repository used to manage food product data.</param>
    /// <param name="eventPublisher">The event publisher used to publish domain events.</param>
    public AddFoodProductHandler(ILogger<AddFoodProductHandler> logger, IFoodProductRepository foodProductRepository, IEventPublisher eventPublisher)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
        _eventPublisher = eventPublisher;
    }

    /// <summary>
    /// Handles the <see cref="AddFoodProductCommand"/> to add a new food product.
    /// </summary>
    /// <param name="request">The command containing the details of the food product to add.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="OperationResult{T}"/> containing the unique identifier of the added food product if successful,
    /// or an error response if the operation fails.
    /// </returns>
    public async Task<OperationResult<string>> Handle(AddFoodProductCommand request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        var result = await _foodProductRepository.AddAsync(request.ToFoodProduct(), cancellationToken: cancellationToken);

        if (result.IsSuccess && result.Data is not null)
        {
            _logger.Information("Food product was added successfully");
            _logger.Property("ProductId", result.Data);

            // Publish a ProductAdded event
            var @event = new ProductAdded(result.Data);
            _logger.Information("Publishing event @ProductAdded");
            await _eventPublisher.Publish(@event, MessagingConstants.InventoryExchange,cancellationToken);
            _logger.Information("Published event @ProductAdded");
        }
        else if (!result.IsSuccess)
        {
            _logger.Error("Failed to add food product");
            _logger.Property("OperationResult", result);
        }

        return result;
    }
}