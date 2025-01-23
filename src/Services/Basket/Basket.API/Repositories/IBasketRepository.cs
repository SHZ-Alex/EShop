using Basket.API.Models;

namespace Basket.API.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken);
    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken);
    Task DeleteBasket(string userName, CancellationToken cancellationToken);
}