using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BurgerQueen_PACUR12400.Model
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual tbl_products Tbl_products { get; set; }
        public int Quantity { get; set; }
    }
}
