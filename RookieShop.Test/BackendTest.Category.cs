using Microsoft.AspNetCore.Mvc;
using Moq;
using RookieShop.Backend.Controllers;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Implement;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RookieShop.Test
{
    public class BackendTest: IClassFixture<sqliteInMemoryFixture>
    {
        private readonly sqliteInMemoryFixture _fixture;
        public BackendTest(sqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task UpdateCategory_Success_When_Value_Valid()
        {
            //Arrange
            var dbContext = _fixture.Context;

            Category item = new Category { Id=5, CategoryName = "Short story", CategoryDescription="Short story is ..." };

            await dbContext.Categories.AddAsync(item);
            dbContext.SaveChanges();
            var categoryService = new CategoryRepo(dbContext);

            var categoriesController = new CategoryController(categoryService);

            Category item1 = new Category { Id = 5, CategoryName = "Test" };
            //Act
            
            var result = await categoriesController.Edit(item1);

            //Assert
            var okObjectResult = result.Result as OkObjectResult;

            var resultValue = Assert.IsType<Category>(okObjectResult.Value);

            var value = resultValue as Category;
   
            Assert.Equal(item.CategoryName, value.CategoryName);

            Assert.Equal(item.Id, value.Id);

        }
        [Fact]
        public async Task AddCategory_Success_When_Value_Valid()
        {
            //Arrange
            var dbContext = _fixture.Context;
            
            CategoryRequest item = new CategoryRequest {  CategoryName = "Comic",CategoryDescription="Comic is ..." };

           
            var categoryService = new CategoryRepo(dbContext);
          
            var categoriesController = new CategoryController(categoryService);

            var CountInitial = await categoriesController.Get() ;

            var valueExpect = CountInitial.Count() + 1;
            //Act

            var result = await categoriesController.Create(item);

            //Assert
            var okObjectResult = result.Result as OkObjectResult;

            var valueAfter = await categoriesController.Get();

            var resultValue = Assert.IsType<Category>(okObjectResult.Value);

            Assert.Equal(resultValue.CategoryName, item.CategoryName);

            Assert.Equal(resultValue.CategoryDescription, item.CategoryDescription);

            Assert.Equal(valueExpect, valueAfter.Count());



        }
        [Fact]
        public async Task GetListCategory_Success()
        {
            //Arrange
            var dbContext = _fixture.Context;
            
            var categoryService = new CategoryRepo(dbContext);
           
            var categoriesController = new CategoryController(categoryService);
            //Act
            var result = await categoriesController.Get();
            //Assert
            Assert.NotEmpty(result as IEnumerable<Category>);

        }

    }

    
}

