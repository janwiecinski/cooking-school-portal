using System;
using System.Collections.Generic;

namespace CookingSchool.DAL.Models
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int MealTypeId { get; set; }
        public virtual MealType MealType { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}