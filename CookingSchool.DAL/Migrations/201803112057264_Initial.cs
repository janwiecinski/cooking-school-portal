namespace CookingSchool.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 120),
                        Age = c.Int(),
                        Job = c.String(maxLength: 20),
                        City = c.String(maxLength: 30),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ModifiedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        MealTypeId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        ImageId = c.Int(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ModifiedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .ForeignKey("dbo.Image", t => t.ImageId)
                .ForeignKey("dbo.MealType", t => t.MealTypeId)
                .Index(t => t.MealTypeId)
                .Index(t => t.AuthorId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        FullPath = c.String(nullable: false, maxLength: 250),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ModifiedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ImageId = c.Int(),
                        CreatedOnUtc = c.DateTime(),
                        ModifiedOnUtc = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.MealType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ModifiedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IngredientId, t.RecipeId })
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "MealTypeId", "dbo.MealType");
            DropForeignKey("dbo.RecipeIngredient", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngredient", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Recipe", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Recipe", "AuthorId", "dbo.Author");
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeId" });
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientId" });
            DropIndex("dbo.Ingredient", new[] { "ImageId" });
            DropIndex("dbo.Recipe", new[] { "ImageId" });
            DropIndex("dbo.Recipe", new[] { "AuthorId" });
            DropIndex("dbo.Recipe", new[] { "MealTypeId" });
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.MealType");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Image");
            DropTable("dbo.Recipe");
            DropTable("dbo.Author");
        }
    }
}
