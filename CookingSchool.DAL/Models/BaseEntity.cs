using System;
using System.ComponentModel.DataAnnotations;

namespace CookingSchool.DAL.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime ModifiedOnUtc { get; set; }
    }
}
