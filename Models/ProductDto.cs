using System.ComponentModel.DataAnnotations;
namespace BurgerQueen_PACUR12400.Model
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; } = "";
        
        public string? Description { get; set; } 
        [Required]
        public double Price { get; set; }
        public IFormFile? ImageFile{ get; set; }
    }
}
