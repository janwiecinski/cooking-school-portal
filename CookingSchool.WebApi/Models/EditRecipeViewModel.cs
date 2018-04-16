using System.ComponentModel.DataAnnotations;

namespace CookingSchool.WebApi.Models
{
    public class EditRecipeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}