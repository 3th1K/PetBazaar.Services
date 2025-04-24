using ProductService.Domain.Interfaces;

namespace ProductService.Infrastructure.Services;

public class RabbitMqEventPublisher : IEventPublisher
{
    private readonly IPublisher _publisher;
    public RabbitMqEventPublisher(IPublisher publisher)
    {
        _publisher = publisher;
    }
    public async Task Publish<TEvent>(TEvent @event, string exchangeName, CancellationToken cancellationToken = default) where TEvent : class
    {
        await _publisher.PublishAsync(@event, exchangeName, null, cancellationToken);
    }
}