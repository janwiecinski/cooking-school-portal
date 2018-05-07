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
            ViewData["pass"] = ConfigurationManager.AppSettings["emailPass"];
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
                }
                catch(Exception ex)
                {
                    ModelState.Clear();
                    throw new Exception(ex.ToString());

                }
            }
            return View("About");
        }
    }
}