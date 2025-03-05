using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public T Id { get; set; } = default!;
}