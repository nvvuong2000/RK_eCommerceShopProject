using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using RookieShop.Shared.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
       
        string Baseurl = "https://localhost:44341/";

        //[HttpGet("/product/{name}-{id:int}")]
       [HttpGet("/product/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            Product EmpInfo = new Product();

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
   
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                string endpoit = "/api/Product/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);
                if (Res.IsSuccessStatusCode)
                {
                   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Product>(EmpResponse);
                    return View(EmpInfo);
                }
                return View();
                
            }
        }
        public async Task<ActionResult> Ratings(RatingProductRequest request)
        {
            return View();
        }
    }
}
