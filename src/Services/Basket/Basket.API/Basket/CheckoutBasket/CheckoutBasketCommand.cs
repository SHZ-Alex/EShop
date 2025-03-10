using Common.CQRS;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(CheckoutBasketDto Dto) : ICommand
{
    
}