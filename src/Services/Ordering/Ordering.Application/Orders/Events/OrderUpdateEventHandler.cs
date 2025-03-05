using MediatR;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.Events;

public class OrderUpdateEventHandler : INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}