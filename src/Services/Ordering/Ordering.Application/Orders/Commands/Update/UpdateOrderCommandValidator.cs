using FluentValidation;

namespace Ordering.Application.Orders.Commands.Update;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order.Id).NotEmpty();
        RuleFor(x => x.Order.OrderName).NotEmpty();
        RuleFor(x => x.Order.CustomerId).NotEmpty();
    }
}