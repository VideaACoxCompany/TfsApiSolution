using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsApiClient.Services
{
    public class BranchService
    {
        public async Task<string> GetBranchStatus()
        {
            try
            {
                var repoService = new RepoService();

                var repoNameList = new List<string>
                {
                    "vom",
                    "order-management",
                    "support",
                    "billing",
                    "sellers",
                    "sss-services",
                    "data-integration"
                };

                var repos = repoService.FindNameAndIds(repoNameList);

                var gitStatService = new GitStatsService();
                var devReleaseBranches = new[] {"dev", "release"};

                var result = new StringBuilder();
                /*
                 * 
                 * <table style="width:100%">
  <tr>
    <th>Firstname</th>
    <th>Lastname</th> 
    <th>Age</th>
  </tr>
   <tr>
    <td>Jill</td>
    <td>Smith</td>
    <td>50</td>
  </tr>
</table>
*/

                result.AppendLine(@"<style>
                    table, th, td {
                        border: 1px solid black;
                        border-collapse: collapse;
                    }
                    th, td {
                        padding: 5px;
                    }
                    th, td {
                        text-align: center;
                    }
                    ");
                result.AppendLine("<table>");
                result.AppendLine("<tr><th>Repo</th><th>Branch</th><th>Behind|Ahead master</th></tr>");

                foreach (var repo in repos)
                {
                    var gitStat = await gitStatService.GetResult(repo.Key);
                    var devReleaseBranchesStat = gitStat.Value.Where(i => devReleaseBranches.Contains(i.Name)).ToList();
                    
                    devReleaseBranchesStat.ForEach(i =>
                        result.AppendLine(
                            $"<tr > <td> {repo.Value} </td> <td> {i.Name} </td> <td> {i.BehindCount} | {i.AheadCount} </td> </tr> "));
                    
                }
                result.AppendLine("</table>");

                return result.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return string.Empty;
        }
    }
}
