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
            var branchService = new BranchService();
            var branchStatus = branchService.GetBranchStatus().Result;

            var emailer = new SmtpService();
            emailer.SendEmail(branchStatus);
        }
    }
}
