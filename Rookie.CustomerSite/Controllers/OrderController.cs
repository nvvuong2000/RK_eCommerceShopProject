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

           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                client.SetBearerToken(accessToken);


                string endpoit = "/api/Order";

                HttpResponseMessage Res = await client.GetAsync(endpoit);
                Res.EnsureSuccessStatusCode();

                if (Res.IsSuccessStatusCode)
                {
                    var listOrder = await Res.Content.ReadAsAsync<IEnumerable<Order>>();
                    return View(listOrder);

                }
                return null;
            }
        }
    }
}
