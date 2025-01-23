using Common.CQRS;

namespace Basket.API.Busket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand;