using FluentValidation;

namespace Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull().WithMessage("Please provide valid Basket Id");
        RuleFor(x => x.Dto.UserName).NotEmpty().WithMessage("Please provide username");
    }
}