using Ordering.Domain.Abstractions;
using Ordering.Domain.Events;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = [];
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
    
    public CustomerId CustomerId { get; set; }
    public OrderName OrderName { get; set; }
    public required Address BillingAddress { get; set; }
    public required Address ShippingAddress { get; set; }
    public required Payment Payment { get; set; }
    public required OrderStatus Status { get; set; }
    
    public decimal OrderTotal
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        set {}
    }

    public static Order Create(OrderId id, CustomerId customerId, OrderName orderName, Address billingAddress,
        Address shippingAddress, Payment payment)
    {
        var order = new Order
        {
            Id = id,
            CustomerId = customerId,
            BillingAddress = billingAddress,
            ShippingAddress = shippingAddress,
            OrderName = orderName,
            Payment = payment,
            Status = OrderStatus.Pending
        };
        
        order.AddDomainEvent(new OrderCreatedEvent(order));
        return order;
    }

    public void Update(OrderName orderName, Address billingAddress,
        Address shippingAddress, Payment payment, OrderStatus status)
    {
        OrderName = orderName;
        BillingAddress = billingAddress;
        ShippingAddress = shippingAddress;
        Payment = payment;
        Status = status;
        
        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void Add(ProductId productId, decimal price, int quantity)
    {
        var orderItem = new OrderItem
        {
            OrderId = Id,
            ProductId = productId,
            Quantity = quantity,
            Price = price
        };
        
        _orderItems.Add(orderItem);
    }

    public void Remove(ProductId productId)
    {
        var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
        
        if (orderItem != null)
            _orderItems.Remove(orderItem);
    }
}