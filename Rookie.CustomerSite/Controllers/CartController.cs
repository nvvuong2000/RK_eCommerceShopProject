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

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
             
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);

                string endpoit = "/api/Cart";
                HttpResponseMessage Res = await client.GetAsync(endpoit);
                Res.EnsureSuccessStatusCode();
             
                decimal total = await Total();

                if (Res.IsSuccessStatusCode)
                {

                    var cartResponse = await Res.Content.ReadAsAsync<IEnumerable<Cart>>();
                    ViewBag.Total = total;
                    return View(cartResponse);
                }
                return null;

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
                string endpoit = "/api/Cart/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);
         
                return RedirectToAction("Index", "Cart");
            }
        }
        [HttpGet("/cart/add/{id}/{id}")]
        public async Task<ActionResult> Add(int id, int productId)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);
                string endpoit = "/api/Cart/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);

                return RedirectToAction("Index", "Cart");
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
                string endpoit = "/remove/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoit);
                if (Res.IsSuccessStatusCode)
                {

                }
                return RedirectToAction("Index", "Cart");
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
                string endpoit = "/api/Cart/total/";
                HttpResponseMessage Res = await client.GetAsync(endpoit);
                if (Res.IsSuccessStatusCode)
                {

                    total = await Res.Content.ReadAsAsync<decimal>();

                }
                return total;
            }
        }
    }
}
