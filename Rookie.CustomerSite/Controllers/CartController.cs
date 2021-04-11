using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using RookieShop.Shared.Repo;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{

   
    public class CartController : Controller
    {
        // GET: CartController

        string Baseurl = "https://localhost:44341/";
        [HttpGet("/cart")]
        [Authorize]
        public async Task<ActionResult> IndexCart()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
             
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);

                string endpoint = "/api/Cart";
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                Res.EnsureSuccessStatusCode();
             
                decimal total = await Total();

                if (Res.IsSuccessStatusCode)
                {

                    var cartResponse = await Res.Content.ReadAsAsync<IEnumerable<CartVM>>();
                    ViewBag.Total = total;
                    return View(cartResponse);
                }
                else
                {
                    return View();
                }
               

            }

        }
        [HttpGet("/cart/add/{id}")]
        public async Task<ActionResult> AddProduct(int id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoint = "/add/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    return View();
                }

               
            }
        }
        
     
        public async Task<ActionResult> Add(IFormCollection form)
        
        {

            int Id = Convert.ToInt32(form["id"]);
            int quantity = Convert.ToInt32(form["quantity"]);
            bool isUpdate = Convert.ToBoolean(form["isUpdate"]);
            

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);

                //var item = new
                //{
                //    id = int.Parse(form["id"]),
                //    quantity = int.Parse(form["quantity"]),
                //    isUpdate  = true,
                //};
                string endpoint = "";
                if (isUpdate == true)
                {
                    endpoint = "/api/Cart/addquantity/" + Id.ToString() + "/number/" + quantity.ToString() + "/isUpdate/true";
                }
                else
                {
                    endpoint = "/api/Cart/addquantity/" + Id.ToString() + "/number/" + quantity.ToString() + "/isUpdate/false";
                }
               
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet("/cart/remove/{id}")]
        public async Task<ActionResult> RemoveItem(int id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoint = "/remove/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<Decimal> Total()
        {

            decimal total = 0;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoint = "/api/Cart/total/";
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {

                    total = await Res.Content.ReadAsAsync<decimal>();

                }
                return total;
            }
        }

        public async Task<IActionResult> Checkout()
        {

            decimal total = 0;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoint = "/api/Cart/checkout";
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Order");

                }
                return RedirectToAction("Index", "Cart");
            }
        }
    }
}
