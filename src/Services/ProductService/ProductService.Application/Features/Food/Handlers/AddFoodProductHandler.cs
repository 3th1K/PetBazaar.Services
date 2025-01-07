using Ethik.Utility.Common.Extentions;
using Ethik.Utility.Data.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetBazaar.Shared.Events;
using ProductService.Application.Extensions.Mappings;
using ProductService.Application.Features.Food.Commands;
using ProductService.Domain.Interfaces;
using System.Text.Json;

namespace ProductService.Application.Features.Food.Handlers;

public sealed class AddFoodProductHandler : IRequestHandler<AddFoodProductCommand, OperationResult<string>>
{
    private readonly ILogger<AddFoodProductHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;
    private readonly IEventPublisher _eventPublisher;

    public AddFoodProductHandler(ILogger<AddFoodProductHandler> logger, IFoodProductRepository foodProductRepository, IEventPublisher eventPublisher)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<OperationResult<string>> Handle(AddFoodProductCommand request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        var result = await _foodProductRepository.AddAsync(request.ToFoodProduct(), cancellationToken: cancellationToken);

        if (result.IsSuccess && result.Data is not null)
        {
            _logger.Information("Food product was added successfully");
            _logger.Property("ProductId", result.Data);
            var @event = new ProductAdded(result.Data);
            _logger.Information("Publishing event @ProductAdded");
            await _eventPublisher.Publish(@event, cancellationToken);
            _logger.Information("Published event @ProductAdded");
        }
        else if(!result.IsSuccess)
        {
            _logger.Error("Failed to add food product");
            _logger.Property("OperationResult", result);
        }
        
        return result;
    }
}