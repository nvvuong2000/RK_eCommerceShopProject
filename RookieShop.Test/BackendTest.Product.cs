using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using RookieShop.Backend.Controllers;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Implement;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace RookieShop.Test
{
    [Collection("ProjectCollection")]
    public class UnitTest1 : IClassFixture<sqliteInMemoryFixture>
    {
        private readonly sqliteInMemoryFixture _fixture;

        private IHostingEnvironment _hostingEnv;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitTest1(sqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();

        }
        [Fact]
        public async Task Get_List_Product()
        {

            //Arrange
            var dbContext = _fixture.Context;

            dbContext.Products.Add(new Product { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book", IsNew = true, Status = true, });

            dbContext.SaveChanges();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var _repoUser = IUserServiesMock.UserServices();

            var productRepo = new ProductRepo(dbContext, _repoUser, _hostingEnv, configuration);

            var productController = new ProductController(productRepo);

            var expected = 1;

            //Act

            var result = await productController.GetAsync();

            //Assert
            var resultValue = Assert.IsType<OkObjectResult>(result.Result);

            Assert.NotEmpty(resultValue.Value as IEnumerable<ProductListVM>);

            var productList = resultValue.Value as IEnumerable<ProductListVM>;

            var countProductList = productList.Count();

            Assert.Equal(countProductList, expected);
        }
        [Fact]
        public async Task Add_Product_When_Value_Valid()
        {
            //Arrange
            var dbContext = _fixture.Context;

            dbContext.Products.Add(new Product { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book", IsNew = true, Status = true, });

            dbContext.SaveChanges();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var _repoUser = IUserServiesMock.UserServices();

            var productRepo = new ProductRepo(dbContext, _repoUser, _hostingEnv, configuration);

            var productController = new ProductController(productRepo);
            var expected = true;
            IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a image file")), 0, 0, "img", "imageBook1.png");

            IFormFile file2 = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a image file")), 0, 0, "img", "imageBook1-2.png");

            List<IFormFile> list = new List<IFormFile>();
            
            list.Add(file);
           
            list.Add(file2);

            //Act
            var result = productController.addProduct(new ProductRequest { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book", IsNew = true, Status = true, FormFiles = list });

            //Assert
            var resultValue = Assert.IsType<OkObjectResult>(result.Result);

            Assert.True(resultValue.Value.Equals(true));
        }
       
        [Fact]
        public async Task Update_Product_When_Value_Valid()
        {
            var dbContext = _fixture.Context;


            dbContext.Products.Add(new Product { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book", IsNew = true, Status = true, });

            dbContext.SaveChanges();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var _repoUser = IUserServiesMock.UserServices();

            var productRepo = new ProductRepo(dbContext, _repoUser, _hostingEnv, configuration);

            var productController = new ProductController(productRepo);

            var expected = true;

            var result = productController.Put(new ProductRequest { ProductId = 1, ProductName = "Book 1", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book", IsNew = true, Status = true, });

            var resultValue = Assert.IsType<OkObjectResult>(result.Result);

            Assert.True(resultValue.Value.Equals(expected));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Get_Product_By_ID__When_ID_Valid(int id)
        {
            //Arrange
            var dbContext = _fixture.Context;


            dbContext.Products.Add(new Product { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book 1", IsNew = true, Status = true, });
            dbContext.Products.Add(new Product { ProductName = "Book 3", Stock = 13, CategoryId = 3, ProviderId = 3, UnitPrice = 500, Description = "new book 2", IsNew = true, Status = true, });
            dbContext.SaveChanges();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var _repoUser = IUserServiesMock.UserServices();

            var productRepo = new ProductRepo(dbContext, _repoUser, _hostingEnv, configuration);

            var productController = new ProductController(productRepo);
            
            //Act

            var result = productController.Get(id);

            //Assert
            var resultValue = Assert.IsType<OkObjectResult>(result.Result.Result);

            var product = resultValue.Value as ProductDetailsVM;

            Assert.True(product.Id.Equals(id));
        }

        [Theory]
        [InlineData("Book 2")]
        public async Task Search_Product_By_Name(string keyword)
        {
            //Arrange
            var dbContext = _fixture.Context;
            dbContext.Products.Add(new Product { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book 1", IsNew = true, Status = true, });
            dbContext.Products.Add(new Product { ProductName = "Book 3", Stock = 13, CategoryId = 3, ProviderId = 3, UnitPrice = 500, Description = "new book 2", IsNew = true, Status = true, });
            dbContext.SaveChanges();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var _repoUser = IUserServiesMock.UserServices();

            var productRepo = new ProductRepo(dbContext, _repoUser, _hostingEnv, configuration);

            var productController = new ProductController(productRepo);
            //Act
            var result = productController.search(keyword);

            //Assert
            var resultValue = Assert.IsType<OkObjectResult>(result.Result.Result);

            var product = resultValue.Value as List<Product> ;

           Assert.Equal(product[0].ProductName, keyword);
        }
        [Theory]
        [InlineData("Booook")]
        [InlineData("Booook1111111")]
        public async Task Seach_Product_by_Name_When_KeyWord_NotExits_in_ProductList(string keyword)
        {
            //Arrange
            var dbContext = _fixture.Context;
            dbContext.Products.Add(new Product { ProductName = "Book 2", Stock = 3, CategoryId = 3, ProviderId = 3, UnitPrice = 1000, Description = "new book 1", IsNew = true, Status = true, });
            dbContext.Products.Add(new Product { ProductName = "Book 3", Stock = 13, CategoryId = 3, ProviderId = 3, UnitPrice = 500, Description = "new book 2", IsNew = true, Status = true, });
            dbContext.SaveChanges();

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var _repoUser = IUserServiesMock.UserServices();

            var productRepo = new ProductRepo(dbContext, _repoUser, _hostingEnv, configuration);

            var productController = new ProductController(productRepo);
            //Act

            var result = productController.search(keyword);

            //Assert
            var resultValue = Assert.IsType<OkObjectResult>(result.Result.Result);

            var product = resultValue.Value as List<Product>;

            Assert.Equal(product.Count(),0);
        }
    }
}


