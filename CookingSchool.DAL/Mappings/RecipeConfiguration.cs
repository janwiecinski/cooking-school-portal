using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CookingSchool.DAL.Models;


namespace CookingSchool.DAL.Mappings
{
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Title).IsRequired().HasMaxLength(100);

            Property(t => t.Description).IsRequired().HasMaxLength(2000);

            Property(t => t.CreatedOnUtc).IsRequired();

            Property(t => t.ModifiedOnUtc).IsRequired();

            Property(t => t.MealTypeId).IsRequired();

            Property(t => t.AuthorId).IsRequired();

            Property(t => t.ImageId).IsOptional();

            HasRequired(t => t.MealType).WithMany(c => c.Recipes).HasForeignKey
                  (t => t.MealTypeId).WillCascadeOnDelete(false);

            HasRequired(t => t.Author).WithMany(c => c.Recipes).HasForeignKey
                  (t => t.AuthorId).WillCascadeOnDelete(false);

            HasOptional(t => t.Image);
        }
    }
}
