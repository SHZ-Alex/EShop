using FluentValidation;

namespace Basket.API.Busket.StoreBasket;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Please provide a shopping cart.");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Please provide a user name.");
    }
}