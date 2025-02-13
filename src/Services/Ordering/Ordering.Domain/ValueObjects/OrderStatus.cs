namespace Ordering.Domain.ValueObjects;

public enum OrderStatus
{
    Draft = 1,
    Pending,
    Completed,
    Cancelled
}

public static class OrderStatusExtensions
{
    public static string ToStringEnum(this OrderStatus orderStatus)
        => orderStatus switch
        {
            OrderStatus.Draft => nameof(OrderStatus.Draft),
            OrderStatus.Pending => nameof(OrderStatus.Pending),
            OrderStatus.Completed => nameof(OrderStatus.Completed),  
            OrderStatus.Cancelled => nameof(OrderStatus.Cancelled),
            _ => throw new ArgumentOutOfRangeException(nameof(orderStatus), orderStatus, null)
        };
}