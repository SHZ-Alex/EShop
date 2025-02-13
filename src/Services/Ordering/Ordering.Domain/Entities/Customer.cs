using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class Customer : Entity<CustomerId>
{
    public required string Email { get; set; }
    public required string Name { get; set; }

    public static Customer Create(CustomerId id, string email, string name)
        => new()
        {
            Id = id,
            Email = email,
            Name = name
        };
}