using AutoMapper;
using CookingSchool.DAL.Models;
using CookingSchool.Models;

namespace CookingSchool.Portal.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeViewModel>();
        }
    }
}