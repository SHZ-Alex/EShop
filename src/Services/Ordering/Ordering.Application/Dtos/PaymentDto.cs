using Ordering.Domain.Entities;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Dtos;

public record PaymentDto(
    Guid OrderId,
    string CardNumber,
    string CardName,
    string Expiration,
    string Cvv,
    int PaymentMethod)
{
    public static Payment MapPayment(PaymentDto paymentDto)
        => new(paymentDto.CardName, paymentDto.CardNumber, 
            paymentDto.Expiration, paymentDto.Cvv, 
            paymentDto.PaymentMethod);

    public static PaymentDto Map(Order order)
        => new(order.Id.Id, order.Payment.CardNumber, 
            order.Payment.CardName, order.Payment.Expiration,
            order.Payment.CVV, order.Payment.PaymentMethod);
}