using System.ComponentModel.DataAnnotations;

namespace CookingSchool.WebApi.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Job { get; set; }
    }
}