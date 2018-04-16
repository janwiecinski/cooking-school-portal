using CookingSchool.DAL.Models;
using System;
using System.Collections.Generic;

namespace CookingSchool.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime ModifiedOnUtc { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int MealTypeId { get; set; }

        public MealType MealType { get; set; }
    }
}