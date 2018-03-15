using CookingSchool.DAL.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;

namespace CookingSchool.DAL
{
    public class CookingContext : DbContext
    {
        public CookingContext() : base("name=CookingSchool")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<MealType> MealTypes { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        
            base.OnModelCreating(modelBuilder);
        }

    }

}
