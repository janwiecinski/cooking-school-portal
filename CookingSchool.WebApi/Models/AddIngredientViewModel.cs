using System.ComponentModel.DataAnnotations;

namespace CookingSchool.Api.Models
{
    public class AddIngredientViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}