using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models.Basket;
using Web.Services;

namespace Web.Pages
{
    public class CheckoutModel
        (IBasketService basketService)
        : PageModel
    {
        [BindProperty]
        public required BasketCheckoutModel Order { get; set; }

        public required ShoppingCartModel Cart { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasket();

            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            Cart = await basketService.LoadUserBasket();

            if (!ModelState.IsValid)
                return Page();
            
            Order.CustomerId = Guid.NewGuid();
            Order.UserName = Cart.UserName;

            await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}
