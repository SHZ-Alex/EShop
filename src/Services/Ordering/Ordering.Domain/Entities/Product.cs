using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class Product : Entity<ProductId>
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }

    public static Product Create(ProductId id, decimal price, string name)
        => new()
        {
            Id = id,
            Name = name,
            Price = price
        };
}