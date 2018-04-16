using CookingSchool.DAL.Models;
using CookingSchool.DAL.Repositories;
using CookingSchool.Portal.Controllers;
using CookingSchool.Portal.Utils;
using Moq;
using AutoMapper;
using Xunit;
using CookingSchool.Models;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using CookingSchool.Portal.Models;
using CookingSchool.Portal.Providers;

namespace CookingSchool.Tests
{
    public class RecipesControllerTests
    {
        public class WhenDetailsIsCalled : RecipesControllerTests
        {
            private RecipesController _controller;
            private Mock<IMapper> _mapperMock;
            private Mock<IRepository<Recipe>> _recipeRepositoryMock;
            private Mock<IRepository<MealType>> _mealTypeRepositoryMock;
            private Mock<IRepository<Author>> _authorRepositoryMock;
            private Mock<IImageManager> _imageManagerMock;

            public WhenDetailsIsCalled()
            {
                _recipeRepositoryMock = new Mock<IRepository<Recipe>>();
                _mealTypeRepositoryMock = new Mock<IRepository<MealType>>();
                _authorRepositoryMock = new Mock<IRepository<Author>>();
                _imageManagerMock = new Mock<IImageManager>();
                _mapperMock = new Mock<IMapper>();

                _controller = new RecipesController(_recipeRepositoryMock.Object,
                                                    _mealTypeRepositoryMock.Object,
                                                    _authorRepositoryMock.Object,
                                                    _imageManagerMock.Object,
                                                    _mapperMock.Object);
            }

            [Fact]
            public void ItShouldReturnCorrectView()
            {
                var recipe = new Recipe { Id = 2, Author = new Author(), AuthorId = 1, CreatedOnUtc = DateTime.Now, Description = "d", Image = new Image(), ImageId = 1, Ingredients = new List<Ingredient>(), MealType = new MealType(), MealTypeId = 2, ModifiedOnUtc = DateTime.Now, Title = "d" };
                _recipeRepositoryMock.Setup(r => r.GetById(2)).Returns(recipe).Verifiable();

                var result = _controller.Details(2) as ViewResult;

                Assert.Equal("Details", result.ViewName);
            }

            [Fact]
            public void ItShouldPassCorrectViewModelToView()
            {
                var model = new RecipeViewModel { Author = new Author(), AuthorId = 1, CreatedOnUtc = DateTime.Now, Description = "d", Id = 2, ImageId = 1, MealType = new MealType(), MealTypeId = 2, Title = "d" };
                var recipe = new Recipe { Id = 2, Author = new Author(), AuthorId = 1, CreatedOnUtc = DateTime.Now, Description = "d", Image = new Image(), ImageId = 1, Ingredients = new List<Ingredient>(), MealType = new MealType(), MealTypeId = 2, ModifiedOnUtc = DateTime.Now, Title = "d" };
                _recipeRepositoryMock.Setup(r => r.GetById(2)).Returns(recipe).Verifiable();
                _mapperMock.Setup(m => m.Map<Recipe, RecipeViewModel>(It.IsAny<Recipe>())).Returns(model);

                var result = _controller.Details(2) as ViewResult;

                Assert.Equal(model, result.ViewData.Model);
            }

            [Fact]
            public void ItShouldCallRecipeRepositoryOnce()
            {
                var recipe = new Recipe { Id = 2, Author = new Author(), AuthorId = 1, CreatedOnUtc = DateTime.Now, Description = "d", Image = new Image(), ImageId = 1, Ingredients = new List<Ingredient>(), MealType = new MealType(), MealTypeId = 2, ModifiedOnUtc = DateTime.Now, Title = "d" };
                _recipeRepositoryMock.Setup(r => r.GetById(2)).Returns(recipe);

                var result = _controller.Details(2) as ViewResult;

                _recipeRepositoryMock.Verify(x => x.GetById(2), Times.Once);
            }

            [Fact]
            public void ItShouldCallAutoMapperOnce()
            {
                var model = new RecipeViewModel { Author = new Author(), AuthorId = 1, CreatedOnUtc = DateTime.Now, Description = "d", Id = 2, ImageId = 1, MealType = new MealType(), MealTypeId = 2, Title = "d" };
                var recipe = new Recipe { Id = 2, Author = new Author(), AuthorId = 1, CreatedOnUtc = DateTime.Now, Description = "d", Image = new Image(), ImageId = 1, Ingredients = new List<Ingredient>(), MealType = new MealType(), MealTypeId = 2, ModifiedOnUtc = DateTime.Now, Title = "d" };
                _recipeRepositoryMock.Setup(r => r.GetById(2)).Returns(recipe);
                _mapperMock.Setup(m => m.Map<Recipe, RecipeViewModel>(recipe)).Returns(model);

                var result = _controller.Details(2) as ViewResult;

                _mapperMock.Verify(m => m.Map<Recipe, RecipeViewModel>(recipe), Times.Once);
            }

            [Fact]
            public void ItShouldReturnNotFoundResult()
            {
                Recipe recipe = null;
                _recipeRepositoryMock.Setup(r => r.GetById(0)).Returns(recipe);

                var result = _controller.Details(0);

                Assert.IsType<HttpNotFoundResult>(result);
            }
        }

        public class WhenRecipesListIsCalled : RecipesControllerTests
        {
            private RecipesController _controller;
            private Mock<IRepository<Recipe>> _recipeRepositoryMock;
            private Mock<IRepository<MealType>> _mealTypeRepositoryMock;
            private Mock<IRepository<Author>> _authorRepositoryMock;
            private Mock<IImageManager> _imageManagerMock;
            private IMapper _iMapper;

            public WhenRecipesListIsCalled()
            {
                _iMapper = new MapperProvider().GetMapper();

                _recipeRepositoryMock = new Mock<IRepository<Recipe>>();
                _mealTypeRepositoryMock = new Mock<IRepository<MealType>>();
                _authorRepositoryMock = new Mock<IRepository<Author>>();
                _imageManagerMock = new Mock<IImageManager>();
                _controller = new RecipesController(_recipeRepositoryMock.Object,
                                                    _mealTypeRepositoryMock.Object,
                                                    _authorRepositoryMock.Object,
                                                    _imageManagerMock.Object,
                                                    _iMapper);
            }

            [Fact]
            public void ItShouldReturnCorrectView()
            {
                var recipeList = new List<Recipe>
                {
                    new Recipe{Id = 1, Title="recipe1"},
                    new Recipe{Id = 2, Title="recipe2"},
                    new Recipe{Id = 3, Title="recipe3"}

                };
                _recipeRepositoryMock.Setup(x => x.GetAll()).Returns(recipeList.AsQueryable);

                var result = _controller.RecipesList(2) as ViewResult;

                Assert.Equal("RecipesList", result.ViewName);
            }

            [Fact]
            public void ItShouldReturnCorrectRecipesForFirstPage()
            {
                var recipes = new List<Recipe>
                {
                    new Recipe{Id = 1, Title="recipe1"},
                    new Recipe{Id = 2, Title="recipe2"},
                    new Recipe{Id = 3, Title="recipe3"}

                };
                _recipeRepositoryMock.Setup(x => x.GetAll()).Returns(recipes.AsQueryable);
                var recipesViewModel = _iMapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipes);
                var pager = new Pager(recipesViewModel.Count(), 1);
                var viewModel = new PaginationViewModel
                {
                    Items = recipesViewModel.ToList(),
                    Pager = pager
                };

                var result = _controller.RecipesList(1) as ViewResult;
                var paginationViewModel = (PaginationViewModel)result.ViewData.Model;

                foreach(var item in recipesViewModel)
                {
                    Assert.Contains(paginationViewModel.Items, r => r.Id == item.Id);
                }
                Assert.True(paginationViewModel.Items.Count() == 3);
                Assert.Contains(paginationViewModel.Items, r => r.Title == recipes[0].Title);
            }

            [Fact]
            public void ItShouldReturnCorrectRecipesForSubsequentPages()
            {
                var recipes = new List<Recipe>();
                for (int i = 1; i<15; i++)
                {
                    recipes.Add(new Recipe { Id = i, Title = "Recipe_"+i});
                }
                _recipeRepositoryMock.Setup(x => x.GetAll()).Returns(recipes.AsQueryable);
                var recipeViewModelList = _iMapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipes);
                var pager = new Pager(recipeViewModelList.Count(), 2);
                var viewModel = new PaginationViewModel
                {
                    Items = recipeViewModelList.Skip((pager.CurrentPage -1)*pager.PageSize).Take(pager.PageSize).ToList(),
                    Pager = pager
                };

                var result = _controller.RecipesList(2) as ViewResult;
                var paginationModel = (PaginationViewModel)result.Model;

                Assert.Collection(paginationModel.Items, 
                                    item => Assert.Equal(11, item.Id),
                                    item => Assert.Equal(12, item.Id),
                                    item => Assert.Equal(13, item.Id),
                                    item => Assert.Equal(14, item.Id)
                                    );
            }
        }
    }
}
