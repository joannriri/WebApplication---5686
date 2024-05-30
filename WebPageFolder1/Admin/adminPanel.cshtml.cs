using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BurgerQueen_PACUR12400.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class adminPanelDashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
