using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BurgerQueen_PACUR12400.Model
{
    public class CheckoutItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual tbl_products Tbl_products { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CheckoutId { get; set; }
        [ForeignKey("CheckoutId")]
        public virtual UserCheckout UserCheckout { get; set; }

    }
}
