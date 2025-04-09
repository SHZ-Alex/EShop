using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models.Basket;
using Web.Models.Catalog;
using Web.Services;

namespace Web.Pages
{
    public class ProductDetailModel(
        ICatalogService catalogService,
        IBasketService basketService) : PageModel
    {
        public ProductModel Product { get; set; } = null!;

        [BindProperty] public string Color { get; set; } = null!;

        [BindProperty] public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(long productId)
        {
            var response = await catalogService.GetProduct(productId);
            Product = response.Product;

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
                Quantity = Quantity,
                Color = Color
            });

            await basketService.StoreBasket(new StoreBasketRequest(basket));

            return RedirectToPage("Cart");
        }
    }
}