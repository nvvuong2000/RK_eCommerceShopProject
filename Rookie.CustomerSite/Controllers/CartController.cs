using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class CartController : Controller
    {
        // GET: CartController

        string Baseurl = "https://localhost:44341/";

        [Authorize]
        public async Task<ActionResult> Index()
        {

            
            using (var client = new HttpClient())
            {

                //Passing service base url  

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  

                string endpoit = "/api/Cart";
                HttpResponseMessage Res = await client.GetAsync(endpoit);
                Res.EnsureSuccessStatusCode();
               //Res.Content.re

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                   var cartResponse = await  Res.Content.ReadAsAsync<IEnumerable<Cart>>();
                    return View(cartResponse);

                    //Deserializing the response recieved from web api and storing into the product with id
                    //  cartItem = JsonConvert.DeserializeObject<Product>(cartResponse);
                }
                return null;
                
            }

            //returning the employee list to view  


        }

        // GET: ProductController/Details/5
        [HttpGet("/cart/add/{id}")]
        public async Task<ActionResult> AddProduct(int id)
        {


            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoit = "/api/Cart/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);
               
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {



                }
                //returning the employee list to view  
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet("/cart/remove/{id}")]
        public async Task<ActionResult> RemoveItem(int id)
        {


            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoit = "/remove/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {



                }
                //returning the employee list to view  
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
