using FluentValidation;

namespace Ordering.Application.Orders.Commands.Delete;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}