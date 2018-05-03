using CookingSchool.Portal.Models;
using System.Web.Mvc;

namespace CookingSchool.Portal.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View("About");
        }

        public ActionResult SendContactMessage( ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}