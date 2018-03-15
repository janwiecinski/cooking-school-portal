using CookingSchool.DAL.Models;
using System;

namespace CookingSchool.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string Author { get; set; }

        public int MealTypeId { get; set; }

        public MealType MealType { get; set; }
    }
}