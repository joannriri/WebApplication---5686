using System.ComponentModel.DataAnnotations;
namespace BurgerQueen_PACUR12400.Model
{
    public class tbl_Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
