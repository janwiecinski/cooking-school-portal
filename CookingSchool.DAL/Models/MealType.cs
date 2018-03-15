using System.Collections.Generic;

//http://stackoverflow.com/questions/34557574/how-to-create-a-table-corresponding-to-enum-in-ef6-code-first
namespace CookingSchool.DAL.Models
{
    public class MealType : BaseEntity
    {
        private MealType(MealTypeEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public MealType() { } //For EF

        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public static implicit operator MealType(MealTypeEnum @enum) => new MealType(@enum);
        
        //public static implicit operator MealTypeEnum(MealType faculty) => (MealTypeEnum)faculty.Id;
    }

    public enum MealTypeEnum
    {
        Breakfast = 1,
        Lunch = 2,
        Supper = 3,
        Dessert = 4,
        Soup = 5,
        MainCourse = 6,
        Noodle = 7,
        Salat = 8
    }
}
//var recipe = GetRecipe(5);
//recipe.MealType - enum