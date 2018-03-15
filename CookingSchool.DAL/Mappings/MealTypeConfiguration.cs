using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CookingSchool.DAL.Models;


namespace CookingSchool.DAL.Mappings
{
    public class MealTypeConfiguration : EntityTypeConfiguration<MealType>
    {
        public MealTypeConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name).IsRequired().HasMaxLength(20);

            Property(t => t.CreatedOnUtc).IsRequired();

            Property(t => t.ModifiedOnUtc).IsRequired();
        }
    }
}
