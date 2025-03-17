using Common.Messaging.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Commands.Create;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.MessageBroker.Consumers;

public class BasketEventConsumer(ISender sender) 
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        var command = MapFromMessage(context.Message);
        await sender.Send(command);
    }

    private static CreateOrderCommand MapFromMessage(BasketCheckoutEvent message)
    {
        var address = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine,
            message.Country, message.State, message.ZipCode);
        
        var orderDto = new OrderDto(message.Id, message.CustomerId, message.UserName, 
            address,
            address,
            new PaymentDto(message.Id, message.CardNumber, message.CardName, message.Expiration, message.CVV, message.PaymentMethod),
            OrderStatus.Pending,
            []);
        
        return new CreateOrderCommand(orderDto);
    }
}