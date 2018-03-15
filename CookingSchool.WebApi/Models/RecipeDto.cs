using System;

namespace CookingSchool.WebApi.Models
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }


    }
}