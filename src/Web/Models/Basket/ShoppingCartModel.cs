namespace Web.Models.Basket;

public class ShoppingCartModel
{
    public required string UserName { get; set; }
    public List<ShoppingCartItemModel> Items { get; set; } = [];
    public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
}

public class ShoppingCartItemModel
{
    public required int Quantity { get; set; }
    public required string Color { get; set; }
    public required decimal Price { get; set; }
    public required long ProductId { get; set; }
    public required string ProductName { get; set; }
}

public record GetBasketResponse(ShoppingCartModel Cart);
public record StoreBasketRequest(ShoppingCartModel Cart);
public record StoreBasketResponse(string UserName);
