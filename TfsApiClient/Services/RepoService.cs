using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TfsApiService.Entities;

namespace TfsApiService.Services
{
    public class RepoService
    {
        public async Task<Repo> GetResult()
        {
            var httpClientService = new HttpClientService();
            var result = await httpClientService.GetResponse<Repo>("https://tfs.videa.tv/tfs/Videa/_apis/git/repositories?api-version=1.0");
            return result;
        }

        public string FindId(string repoName)
        {
            var repos =  GetResult().Result;
            return repos.Value.First(i => i.Name == repoName).Id;
        }

        public IEnumerable<string> FindIds(IEnumerable<string> repoNames)
        {
            var repos = GetResult().Result;
            return repos.Value.Where(i => repoNames.Contains(i.Name)).Select(i => i.Id);
        }

        public Dictionary<string, string> FindNameAndIds(IEnumerable<string> repoNames)
        {
            var repos = GetResult().Result;
            return repos.Value.Where(i => repoNames.Contains(i.Name) && i.Project.Name == "Videa Git").ToList().ToDictionary(i => i.Id, i => i.Name);
        }
    }
}
