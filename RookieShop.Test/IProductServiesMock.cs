using Moq;
using RookieShop.Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Test
{
    public static class IProductServiesMock
    {
        public static IProduct ProductServices()
        {
            var fileStorageService = Mock.Of<IProduct>();

            return fileStorageService;
        }
    }
}
