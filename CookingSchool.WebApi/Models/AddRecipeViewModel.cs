using System.ComponentModel.DataAnnotations;

namespace CookingSchool.WebApi.Models
{
    public class AddRecipeViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

    }
}