using System.Collections.Generic;

namespace CookingSchool.DAL.Models
{
    public class Author : BaseEntity
    {
        public  string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Job { get; set; }
         
        public string City { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}