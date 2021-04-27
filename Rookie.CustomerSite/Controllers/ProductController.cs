using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Rookie.CustomerSite.Containts;
using Rookie.CustomerSite.Services.BaseServices;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using X.PagedList;

namespace Rookie.CustomerSite.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        // GET: ProductController

        [HttpGet("/product/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            ProductDetailsVM productInfo = new ProductDetailsVM();
            HttpResponseMessage Res = await RequestServices.GetAsync(APIProductEndPoint.Details + id.ToString());
            if (Res.IsSuccessStatusCode)
            {

                var product = Res.Content.ReadAsStringAsync().Result;
                productInfo = JsonConvert.DeserializeObject<ProductDetailsVM>(product);
                return View(productInfo);
            }
            return View();


        }
        [HttpGet("/ratingproductlist")]
        public async Task<IActionResult> Ratings()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APIProductEndPoint.Ratings, accessToken);
            if (Res.IsSuccessStatusCode)
            {

                var cartResponse = await Res.Content.ReadAsAsync<IEnumerable<ProductListVM>>();
                return View(cartResponse);
            }
            TempData["ERROR"] = "ERROR";
            return View();
        }
        // Post
        [HttpPost("/ratingproductlist")]

        public async Task<IActionResult> PostRatings(IFormCollection request)
        {

            var id = Convert.ToInt32(request["id"]);
            var numberRate = Convert.ToInt32(request[$"stars-{id}"]);

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            RatingProductRequest rating = new RatingProductRequest()
            {
                productId = id,
                numberRating = numberRate,
            };
            HttpResponseMessage Res = await RequestServices.PostAsync(APIProductEndPoint.Ratings, accessToken, rating);
            if (Res.IsSuccessStatusCode)
            {
                TempData["RATINGS_SUCESS"] = "RATINGS_SUCESS";
                return View("Ratings");
            }
            else
            {
                TempData["ERROR"] = "ERROR";
                return View("Ratings");
            }

        }



        [AllowAnonymous]
        public async Task<IActionResult> ProductFilter(int? id, string? flag, string? keyword)
        {
            List<ProductListVM> ListProduct = new List<ProductListVM>();
            ViewBag.ListCategory = await getListCategory();

            HttpResponseMessage Res = await RequestServices.GetAsync(APIProductEndPoint.GetList);

            if (Res.IsSuccessStatusCode)
            {
                var ProductsResponse = Res.Content.ReadAsStringAsync().Result;
                ListProduct = JsonConvert.DeserializeObject<List<ProductListVM>>(ProductsResponse);

            }
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                List<ProductListVM> productsListbyCategoryId = ListProduct.Where(x => x.categoryId == id).ToList();
                return View(productsListbyCategoryId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                var productsListbyNameProduct = ListProduct.Where(x => x.productName.ToUpper().Contains(keyword.ToUpper()));
                return View(productsListbyNameProduct);
            }
            if (!string.IsNullOrEmpty(flag))
            {
                switch (flag)
                {
                    case "Desc-Name":
                        var productsListbyDescNameProduct = ListProduct.OrderByDescending(x => x.productName).ToList();
                        return View(productsListbyDescNameProduct);
                    case "Asc-Name":
                        var productsListbyAscNameProduct = ListProduct.OrderBy(x => x.productName).ToList();
                        return View(productsListbyAscNameProduct);
                    case "Desc-Price":
                        var productsListbyDescPrice = ListProduct.OrderByDescending(x => x.unitPrice).ToList();
                        return View(productsListbyDescPrice);
                    case "Asc-Price":
                        var productsListbyAscPrice = ListProduct.OrderBy(x => x.unitPrice).ToList();
                        return View(productsListbyAscPrice);
                    default:
                        var list = ListProduct.ToList();
                        return View(list);
                }

            }
            return View(null);
        }

        [HttpGet("/getAllProducts")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllProduct(int? page)
        {
            List<ProductListVM> ListProduct = new List<ProductListVM>();

            HttpResponseMessage Res = await RequestServices.GetAsync(APIProductEndPoint.GetList);

            if (Res.IsSuccessStatusCode)
            {
                var ProductsResponse = Res.Content.ReadAsStringAsync().Result;
                ListProduct = JsonConvert.DeserializeObject<List<ProductListVM>>(ProductsResponse);

            }
            ViewBag.ListCategory = await getListCategory();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var onePageOfProducts = ListProduct.ToPagedList(pageNumber, pageSize); // will only contain 10 products max because of the pageSize
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();

        }

        [HttpGet("/getListCategory")]
        [AllowAnonymous]
        public async Task<List<Category>> getListCategory()
        {

            HttpResponseMessage Res = await RequestServices.GetAsync(APICategoryEndPoint.GetList);
            if (Res.IsSuccessStatusCode)
            {
                var list = await Res.Content.ReadAsAsync<IEnumerable<Category>>();

                return list.ToList();
            }
            return null;

        }
    }
}
