using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Interfaces.MessageBroker;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.Events;

public class OrderCreatedEventHandler(IMessageBrokerService messageBrokerService)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        var orderDto = OrderDto.MapFromOrder(notification.Order);
        await messageBrokerService.PublishOrderCreatedEvent(orderDto, cancellationToken);
    }
}