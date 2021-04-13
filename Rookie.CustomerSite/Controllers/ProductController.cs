using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using X.PagedList;

namespace Rookie.CustomerSite.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        // GET: ProductController
       
        string Baseurl = "https://localhost:44341";
       [HttpGet("/product/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            ProductDetailsVM productInfo = new ProductDetailsVM();

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                string endpoint = "/api/Product/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {
                   
                    var product = Res.Content.ReadAsStringAsync().Result;
                    productInfo = JsonConvert.DeserializeObject<ProductDetailsVM>(product);
                    return View(productInfo );
                }
                return View();
                
            }
        }
        [HttpGet("/ratingproductlist")]
        public async Task<IActionResult> Ratings()
        {
            ProductListVM list = new ProductListVM();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoint = "/rating";
               
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {

                    var cartResponse = await Res.Content.ReadAsAsync<IEnumerable<ProductListVM>>();
                    return View(cartResponse);
                }
              
            }

            return View();
        }
        // Post
        [HttpPost("/ratingproductlist")]
        public async Task<IActionResult> PostRatings(IFormCollection request)
        {
          
            var id = Convert.ToInt32(request["id"]);
            var numberRate = Convert.ToInt32(request[$"stars-{id}"]);
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);

                RatingProductRequest rating = new RatingProductRequest()
                {
                    productId = id,
                    numberRating = numberRate,
                };

                string endpoint = "/rating";

                HttpResponseMessage Res = await client.PostAsJsonAsync(endpoint,rating);
                if (Res.IsSuccessStatusCode)
                {

                    var cartResponse = await Res.Content.ReadAsAsync<IEnumerable<ProductListVM>>();
                    return View(cartResponse);
                }
   
            }

            return View();
        }
       
  
       

        public async Task<IActionResult> ProductFilter(int? id, string? flag, string? keyword)
        {
            List<ProductListVM> ListProduct = new List<ProductListVM>();
            ViewBag.ListCategory = await getListCategory();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);



                HttpResponseMessage Res = await client.GetAsync("/api/Product");

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
                            break;
                        case "Asc-Name":
                            var productsListbyAscNameProduct = ListProduct.OrderBy(x => x.productName).ToList();
                            return View(productsListbyAscNameProduct);
                            break;
                        case "Desc-Price":
                            var productsListbyDescPrice = ListProduct.OrderByDescending(x => x.unitPrice).ToList();
                            return View(productsListbyDescPrice);
                            break;
                        case "Asc-Price":
                            var productsListbyAscPrice = ListProduct.OrderBy(x => x.unitPrice).ToList();
                            return View(productsListbyAscPrice);
                            break;
                        default:
                            var list = ListProduct.ToList();
                            return View(list);
                            break;
                    }


                }

            }

            return View(null);
        }
        [HttpGet("/getAllProducts")]
        public async Task<ActionResult> GetAllProduct(int? page)
        {
            List<ProductListVM> ListProduct = new List<ProductListVM>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/Product");

                if (Res.IsSuccessStatusCode)
                {
                    var ProductsResponse = Res.Content.ReadAsStringAsync().Result;
                    ListProduct = JsonConvert.DeserializeObject<List<ProductListVM>>(ProductsResponse);

                }
                ViewBag.ListCategory = await getListCategory();
                int pageSize = 1;
                int pageNumber = (page ?? 1);
                var onePageOfProducts = ListProduct.ToPagedList(pageNumber, 1); // will only contain 10 products max because of the pageSize
                ViewBag.OnePageOfProducts = onePageOfProducts;
                return View();


            }
        }
        [HttpGet("/getListCategory")]
        public async Task<List<Category>> getListCategory()
        {
            Category cateInfo = new Category();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string endpoint = "/api/Category";
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {

                    var list = await Res.Content.ReadAsAsync<IEnumerable<Category>>();

                    return list.ToList();
                }
                return null;

            }
        }


    }
}
