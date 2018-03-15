using System.Collections.Generic;

namespace CookingSchool.DAL.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}