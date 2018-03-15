using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CookingSchool.DAL.Models;

namespace CookingSchool.DAL.Mappings
{
    public class IngredientConfiguration: EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name).IsRequired().HasMaxLength(30);

            Property(t => t.CreatedOnUtc).IsOptional();

            Property(t => t.ModifiedOnUtc).IsOptional();

            Property(t => t.ImageId).IsOptional();

            HasMany(t => t.Recipes).WithMany(c => c.Ingredients).Map(t => t.ToTable("RecipeIngredient")
                .MapLeftKey("IngredientId")
                .MapRightKey("RecipeId"));

            HasOptional(t => t.Image);
        }
    }
}
