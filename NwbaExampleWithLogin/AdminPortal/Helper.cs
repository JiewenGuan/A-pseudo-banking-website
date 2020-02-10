using System;
using System.Net.Http;
using System.Net.Http.Headers;
namespace AdminPortal.Web.Helper
{
    public class AdminApi
    {
        private const string ApiBaseUri = "http://localhost:49891/api/";
        public static HttpClient InitializeClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
