using BurgerQueen_PACUR12400.Data;
using BurgerQueen_PACUR12400.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Web.Helpers;

namespace BurgerQueen_PACUR12400.Pages.Contact
{
    public class ContactModel : PageModel
    { 
      //  private readonly ILogger<ContactModel> logger;
       // public ContactModel(ILogger<ContactModel> logger)
       // {
       //     this.logger = logger;
        //}
        public void OnGet()
        {

        }
        [BindProperty]
        public Email sendmail { get; set; }
        public async Task OnPost()
        {
            string To =sendmail.To;
            string Subject =sendmail.Subject;
            string Body =sendmail.Body;
            MailMessage mm  = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("5686LCB@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("5686LCB@gmail.com", "najzuoujwohohwsi");
            await smtp.SendMailAsync(mm);
            ViewData["Message"] = "The Mail Has Been Sent To " + sendmail.To;
        }
    }
      

}
