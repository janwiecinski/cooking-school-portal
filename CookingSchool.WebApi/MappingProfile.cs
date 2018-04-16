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
            CreateMap<Author, EditAuthorViewModel>().ReverseMap();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}