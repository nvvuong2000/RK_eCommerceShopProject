using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class OrderController : Controller
    {
        string Baseurl = "https://localhost:44341/";
     
          public async Task<ActionResult> Index()
            {

                Order listOrder = new Order();
                using (var client = new HttpClient())
                {
                    var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                    client.SetBearerToken(accessToken);
                    //Passing service base url  

                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                    string endpoit = "/api/Order";
                    HttpResponseMessage Res = await client.GetAsync(endpoit);
                    Res.EnsureSuccessStatusCode();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {

                        var orderResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the product with id
                        listOrder= JsonConvert.DeserializeObject<Order>(orderResponse);
                    }
                    return View(listOrder);
                }
            }
    }
}
