using Basket.API.Models;
using Common.CQRS;

namespace Basket.API.Busket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand;