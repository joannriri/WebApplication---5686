using Microsoft.AspNetCore.Identity;

namespace BurgerQueen_PACUR12400.Model
{
    public class tbl_appuser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime DateCreated { get; set; }
    }
}
