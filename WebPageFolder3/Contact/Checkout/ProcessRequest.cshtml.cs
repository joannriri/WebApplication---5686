using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Contact
{
    public class ProcessRequestModel : PageModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerRequest { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet(bool isSuccessful, string customerName = null, string customerEmail = null, string customerRequest = null, string errorMessage = null)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerRequest = customerRequest;
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
        }
    }
}
