using Ordering.Domain.Entities;

namespace Ordering.Application.Dtos;

public record OrderItemDto(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal Price)
{
    public static List<OrderItemDto> MapFromOrder(Order order)
        => order.OrderItems
            .Select(x => new OrderItemDto(x.OrderId.Id, x.ProductId.Id, x.Quantity, x.Price))
            .ToList();
}