using Basket.API.Models;

namespace Basket.API.Controllers.Contracts.Requests;

public class StoreBasketRequest
{
    public required string UserName { get; set; }
    public required IList<ShoppingCartItem> Items { get; set; }
}