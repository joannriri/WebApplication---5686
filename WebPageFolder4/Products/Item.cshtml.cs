using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Products
{
    public class ItemModel : PageModel
    {
        private readonly AppDbContext _context;
        public ItemModel(AppDbContext context)
        {
            _context = context;
        }
        public List<tbl_products> Products { get; set; } = new List<tbl_products>();
        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
        public IActionResult OnPostAddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return NotFound();
            }
            //add product to cart
            var cartItem = _context.CartItem.FirstOrDefault(ci => ci.ProductID == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItem = new CartItem
                {
                    ProductID = product.ProductID,
                    Tbl_products = product,
                    Quantity = 1
                };
                _context.CartItem.Add(cartItem);
            }
            _context.SaveChanges();
            return RedirectToPage("/Cart/Cart");
        }
        
       
        
    }
}
