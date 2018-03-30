using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TfsApiService.Services
{
    public class HttpClientObjectService
    {
        const string Personalaccesstoken = "4lck6b2fcjnfrddl5tpiru356xbkb2chgo4du4nirhor4fxmmqka";

        public async Task<object> GetResponse(string url)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", Personalaccesstoken))));

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject(responseBody);

                    return result;
                }
            }
        }

    }
}
