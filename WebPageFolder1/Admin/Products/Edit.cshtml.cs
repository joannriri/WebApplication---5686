using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public tbl_products Product { get; set; } = new tbl_products();
        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment environment, AppDbContext context) 
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if(id == null) 
            {
                Response.Redirect("/Admin/ProductsPanel");
                return;
            }

            var product = context.Products.Find(id);
            if(product == null) 
            {
                Response.Redirect("/Admin/ProductsPanel");
                return;
            }
            ProductDto.Name = product.Name;
            ProductDto.Description = product.Description;
            ProductDto.Price = product.Price;

            Product = product;
        }

        public void OnPost(int? id) 
        {
            if(id == null) 
            {
                Response.Redirect("/Admin/ProductsPanel");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin/ProductsPanel");
                return;
            }

            //update image file if have new img file
            string newFileName = product.ImageFileName;
            if (ProductDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProductDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/img/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    ProductDto.ImageFile.CopyTo(stream);
                }

                //delete old img
                string oldImageFullPath = environment.WebRootPath + "/img/" + product.ImageFileName;
                //System.IO.File.Delete(oldImageFullPath);
            }

            //update the product in db
            product.Name = ProductDto.Name;
            product.Description = ProductDto.Description ?? "";
            product.Price = ProductDto.Price;
            product.ImageFileName = newFileName;

            context.SaveChanges();

            Product = product;
            successMessage = "Product updated successfully";
            Response.Redirect("/Admin/ProductsPanel");
        }
    }
}
