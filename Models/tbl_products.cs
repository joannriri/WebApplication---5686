using System.ComponentModel.DataAnnotations;
namespace BurgerQueen_PACUR12400.Model
{
    public class tbl_products
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Price { get; set; }
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }

    }
}
