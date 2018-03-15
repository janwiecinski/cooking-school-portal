using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CookingSchool.DAL.Repositories;
using CookingSchool.WebApi.Models;
using CookingSchool.Api.Models;
using CookingSchool.DAL.Models;
using AutoMapper;
using CookingSchool.WebApi.Utils;
using System.Threading.Tasks;

namespace CookingSchool.WebApi.Controllers
{   
    [Authorize]
    [RoutePrefix("ingredients")]
    public class IngredientController : ApiController
    {
        private IRepository<Ingredient> _ingredientRepository;

        private IMapper _mapper;

        private IImageManager _imageManager;

        public IngredientController(IRepository<Ingredient> repository, IMapper mapper, IImageManager imageManager)
        {
            _ingredientRepository = repository;
            _mapper = mapper;
            _imageManager = imageManager;
        }

        [AuthorizeScope("read")]
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var ingredients = _ingredientRepository.GetAll();

            var ingredientsDtos = new List<IngredientDto>();

            _mapper.Map(ingredients, ingredientsDtos);

            return Ok(ingredientsDtos);
        }

        [AuthorizeScope("read")]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetIngredient(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);

            if (ingredient == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            IngredientDto ingredientDto = new IngredientDto();

            _mapper.Map(ingredient, ingredientDto);

            return Ok(ingredientDto);
        }

        [AuthorizeScope("write")]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(AddIngredientViewModel model)
        {
            var ingredient = new Ingredient { Name = model.Name };

            _ingredientRepository.Add(ingredient);

            return Json(ingredient.Id);
        }

        [AuthorizeScope("delete")]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);

            if (ingredient.Recipes.Any())
            {
                return Content(System.Net.HttpStatusCode.Conflict,
                    $"Cannot remove ingredient id {id} because it is used in recipies.");
            }

            _ingredientRepository.Delete(ingredient);

            return Ok("Ingredient has been removed successfully");
        }

        [AuthorizeScope("write")]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(EditIngredientViewModel model)
        {
            var ingredient = _ingredientRepository.GetById(model.Id);

            ingredient.Name = model.Name;

            _ingredientRepository.Update(ingredient);

            return Ok($"You have updated {ingredient.Name}");
        }

        [HttpPost]
        [Route("{id}/images")]
        public async Task<IHttpActionResult> UploadIngredientImage(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);

            var image = (await _imageManager.UploadImages(Request)).FirstOrDefault();

            if (image != null)
            {
                ingredient.ImageId = image.Id;

                _ingredientRepository.Update(ingredient);

                return Ok(new FineUploaderResponseViewModel { success = true });
            }

            return BadRequest();
        }
    }
}