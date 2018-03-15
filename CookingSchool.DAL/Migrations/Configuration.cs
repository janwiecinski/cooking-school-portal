namespace CookingSchool.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<CookingSchool.DAL.CookingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(CookingSchool.DAL.CookingContext context)
        {

            context.MealTypes.AddOrUpdate(
            p => p.Name,
                    new MealType { Id = (int) MealTypeEnum.Breakfast, Name = "Breakfast", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.Lunch, Name = "Lunch", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.Salat, Name = "Salat", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.Noodle, Name = "Noodle", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.MainCourse, Name = "MainCourse", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.Soup, Name = "Soup", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.Supper, Name = "Supper", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow },
                    new MealType { Id = (int) MealTypeEnum.Dessert, Name = "Dessert", CreatedOnUtc = DateTime.UtcNow, ModifiedOnUtc = DateTime.UtcNow }
                );

                context.SaveChanges();
            
        }
    }
}