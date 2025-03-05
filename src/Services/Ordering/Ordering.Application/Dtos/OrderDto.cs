using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Dtos;

public record OrderDto(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems)
{
    public static OrderDto MapFromOrder(Order order)
    {
        return new OrderDto(order.Id.Id, order.CustomerId.Id, order.OrderName.Value, 
            AddressDto.Map(order.ShippingAddress), AddressDto.Map(order.BillingAddress),
            PaymentDto.Map(order), order.Status, OrderItemDto.MapFromOrder(order));
    }
}