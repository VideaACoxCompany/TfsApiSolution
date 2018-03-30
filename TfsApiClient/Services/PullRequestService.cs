using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TfsGitApiProject.Services
{
    public class PullRequestService
    {
        //71946fdd-cdc6-4096-b24c-61a2d8c6f531 vom

        //string url = "https://tfs.videa.tv/tfs/Videa/_apis/git/repositories/3df85a8a-c073-42a7-88e9-e3e67dfa35c2/pullRequests?status=completed&api-version=3.0";
        string url = "https://tfs.videa.tv/tfs/Videa/_apis/git/repositories/71946fdd-cdc6-4096-b24c-61a2d8c6f531/pullRequests?status=completed&api-version=3.0";
        
        const string Personalaccesstoken = "4lck6b2fcjnfrddl5tpiru356xbkb2chgo4du4nirhor4fxmmqka";

        public async Task<object> GetResult()
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
