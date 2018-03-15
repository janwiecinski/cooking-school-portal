using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CookingSchool.DAL.Models;

namespace CookingSchool.DAL.Mappings
{
    public class ImageConfiguration : EntityTypeConfiguration<Image>
    {
        public ImageConfiguration()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.Name).IsRequired().HasMaxLength(100);

            Property(t => t.FullPath).IsRequired().HasMaxLength(250);

            Property(t => t.CreatedOnUtc).IsRequired();

            Property(t => t.ModifiedOnUtc).IsRequired();
        }
    }
}
