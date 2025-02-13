using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.ValueObjects;

public record OrderName([MinLength(5)] string Value);