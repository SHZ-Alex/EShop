using MediatR;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.Events;

public class OrderCreatedEventHandler
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}