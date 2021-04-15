using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RookieShop.Backend.Controllers;
using RookieShop.Backend.Models;
using RookieShop.Backend.Services.Interface;
using RookieShop.Shared;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace RookieShop.Test
{
    public class UnitTest1
    {

        private  List<ProductListVM> GetListProductTest()
        {
            var sessions = new List<ProductListVM>();
            sessions.Add(new ProductListVM()
            {

                productID = 3,
                providerID = 3,
                productName = "Sad Story 3",
                unitPrice = 1000,
                categoryId = 4,
                isNew = false,


            });
            sessions.Add(new ProductListVM()
            {

                productID = 4,
                providerID = 3,
                productName = "Sad Story 4",
                unitPrice = 1000,
                categoryId = 4,
                isNew = false,
            });

            return  sessions;
        }
        [Fact]
        public async Task ProductGet_ReturnCountWithAListProduct()
        {
            // Arrange

            var mockUser = new Mock<IUserDF>();
            var mockHosting = new Mock<IHostingEnvironment>();
            var mockProduct = new Mock<IProduct>();
            int expectCount = 2;
            mockProduct.Setup(repo => repo.getListProductAsync()).Returns(Task.FromResult(GetListProductTest()));
            var controller = new ProductController(mockUser.Object, mockProduct.Object, mockHosting.Object);
            // Act
            var result = await controller.GetAsync();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var listProduct = actionResult.Value as List<ProductListVM>;
            Assert.Equal(listProduct.Count(), expectCount);
        }
        [Fact]
        public async Task ProductPost_AddProduct_retrunStatusCode201_whenProductValid()
        {
            // Arrange
            var product = new ProductCreateRequest
            {
                providerID = 5,
                productName = "Sad Story 5",
                unitPrice = 1000,
                categoryID = 4,
                isNew = false,
                status = true,
                stock = 1000,
            };
            var mockUser = new Mock<IUserDF>();
            var mockHosting = new Mock<IHostingEnvironment>();
            var mockProduct = new Mock<IProduct>();
            var controller = new ProductController(mockUser.Object, mockProduct.Object, mockHosting.Object);
            // Act
            var result = await controller.addProduct(product);
            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = result as OkObjectResult;
            var statusCode = okObjectResult.Value;
            Assert.Equal(201, statusCode);

        }
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public async Task ProductsGet_ReturnsProductDetailsWhenGetIdproductExits(int id)
        {
            // Arrange
            var mockUser = new Mock<IUserDF>();
            var mockHosting = new Mock<IHostingEnvironment>();
            var mockProduct = new Mock<IProduct>();
            
            mockProduct.Setup(repo => repo.getProductAsync(id)).ReturnsAsync(GetListProductTest().Select(p => new ProductDetailsVM { Id = p.productID, productName = p.productName }).FirstOrDefault(s => s.Id == id));
            var controller = new ProductController(mockUser.Object, mockProduct.Object, mockHosting.Object);
            // Act
           var result = await controller.Get(id);
            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = okObjectResult.Value as ProductDetailsVM;
            Assert.Equal(id, model.Id);


        }
    

    }
}
