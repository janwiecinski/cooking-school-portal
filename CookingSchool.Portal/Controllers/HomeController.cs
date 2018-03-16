using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CookingSchool.DAL.Repositories;
using CookingSchool.Models;
using CookingSchool.DAL.Models;
using System.Net;

namespace CookingSchool.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<Recipe> _recipeRepository;

        public HomeController(IRepository<Recipe> recipe)
        {
            _recipeRepository = recipe;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Redirect()
        {
            string url = Url.RouteUrl(
                                    "DefaultApi",
                                     new { httproute = "", controller = "images"}
                            );
            return View("",url);

        }

        [HttpGet]
        public ActionResult ShowResult(string query)
        {
            var recipes = _recipeRepository.GetAll();

            var filterRecipes = recipes.Where(s => s.Title.Contains(query));

            List<RecipeViewModel> recipesViewModel = new List<RecipeViewModel>();

            if (!String.IsNullOrEmpty(query))
            {
                foreach (var recipe in filterRecipes)
                {
                    var viewModel = new RecipeViewModel();

                    viewModel.Title = recipe.Title;
                    viewModel.Id = recipe.Id;
                    recipesViewModel.Add(viewModel);
                }
            }
            return PartialView("ViewResult", recipesViewModel);
        }

        [HttpGet]
        public JsonResult TitleIndex()
        {
            var test = Request;
            var recipes = _recipeRepository.GetAll();

            List<SearchViewModel> recipesViewModel = new List<SearchViewModel>();

            foreach (var recipe in recipes)
            {
                var viewModel = new SearchViewModel();

                viewModel.Title = recipe.Title;

                recipesViewModel.Add(viewModel);
            }
            return Json(recipesViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Error(string message)
        {
            ViewData["error"] = message;
            return View();
        }

      
    }
}
