using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class ProductsPanelModel : PageModel
    {
        private readonly AppDbContext context;
        public List<tbl_products> Products { get; set; } = new List<tbl_products>();
        public ProductsPanelModel(AppDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products = context.Products.ToList();
        }
    }
}
