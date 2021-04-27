using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Rookie.CustomerSite.Containts;
using Rookie.CustomerSite.Services.BaseServices;
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
    [Authorize]

    public class CartController : Controller
    {
        // GET: CartController

        [HttpGet("/cart")]

        public async Task<ActionResult> IndexCart()
        {

            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            HttpResponseMessage Res = await RequestServices.GetAsync(APICartEndPoint.GetList, accessToken);

            if (Res.StatusCode.ToString().Equals(HttpStatusCode.Unauthorized.ToString()))
            {
                return RedirectToAction("SignIn", "Account");
            }
            else
            {
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
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            HttpResponseMessage Res = await RequestServices.GetAsync(APICartEndPoint.InsertToCart + id.ToString(), accessToken);

            if (Res.IsSuccessStatusCode)
            {
                TempData["ADD_SUCESS"] = "ADD_SUCESS";

                return RedirectToAction("IndexCart", "Cart");
            }
            else
            {
                TempData["ERROR_ADD_ITEM"] = "";
                return RedirectToAction("Index", "Home");
            }
        }


        public async Task<ActionResult> Add(IFormCollection form)
        {
            int Id = Convert.ToInt32(form["id"]);
            int quantity = Convert.ToInt32(form["quantity"]);
            bool isUpdate = Convert.ToBoolean(form["isUpdate"]);

            string endpoint = "";
            if (isUpdate == true)
            {
                endpoint = "Cart/addquantity/" + Id.ToString() + "/number/" + quantity.ToString() + "/isUpdate/true";
            }
            else
            {
                endpoint = "Cart/addquantity/" + Id.ToString() + "/number/" + quantity.ToString() + "/isUpdate/false";
            }
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(endpoint, accessToken);
            if (Res.IsSuccessStatusCode)
            {

                TempData["UPDATE_SUCESS"] = "UPDATE_SUCESS";
                return RedirectToAction("IndexCart", "Cart");
            }
            else
            {
                TempData["ERROR_ADD_ITEM"] = "";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet("/cart/remove/{id}")]
        public async Task<ActionResult> RemoveItem(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APICartEndPoint.DeleteFromCart + id.ToString(), accessToken);
            if (Res.IsSuccessStatusCode)
            {
                TempData["REMOVE_SUCESS"] = "REMOVE_SUCESS";
                return RedirectToAction("IndexCart", "Cart");
            }
            else
            {
                TempData["ERROR"] = "ERROR";
                return View();
            }

        }

        public async Task<Decimal> Total()
        {
            decimal total = 0;
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APICartEndPoint.Total, accessToken);
            if (Res.IsSuccessStatusCode)
            {
                total = await Res.Content.ReadAsAsync<decimal>();

            }
            return total;
        }
        [HttpGet("/checkout")]
        public async Task<IActionResult> Checkout()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpResponseMessage Res = await RequestServices.GetAsync(APICartEndPoint.Checkout, accessToken);
            if (Res.IsSuccessStatusCode)
            {
                TempData["CHECKOUT_SUCESS"] = "CHECKOUT_SUCESS";
                return RedirectToAction("Index", "Order");

            }
            TempData["ERROR"] = "ERROR";
            return RedirectToAction("IndexCart", "Cart");
        }
    }
}
