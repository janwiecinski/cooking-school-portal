using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CookingSchool.DAL.Models;

namespace CookingSchool.DAL.Mappings
{
    public class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name).IsRequired().HasMaxLength(20);

            Property(t => t.Surname).IsRequired().HasMaxLength(120);

            Property(t => t.Job).IsOptional().HasMaxLength(20);

            Property(t => t.City).IsOptional().HasMaxLength(30);

            Property(t => t.Age).IsOptional();

            Property(t => t.CreatedOnUtc).IsRequired();

            Property(t => t.ModifiedOnUtc).IsRequired();
        }
    }
}
