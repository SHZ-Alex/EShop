using System.ComponentModel.DataAnnotations;

namespace Ordering.Domain.ValueObjects;

public record Payment(string CardName, string CardNumber, string Expiration, 
    [Length(3, 3)] string CVV, int PaymentMethod);