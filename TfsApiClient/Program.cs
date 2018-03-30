using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsApiClient.Services;


namespace TfsApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //branches
            var result = GetResults().Result;

            var emailer = new SmtpService();
            emailer.SendEmail(result);
        }
        
        public static async Task<string> GetResults()
        {
            try
            {
                //Display all projects
                //ProjectService projectService = new ProjectService();
                //var projects = await projectService.GetResult();
                //projects.Value.ForEach(i => Console.WriteLine(i.Name));

                RepoService repoService = new RepoService();

                //Dispaly all repos
                //var repos = await repoService.GetResult();
                //repos.Value.ForEach(i => Console.WriteLine(i.Name + " " + i.Id));


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
                

                foreach (var repo in repos)
                {
                    var gitStat = await gitStatService.GetResult(repo.Key);
                    var devReleaseBranchesStat = gitStat.Value.Where(i => devReleaseBranches.Contains(i.Name)).ToList();

                    devReleaseBranchesStat.ForEach(i =>
                        result.AppendLine(
                            $"Repo: {repo.Value} Branch {i.Name} is {i.BehindCount} commit(s) behind and {i.AheadCount} commit(s) ahead master branch <br/> "));

                }
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
