using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using RookieShop.Backend.Models;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        string Baseurl = "https://localhost:44341/";

        public async Task<ActionResult> Index()
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);


                string endpoint = "/api/Order";

                HttpResponseMessage Res = await client.GetAsync(endpoint);


                if (Res.IsSuccessStatusCode)
                {
                    var listOrder = await Res.Content.ReadAsAsync<IEnumerable<OrderVm>>();
                    return View(listOrder);

                }
                else
                {
                    return View();
                }

            }
        }
        [HttpGet("/order/{id:int}")]
        public async Task<ActionResult> getOrderbyId(int id)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);


                string endpoint = "/api/Order/" + id.ToString();

                HttpResponseMessage Res = await client.GetAsync(endpoint);


                if (Res.IsSuccessStatusCode)
                {
                    var listOrderDetails = await Res.Content.ReadAsAsync<OrderVm>();



                    return View(listOrderDetails);

                }
                else
                {
                    return View();
                }

            }
        }
        [HttpGet("/updateorder/{id:int}")]
        public async Task<IActionResult> updateStatusOrder(int id)
        {
            Product EmpInfo = new Product();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);



                string endpoint = "/api/Order/updateSttOrder/" + id.ToString();
                HttpResponseMessage Res = await client.GetAsync(endpoint);
                if (Res.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Order");
                }

                return RedirectToAction("Index", "Order");
            }
        }

    }
}
