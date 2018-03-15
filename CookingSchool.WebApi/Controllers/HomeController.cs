using System.Web.Mvc;

namespace CookingSchool.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
       

       
    }
}
