using System.Threading.Tasks;
using TfsApiService.Entities;

namespace TfsApiClient.Services
{
    public class ProjectService
    {
        public async Task<Project> GetResult()
        {
            var httpClientService = new HttpClientService();
            var result = await httpClientService.GetResponse<Project>("https://tfs.videa.tv/tfs/Videa/_apis/projects");
            return result;
        }
        
    }
}
