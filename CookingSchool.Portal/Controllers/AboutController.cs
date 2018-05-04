using CookingSchool.Portal.Models;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;

namespace CookingSchool.Portal.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var str = ConfigurationManager.AppSettings["apiGoogleMap"];
            ViewData["apiGoogle"] = str;
            return View("About");
        }

        [HttpPost]
        public ActionResult SendContactMessage( ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                 string pass = ConfigurationManager.AppSettings["emailPass"];
                
                try
                {

                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(model.Email);

                    msz.To.Add("janwiecinski1985@gmail.com");
                    msz.Subject = model.Subject;
                    msz.Body = model.Message;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential("janwiecinski1985@gmail.com", pass);
                    smtp.EnableSsl = true;
                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Title = "Thank You for Contacting us ";
                    return View("About");
                }
                catch(Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }
            return View("About");
        }
    }
}