using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rookie.CustomerSite.Models;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Hosted web API REST Service base url  
        string Baseurl = "https://localhost:44341/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("/")]
        public async Task<ActionResult> Index()
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
                return View(ListProduct);
            }
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
