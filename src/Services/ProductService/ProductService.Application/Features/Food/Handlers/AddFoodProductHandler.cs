using Ethik.Utility.Common.Extentions;
using Ethik.Utility.Data.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductService.Application.Extensions.Mappings;
using ProductService.Application.Features.Food.Commands;
using ProductService.Domain.Interfaces;

namespace ProductService.Application.Features.Food.Handlers;

public sealed class AddFoodProductHandler : IRequestHandler<AddFoodProductCommand, OperationResult<string>>
{
    private readonly ILogger<AddFoodProductHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;

    public AddFoodProductHandler(ILogger<AddFoodProductHandler> logger, IFoodProductRepository foodProductRepository)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
    }

    public async Task<OperationResult<string>> Handle(AddFoodProductCommand request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        var result = await _foodProductRepository.AddAsync(request.ToFoodProduct(), cancellationToken: cancellationToken);
        return result;
    }
}