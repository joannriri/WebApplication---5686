using BurgerQueen_PACUR12400.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        public DeleteModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/ProductsPanel");
                return;
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin/ProductsPanel");
                return;
            }

            string imageFullPath = environment.WebRootPath + "/img/" + product.ImageFileName;
            //System.IO.File.Delete(imageFullPath);

            context.Products.Remove(product);
            context.SaveChanges();

            Response.Redirect("/Admin/ProductsPanel");
        }
    }
}
