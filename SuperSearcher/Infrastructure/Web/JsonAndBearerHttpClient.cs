using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SuperSearcher.Infrastructure.Web
{
    // Generic ex
    public class JsonAndBearerHttpClient
    {
        private HttpClient httpClient;

        public JsonAndBearerHttpClient(string baseUrl, string bearerAccessToken)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerAccessToken);
        }

        public async Task<T> PostAsync<T>(string relativeUri, string body)
        {         
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(relativeUri, content);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}