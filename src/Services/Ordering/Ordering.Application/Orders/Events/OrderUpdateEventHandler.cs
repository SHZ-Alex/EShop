using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Interfaces.MessageBroker;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.Events;

public class OrderUpdateEventHandler(IMessageBrokerService messageBrokerService) : INotificationHandler<OrderUpdatedEvent>
{
    public async Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var orderDto = OrderDto.MapFromOrder(notification.Order);
        await messageBrokerService.PublishOrderUpdatedEvent(orderDto, cancellationToken);
    }
}