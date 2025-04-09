using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Models.Ordering;
using Web.Services;

namespace Web.Pages
{
    public class OrderListModel
        (IOrderingService orderingService)
        : PageModel
    {
        public IEnumerable<OrderModel> Orders { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            var customerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");

            var response = await orderingService.GetOrdersByCustomer(customerId);
            Orders = response.Orders;

            return Page();
        }
    }
}
