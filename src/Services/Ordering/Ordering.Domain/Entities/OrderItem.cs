using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class OrderItem : Entity<OrderItemId>
{
    public required OrderId OrderId { get; set; }
    public required ProductId ProductId { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
}