using System.ComponentModel.DataAnnotations;
namespace BurgerQueen_PACUR12400.Model
{
    public class CheckoutDto
    {
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
    }
}
