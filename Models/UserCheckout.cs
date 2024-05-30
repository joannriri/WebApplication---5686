using System.ComponentModel.DataAnnotations;
namespace BurgerQueen_PACUR12400.Model
{
    public class UserCheckout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string CVV { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<CheckoutItem> CheckoutItems { get; set; } = new List<CheckoutItem>();
    }
}
