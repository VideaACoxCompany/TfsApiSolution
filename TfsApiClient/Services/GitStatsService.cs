using System.Threading.Tasks;
using TfsApiService.Entities;

namespace TfsApiService.Services
{
    public class GitStatsService
    {
        //example: GET https://{instance}/DefaultCollection/{project}/_apis/git/repositories/{repository}/stats/branches[/{name}]?api-version={version}
        //example: https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/stats/branches?api-version=1.0
        //avail-gateway-svc repid: 3df85a8a-c073-42a7-88e9-e3e67dfa35c2

        public async Task<GitStat> GetResult(string repoId)
        {
            string url = "https://tfs.videa.tv/tfs/Videa/_apis/git/repositories/" + repoId + "/stats/branches?api-version=1.0";
            var httpClientService = new HttpClientService();
            var result = await httpClientService.GetResponse<GitStat>(url);
            return result;
        }
    }
}
