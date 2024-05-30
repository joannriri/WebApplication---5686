using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BurgerQueen_PACUR12400.Pages.Checkout
{
    public class CheckoutModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext _context;
        [BindProperty]
        public CheckoutDto CheckoutDto { get; set; } = new CheckoutDto();
        public CheckoutModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            _context = context;
        }
        public string errorMessage = "";
        public string successMessage = "";

        [BindProperty]
        public string FullName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string CardName { get; set; }
        [BindProperty]
        public string CardNumber { get; set; }
        [BindProperty]
        public string CVV { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public double CartTotal { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadCartItemsAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCartItemsAsync();
                return Page();
            }
            //save checkout details to db
            UserCheckout userCheckout = new UserCheckout()
            {
                FullName = CheckoutDto.FullName,
                Email = CheckoutDto.Email,
                Address = CheckoutDto.Address,
                CardName = CheckoutDto.CardName,
                CardNumber = CheckoutDto.CardNumber,
                CVV = CheckoutDto.CVV
            };
            _context.UserCheckout.Add(userCheckout);
             await _context.SaveChangesAsync();

            //clear form
            CheckoutDto = new CheckoutDto();
            ModelState.Clear();
            successMessage = "Checkout Saved";

           
            return RedirectToPage("/Index");
        }
        private async Task LoadCartItemsAsync()
        {
            //load cart items from db
            CartItems = await _context.CartItem.Include(ci => ci.Tbl_products).ToListAsync();
            //calc cart total
            foreach (var item in CartItems)
            {
                CartTotal += item.Quantity * item.Tbl_products.Price;
            }
        }
    }
}
