using System.Web.Mvc;
using SATApplication.UI.MVC.Models;

using System.Net;
using System.Net.Mail;

namespace SATApplication.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            // 1. build the body of the email
            string body = $"You have revieved an email from {cvm.Name} at the address {cvm.Email} with a subject of {cvm.Subject}<br>>strong>Message:</strong>{cvm.Message}";

            // 2.instantiate the MainMessage object (needs System.Net.Mail)
            MailMessage msg = new MailMessage("admin@codeweeks.com", "wcoltonweeks@outlook.com", cvm.Subject, body);
            // (optional) customize the MainMessage properties
            msg.IsBodyHtml = true;

            //instantiate the SmtpClient
            SmtpClient client = new SmtpClient("mail.codeweeks.com");

            // 4. provide credentials for the client (needs the System.Net namespace)
            client.Credentials = new NetworkCredential("admin@codeweeks.com", "WZxaw4dh_");

            // 5. attempt to send the email
            try
            {
                client.Send(msg);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = "Sorry, had some trouble with that. see stacktrace or contact an admin." + ex.StackTrace;
            }
            return View("EmailConfirmation", cvm);
        }
    }
}
