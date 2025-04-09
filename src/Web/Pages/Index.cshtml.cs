using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models.Basket;
using Web.Models.Catalog;
using Web.Services;

namespace Web.Pages;
public class IndexModel
    (ICatalogService catalogService, IBasketService basketService)
    : PageModel
{
    public IEnumerable<ProductModel> ProductList { get; set; } = [];   

    public async Task<IActionResult> OnGetAsync()
    {
        var result = await catalogService.GetProducts();
        ProductList = result.Products;
        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(long productId)
    {
        var productResponse = await catalogService.GetProduct(productId);

        var basket = await basketService.LoadUserBasket();

        basket.Items.Add(new ShoppingCartItemModel
        {
            ProductId = productId,
            ProductName = productResponse.Product.Name,
            Price = productResponse.Product.Price,
            Quantity = 1,
            Color = "Black"
        });

        await basketService.StoreBasket(new StoreBasketRequest(basket));
        return RedirectToPage("Cart");
    }    
}
