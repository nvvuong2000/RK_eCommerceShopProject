using AutoMapper;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Mapping
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductRequest, Product>().ConstructUsing(i => new Product
            {

                CategoryId = i.CategoryId,

                ProductName = i.ProductName,

                ProviderId = i.ProviderId,

                Description = i.Description,

                Stock = i.Stock,

                UnitPrice = i.UnitPrice,

                Status = i.Status,

                IsNew = i.IsNew,

                DateCreated = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")),

                DateUpated = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")),
            }); ;
            CreateMap<Product, ProductRequest>();
        }
    }
}
