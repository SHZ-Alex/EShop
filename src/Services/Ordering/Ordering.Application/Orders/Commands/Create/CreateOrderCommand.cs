using Common.CQRS;
using Ordering.Application.Dtos;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.Create;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderCommandResponse>
{
    public static Order Map(OrderDto order)
    {
        return Domain.Entities.Order.Create(new OrderId(Guid.NewGuid()),
            new CustomerId(order.CustomerId),
            new OrderName(order.OrderName),
            AddressDto.MapAddress(order.BillingAddress),
            AddressDto.MapAddress(order.ShippingAddress),
            PaymentDto.MapPayment(order.Payment));
    }
}