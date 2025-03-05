using Common.CQRS;
using Ordering.Application.Dtos;
using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.Update;

public record UpdateOrderCommand(OrderDto Order) : ICommand
{
    public static void UpdateMap(Order order, OrderDto orderDto)
    {
        order.Update(new OrderName(orderDto.OrderName),
            AddressDto.MapAddress(orderDto.BillingAddress),
            AddressDto.MapAddress(orderDto.ShippingAddress),
            PaymentDto.MapPayment(orderDto.Payment),
            orderDto.Status);
    }
}