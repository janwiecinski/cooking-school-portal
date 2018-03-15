using AutoMapper;
using CookingSchool.DAL.Models;
using CookingSchool.WebApi.Models;

namespace CookingSchool.WebApi
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}