using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CookingSchool.Models;
using CookingSchool.DAL.Models;
using CookingSchool.Portal.Models;
using CookingSchool.DAL.Repositories;
using System.Collections.Generic;
using CookingSchool.Portal.Utils;
using AutoMapper;
using System;

namespace CookingSchool.Portal.Controllers
{
    [RoutePrefix("recipes")]
    public class RecipesController : Controller
    {
        private IMapper _mapper;
        private IRepository<Recipe> _repository;
        private IRepository<MealType> _mealRepository;
        private IRepository<Author> _authorRepository;
        private IImageManager _imageManager;

        public RecipesController(IRepository<Recipe> repository, IRepository<MealType> mealRepository,
            IRepository<Author> authorRepository, IImageManager imageManager, IMapper mapper)
        {
            _imageManager = imageManager;
            _repository = repository;
            _mealRepository = mealRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public ActionResult RecipesList(int? page)
        {
            var recipes = _repository.GetAll();
            var recipesViewModel = _mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipes);

            var pager = new Pager(recipesViewModel.Count(), page);

            var viewModel = new PaginationViewModel
            {
                Items = recipesViewModel.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager
            };

            return View("RecipesList", viewModel);
        }

        // GET: Recipes
        public ActionResult Index(int? page)
        {
            var recipes = _repository.GetAll();

            var recipesViewModel = new List<RecipeViewModel>();

            foreach (var item in recipes)
            {
                var recipeViewModel = _mapper.Map<Recipe, RecipeViewModel>(item);

                recipesViewModel.Add(recipeViewModel);

            }
            var pager = new Pager(recipesViewModel.Count(), page);

            var viewModel = new PaginationViewModel { Items = recipesViewModel, Pager = pager };

            return View(viewModel);
        }

        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            var recipe = _repository.GetById(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }
            var modelViewRecipe = _mapper.Map<Recipe, RecipeViewModel>(recipe);

            return View("Details", modelViewRecipe);
        }

        //[Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            AuthorListFill();
            MealTypeFill();

            var modelViewRecipe = new RecipeViewModel();

            return View(modelViewRecipe);
        }

        [HttpPost]
        public ActionResult Create(RecipeViewModel model)
        {
            return View("CreateImage");
        }

        [HttpPost]
        public ActionResult CreateImage(RecipeViewModel model)
        {
            var recipe = _mapper.Map<RecipeViewModel, Recipe>(model);

            _repository.Add(recipe);

            return RedirectToAction("Index");
        }

        // GET: Recipes/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mealTypes = _mealRepository.GetAll();
            var authors = _authorRepository.GetAll();

            var recipe = _repository.GetById(id);

            var thisAuthor = recipe.Author.Id;
            var theMealType = (from m in mealTypes
                               where m.Id == recipe.MealType.Id
                               select m.Id).First();

            if (recipe == null)
            {
                return HttpNotFound();
            }

            var authorList = new List<SelectListItem>();

            foreach (var item in authors)
            {
                var text = item.Surname + " " + item.Name;
                var value = item.Id;
                authorList.Add(new SelectListItem { Text = text, Value = value.ToString() });
            }

            ViewData["MealType"] = new SelectList(mealTypes, "Id", "Name", theMealType);
            ViewData["Author"] = new SelectList(authorList, "Value", "Text", thisAuthor);

            var modelViewRecipe = _mapper.Map<Recipe, RecipeViewModel>(recipe);

            return View(modelViewRecipe);
        }

        [HttpPost]
        [Route("{Id}")]
        public ActionResult Edit(RecipeViewModel model)
        {

            var recipe = _mapper.Map<RecipeViewModel, Recipe>(model);

            recipe.ModifiedOnUtc = DateTime.UtcNow;
            recipe.CreatedOnUtc = DateTime.UtcNow;

            _repository.Update(recipe);

            return View("Details", model);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var recipe = _repository.GetById(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var recipe = _repository.GetById(id);
            _repository.Delete(recipe);
            return RedirectToAction("Index");
        }

        public void AuthorListFill()
        {
            var authors = _authorRepository.GetAll();

            var authorList = new List<SelectListItem>();

            foreach (var item in authors)
            {
                var text = item.Surname + " " + item.Name;
                var value = item.Id;
                authorList.Add(new SelectListItem { Text = text, Value = value.ToString() });
            }

            ViewData["Author"] = authorList;
        }

        public void MealTypeFill()
        {
            var mealTypes = _mealRepository.GetAll();

            ViewData["MealType"] = new SelectList(mealTypes, "Id", "Name");
        }
    }
}
