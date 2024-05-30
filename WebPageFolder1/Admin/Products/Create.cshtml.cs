using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public CreateModel(IWebHostEnvironment environment, AppDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            if(ProductDto.ImageFile == null)
            {
                ModelState.AddModelError("ProductDto.ImageFile", "The image file is required");
            }

            if(!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            //save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/img/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                ProductDto.ImageFile.CopyTo(stream);
            }


            //save new product in db
            tbl_products product = new tbl_products()
            {
                Name = ProductDto.Name,
                Description = ProductDto.Description ?? "",
                Price = ProductDto.Price,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };
            context.Products.Add(product);
            context.SaveChanges();

            //clear the form
            ProductDto.Name = "";
            ProductDto.Description = "";
            ProductDto.Price = 0;
            ProductDto.ImageFile = null;

            ModelState.Clear();

            successMessage = "Product Created Successfully";

            Response.Redirect("/Admin/ProductsPanel");
        }
    }
}
