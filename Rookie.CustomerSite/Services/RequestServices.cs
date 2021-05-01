using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rookie.CustomerSite.Containts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Services.BaseServices
{
    public static class RequestServices
    {
        public static async Task<HttpResponseMessage> GetAsync(string endpoint, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                httpClient.SetBearerToken(accessToken);

                return await httpClient.GetAsync($"{APIRootUrl.BaseURL}{endpoint}");
            }
        }

        public static async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return await httpClient.GetAsync($"{APIRootUrl.BaseURL}{endpoint}");
            }
        }

        public static async Task<HttpResponseMessage> PostAsync(string endpoint, string accessToken, object requestbody)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
               
                return await httpClient.PostAsJsonAsync($"{APIRootUrl.BaseURL}{endpoint}", requestbody);

            }

        }
    }
}
