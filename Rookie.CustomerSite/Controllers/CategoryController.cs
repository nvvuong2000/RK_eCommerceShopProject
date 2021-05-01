using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rookie.CustomerSite.Containts;
using Rookie.CustomerSite.Services.BaseServices;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<List<Category>> getList(int id)
        {
            HttpResponseMessage Res = await RequestServices.GetAsync(APICartEndPoint.GetList);
           
            if (Res.IsSuccessStatusCode)
            {
                var list = await Res.Content.ReadAsAsync<IEnumerable<Category>>();

                return list.ToList();
            }

            return null;
        }
    }

}
