using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; } = null!;

        public void OnGetContact()
        {
            Message = "Your email was sent.";
        }

        public void OnGetOrderSubmitted()
        {
            Message = "Your order submitted successfully.";
        }
    }
}
