using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using RookieShop.Shared;
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
        // GET: ProductController/Details/5
        [HttpGet("/product/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            Product EmpInfo = new Product();

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
            
                string endpoit = "/api/Product/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);

                //Checking the response is successful or not which is sent using HttpClient  
                
                if (Res.IsSuccessStatusCode)
                {
                   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the product with id
                    EmpInfo = JsonConvert.DeserializeObject<Product>(EmpResponse);
                    return View(EmpInfo);
                }
                //returning the product to view  
                return View();
                
            }
        }
    }
}
