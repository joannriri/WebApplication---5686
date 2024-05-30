using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BurgerQueen_PACUR12400.Pages.Cart
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _context;
        public CartModel(AppDbContext context)
        {
            _context = context;
        }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public double CartTotal { get; set; }

       public void OnGet()
        {
            LoadCartItems();
        }
        public IActionResult OnPostUpdateQuantity(int cartItemId, int change)
        {
            var cartItem = _context.CartItem.FirstOrDefault(ci => ci.Id == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity += change;
                if (cartItem.Quantity < 1) 
                {
                    cartItem.Quantity = 1;
                }
                _context.SaveChanges();
            }
            LoadCartItems();
            return RedirectToPage();
        }
        public IActionResult OnPostRemoveItem(int cartItemId)
        {
            var cartItem = _context.CartItem.FirstOrDefault(ci => ci.Id == cartItemId);
            if (cartItem != null)
            {
                _context.CartItem.Remove(cartItem);
                _context.SaveChanges();
            }
            LoadCartItems();
            return RedirectToPage();
        }
        public IActionResult OnPostClearCart()
        {
            var cartItems = _context.CartItem.ToList();
            _context.CartItem.RemoveRange(cartItems);
            _context.SaveChanges();
            LoadCartItems();
            return RedirectToPage();
        }
        public IActionResult OnPostCheckout()
        {
            return RedirectToPage("/Contact/Checkout/Checkout");
        }
        public IActionResult OnPostAddProduct()
        {
            return RedirectToPage("/Products/Item");
        }
        private void LoadCartItems()
        {
            CartItems = _context.CartItem.Include(ci => ci.Tbl_products).ToList();
            CartTotal = CartItems.Sum(item => item.Quantity * item.Tbl_products.Price);
        }
        
    }
}
