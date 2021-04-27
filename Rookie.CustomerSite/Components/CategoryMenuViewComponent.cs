using Microsoft.AspNetCore.Mvc;
using Rookie.CustomerSite.Containts;
using Rookie.CustomerSite.Services.BaseServices;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Components
{
    public class CategoryMenuViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            HttpResponseMessage Res = await RequestServices.GetAsync(APICategoryEndPoint.GetList);
            if (Res.IsSuccessStatusCode)
            {
                var list = await Res.Content.ReadAsAsync<IEnumerable<Category>>();

                return  View(list.ToList()) ;
            }
            return null;

        }
    }
}
