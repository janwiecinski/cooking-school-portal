using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using CookingSchool.DAL.Repositories;
using CookingSchool.DAL.Models;
using CookingSchool.Api.Models;
using CookingSchool.WebApi.Models;
using AutoMapper;
using CookingSchool.WebApi.Utils;

namespace CookingSchool.WebApi.Controllers
{
    [RoutePrefix("recipes")]
    [Authorize]
    public class RecipeController : ApiController
    {
        private IRepository<Recipe> _recipeRepository;
        private IMapper _mapper;

        public RecipeController(IRepository<Recipe> repository, IMapper  mapper)
        {
            _recipeRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [AuthorizeScope("read")]
        public IHttpActionResult GetRecipes()
        {
            var recipes = _recipeRepository.GetAll();

            List<RecipeDto> recipesDto = new List<RecipeDto>();

            _mapper.Map(recipes, recipesDto);

            return Ok(recipesDto);
        }

        [HttpGet]
        [Route("id")]
        [AuthorizeScope("read")]
        [ResponseType(typeof(IngredientDto))]
        public IHttpActionResult GetRecipe(int id)
        {
            var recipes = _recipeRepository.GetAll();

            IngredientDto dto = new IngredientDto();

            var recipe = recipes.FirstOrDefault((p) => p.Id == id);

            _mapper.Map(recipe, dto);

            return Ok(dto);
        }

        [HttpDelete]
        [Route("")]
        [AuthorizeScope("delete")]
        public IHttpActionResult DeleteRecipe(int id)
        {
            var recipe = _recipeRepository.GetById(id);

            _recipeRepository.Delete(recipe);

            return Ok();
        }

        [HttpPost]
        [Route("")]
        [AuthorizeScope("write")]
        public IHttpActionResult PostRecipe(AddRecipeViewModel model)
        {
            var recipe = new Recipe { Title = model.Title, Description = model.Description };

            _recipeRepository.Add(recipe);

            return Ok(recipe);
        }

        [HttpPut]
        [Route("")]
        [AuthorizeScope("write")]
        public IHttpActionResult UpdateRecipe(EditRecipeViewModel model)
        {
            var recipe = _recipeRepository.GetById(model.Id);

            recipe.Title = model.Title;
            recipe.Description = model.Description;

            _recipeRepository.Update(recipe);

            return Ok();
        }
    }
}
