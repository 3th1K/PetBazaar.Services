using MassTransit;
using ProductService.Domain.Interfaces;

namespace ProductService.Infrastructure.Services;

/// <summary>
/// Implements the <see cref="IEventPublisher"/> interface using MassTransit to publish domain events.
/// </summary>
public class MassTransitEventPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    /// <summary>
    /// Initializes a new instance of the <see cref="MassTransitEventPublisher"/> class.
    /// </summary>
    /// <param name="publishEndpoint">The MassTransit <see cref="IPublishEndpoint"/> used to publish events.</param>
    public MassTransitEventPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Publishes a domain event using MassTransit.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to publish.</typeparam>
    /// <param name="event">The event to publish.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : class
    {
        await _publishEndpoint.Publish(@event, cancellationToken);
    }
}