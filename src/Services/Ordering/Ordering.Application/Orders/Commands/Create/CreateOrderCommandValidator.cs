using FluentValidation;

namespace Ordering.Application.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order.OrderName).NotEmpty();
        RuleFor(x => x.Order.CustomerId).NotNull();
        RuleFor(x => x.Order.OrderItems).NotEmpty();
    }
}