using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models.Basket;
using Web.Services;

namespace Web.Pages
{
    public class CartModel(IBasketService basketService)
        : PageModel
    {
        public ShoppingCartModel Cart { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasket();
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(long productId)
        {
            var cart = await basketService.LoadUserBasket();

            cart.Items.RemoveAll(x => x.ProductId == productId);

            await basketService.StoreBasket(new StoreBasketRequest(cart));

            return RedirectToPage();
        }
    }
}
