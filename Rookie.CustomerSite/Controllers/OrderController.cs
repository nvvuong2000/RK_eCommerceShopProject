using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Rookie.CustomerSite.Containts;
using Rookie.CustomerSite.Services.BaseServices;
using RookieShop.Backend.Models;
using RookieShop.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        public async Task<ActionResult> Index()
        {

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APIOrderEndPoint.GetList, accessToken);

            if (Res.StatusCode.ToString().Equals(HttpStatusCode.Unauthorized.ToString()))
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
                if (Res.IsSuccessStatusCode)
                {
                    var listOrder = await Res.Content.ReadAsAsync<IEnumerable<OrderVm>>();
                    return View(listOrder);

                }
                TempData["ERROR"] = "ERROR";
                return View();
            }
        }
        [HttpGet("/order/{id:int}")]
        public async Task<ActionResult> getOrderbyId(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APIOrderEndPoint.GetOrderDetails + id.ToString(), accessToken);

            if (Res.IsSuccessStatusCode)
            {
                var listOrderDetails = await Res.Content.ReadAsAsync<OrderVm>();

                return View(listOrderDetails);
            }
            else
            {
                TempData["ERROR"] = "ERROR";
                return View();
            }
        }
        [HttpGet("/updateorder/{id:int}")]
        public async Task<IActionResult> updateStatusOrder(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APIOrderEndPoint.UpdateStatusOrder + id.ToString(), accessToken);
            if (Res.IsSuccessStatusCode)
            {

                TempData["UPDATE_STATUS_SUCESS"] = "UPDATE_STATUS_SUCESS";
                return RedirectToAction("Index", "Order");
            }
            TempData["ERROR"] = "ERROR";
            return RedirectToAction("Index", "Order");
        }
    }

}

