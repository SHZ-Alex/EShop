using Ordering.Application.Dtos;

namespace Ordering.Application.Interfaces.MessageBroker;

public interface IMessageBrokerService
{
    Task PublishOrderUpdatedEvent(OrderDto order, CancellationToken cancellationToken);
    Task PublishOrderCreatedEvent(OrderDto order, CancellationToken cancellationToken);
}