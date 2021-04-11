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

namespace Rookie.CustomerSite.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        // GET: ProductController
       
        string Baseurl = "https://localhost:44341/";
       [HttpGet("/product/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            ProductDetailsVM EmpInfo = new ProductDetailsVM();

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                string endpoint = "/api/Product/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {
                   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<ProductDetailsVM>(EmpResponse);
                    return View(EmpInfo);
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


    }
}
