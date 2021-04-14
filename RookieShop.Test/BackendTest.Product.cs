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
       
        private List<ProductListVM> GetListProductTest()
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

            return sessions;
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
            var controller = new ProductController(mockUser.Object,mockProduct.Object,mockHosting.Object);
            // Act
            var result = await controller.GetAsync();
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var listProduct = actionResult.Value as List<ProductListVM>;
            Assert.Equal(listProduct.Count(), expectCount);
        }
       

    }
}
