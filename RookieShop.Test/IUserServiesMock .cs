using Moq;
using RookieShop.Backend.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Test
{
    public static class IUserServiesMock
    {
        public static IUserDF UserServices()
        {
            var fileStorageService = Mock.Of<IUserDF>();

            return fileStorageService;
        }
    }
}
